namespace Kepler.Runner
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Kepler.Network.Login;
    using Kepler.Network.Login.Handshake;
    using Kepler.Network.Login.VersionValidation;
    using Kepler.Network.Message.Decoder;

    public class DependencyInstaller : IWindsorInstaller
    {
        private const string HandshakeDecoder = "Handshake Decoder";

        private const string VersionValidationDecoder = "VersionValidationDecoder";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<ILoginServerInitializer, LoginServerInitializer>().LifestyleTransient().DependsOn(
                    Dependency.OnComponent(typeof(IByteMessageDecoder), HandshakeDecoder)));

            container.Register(
                Component.For<IByteMessageDecoder, HandshakeDecoder>().LifestyleTransient().DependsOn(
                        Dependency.OnComponent(typeof(IByteMessageDecoder), VersionValidationDecoder))
                    .Named(HandshakeDecoder));

            container.Register(
                Component.For<IByteMessageDecoder>().ImplementedBy<VersionValidationDecoder>().LifestyleTransient()
                    .Named(VersionValidationDecoder));
        }

        private void RegisterSimpleSingleDependency<TInterface, TClass>(IWindsorContainer container)
            where TInterface : class where TClass : TInterface
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TClass>().LifestyleTransient());
        }
    }
}
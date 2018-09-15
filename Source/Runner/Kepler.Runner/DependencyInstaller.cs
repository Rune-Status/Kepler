namespace Kepler.Runner
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Kepler.Network.Login;
    using Kepler.Network.Login.Handshake;
    using Kepler.Network.Login.OnDemand;
    using Kepler.Network.Login.UpdateStatus;
    using Kepler.Network.Login.VersionValidation;
    using Kepler.Network.Message.Decoder;
    using Kepler.Network.Message.Encoder;

    public class DependencyInstaller : IWindsorInstaller
    {
        private const string HandshakeDecoder = "Handshake Decoder";

        private const string OnDemandDecoder = "OnDemandDecoder";

        private const string UpdateStatusEncoder = "UpdateStatusEncoder";

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
                    .DependsOn(Dependency.OnComponent(typeof(IByteMessageEncoder), UpdateStatusEncoder))
                    .Named(VersionValidationDecoder));

            container.Register(
                Component.For<IByteMessageEncoder>().ImplementedBy<UpdateStatusEncoder>().LifestyleTransient()
                    .DependsOn(Dependency.OnComponent(typeof(IByteMessageDecoder), OnDemandDecoder))
                    .Named(UpdateStatusEncoder));

            container.Register(
                Component.For<IByteMessageDecoder>().ImplementedBy<OnDemandDecoder>().LifestyleTransient()
                    .Named(OnDemandDecoder));
        }

        private void RegisterSimpleSingleDependency<TInterface, TClass>(IWindsorContainer container)
            where TInterface : class where TClass : TInterface
        {
            container.Register(Component.For<TInterface>().ImplementedBy<TClass>().LifestyleTransient());
        }
    }
}
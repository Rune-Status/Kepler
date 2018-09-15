namespace Kepler.Runner
{
    using Castle.Windsor;

    public class DependencyContainer
    {
        private static IWindsorContainer container;

        public static IWindsorContainer Instance => container ?? (container = CreateWindsorContainer());

        private static IWindsorContainer CreateWindsorContainer()
        {
            IWindsorContainer windsorContainer = new WindsorContainer();

            windsorContainer.Install(new DependencyInstaller());

            return windsorContainer;
        }
    }
}
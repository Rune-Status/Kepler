namespace Kepler.Runner
{
    using System;

    using Kepler.Network.Login;

    public class Program
    {
        public static void Main()
        {
            Console.Title = "Kepler (OSRS #172)"; //TODO Pull server name & revision from configuration.

            InitializeLoginServer();
        }

        private static void InitializeLoginServer()
        {
            ILoginServerInitializer loginServerInitializer = Resolve<ILoginServerInitializer>();

            loginServerInitializer.InitializeLoginServer();
        }

        private static T Resolve<T>()
        {
            return DependencyContainer.Instance.Resolve<T>();
        }
    }
}
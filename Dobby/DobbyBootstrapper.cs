namespace Dobby
{
    public static class DobbyBootstrapper
    {
        private static DobbyContainer _container;

        public static void Initialize(DobbyContainer container)
        {
            _container = container;
        }

        public static DobbyContainer GetContainer()
        {
            return _container;
        }
    }
}
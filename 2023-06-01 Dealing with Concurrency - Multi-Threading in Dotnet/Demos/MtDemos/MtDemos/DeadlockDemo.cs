namespace MtDemos
{
    public static class DeadlockDemo
    {
        private static object _lockA = new();
        private static object _lockB = new();

        public static void SomeMethod()
        {
            lock (_lockA)
            {
                // Some code...

                lock (_lockB)
                {
                    // Some code...
                }

                // Some other code...
            }
        }

        public static void AnotherMethod()
        {
            lock (_lockB)
            {
                // Some code...

                lock (_lockA)
                {
                    // Some code...
                }

                // Some other code...
            }
        }
    }
}

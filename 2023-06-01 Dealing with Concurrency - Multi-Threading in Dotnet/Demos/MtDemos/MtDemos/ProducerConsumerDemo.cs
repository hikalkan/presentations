namespace MtDemos
{
    public static class ProducerConsumerDemo
    {
        // The shared state: Queue
        private static Queue<WorkItem> _queue = new();

        // A flag to control thread execution
        private static volatile bool _isRunning = true;

        // A counter to use while producing numbers
        private static volatile int _nextNumber = 1;

        public static void Run()
        {
            var threads = new[]
            {
                // 2 Producer threads
                new Thread(RunProducer),
                new Thread(RunProducer),

                // 2 Consumer threads
                new Thread(RunConsumer),
                new Thread(RunConsumer),
                new Thread(RunConsumer),
            };

            //Start all threads in parallel
            foreach (var thread in threads)
            {
                thread.Start();
            }

            //Waiting for user interruption
            Console.WriteLine("PRESS <<ENTER>> TO STOP ALL THREADS!");
            Console.ReadLine();

            lock (_queue)
            {
                _isRunning = false;
                Monitor.PulseAll(_queue);
            }
        }

        public static void RunProducer()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread.Sleep(1000); // Simulate item producing

                lock (_queue)
                {
                    if (_isRunning == false)
                    {
                        break;
                    }

                    _queue.Enqueue(new WorkItem { Number = _nextNumber }); // Add an item to the queue
                    Logger.Log($"Queued: {_nextNumber}");

                    _nextNumber++;

                    Monitor.PulseAll(_queue); // Trigger the waiting threads!
                }
            }

            Logger.Log("Producer exits...");
        }

        public static void RunConsumer()
        {
            while (true)
            {
                WorkItem? workItem = null;

                lock (_queue)
                {
                    if (_isRunning == false)
                    {
                        break;
                    }

                    if (_queue.Count > 0)
                    {
                        workItem = _queue.Dequeue(); // Get item from queue
                    }
                    else
                    {
                        workItem = null;
                        Monitor.Wait(_queue); // Wait producer to add new items
                    }
                }

                if (workItem != null)
                {
                    Thread.Sleep(3000); // Simulate item processsing
                    Logger.Log($"Processed: {workItem.Number}");
                }
            }

            Logger.Log("Consumer exits...");
        }
    }

    public class WorkItem
    {
        public int Number { get; set; }
    }
}

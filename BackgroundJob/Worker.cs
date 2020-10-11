using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundJob
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> _logger;
        private int number = 0;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        public async Task DoWork(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Interlocked.Increment(ref number);
                _logger.LogInformation($"Job number {number}");

                await Task.Delay(1000 * 5);
            }
        }
    }
}

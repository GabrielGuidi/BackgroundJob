using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundJob
{
    public class BackgroundPrinter : IHostedService/*, IDisposable*/
    {
        //private int number = 0;
        private readonly ILogger<BackgroundPrinter> _logger;
        //private Timer _timer;
        private readonly IWorker _worker;

        public BackgroundPrinter(ILogger<BackgroundPrinter> logger, IWorker worker)
        {
            _logger = logger;
            _worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //_timer = new Timer(o =>
            //{
            //    Interlocked.Increment(ref number);
            //    _logger.LogInformation($"Printing stared from worker! - Times: {number}");
            //},
            //null,
            //TimeSpan.Zero,
            //TimeSpan.FromSeconds(2));

            await _worker.DoWork(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            //_logger.LogInformation("Printer stoped!");

            await _worker.DoWork(cancellationToken);
        }

        //public void Dispose()
        //{
        //    _timer?.Dispose();
        //}
    }
}

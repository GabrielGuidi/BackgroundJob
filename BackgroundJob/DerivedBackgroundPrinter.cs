using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundJob
{
    public class DerivedBackgroundPrinter : BackgroundService
    {
        private readonly IWorker _worker;

        public DerivedBackgroundPrinter(IWorker worker)
        {
            _worker = worker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await _worker.DoWork(stoppingToken);
        }
    }
}

using System.Threading;
using System.Threading.Tasks;

namespace BackgroundJob
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}
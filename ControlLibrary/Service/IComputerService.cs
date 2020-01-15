using System.Threading.Tasks;

namespace ControlLibrary.Service
{
    public interface IComputerService
    {
        Task Start();

        bool Shutdown();

        Task<bool> IsRunning();
    }
}

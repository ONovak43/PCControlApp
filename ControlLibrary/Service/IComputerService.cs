using System.Threading.Tasks;

namespace ControlLibrary.Service
{
    public interface IComputerService
    {
        Task Start();

        void Shutdown();

        Task<bool> IsRunning();
    }
}

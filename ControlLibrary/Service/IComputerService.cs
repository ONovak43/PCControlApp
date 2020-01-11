using System.Threading.Tasks;

namespace ControlLibrary.Service
{
    public interface IComputerService
    {
        void Start();

        bool Shutdown();

        Task<bool> IsRunning();
    }
}

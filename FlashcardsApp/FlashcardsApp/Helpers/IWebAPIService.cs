using FlashcardsApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlashcardsApp.Helpers
{
    public interface IWebAPIService
    {
        Task<ObservableCollection<Module>> GetAllModulesAsync();
        Task<ObservableCollection<ModuleBlock>> GetModuleBlocksAsync(string moduleCode);
        Task<ObservableCollection<BlockPart>> GetBlockPartsAsync(string moduleCodeId);
    }
}
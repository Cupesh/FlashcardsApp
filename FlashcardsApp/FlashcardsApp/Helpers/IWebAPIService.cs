using FlashcardsApp.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FlashcardsApp.Helpers
{
    public interface IWebAPIService
    {
        Task<Flashcard> GetFlashcardAsync();
        Task<ObservableCollection<Module>> GetAllModulesAsync();
    }
}
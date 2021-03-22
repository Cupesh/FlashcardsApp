using FlashcardsApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlashcardsApp.Helpers
{
    public interface IWebAPIService
    {
        Task<Flashcard> GetFlashcardAsync();
        Task<List<Module>> GetAllModulesAsync();
    }
}
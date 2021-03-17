using FlashcardsApp.Models;
using System.Threading.Tasks;

namespace FlashcardsApp.Helpers
{
    public interface IWebAPIService
    {
        Task<Flashcard> GetFlashcardAsync();
    }
}
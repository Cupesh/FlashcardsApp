using FlashcardsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FlashcardsApp.Helpers
{
    public class WebAPIService : IWebAPIService
    {
        private HttpClient apiClient { get; set; }

        public WebAPIService()
        {
            InitializeClient();
        }

        private void InitializeClient()
        {
            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri("http://192.168.1.81:45455/");
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Flashcard> GetFlashcardAsync()
        {
            using (HttpResponseMessage response = await apiClient.GetAsync("/api/v1/flashcards/1"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Flashcard>(content);
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<ObservableCollection<Module>> GetAllModulesAsync()
        {
            using (HttpResponseMessage response = await apiClient.GetAsync("/api/v1/modules/"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ObservableCollection<Module>>(content);
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<ObservableCollection<ModuleBlock>> GetModuleBlocksAsync(string moduleCode)
        {
            using (HttpResponseMessage response = await apiClient.GetAsync("/api/v1/moduleblocks/{moduleCode}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ObservableCollection<ModuleBlock>>(content);
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

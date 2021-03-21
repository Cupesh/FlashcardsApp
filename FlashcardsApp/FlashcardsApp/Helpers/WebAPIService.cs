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
            apiClient.BaseAddress = new Uri("http://192.168.1.81:45456/");
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Flashcard> GetFlashcardAsync()
        {
            Console.WriteLine("1");
            using (HttpResponseMessage response = await apiClient.GetAsync("/api/v1/flashcards/1"))
            {
                Console.WriteLine("2");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("3");
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


    }
}

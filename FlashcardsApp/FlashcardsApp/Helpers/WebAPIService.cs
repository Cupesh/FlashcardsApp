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
            apiClient.BaseAddress = new Uri("https://flashcardsappdatamanager.conveyor.cloud/");
            apiClient.DefaultRequestHeaders.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
            using (HttpResponseMessage response = await apiClient.GetAsync(String.Format("/api/v1/moduleblocks/{0}", moduleCode)))
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

        public async Task<ObservableCollection<BlockPart>> GetBlockPartsAsync(string moduleBlockId)
        {
            using (HttpResponseMessage response = await apiClient.GetAsync(String.Format("/api/v1/blockparts/{0}", moduleBlockId)))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ObservableCollection<BlockPart>>(content);
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

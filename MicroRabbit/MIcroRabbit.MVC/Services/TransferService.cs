using MIcroRabbit.MVC.Models.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MIcroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public TransferService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task Transfer(TransferDto transferDto)
        {
            var uri = _configuration["MicroServices_API:BankingAPI"];
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsJsonAsync(uri, transferContent);
            response.EnsureSuccessStatusCode(); 

        }
    }
}

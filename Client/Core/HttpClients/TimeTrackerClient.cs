using RiverviewTimeTracker.Client.Core.Interfaces;
using RiverviewTimeTracker.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace RiverviewTimeTracker.Client.Core.HttpClients
{
    public class TimeTrackerClient : ITimeTrackerClient
    {
        private readonly HttpClient _httpClient;

        public TimeTrackerClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Project>>("api/Projects");
        }
    }
}

using RiverviewTimeTracker.Client.Core.Interfaces;
using RiverviewTimeTracker.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverviewTimeTracker.Client.Core.Services
{
    public class TimeTrackerService : ITimeTrackerService
    {
        private readonly ITimeTrackerClient _client;

        public TimeTrackerService(ITimeTrackerClient client)
        {
            _client = client;
        }
        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var projects = await _client.GetProjectsAsync();
            return projects.FirstOrDefault(p => p.Id == id);
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            return await _client.GetProjectsAsync();
        }
    }
}

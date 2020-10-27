using RiverviewTimeTracker.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverviewTimeTracker.Client.Core.Interfaces
{
    public interface ITimeTrackerService
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
    }
}

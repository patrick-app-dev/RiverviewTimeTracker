using Microsoft.AspNetCore.Components;
using RiverviewTimeTracker.Client.Core.Interfaces;
using RiverviewTimeTracker.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiverviewTimeTracker.Client.Pages
{
    public partial class Projects : ComponentBase
    {
        [Inject] private ITimeTrackerService dataService { get; set; }
        private IEnumerable<Project> projects;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();
            projects = await dataService.GetProjectsAsync();
        }
    }
}

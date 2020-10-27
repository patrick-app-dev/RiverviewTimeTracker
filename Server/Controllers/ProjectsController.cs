using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RiverviewTimeTracker.Shared.Models;

namespace RiverviewTimeTracker.Server.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ILogger logger;
        private IEnumerable<Project> Projects;

        public ProjectsController(ILogger<ProjectsController> logger)
        {
            this.logger = logger;
            InitializeProjects();
        }

        [HttpGet]
        public IEnumerable<Project> Get()
        {
            return Projects.ToArray();
        }
        private void InitializeProjects()
        {
            Projects = new List<Project>
            {
                new Project { Id = 1, Name = "MIMS", Description = "Members Information Management System"},
                new Project { Id = 2, Name = "Online Payments API", Description = "Supply an API for RedRhino Dues Payment front end."},
                new Project { Id = 3, Name = "GB Claims Import", Description = "Import the weekly import of Global Benefits claims history"},
                new Project { Id = 4, Name = "Documentation", Description = "Document entire LIUNA 1059 system."},
            };
        }

    }
}

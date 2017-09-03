using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TimeKeeper.Domain;
using TimeKeeper.Domain.Models;
using TimeKeeper.Domain.Abstract;
using TimeKeeper.WebApi.Models.DTO;
using TimeKeeper.WebApi.Infrastructure;

namespace TimeKeeper.Controllers
{
    public class ProjectController : ApiController
    {
        private ITimeKeeperRepository repo;
        public ProjectController()
        {

        }
        public ProjectController(ITimeKeeperRepository _repo)
        {
            repo = _repo;
        }

        [HttpGet]
        public HttpResponseMessage GetProjects()
        {
            var ProjectsList = repo.GetProjects;
            List<ProjectDTO> projects = new List<ProjectDTO>();
            if(ProjectsList.Count() > 0)
            {
                EntityToDTO dte = new EntityToDTO();
                foreach( var p in ProjectsList)
                {
                    var dto = dte.ProjectEntityToDTO(p);
                    projects.Add(dto);
                }
                return Request.CreateResponse(HttpStatusCode.OK, projects);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "There are currently no projects.");
            }        
        }

        [HttpPost]
        public HttpResponseMessage GetProjectById([FromBody]int Id)
        {
            if (Id != 0 || Id < 0)
            {
                var project = repo.GetProjectById(Id);

                if (project != null)
                {
                    EntityToDTO etd = new EntityToDTO();
                    var dto = etd.ProjectEntityToDTO(project);

                    return Request.CreateResponse(HttpStatusCode.OK, dto);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No project was found");
                }
            }
            else
            {
                Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error: No ID was present.");
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An error occured");
        }

        [HttpPost]
        public HttpResponseMessage AddNewProject([FromBody]ProjectDTO project)
        {
            if(project != null)
            {
                DTOToEntity dte = new DTOToEntity();

                Project newProject = dte.ProjectDTOToEntity(project);

                repo.AddNewProject(newProject);

                return Request.CreateResponse(HttpStatusCode.OK, "Project added successfully.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "The project contained no information. Please fill in the form and try again.");
            }
        }


        [HttpPost]
        public HttpResponseMessage DeleteProject([FromBody]int projectId)
        {
            if(projectId != 0)
            {
                var projectToDelete = repo.GetProjectById(projectId);
                var projectOwners = repo.GetProjectOwnersByProjectId(projectToDelete.Id);
                var projectTimes = repo.GetProjectTimeRecords(projectToDelete.Id);
                if(projectOwners.Count() > 0)
                {
                    foreach (var owner in projectOwners)
                    {
                        repo.deleteOwner(owner);
                    }
                }

                if(projectTimes.Count() > 0)
                {
                    foreach (var time in projectTimes)
                    {
                        repo.DeleteTime(time);
                    }
                }    
                if(projectToDelete != null)
                {
                    repo.DeleteProject(projectToDelete);
                    return Request.CreateResponse(HttpStatusCode.OK, "Project deleted successfully.");
                }   
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No project found. Please try again.");
                } 
            
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An error occured.");
            }
        }


        [HttpPut]
        public HttpResponseMessage UpdateProject([FromBody]ProjectDTO project)
        {
            if(project != null )
            {
                DTOToEntity dte = new DTOToEntity();
                var updatedProject = dte.ProjectDTOToEntity(project);
                repo.UpdateProject(updatedProject);

                return Request.CreateResponse(HttpStatusCode.OK, "Project Updated successfully.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An error occured.");
            }

        }

    }
}

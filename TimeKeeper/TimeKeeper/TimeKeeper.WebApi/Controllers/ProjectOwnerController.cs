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
    public class ProjectOwnerController : ApiController
    {
        private ITimeKeeperRepository repo;

        public ProjectOwnerController()
        {

        }
        public ProjectOwnerController(ITimeKeeperRepository _repo)
        {
            repo = _repo;
        }


        [HttpPost]
        public HttpResponseMessage UpdateProjectOwner(ProjectOwnerDTO projectOwner)
        {
            if(projectOwner != null)
            {
                DTOToEntity dte = new DTOToEntity();
                var owner = dte.OwnerDTOToEntity(projectOwner);
                repo.AddProjectOwner(owner);
                return Request.CreateResponse(HttpStatusCode.OK, "Owner Added Successfully.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "An Error Occured. Please check your details and try again.");
            }
        }
    }
}

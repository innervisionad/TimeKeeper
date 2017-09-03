using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TimeKeeper.Domain.Models;
using TimeKeeper.Domain.Abstract;
using TimeKeeper.WebApi.Infrastructure;
using TimeKeeper.WebApi.Models.DTO;

namespace TimeKeeper.WebApi.Controllers
{
    public class TimeController : ApiController
    {
        private ITimeKeeperRepository repo;

        public TimeController()
        {

        }
        public TimeController(ITimeKeeperRepository _repo)
        {
            repo = _repo;
        }


        [HttpPost]
        public HttpResponseMessage GetProjectTimeRecords([FromBody]int projectId)

        {
            if(projectId != 0)
            {
                var records = repo.GetProjectTimeRecords(projectId);
                List<TimeDTO> ProjectTimeRecords = new List<TimeDTO>();

                if(records == null || records.Count() == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "No Records were found.");
                }
                else
                {
                    EntityToDTO etd = new EntityToDTO();

                    foreach(var r in records)
                    {
                        r.TimeSpent = CalculateProjectHours(r);
                        TimeDTO timeDTO = etd.TimeEntityToDTO(r);
                        if(timeDTO != null)
                        {
                            ProjectTimeRecords.Add(timeDTO);
                        }                      
                    };

                    return Request.CreateResponse(HttpStatusCode.OK, ProjectTimeRecords);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "An error Occured");
            }
        }

        [HttpPost]
        public HttpResponseMessage AddTime([FromBody]TimeDTO newTime)
        {
            if(newTime != null)
            {
          
                DTOToEntity dte = new DTOToEntity();

                newTime.Date = DateTime.Now;
                newTime.IsInvoiced = false;
                var entity = dte.TimeDTOToEntity(newTime);

                repo.AddTime(entity);
                return Request.CreateResponse(HttpStatusCode.OK, "Time uploaded successfully.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "An error Occured");
            }

        }

        [HttpPut]
        public HttpResponseMessage UpdateTime([FromBody]TimeDTO time)
        {
            if(time != null)
            {
                DTOToEntity dte = new DTOToEntity();
                var entity = dte.TimeDTOToEntity(time);

                repo.UpdateTime(entity);

                return Request.CreateResponse(HttpStatusCode.OK, "Time changed successfully.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "An error Occured");
            }
        }

        [HttpPost]
        public HttpResponseMessage DeleteTime([FromBody]TimeDTO time)
        {
            if(time != null)
            {
                DTOToEntity dte = new DTOToEntity();
                var entity = dte.TimeDTOToEntity(time);

                repo.DeleteTime(entity);

                return Request.CreateResponse(HttpStatusCode.OK, "Time deleted successfully.");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "An error Occured");
            }
        }

        //Calculate the hours between 2 times.
        public int CalculateProjectHours(Time r)
        {
            var Start = r.TimeStart;
            var End = r.TimeEnd;

            return End.Hour - Start.Hour;
        }
    }
}

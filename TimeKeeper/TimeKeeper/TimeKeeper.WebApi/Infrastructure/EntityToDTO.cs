using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeKeeper.Domain.Models;
using TimeKeeper.WebApi.Models.DTO;

namespace TimeKeeper.WebApi.Infrastructure
{
    public class EntityToDTO
    {
        public TimeDTO TimeEntityToDTO(Time entity)
        {
            if(entity != null)
            {
                TimeDTO dto = new TimeDTO
                {
                    Id = entity.Id,
                    Project_Id = entity.Project_Id,
                    Date = entity.Date,
                    TimeStart = entity.TimeStart,
                    TimeEnd = entity.TimeEnd,
                    HoursSpent = entity.TimeSpent,
                    Description = entity.Description,
                     IsInvoiced = (bool)entity.IsInvoiced
                };

                return dto;
            }
            else
            {
                return null;
            }
        }

        public ProjectDTO ProjectEntityToDTO(Project project)
        {
            if(project!= null)
            {
                ProjectDTO dto = new ProjectDTO
                {
                    Id = project.Id,
                    ProjectName = project.ProjectName,
                    ProjectDescription = project.ProjectDescription,
                    Invoiced = (bool)project.Invoiced               
                };

                return dto;
            }
            else
            {
                return null;
            }
        }



    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TimeKeeper.Domain.Models;
using TimeKeeper.WebApi.Models.DTO;

namespace TimeKeeper.WebApi.Infrastructure
{
    public class DTOToEntity
    {
        public Project ProjectDTOToEntity(ProjectDTO project)
        {
            Project proj = new Project();

            if(project.Id == 0)
            {

                proj.ProjectName = project.ProjectName;
                proj.ProjectDescription = project.ProjectDescription;
                proj.Invoiced = false;

                return proj;
            }
            else
            {
                proj.Id = project.Id;
                proj.ProjectName = project.ProjectName;
                proj.ProjectDescription = project.ProjectDescription;
                proj.Invoiced = project.Invoiced;

                return proj;
            };
        }

        public ProjectOwner OwnerDTOToEntity(ProjectOwnerDTO projectOwner)
        {
            ProjectOwner owner = new ProjectOwner();

            if(projectOwner.Id != 0)
            {
                owner.Id = projectOwner.Id;
            }

            if (projectOwner != null)
            {
                owner.Name = projectOwner.Name;
                owner.PhoneNumber = projectOwner.PhoneNumber;
                owner.Project_Id = projectOwner.Project_Id;
                owner.AddressLine1 = projectOwner.AddressLine1;
                owner.AddressLine2 = projectOwner.AddressLine2;
                owner.Town = projectOwner.Town;
                owner.County = projectOwner.County;
                owner.PostCode = projectOwner.PostCode;
            }
           
            return owner;
        }

        public Time TimeDTOToEntity(TimeDTO newtime)
        {
            Time time = new Time();
            if (newtime != null)
            {            
             
                time.Id = newtime.Id;
                time.Project_Id = newtime.Project_Id;
                time.Date = newtime.Date;
                time.TimeStart = newtime.TimeStart;
                time.TimeEnd = newtime.TimeEnd;
                time.Description = newtime.Description;
                time.IsInvoiced = newtime.IsInvoiced;
            }



            return time; 
        }

    }
}
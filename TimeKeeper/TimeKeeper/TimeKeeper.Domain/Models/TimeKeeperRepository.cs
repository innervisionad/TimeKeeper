using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;

using TimeKeeper.Domain.Models;
using TimeKeeper.Domain.Abstract;

namespace TimeKeeper.Domain
{
    public class TimeKeeperRepository : ITimeKeeperRepository
    {
        private TimeKeeperEntities context;
        public TimeKeeperRepository(TimeKeeperEntities context)
        {
            this.context = context;
        }

        // PROJECT //
        public IEnumerable<Project> GetProjects
        {
            get
            {
                return context.Projects;
            }
        }

     

        public Project GetProjectById(int Id)
        {
            return context.Projects.FirstOrDefault(x => x.Id == Id);
        }

        public void AddNewProject(Project project)
        {
            if(project != null)
            {
                context.Projects.Add(project);
                context.SaveChanges();
            }
        }

        public void UpdateProject(Project project)
        {
          if(project != null)
            {
                context.Entry(project).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProject(Project project)
        {
            if(project != null)
            {
                context.Entry(project).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        // PROJECT OWNERS //

        public IEnumerable<ProjectOwner> GetProjectOwnersByProjectId(int id)
        {
            return context.ProjectOwners.Where(x => x.Project_Id == id);
        }

        public void deleteOwner(ProjectOwner owner)
        {
            if(owner != null)
            {
                context.Entry(owner).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void AddProjectOwner(ProjectOwner owner)
        {
          if(owner != null)
            {
                if(owner.Id == 0)
                {
                    context.ProjectOwners.Add(owner);
                }
                else
                {
                    context.Entry(owner).State = EntityState.Modified;
                }
               
                context.SaveChanges();
            }
        }

        // TIME //
        public IEnumerable<Time> GetProjectTimeRecords(int Id)
        {
            return context.Times.Where(x => x.Project_Id == Id);
        }

        public void DeleteTime(Time time)
        {
            if (time != null)
            {
                context.Entry(time).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void AddTime(Time time)
        {
           if(time != null)
            {
                context.Times.Add(time);
                context.SaveChanges();
            }
        }

        public void UpdateTime(Time time)
        {
            if(time != null)
            {
                context.Entry(time).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Time GetTimeById(int id)
        {
            return context.Times.FirstOrDefault(x => x.Id == id);
        }
    }
}

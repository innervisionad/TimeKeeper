using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TimeKeeper.Domain.Models;
namespace TimeKeeper.Domain.Abstract
{
    public interface ITimeKeeperRepository
    {
        //stubs//

        //project stubs//
        IEnumerable<Project> GetProjects { get; }
        Project GetProjectById(int Id);
        void AddNewProject(Project project);
        void DeleteProject(Project project);
        void UpdateProject(Project project);




        //projectOwner stubs//
        IEnumerable<ProjectOwner> GetProjectOwnersByProjectId(int id);
        void deleteOwner(ProjectOwner owner);
        void AddProjectOwner(ProjectOwner owner);

        //time stubs//
        IEnumerable<Time> GetProjectTimeRecords(int id);
        Time GetTimeById(int id);
        void DeleteTime(Time time);
        void AddTime(Time time);
        void UpdateTime(Time time);
        
    }
}

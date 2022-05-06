using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ATP.Exam.Models;
using ATP.Exam.ViewModels;

namespace ATP.Exam.Repositories
{
    public interface IBusinessRepository
    {
        public List<Employee> GetEmployees();
        public List<Project> GetProjects();
        public Project GetEmployeesbyProject(Guid projectId);
        public Project SaveRelationProjectEmployee(ProjectEmployeeViewModel projectEmployeeVM);
    }

    public class BusinessRepository : IBusinessRepository
    {
        private BusinessDBContext _context;

        public BusinessRepository(BusinessDBContext context)
        {
            _context = context;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = _context.Employee.ToList();

            return employees;
        }

        public List<Project> GetProjects()
        {
            List<Project> projects = _context.Project.ToList();

            return projects;
        }

        public Project GetEmployeesbyProject(Guid projectId)
        {
            Project project = _context.Project.
                                Where(x => x.projectId == projectId).
                                ToList().
                                FirstOrDefault();

            List<ProjectEmployee> employees = _context.ProjectEmloyee
                                    .Where(x => x.projectId == projectId)
                                    .Include(x => x.Employee)
                                    .ToList();

            project.ProjectEmloyees = employees;

            return project;
        }

        public Project SaveRelationProjectEmployee(ProjectEmployeeViewModel projectEmployeeVM)
        {
            ProjectEmployee projectEmployee = new ProjectEmployee();

            if (projectEmployeeVM.projectEmployeeId == null)
            {
                projectEmployee = new ProjectEmployee()
                {
                  projectEmployeeId = Guid.NewGuid(),
                  projectId = projectEmployeeVM.projectId,
                  employeeId = projectEmployeeVM.employeeId,
                  role = projectEmployeeVM.role
                };

                _context.ProjectEmloyee.Add(projectEmployee);
            }
            else
            {
                projectEmployee = _context.ProjectEmloyee
                                          .Where(x => x.projectEmployeeId == projectEmployeeVM.projectEmployeeId)
                                          .FirstOrDefault();

                projectEmployee.projectId = projectEmployeeVM.projectId;
                projectEmployee.employeeId = projectEmployeeVM.employeeId;
                projectEmployee.role = projectEmployeeVM.role;

                _context.ProjectEmloyee.Update(projectEmployee);
            }
            _context.SaveChanges();

            Project project = _context.Project.
                                Where(x => x.projectId == projectEmployee.projectId).
                                ToList().
                                FirstOrDefault();

            List<ProjectEmployee> employees = _context.ProjectEmloyee
                                    .Where(x => x.projectId == projectEmployee.projectId)
                                    .Include(x => x.Employee)
                                    .ToList();

            project.ProjectEmloyees = employees;

            return project;
        }
    }
}

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
        public Project SaveProject(ProjectViewModel projectVM);
        public Employee SaveEmployee(EmployeeViewModel employeetVM);
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

            Project project = GetEmployeesbyProject(projectEmployee.projectId);

            return project;
        }
        public Project SaveProject(ProjectViewModel projectVM)
        {
            Project project = new Project();

            if (projectVM.projectId == null)
            {
                project = new Project()
                {
                    projectId = Guid.NewGuid(),
                    title = projectVM.title,
                    dateInit = projectVM.dateInit,
                    dateEnd = projectVM.dateEnd,
                    cost = projectVM.cost,
                    month = projectVM.month,
                    createdDate = DateTime.Today
                };

                _context.Project.Add(project);
            }
            else
            {
                project = _context.Project
                                  .Where(x => x.projectId == projectVM.projectId)
                                  .FirstOrDefault();

                project.projectId = projectVM.projectId;
                project.title = projectVM.title;
                project.dateInit = projectVM.dateInit;
                project.dateEnd = projectVM.dateEnd;
                project.cost = projectVM.cost;
                project.month = projectVM.month;
                _context.Project.Update(project);
            }
            _context.SaveChanges();

            return project;
        }
        public Employee SaveEmployee(EmployeeViewModel employeetVM)
        {
            Employee employee = new Employee();

            if (employeetVM.employeeId == null)
            {
                employee = new Employee()
                {
                    employeeId = Guid.NewGuid(),
                    name = employeetVM.name,
                    birthDate = employeetVM.birthDate,
                    entryDate = employeetVM.entryDate,
                    job = employeetVM.job,
                    salary = employeetVM.salary,
                    createdDate = DateTime.Today
                };

                _context.Employee.Add(employee);
            }
            else
            {
                employee = _context.Employee
                                  .Where(x => x.employeeId == employeetVM.employeeId)
                                  .FirstOrDefault();

                employee.employeeId = employeetVM.employeeId;
                employee.name = employeetVM.name;
                employee.birthDate = employeetVM.birthDate;
                employee.entryDate = employeetVM.entryDate;
                employee.job = employeetVM.job;
                employee.salary = employeetVM.salary;
                _context.Employee.Update(employee);
            }
            _context.SaveChanges();

            return employee;
        }
    }
}

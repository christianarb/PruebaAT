using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATP.Exam.Repositories;
using ATP.Exam.Models;
using ATP.Exam.ViewModels;

namespace ATP.Exam.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        IBusinessRepository iBusinessRepository;

        public BusinessController(
            IBusinessRepository _iBusinessRepository
        )
        {
            iBusinessRepository = _iBusinessRepository;
        }

        /// <summary>
        /// Obtiene los empleados existentes.
        /// </summary>
        /// <remarks>Lista los empleados de la base de datos.</remarks>
        [HttpGet("employees")]
        public IActionResult GetEmployees()
        {
            try
            {
                List<Employee> employees = iBusinessRepository.
                    GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Obtiene los proyectos existentes.
        /// </summary>
        /// <remarks>Lista los proyectos de la base de datos.</remarks>
        [HttpGet("projects")]
        public IActionResult GetProjects()
        {
            try
            {
                List<Project> projects = iBusinessRepository.
                    GetProjects();
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Obtiene empleados segun el projectId de su relacion.
        /// </summary>
        /// <remarks>Lista los empleados segun el projectId de la base de datos.</remarks>
        [HttpGet("project_employees/{projectId}")]
        public IActionResult GetEmployeesbyProject(Guid projectId)
        {
            try
            {
                Project rs = iBusinessRepository.GetEmployeesbyProject(projectId);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Guardar/Actualizar relacion de Proyecto-Empleado.
        /// </summary>
        /// <remarks>Registra/Actualiza los registros en la base de datos.</remarks>
        [HttpPost("saveProjectEmployee")]
        public IActionResult SaveRelationProjectEmployee([FromBody] ProjectEmployeeViewModel projectEmployeeVM)
        {
            try
            {
                Project rs = iBusinessRepository.SaveRelationProjectEmployee(projectEmployeeVM);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        /// <summary>
        /// Guardar/Actualizar de Proyectos.
        /// </summary>
        /// <remarks>Registra/Actualiza los registros en la base de datos.</remarks>
        [HttpPost("saveProject")]
        public IActionResult SaveProject([FromBody] ProjectViewModel projectVM)
        {
            try
            {
                Project rs = iBusinessRepository.SaveProject(projectVM);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        /// <summary>
        /// Guardar/Actualizar de Empleados.
        /// </summary>
        /// <remarks>Registra/Actualiza los registros en la base de datos.</remarks>
        [HttpPost("saveEmployee")]
        public IActionResult SaveEmployee([FromBody] EmployeeViewModel employeeVM)
        {
            try
            {
                Employee rs = iBusinessRepository.SaveEmployee(employeeVM);
                return Ok(rs);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}

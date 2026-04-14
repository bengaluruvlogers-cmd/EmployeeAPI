using Microsoft.AspNetCore.Mvc;
using EmployeeAPI.Data;
using EmployeeAPI.Models;
using System.Linq;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.EmployeesD.ToList());
        }

        [HttpPost]
        public IActionResult Add(Employee emp)
        {
            _context.EmployeesD.Add(emp);
            _context.SaveChanges();
            return Ok(emp);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Employee updated)
        {
            var emp = _context.EmployeesD.Find(id);
            if (emp == null) return NotFound();

            emp.Name = updated.Name;
            emp.Department = updated.Department;
            emp.Salary = updated.Salary;

            _context.SaveChanges();
            return Ok(emp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var emp = _context.EmployeesD.Find(id);
            if (emp == null) return NotFound();

            _context.EmployeesD.Remove(emp);
            _context.SaveChanges();
            return Ok();
        }
    }
}
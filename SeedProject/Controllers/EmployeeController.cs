using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class EmployeeController : ApiController
    {
        private DBModels db = new DBModels();

        // GET api/Employee
        public IQueryable<Employees> GetEmployees()
        {
            if (!db.Employees.Any())
            {
                db.Employees.Add(new Employees { Name = "Jeff", Salary = 50000, Department = "IT", Project = "Help Page" });
                db.Employees.Add(new Employees { Name = "Bob", Salary = 55000, Department = "Accounting", Project = "Operation Ripoff" });
                db.Employees.Add(new Employees { Name = "Smith", Salary = 40000, Department = "IT", Project = "Login Page" });
                db.Employees.Add(new Employees { Name = "Taby", Salary = 37000, Department = "Legal", Project = "Do not sue us" });
                db.Employees.Add(new Employees { Name = "Babs", Salary = 52000, Department = "Accounting", Project = "Operation Ripoff" });

                db.SaveChanges();
            }
            //db.Departments.Add(new Departments { DeptName = "IT", Location = "9th Floor", Budget = 2000000 });
            //db.Departments.Add(new Departments { DeptName = "Accounting", Location = "7th Floor", Budget = 5000000 });
            //db.Departments.Add(new Departments { DeptName = "Legal", Location = "3rd Floor", Budget = 700000 });
            //db.Departments.Add(new Departments { DeptName = "Human Resources", Location = "5th Floor", Budget = 300000 });
            //db.Departments.Add(new Departments { DeptName = "Support", Location = "20th Floor", Budget = 90000 });

            //db.Projects.Add(new Projects { ProjName = "Help Page", Budget = 75000, Department = "IT" });
            //db.Projects.Add(new Projects { ProjName = "Operation Ripoff", Budget = 300000, Department = "Accounting" });
            //db.Projects.Add(new Projects { ProjName = "Login Page", Budget = 225000, Department = "IT" });
            //db.Projects.Add(new Projects { ProjName = "Do not sue us", Budget = 20000, Department = "Legal" });
            //db.Projects.Add(new Projects { ProjName = "Reach out", Budget = 50000, Department = "Human Resources" });

            //db.SaveChanges();

            return db.Employees;
        }

        // GET api/Employee/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult GetEmployees(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST api/Employee
        [ResponseType(typeof (Employees))]
        public IHttpActionResult PostEmployees(Employees employee)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(employee.Name))
            {
                db.Employees.Add(employee);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
        }

        // POST api/Employee/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult PostEmployees(int id, Employees employee)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(employee.Name))
            {
                var employeeEdit = db.Employees.Find(id);

                employeeEdit.Name = employee.Name;
                employeeEdit.Department = employee.Department;
                employeeEdit.Salary = employee.Salary;
                employeeEdit.Project = employee.Project;
                
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = id }, employee);
        }

        // DELETE api/Employee/5
        [ResponseType(typeof(Employees))]
        public IHttpActionResult DeleteEmployees(int id)
        {
            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.Employees.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }
    }
}
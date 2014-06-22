using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class DepartmentController : ApiController
    {
        private DBModels db = new DBModels();

        // GET api/Department
        public IQueryable<Departments> GetDepartments()
        {
            if (!db.Departments.Any())
            {
                db.Departments.Add(new Departments { DeptName = "IT", Location = "9th Floor", Budget = 2000000 });
                db.Departments.Add(new Departments { DeptName = "Accounting", Location = "7th Floor", Budget = 5000000 });
                db.Departments.Add(new Departments { DeptName = "Legal", Location = "3rd Floor", Budget = 700000 });
                db.Departments.Add(new Departments { DeptName = "Human Resources", Location = "5th Floor", Budget = 300000 });
                db.Departments.Add(new Departments { DeptName = "Support", Location = "20th Floor", Budget = 90000 });

                db.SaveChanges();
            }

            return db.Departments;
        }

        // GET api/Department/5
        [ResponseType(typeof(Departments))]
        public IHttpActionResult GetDepartments(int id)
        {
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // POST api/Department
        [ResponseType(typeof(Departments))]
        public IHttpActionResult PostDepartments(Departments department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(department.DeptName))
            {
                db.Departments.Add(department);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = department.Id }, department);
        }

        // POST api/Department/5
        [ResponseType(typeof(Departments))]
        public IHttpActionResult PostDepartments(int id, Departments department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(department.DeptName))
            {
                var departmentEdit = db.Departments.Find(id);

                departmentEdit.DeptName = department.DeptName;
                departmentEdit.Location = department.Location;
                departmentEdit.Budget = department.Budget;

                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = id }, department);
        }

        // DELETE api/Department/5
        [ResponseType(typeof(Departments))]
        public IHttpActionResult DeleteDepartments(int id)
        {
            var department = db.Departments.Find(id);
            if (department == null)
            {
                return NotFound();
            }

            db.Departments.Remove(department);
            db.SaveChanges();

            return Ok(department);
        }
    }
}
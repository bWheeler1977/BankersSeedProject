using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class ProjectController : ApiController
    {
        private DBModels db = new DBModels();

        // GET api/Project
        public IQueryable<Projects> GetProjects()
        {
            if (!db.Projects.Any())
            {
                db.Projects.Add(new Projects { ProjName = "Help Page", Budget = 75000, Department = "IT" });
                db.Projects.Add(new Projects { ProjName = "Operation Ripoff", Budget = 300000, Department = "Accounting" });
                db.Projects.Add(new Projects { ProjName = "Login Page", Budget = 225000, Department = "IT" });
                db.Projects.Add(new Projects { ProjName = "Do not sue us", Budget = 20000, Department = "Legal" });
                db.Projects.Add(new Projects { ProjName = "Reach out", Budget = 50000, Department = "Human Resources" });

                db.SaveChanges();
            }

            return db.Projects;
        }

        // GET api/Project/5
        [ResponseType(typeof(Projects))]
        public IHttpActionResult GetProjects(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // POST api/Project
        [ResponseType(typeof(Projects))]
        public IHttpActionResult PostProjects(Projects project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(project.ProjName))
            {
                db.Projects.Add(project);
                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = project.Id }, project);
        }

        // POST api/Project/5
        [ResponseType(typeof(Projects))]
        public IHttpActionResult PostProjects(int id, Projects project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(project.ProjName))
            {
                var projectEdit = db.Projects.Find(id);

                projectEdit.ProjName = project.ProjName;
                projectEdit.Department = project.Department;
                projectEdit.Budget = project.Budget;

                db.SaveChanges();
            }

            return CreatedAtRoute("DefaultApi", new { id = id }, project);
        }

        // DELETE api/Project/5
        [ResponseType(typeof(Projects))]
        public IHttpActionResult DeleteProjects(int id)
        {
            var project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }
    }
}
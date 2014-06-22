
namespace API.Models {
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class DBModels : DbContext {
        // Your context has been configured to use a 'DBModels' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'API.Models.DBModels' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'DBModels' 
        // connection string in the application configuration file.
        public DBModels()
            : base("name=DBModels")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
    }

    public class Messages
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    public class Departments
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }
        [Column(TypeName = "Money")]
        public decimal Budget { get; set; }
    }
    public class Employees
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        [Column(TypeName = "Money")]
        public decimal Salary { get; set; }
        public string Department { get; set; }
        public string Project { get; set; }
    }
    public class Projects
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProjName { get; set; }
        [Column(TypeName = "Money")]
        public decimal Budget { get; set; }
        public string Department { get; set; }
    }
}
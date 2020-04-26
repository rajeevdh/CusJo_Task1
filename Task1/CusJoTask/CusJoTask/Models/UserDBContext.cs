namespace CusJoTask.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UserDBContext : DbContext
    {
        public DbSet<Roles> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        // Your context has been configured to use a 'UserDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CusJoTask.Models.UserDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'UserDBContext' 
        // connection string in the application configuration file.
        public UserDBContext()
            : base("name=UserDBContext")
        {
            Database.SetInitializer<UserDBContext>(null);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
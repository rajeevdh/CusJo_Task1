namespace CusJoTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoles : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Roles (RoleId, RoleName) values (1,'Admin')");
            Sql("insert into Roles (RoleId, RoleName) values (2,'Staff')");
            Sql("insert into Roles (RoleId, RoleName) values (3,'EndUser')");
        }
        
        public override void Down()
        {
        }
    }
}

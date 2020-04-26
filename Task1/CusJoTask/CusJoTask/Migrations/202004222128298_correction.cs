namespace CusJoTask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correction : DbMigration
    {
        public override void Up()
        {
            Sql("insert into users (Name,EmailId,PhoneNumber,RoleId,Birthdate) values ('RajeevAdmin','admin@gmail.com','12345678',1,'04/15/1991')");
            Sql("insert into users (Name,EmailId,PhoneNumber,RoleId,Birthdate) values ('RajeevStaff','staff@gmail.com','12345678',1,'04/15/1991')");
            Sql("insert into users (Name,EmailId,PhoneNumber,RoleId,Birthdate) values ('RajeevEnduser','enduser@gmail.com','12345678',1,'04/15/1991')");
        }
        
        public override void Down()
        {
        }
    }
}

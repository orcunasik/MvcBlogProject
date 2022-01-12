namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_admin_password_hashing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "AdminMail", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordSalt", c => c.Binary());
            AddColumn("dbo.Admins", "AdminPasswordHash", c => c.Binary());
            DropColumn("dbo.Admins", "AdminPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "AdminPassword", c => c.String(maxLength: 50));
            DropColumn("dbo.Admins", "AdminPasswordHash");
            DropColumn("dbo.Admins", "AdminPasswordSalt");
            DropColumn("dbo.Admins", "AdminMail");
        }
    }
}

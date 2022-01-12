namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_update_writer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Writers", "WriterMail");
            DropColumn("dbo.Writers", "WriterPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Writers", "WriterPassword", c => c.String(maxLength: 200));
            AddColumn("dbo.Writers", "WriterMail", c => c.String(maxLength: 200));
        }
    }
}

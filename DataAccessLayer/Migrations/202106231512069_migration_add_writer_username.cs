namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_add_writer_username : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writers", "WriterUserName", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Writers", "WriterUserName");
        }
    }
}

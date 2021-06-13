namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration_add_skill_card : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SkillCards",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 40),
                        Description = c.String(maxLength: 50),
                        Skill1 = c.String(maxLength: 25),
                        SkillPoint1 = c.Int(nullable: false),
                        Skill2 = c.String(maxLength: 25),
                        SkillPoint2 = c.Int(nullable: false),
                        Skill3 = c.String(maxLength: 25),
                        SkillPoint3 = c.Int(nullable: false),
                        Skill4 = c.String(maxLength: 25),
                        SkillPoint4 = c.Int(nullable: false),
                        Skill5 = c.String(maxLength: 25),
                        SkillPoint5 = c.Int(nullable: false),
                        Skill6 = c.String(maxLength: 25),
                        SkillPoint6 = c.Int(nullable: false),
                        Skill7 = c.String(maxLength: 25),
                        SkillPoint7 = c.Int(nullable: false),
                        Skill8 = c.String(maxLength: 25),
                        SkillPoint8 = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SkillCards");
        }
    }
}

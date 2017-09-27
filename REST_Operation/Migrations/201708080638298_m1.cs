namespace REST_Operation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Saurabh.Members",
                c => new
                    {
                        MemId = c.Int(nullable: false, identity: true),
                        MemName = c.String(),
                        MemEmail = c.String(),
                        MemAddress = c.String(),
                    })
                .PrimaryKey(t => t.MemId);
            
        }
        
        public override void Down()
        {
            DropTable("Saurabh.Members");
        }
    }
}

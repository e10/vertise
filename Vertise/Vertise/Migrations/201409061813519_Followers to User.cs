namespace Vertise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FollowerstoUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.AspNetUsers", t => t.FollowerId)
                .ForeignKey("dbo.AspNetUsers", t => t.FolloweeId)
                .Index(t => t.FollowerId)
                .Index(t => t.FolloweeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followers", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followers", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followers", new[] { "FolloweeId" });
            DropIndex("dbo.Followers", new[] { "FollowerId" });
            DropTable("dbo.Followers");
        }
    }
}

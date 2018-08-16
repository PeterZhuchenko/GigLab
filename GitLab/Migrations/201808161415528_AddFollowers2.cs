namespace GitLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowers2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followments", "Artist_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followments", "Follower_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Followments", new[] { "Artist_Id" });
            DropIndex("dbo.Followments", new[] { "Follower_Id" });
            CreateTable(
                "dbo.Followings",
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
            
            DropTable("dbo.Followments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Followments",
                c => new
                    {
                        FollowerId = c.Int(nullable: false),
                        ArtistId = c.Int(nullable: false),
                        Artist_Id = c.String(nullable: false, maxLength: 128),
                        Follower_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.ArtistId });
            
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followings", "FollowerId", "dbo.AspNetUsers");
            DropIndex("dbo.Followings", new[] { "FolloweeId" });
            DropIndex("dbo.Followings", new[] { "FollowerId" });
            DropTable("dbo.Followings");
            CreateIndex("dbo.Followments", "Follower_Id");
            CreateIndex("dbo.Followments", "Artist_Id");
            AddForeignKey("dbo.Followments", "Follower_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Followments", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

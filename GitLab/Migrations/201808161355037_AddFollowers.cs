namespace GitLab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowers : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => new { t.FollowerId, t.ArtistId })
                .ForeignKey("dbo.AspNetUsers", t => t.Artist_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Follower_Id)
                .Index(t => t.Artist_Id)
                .Index(t => t.Follower_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followments", "Follower_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followments", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Followments", new[] { "Follower_Id" });
            DropIndex("dbo.Followments", new[] { "Artist_Id" });
            DropTable("dbo.Followments");
        }
    }
}

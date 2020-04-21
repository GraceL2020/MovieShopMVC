namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieTrailerRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Trailer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 2084),
                        TrailerUrl = c.String(maxLength: 2084),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trailer", "MovieId", "dbo.Movie");
            DropIndex("dbo.Trailer", new[] { "MovieId" });
            DropTable("dbo.Trailer");
        }
    }
}

namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class movieGenreRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieGenre",
                c => new
                    {
                        GenreId = c.Int(nullable: false),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GenreId, t.MovieId })
                .ForeignKey("dbo.Genre", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.GenreId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MovieGenre", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieGenre", "GenreId", "dbo.Genre");
            DropIndex("dbo.MovieGenre", new[] { "MovieId" });
            DropIndex("dbo.MovieGenre", new[] { "GenreId" });
            DropTable("dbo.MovieGenre");
        }
    }
}

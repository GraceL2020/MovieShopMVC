namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingGenreTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Genres", newName: "Genre");
            AlterColumn("dbo.Genre", "Name", c => c.String(nullable: false, maxLength: 64));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genre", "Name", c => c.String());
            RenameTable(name: "dbo.Genre", newName: "Genres");
        }
    }
}

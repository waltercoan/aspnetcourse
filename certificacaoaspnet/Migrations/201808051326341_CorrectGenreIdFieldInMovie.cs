namespace certificacaoaspnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectGenreIdFieldInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreId", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "GenresId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenresId", c => c.Byte(nullable: false));
            DropColumn("dbo.Movies", "GenreId");
        }
    }
}

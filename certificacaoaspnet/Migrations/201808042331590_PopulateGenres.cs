namespace certificacaoaspnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO GENRES (name) values ('Comedy')");
            Sql("INSERT INTO GENRES (name) values ('Action')");
            Sql("INSERT INTO GENRES (name) values ('Family')");
            Sql("INSERT INTO GENRES (name) values ('Romance')");
        }
        
        public override void Down()
        {
        }
    }
}

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviesData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, AddedDate, StockNumber) VALUES ('Hang Over 3', 5, '2012-06-18', '2012-06-18',3)");
            Sql("INSERT INTO Movies (Name, GenreId, ReleaseDate, AddedDate, StockNumber) VALUES ('Whats Over', 3, '2016-03-08', '2020-06-18',5)");
        }
        
        public override void Down()
        {
        }
    }
}

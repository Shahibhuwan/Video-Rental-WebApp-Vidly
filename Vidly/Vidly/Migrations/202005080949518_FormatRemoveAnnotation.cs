namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FormatRemoveAnnotation : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Movies WHERE id=3");
            Sql("DELETE FROM Movies WHERE id=5");
            Sql("DELETE FROM Movies WHERE id=6");

        }
        
        public override void Down()
        {
        }
    }
}

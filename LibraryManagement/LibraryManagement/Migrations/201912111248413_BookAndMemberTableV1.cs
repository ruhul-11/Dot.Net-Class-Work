namespace LibraryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookAndMemberTableV1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Books", "Publisher", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Members", "MemberNo", c => c.String(nullable: false, maxLength: 8000, unicode: false));
            AlterColumn("dbo.Members", "Name", c => c.String(nullable: false, maxLength: 8000, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Name", c => c.String());
            AlterColumn("dbo.Members", "MemberNo", c => c.String());
            AlterColumn("dbo.Books", "Publisher", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
        }
    }
}

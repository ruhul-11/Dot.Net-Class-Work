namespace LibraryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyBorrowName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Borrows", "IsBorrowed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Borrows", "IsReturn");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Borrows", "IsReturn", c => c.Boolean(nullable: false));
            DropColumn("dbo.Borrows", "IsBorrowed");
        }
    }
}

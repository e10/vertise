namespace Vertise.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityMoved : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MessageMedias", newName: "MessageMediaMapping");
            RenameColumn(table: "dbo.MessageMediaMapping", name: "Message_Id", newName: "MsssageId");
            RenameColumn(table: "dbo.MessageMediaMapping", name: "Media_Id", newName: "MediaId");
            RenameIndex(table: "dbo.MessageMediaMapping", name: "IX_Media_Id", newName: "IX_MediaId");
            RenameIndex(table: "dbo.MessageMediaMapping", name: "IX_Message_Id", newName: "IX_MsssageId");
            DropPrimaryKey("dbo.MessageMediaMapping");
            AddColumn("dbo.Media", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Media", "Deleted", c => c.DateTime());
            AddColumn("dbo.Media", "Created", c => c.DateTime(nullable: false,defaultValueSql:"getutcdate()"));
            AddColumn("dbo.Media", "Modified", c => c.DateTime(nullable: false, defaultValueSql: "getutcdate()"));
            AddColumn("dbo.Messages", "Modified", c => c.DateTime(nullable: false, defaultValueSql: "getutcdate()"));
            AddPrimaryKey("dbo.MessageMediaMapping", new[] { "MediaId", "MsssageId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MessageMediaMapping");
            DropColumn("dbo.Messages", "Modified");
            DropColumn("dbo.Media", "Modified");
            DropColumn("dbo.Media", "Created");
            DropColumn("dbo.Media", "Deleted");
            DropColumn("dbo.Media", "IsDeleted");
            AddPrimaryKey("dbo.MessageMediaMapping", new[] { "Message_Id", "Media_Id" });
            RenameIndex(table: "dbo.MessageMediaMapping", name: "IX_MsssageId", newName: "IX_Message_Id");
            RenameIndex(table: "dbo.MessageMediaMapping", name: "IX_MediaId", newName: "IX_Media_Id");
            RenameColumn(table: "dbo.MessageMediaMapping", name: "MediaId", newName: "Media_Id");
            RenameColumn(table: "dbo.MessageMediaMapping", name: "MsssageId", newName: "Message_Id");
            RenameTable(name: "dbo.MessageMediaMapping", newName: "MessageMedias");
        }
    }
}

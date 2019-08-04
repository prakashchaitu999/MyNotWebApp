using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyNoteWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyNotes",
                columns: table => new
                {
                    NoteId = table.Column<int>(nullable: false),
                    NoteName = table.Column<string>(nullable: false),
                    Contact = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyNotes", x => x.NoteId);
                    table.UniqueConstraint("AK_MyNotes_Contact", x => x.Contact);
                });

            migrationBuilder.CreateTable(
                name: "MyLabels",
                columns: table => new
                {
                    LabelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LabelName = table.Column<string>(nullable: true),
                    LabelDescription = table.Column<string>(nullable: true),
                    LabelDate = table.Column<DateTime>(nullable: false),
                    MyNoteNoteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyLabels", x => x.LabelId);
                    table.ForeignKey(
                        name: "FK_MyLabels_MyNotes_MyNoteNoteId",
                        column: x => x.MyNoteNoteId,
                        principalTable: "MyNotes",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyLabels_MyNoteNoteId",
                table: "MyLabels",
                column: "MyNoteNoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyLabels");

            migrationBuilder.DropTable(
                name: "MyNotes");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace JMCRM.Migrations
{
    public partial class AddedStorylinesAndEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storyline",
                columns: table => new
                {
                    StorylineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storyline", x => x.StorylineId);
                    table.ForeignKey(
                        name: "FK_Storyline_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorylineId = table.Column<int>(type: "int", nullable: false),
                    EventContactContactId = table.Column<int>(type: "int", nullable: true),
                    OccurenceDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Event_Contact_EventContactContactId",
                        column: x => x.EventContactContactId,
                        principalTable: "Contact",
                        principalColumn: "ContactId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Event_Storyline_StorylineId",
                        column: x => x.StorylineId,
                        principalTable: "Storyline",
                        principalColumn: "StorylineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventContactContactId",
                table: "Event",
                column: "EventContactContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_StorylineId",
                table: "Event",
                column: "StorylineId");

            migrationBuilder.CreateIndex(
                name: "IX_Storyline_ProjectId",
                table: "Storyline",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Storyline");
        }
    }
}

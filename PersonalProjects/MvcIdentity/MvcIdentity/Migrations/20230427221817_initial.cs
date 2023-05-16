using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcIdentity.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameRecords",
                columns: table => new
                {
                    MatchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WinOrLoose = table.Column<bool>(type: "bit", nullable: false),
                    GameName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Against = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeRecord = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRecords", x => x.MatchId);
                });

            migrationBuilder.InsertData(
                table: "GameRecords",
                columns: new[] { "MatchId", "Against", "Duration", "GameName", "TimeRecord", "WinOrLoose" },
                values: new object[] { 1, "Computer", new TimeSpan(0, 0, 5, 0, 0), "Jokenpo", new DateTime(2023, 4, 27, 19, 18, 17, 0, DateTimeKind.Unspecified), true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameRecords");
        }
    }
}

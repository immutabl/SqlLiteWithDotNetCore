using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SqlLiteWithDotNetCore.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AfterGoingClean : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Contact",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryCode = table.Column<string>(type: "TEXT", nullable: false),
                    Capital = table.Column<string>(type: "TEXT", nullable: false),
                    DialingCode = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CountryId",
                table: "Contact",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Countries_CountryId",
                table: "Contact",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Countries_CountryId",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Contact_CountryId",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Contact");
        }
    }
}

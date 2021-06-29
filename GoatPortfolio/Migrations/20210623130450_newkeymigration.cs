using Microsoft.EntityFrameworkCore.Migrations;

namespace GoatPortfolio.Migrations
{
    public partial class newkeymigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ForexKey",
                table: "UserApiKey",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ForexKey",
                table: "UserApiKey");
        }
    }
}

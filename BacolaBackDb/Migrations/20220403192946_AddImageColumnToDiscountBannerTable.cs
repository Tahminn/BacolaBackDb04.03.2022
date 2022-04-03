using Microsoft.EntityFrameworkCore.Migrations;

namespace BacolaBackDb.Migrations
{
    public partial class AddImageColumnToDiscountBannerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "DiscountBanners",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "DiscountBanners");
        }
    }
}

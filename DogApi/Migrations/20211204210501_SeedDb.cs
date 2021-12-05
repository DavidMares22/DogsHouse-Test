using Microsoft.EntityFrameworkCore.Migrations;

namespace DogApi.Migrations
{
    public partial class SeedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Tail_length = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "Id", "Color", "Name", "Tail_length", "Weight" },
                values: new object[,]
                {
                    { 1, "red & amber", "Neo", 22, 32 },
                    { 2, "white & amber", "Geo", 40, 20 },
                    { 3, "black & white", "Rio", 28, 37 },
                    { 4, "white", "Dj", 10, 19 },
                    { 5, "black", "Jessy", 17, 5 },
                    { 6, "gray", "Dory", 12, 16 },
                    { 7, "gold", "Nora", 32, 30 },
                    { 8, "gray & white", "Pedro", 47, 4 },
                    { 9, "yellow", "Pongo", 37, 16 },
                    { 10, "white", "Z", 47, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_Name",
                table: "Dogs",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}

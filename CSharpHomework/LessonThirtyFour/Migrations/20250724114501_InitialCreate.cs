using Microsoft.EntityFrameworkCore.Migrations;


namespace LessonThirtyFour.Migrations
{
    
    public partial class InitialCreate : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    CopiesAvailable = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CopiesAvailable", "Title", "Year" },
                values: new object[,]
                {
                    { 1, "Jon Skeet", 5, "C# in Depth", 2019 },
                    { 2, "Andrew Troelsen", 2, "Pro C# 7", 2018 },
                    { 3, "Andrew Troelsen", 0, "C# 6.0 and the .NET 4.6 Framework", 2015 },
                    { 4, "Harrison Ferrone", 4, "Learning C# by Developing Games", 2020 },
                    { 5, "Jeffrey Richter", 1, "CLR via C#", 2012 }
                });
        }

        
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}

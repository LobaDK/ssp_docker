using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SSP_app.Migrations.TodoDb
{
    /// <inheritdoc />
    public partial class TodoListInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cpr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CprNr = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cpr__3214EC07F9689AA0", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    Item = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TodoList__3214EC07DA7A60E9", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Todolist_Cpr",
                        column: x => x.UserId,
                        principalTable: "Cpr",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoList_UserId",
                table: "TodoList",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoList");

            migrationBuilder.DropTable(
                name: "Cpr");
        }
    }
}

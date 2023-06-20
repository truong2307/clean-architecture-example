using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizApp.Infrastructure.Persistence.Migrations
{
    public partial class Add_Table_ClassRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRoom_ClassRoomCategories_ClassRoomCategoryId",
                table: "ClassRoom");

            migrationBuilder.DropTable(
                name: "ClassRoomQuiz");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassRoom",
                table: "ClassRoom");

            migrationBuilder.RenameTable(
                name: "ClassRoom",
                newName: "ClassRooms");

            migrationBuilder.RenameIndex(
                name: "IX_ClassRoom_ClassRoomCategoryId",
                table: "ClassRooms",
                newName: "IX_ClassRooms_ClassRoomCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ClassRooms",
                type: "nvarchar(126)",
                maxLength: 126,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeRoomTeacherId",
                table: "ClassRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ClassRooms",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ClassRooms",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassRoomCategoryId",
                table: "ClassRooms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassRooms",
                table: "ClassRooms",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "QuizClassRoom",
                columns: table => new
                {
                    QuizId = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizClassRoom", x => new { x.QuizId, x.ClassRoomId });
                    table.ForeignKey(
                        name: "FK_QuizClassRoom_ClassRooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuizClassRoom_Quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizClassRoom_ClassRoomId",
                table: "QuizClassRoom",
                column: "ClassRoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRooms_ClassRoomCategories_ClassRoomCategoryId",
                table: "ClassRooms",
                column: "ClassRoomCategoryId",
                principalTable: "ClassRoomCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassRooms_ClassRoomCategories_ClassRoomCategoryId",
                table: "ClassRooms");

            migrationBuilder.DropTable(
                name: "QuizClassRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClassRooms",
                table: "ClassRooms");

            migrationBuilder.RenameTable(
                name: "ClassRooms",
                newName: "ClassRoom");

            migrationBuilder.RenameIndex(
                name: "IX_ClassRooms_ClassRoomCategoryId",
                table: "ClassRoom",
                newName: "IX_ClassRoom_ClassRoomCategoryId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ClassRoom",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(126)",
                oldMaxLength: 126);

            migrationBuilder.AlterColumn<string>(
                name: "HomeRoomTeacherId",
                table: "ClassRoom",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "ClassRoom",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ClassRoom",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ClassRoomCategoryId",
                table: "ClassRoom",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClassRoom",
                table: "ClassRoom",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClassRoomQuiz",
                columns: table => new
                {
                    ClassRoomsId = table.Column<int>(type: "int", nullable: false),
                    QuizzesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassRoomQuiz", x => new { x.ClassRoomsId, x.QuizzesId });
                    table.ForeignKey(
                        name: "FK_ClassRoomQuiz_ClassRoom_ClassRoomsId",
                        column: x => x.ClassRoomsId,
                        principalTable: "ClassRoom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassRoomQuiz_Quizzes_QuizzesId",
                        column: x => x.QuizzesId,
                        principalTable: "Quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassRoomQuiz_QuizzesId",
                table: "ClassRoomQuiz",
                column: "QuizzesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassRoom_ClassRoomCategories_ClassRoomCategoryId",
                table: "ClassRoom",
                column: "ClassRoomCategoryId",
                principalTable: "ClassRoomCategories",
                principalColumn: "Id");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PictureScan.DBMigrator.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "varchar(26)", nullable: true),
                    FileDirectory = table.Column<string>(type: "varchar(max)", nullable: true),
                    CreationFileDate = table.Column<DateTime>(nullable: false),
                    LeftTop = table.Column<long>(nullable: false),
                    LeftBottom = table.Column<long>(nullable: false),
                    LeftCenter = table.Column<long>(nullable: false),
                    CenterTop = table.Column<long>(nullable: false),
                    CenterBottom = table.Column<long>(nullable: false),
                    CenterCenter = table.Column<long>(nullable: false),
                    RightTop = table.Column<long>(nullable: false),
                    RightBottom = table.Column<long>(nullable: false),
                    RightCenter = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Picture_Id",
                table: "Picture",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Picture");
        }
    }
}

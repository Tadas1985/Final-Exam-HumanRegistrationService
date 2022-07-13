using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Human_Registration_Service.Migrations
{
    public partial class App11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImage",
                table: "HumanInformation",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImage",
                table: "HumanInformation");
        }
    }
}

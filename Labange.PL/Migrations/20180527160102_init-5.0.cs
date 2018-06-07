using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Labange.PL.Migrations
{
    public partial class init50 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Resumes_UnemployedId",
                table: "Resumes");

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Unemployeds",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_UnemployedId",
                table: "Resumes",
                column: "UnemployedId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Resumes_UnemployedId",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Unemployeds");

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_UnemployedId",
                table: "Resumes",
                column: "UnemployedId");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateInsuranceReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceReports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SchemeName = table.Column<string>(type: "TEXT", nullable: false),
                    PolicyName = table.Column<string>(type: "TEXT", nullable: false),
                    PolicyStartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PolicyEndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    InitialEffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReportStartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReportEndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CalimsProcessed = table.Column<decimal>(type: "TEXT", nullable: false),
                    ClaimsNotProcessed = table.Column<decimal>(type: "TEXT", nullable: false),
                    ClaimsNotReported = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceReports", x => x.ReportId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceReports");
        }
    }
}

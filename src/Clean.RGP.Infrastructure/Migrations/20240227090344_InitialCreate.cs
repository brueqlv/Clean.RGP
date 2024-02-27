using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clean.RGP.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
  /// <inheritdoc />
  protected override void Up(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.CreateTable(
        name: "Contributors",
        columns: table => new
        {
          Id = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Contributors", x => x.Id);
        });

    migrationBuilder.CreateTable(
        name: "People",
        columns: table => new
        {
          PersonId = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
          PersonalCodeOrRegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
          PersonType = table.Column<int>(type: "int", nullable: false),
          Id = table.Column<int>(type: "int", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_People", x => x.PersonId);
        });

    migrationBuilder.CreateTable(
        name: "LandProperties",
        columns: table => new
        {
          LandPropertyId = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
          CadastralMark = table.Column<long>(type: "bigint", nullable: false),
          Status = table.Column<int>(type: "int", nullable: false),
          PersonId = table.Column<int>(type: "int", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_LandProperties", x => x.LandPropertyId);
          table.ForeignKey(
                      name: "FK_LandProperties_People_PersonId",
                      column: x => x.PersonId,
                      principalTable: "People",
                      principalColumn: "PersonId",
                      onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateTable(
        name: "Plots",
        columns: table => new
        {
          PlotId = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          CadastralMark = table.Column<long>(type: "bigint", nullable: false),
          TotalAreaInHectares = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
          DateOfSurvey = table.Column<DateTime>(type: "datetime2", nullable: false),
          LandPropertyId = table.Column<int>(type: "int", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Plots", x => x.PlotId);
          table.ForeignKey(
                      name: "FK_Plots_LandProperties_LandPropertyId",
                      column: x => x.LandPropertyId,
                      principalTable: "LandProperties",
                      principalColumn: "LandPropertyId",
                      onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateTable(
        name: "LandTypes",
        columns: table => new
        {
          LandTypeId = table.Column<int>(type: "int", nullable: false)
                .Annotation("SqlServer:Identity", "1, 1"),
          Type = table.Column<int>(type: "int", nullable: false),
          AreaInHectares = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
          PlotId = table.Column<int>(type: "int", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_LandTypes", x => x.LandTypeId);
          table.ForeignKey(
                      name: "FK_LandTypes_Plots_PlotId",
                      column: x => x.PlotId,
                      principalTable: "Plots",
                      principalColumn: "PlotId",
                      onDelete: ReferentialAction.Cascade);
        });

    migrationBuilder.CreateIndex(
        name: "IX_LandProperties_PersonId",
        table: "LandProperties",
        column: "PersonId");

    migrationBuilder.CreateIndex(
        name: "IX_LandTypes_PlotId",
        table: "LandTypes",
        column: "PlotId");

    migrationBuilder.CreateIndex(
        name: "IX_Plots_LandPropertyId",
        table: "Plots",
        column: "LandPropertyId");
  }

  /// <inheritdoc />
  protected override void Down(MigrationBuilder migrationBuilder)
  {
    migrationBuilder.DropTable(
        name: "Contributors");

    migrationBuilder.DropTable(
        name: "LandTypes");

    migrationBuilder.DropTable(
        name: "Plots");

    migrationBuilder.DropTable(
        name: "LandProperties");

    migrationBuilder.DropTable(
        name: "People");
  }
}


using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ProjeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    Hospital_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hospital_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hospital_Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDoctors = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Hospital_Id);
                });

            migrationBuilder.CreateTable(
                name: "Poliklinik",
                columns: table => new
                {
                    Poliklinik_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Poliklinik_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfDoctors = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poliklinik", x => x.Poliklinik_Id);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    Patient_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patient_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patient_Condition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hospital_Id = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient", x => x.Patient_Id);
                    table.ForeignKey(
                        name: "FK_Patient_Hospital_Hospital_Id",
                        column: x => x.Hospital_Id,
                        principalTable: "Hospital",
                        principalColumn: "Hospital_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    Doctor_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Doctor_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hospital_Id = table.Column<int>(type: "int", nullable: true),
                    Poliklinik_Id = table.Column<int>(type: "int", nullable: true),
                    IsActıve = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctor", x => x.Doctor_Id);
                    table.ForeignKey(
                        name: "FK_Doctor_Hospital_Hospital_Id",
                        column: x => x.Hospital_Id,
                        principalTable: "Hospital",
                        principalColumn: "Hospital_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Doctor_Poliklinik_Poliklinik_Id",
                        column: x => x.Poliklinik_Id,
                        principalTable: "Poliklinik",
                        principalColumn: "Poliklinik_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    Date_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date_Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Doctor_Id = table.Column<int>(type: "int", nullable: true),
                    Patient_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.Date_Id);
                    table.ForeignKey(
                        name: "FK_Date_Doctor_Doctor_Id",
                        column: x => x.Doctor_Id,
                        principalTable: "Doctor",
                        principalColumn: "Doctor_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Date_Patient_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patient",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    Prescriptions_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Medicine_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Doctor_Id = table.Column<int>(type: "int", nullable: true),
                    Patient_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescription", x => x.Prescriptions_Id);
                    table.ForeignKey(
                        name: "FK_Prescription_Doctor_Doctor_Id",
                        column: x => x.Doctor_Id,
                        principalTable: "Doctor",
                        principalColumn: "Doctor_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prescription_Patient_Patient_Id",
                        column: x => x.Patient_Id,
                        principalTable: "Patient",
                        principalColumn: "Patient_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Date_Doctor_Id",
                table: "Date",
                column: "Doctor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Date_Patient_Id",
                table: "Date",
                column: "Patient_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Hospital_Id",
                table: "Doctor",
                column: "Hospital_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctor_Poliklinik_Id",
                table: "Doctor",
                column: "Poliklinik_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Hospital_Id",
                table: "Patient",
                column: "Hospital_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Doctor_Id",
                table: "Prescription",
                column: "Doctor_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_Patient_Id",
                table: "Prescription",
                column: "Patient_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");

            migrationBuilder.DropTable(
                name: "Poliklinik");

            migrationBuilder.DropTable(
                name: "Hospital");
        }
    }
}

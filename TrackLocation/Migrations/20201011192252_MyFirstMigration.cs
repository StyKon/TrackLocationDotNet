using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using TrackLocation.Model;

namespace TrackLocation.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FamilyCar",
                columns: table => new
                {
                    FamilyCarID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameFamily = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyCar", x => x.FamilyCarID);
                });

            migrationBuilder.CreateTable(
                name: "TypeCar",
                columns: table => new
                {
                    TypeCarID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCar", x => x.TypeCarID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 30, nullable: false),
                    LastName = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Cin = table.Column<string>(maxLength: 50, nullable: false),
                    NumTel = table.Column<string>(maxLength: 30, nullable: false),
                    NumPassport = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    TypeUser = table.Column<string>(nullable: false),
                    token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    CarID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCar = table.Column<string>(nullable: false),
                    Puissance = table.Column<int>(nullable: false),
                    NumberPlace = table.Column<int>(nullable: false),
                    Matricule = table.Column<string>(nullable: false),
                    DateCirculation = table.Column<DateTime>(nullable: false),
                    TotKm = table.Column<int>(nullable: true),
                    FamilyCarID = table.Column<long>(nullable: false),
                    UserID = table.Column<long>(nullable: false),
                    TypeCarID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.CarID);
                    table.ForeignKey(
                        name: "FK_Car_FamilyCar_FamilyCarID",
                        column: x => x.FamilyCarID,
                        principalTable: "FamilyCar",
                        principalColumn: "FamilyCarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_TypeCar_TypeCarID",
                        column: x => x.TypeCarID,
                        principalTable: "TypeCar",
                        principalColumn: "TypeCarID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<long>(nullable: false),
                    Tracking = table.Column<ICollection<Coordination>>(nullable: false),
                    startDate = table.Column<DateTime>(nullable: false),
                    endDate = table.Column<DateTime>(nullable: false),
                    UserID = table.Column<long>(nullable: false),
                    CarID = table.Column<long>(nullable: false),
                    severity = table.Column<byte>(nullable: true, computedColumnSql: "(CONVERT([tinyint],json_value([Tracking],'$.severity')))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Location__E7FEA47605B8C4E7", x => x.LocationID)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_CAR_LOC",
                        column: x => x.CarID,
                        principalTable: "Car",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_LOC",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_FamilyCarID",
                table: "Car",
                column: "FamilyCarID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TypeCarID",
                table: "Car",
                column: "TypeCarID");

            migrationBuilder.CreateIndex(
                name: "IX_Car_UserID",
                table: "Car",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Location_CarID",
                table: "Location",
                column: "CarID");

            migrationBuilder.CreateIndex(
                name: "ix_severity",
                table: "Location",
                column: "severity");

            migrationBuilder.CreateIndex(
                name: "IX_Location_UserID",
                table: "Location",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "FamilyCar");

            migrationBuilder.DropTable(
                name: "TypeCar");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

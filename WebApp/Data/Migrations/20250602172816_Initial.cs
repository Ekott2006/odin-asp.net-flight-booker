using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DepartureDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    DepartureId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArrivalId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_ArrivalId",
                        column: x => x.ArrivalId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_DepartureId",
                        column: x => x.DepartureId,
                        principalTable: "Airports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FlightId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    BookingId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passengers_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "Code" },
                values: new object[,]
                {
                    { new Guid("01e570bb-0ff6-4ff7-a7a0-c593d4fb384c"), "ENA" },
                    { new Guid("02a94dde-5c29-4e28-bfdc-7ee4d2c34591"), "ABJ" },
                    { new Guid("0be95ac0-a3e3-43e5-b305-48bf59e4f605"), "AIA" },
                    { new Guid("0cc51007-5187-414b-b55b-3af6023a54e1"), "AHO" },
                    { new Guid("1ec5bb10-58b3-48d5-87e0-5152eb997b14"), "AMD" },
                    { new Guid("2e423506-11cb-4f97-886a-77ada95db630"), "YLW" },
                    { new Guid("2f1971f2-1857-4210-a3f8-d3f183567686"), "KTN" },
                    { new Guid("30536cf8-5a8d-46ee-9c23-44d732fbf28e"), "AGU" },
                    { new Guid("31620eb9-7a92-4402-aeae-2858dd5942e6"), "APN" },
                    { new Guid("3451b36e-32af-4a41-9a05-3b730c8586ec"), "YNY" },
                    { new Guid("3456f7a7-3308-40d5-a3de-ce1d6d07aa6a"), "HRK" },
                    { new Guid("37f46204-b0de-4e93-a74f-f66bc055b2a9"), "ALS" },
                    { new Guid("44b00cd2-916a-43b0-8c0b-fd93de913ec7"), "LEI" },
                    { new Guid("46fa70fb-d1c8-4569-a6cd-ed2c5cb0598a"), "SBP" },
                    { new Guid("48c24aa5-ed36-4e4e-89bc-07dd5fc5daec"), "SJC" },
                    { new Guid("5101b4c9-0306-4033-801d-1575dcc305ea"), "AZO" },
                    { new Guid("519c5c35-2d60-4cdc-a331-e705ef305d22"), "ADA" },
                    { new Guid("52cda36b-8c4f-40ea-bd2a-7409124101aa"), "ALC" },
                    { new Guid("5a559560-3645-4432-b7d0-7c5a6878d0b1"), "EVN" },
                    { new Guid("60b4fe28-d1fe-4c1a-ad41-ea83fd42c4f9"), "GUM" },
                    { new Guid("688f56ea-46c1-436a-ae9e-8c2c55c2c0db"), "YXX" },
                    { new Guid("6ddaa335-1f81-428e-a3bb-9819b34189b2"), "NSB" },
                    { new Guid("78bd612f-e246-4649-84f3-436725c13e5c"), "KGD" },
                    { new Guid("7a20b5c5-5d8b-4cc4-b008-d34a7d98ff75"), "ZAZ" },
                    { new Guid("8722b824-faf6-4c93-96a9-d41d146fe95f"), "ZAM" },
                    { new Guid("887bd4eb-627e-458e-ade1-7f36d87718c4"), "ACH" },
                    { new Guid("9933caf8-8a15-4a70-a487-d9cf9c7806e8"), "ACA" },
                    { new Guid("9c6c1491-e4da-462c-ad34-a046c2f186cc"), "SAL" },
                    { new Guid("9d4c68fb-9afb-4dbb-bcdc-aa56b6b440cf"), "ADF" },
                    { new Guid("a7c76537-5b8c-4369-8a76-3761cf799ab1"), "ADL" },
                    { new Guid("ae84a5ae-358e-4b04-aa3f-324372ffa3a5"), "YUM" },
                    { new Guid("af0ead33-269a-43b1-9b4f-ecb6bc0a3f88"), "YQK" },
                    { new Guid("b95c8e02-ae49-4b40-8ae8-7c4a6bf82af4"), "ALB" },
                    { new Guid("be114477-ab16-43e6-8160-b44780e8d7d4"), "KKC" },
                    { new Guid("be9b63ff-af37-4010-8fe2-ad534fd5003e"), "AES" },
                    { new Guid("c4654592-554a-4cd9-adce-3093956f6354"), "YZF" },
                    { new Guid("ccf71d15-696f-474b-89e4-375596392e69"), "AXT" },
                    { new Guid("ce510c8c-f4b8-4db2-b77b-45f01d3076c1"), "ZAD" },
                    { new Guid("cfd78e93-f5c7-46d3-ad52-31c86ae3bf87"), "ABQ" },
                    { new Guid("dbc624a0-b399-45b6-a4ec-575ec6652e44"), "YAO" },
                    { new Guid("e1098f36-f69d-4b12-9230-8a9818911fe4"), "KGI" },
                    { new Guid("e242c9ec-00c0-468d-a2f4-b5272c72d0c8"), "ABZ" },
                    { new Guid("ef9a1269-80a3-43c9-a6e8-0f902a60e402"), "YNT" },
                    { new Guid("fabf35b2-d7f2-424f-9006-e15ed821928b"), "AUH" },
                    { new Guid("feaec228-b41a-4cac-9155-34474d4ed1c2"), "ALY" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FlightId",
                table: "Bookings",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_ArrivalId",
                table: "Flights",
                column: "ArrivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_DepartureId",
                table: "Flights",
                column: "DepartureId");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_BookingId",
                table: "Passengers",
                column: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}

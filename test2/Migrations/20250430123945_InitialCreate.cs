using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    city_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descreption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.city_id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Historical_Places",
                columns: table => new
                {
                    place_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    descreption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    entry_fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historical_Places", x => x.place_id);
                    table.ForeignKey(
                        name: "FK_Historical_Places_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    hotel_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descreption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    price_per_night = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HistoricalPlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.hotel_id);
                    table.ForeignKey(
                        name: "FK_Hotels_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hotels_Historical_Places_HistoricalPlaceId",
                        column: x => x.HistoricalPlaceId,
                        principalTable: "Historical_Places",
                        principalColumn: "place_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "trips",
                columns: table => new
                {
                    trip_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    duration = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    historicalplacesplace_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.trip_id);
                    table.ForeignKey(
                        name: "FK_trips_cities_city_id",
                        column: x => x.city_id,
                        principalTable: "cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trips_Historical_Places_historicalplacesplace_id",
                        column: x => x.historicalplacesplace_id,
                        principalTable: "Historical_Places",
                        principalColumn: "place_id");
                });

            migrationBuilder.CreateTable(
                name: "hotelbookings",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    hotel_id = table.Column<int>(type: "int", nullable: false),
                    booking_id = table.Column<int>(type: "int", nullable: false),
                    bookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tripstrip_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelbookings", x => new { x.user_id, x.hotel_id });
                    table.ForeignKey(
                        name: "FK_hotelbookings_Hotels_hotel_id",
                        column: x => x.hotel_id,
                        principalTable: "Hotels",
                        principalColumn: "hotel_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hotelbookings_trips_tripstrip_id",
                        column: x => x.tripstrip_id,
                        principalTable: "trips",
                        principalColumn: "trip_id");
                    table.ForeignKey(
                        name: "FK_hotelbookings_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    trip_id = table.Column<int>(type: "int", nullable: false),
                    hotel_id = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<double>(type: "float", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_reviews_Hotels_hotel_id",
                        column: x => x.hotel_id,
                        principalTable: "Hotels",
                        principalColumn: "hotel_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reviews_trips_trip_id",
                        column: x => x.trip_id,
                        principalTable: "trips",
                        principalColumn: "trip_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reviews_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tripBookings",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    trip_id = table.Column<int>(type: "int", nullable: false),
                    booking_id = table.Column<int>(type: "int", nullable: false),
                    booking_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tripBookings", x => new { x.user_id, x.trip_id });
                    table.ForeignKey(
                        name: "FK_tripBookings_trips_trip_id",
                        column: x => x.trip_id,
                        principalTable: "trips",
                        principalColumn: "trip_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tripBookings_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historical_Places_city_id",
                table: "Historical_Places",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_hotelbookings_hotel_id",
                table: "hotelbookings",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_hotelbookings_tripstrip_id",
                table: "hotelbookings",
                column: "tripstrip_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_city_id",
                table: "Hotels",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HistoricalPlaceId",
                table: "Hotels",
                column: "HistoricalPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_hotel_id",
                table: "reviews",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_trip_id",
                table: "reviews",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_user_id",
                table: "reviews",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tripBookings_trip_id",
                table: "tripBookings",
                column: "trip_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_city_id",
                table: "trips",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_historicalplacesplace_id",
                table: "trips",
                column: "historicalplacesplace_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hotelbookings");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "tripBookings");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "Historical_Places");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}

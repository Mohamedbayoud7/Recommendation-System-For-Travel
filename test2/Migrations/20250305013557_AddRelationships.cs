using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2.Migrations
{
    public partial class AddRelationships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

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
                name: "Employee",
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
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "historical_places",
                columns: table => new
                {
                    place_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    city_id = table.Column<int>(type: "int", nullable: false),
                    descreption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    entry_fee = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    citiescity_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_historical_places", x => x.place_id);
                    table.ForeignKey(
                        name: "FK_historical_places_cities_citiescity_id",
                        column: x => x.citiescity_id,
                        principalTable: "cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tripBookings",
                columns: table => new
                {
                    booking_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    trip_id = table.Column<int>(type: "int", nullable: false),
                    booking_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tripBookings", x => x.booking_id);
                    table.ForeignKey(
                        name: "FK_tripBookings_Employee_userId",
                        column: x => x.userId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "hotels",
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
                    citiescity_id = table.Column<int>(type: "int", nullable: false),
                    historical_placesplace_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotels", x => x.hotel_id);
                    table.ForeignKey(
                        name: "FK_hotels_cities_citiescity_id",
                        column: x => x.citiescity_id,
                        principalTable: "cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hotels_historical_places_historical_placesplace_id",
                        column: x => x.historical_placesplace_id,
                        principalTable: "historical_places",
                        principalColumn: "place_id");
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
                    citiescity_id = table.Column<int>(type: "int", nullable: false),
                    historical_placesplace_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trips", x => x.trip_id);
                    table.ForeignKey(
                        name: "FK_trips_cities_citiescity_id",
                        column: x => x.citiescity_id,
                        principalTable: "cities",
                        principalColumn: "city_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_trips_historical_places_historical_placesplace_id",
                        column: x => x.historical_placesplace_id,
                        principalTable: "historical_places",
                        principalColumn: "place_id");
                });

            migrationBuilder.CreateTable(
                name: "hotelbookings",
                columns: table => new
                {
                    booking_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(type: "int", nullable: false),
                    hotel_id = table.Column<int>(type: "int", nullable: false),
                    bookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeId = table.Column<int>(type: "int", nullable: false),
                    hotelshotel_id = table.Column<int>(type: "int", nullable: false),
                    booking_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tripstrip_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hotelbookings", x => x.booking_id);
                    table.ForeignKey(
                        name: "FK_hotelbookings_Employee_employeeId",
                        column: x => x.employeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hotelbookings_hotels_hotelshotel_id",
                        column: x => x.hotelshotel_id,
                        principalTable: "hotels",
                        principalColumn: "hotel_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hotelbookings_trips_tripstrip_id",
                        column: x => x.tripstrip_id,
                        principalTable: "trips",
                        principalColumn: "trip_id");
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
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hotelshotel_id = table.Column<int>(type: "int", nullable: true),
                    tripstrip_id = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_reviews_Employee_userId",
                        column: x => x.userId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_reviews_hotels_hotelshotel_id",
                        column: x => x.hotelshotel_id,
                        principalTable: "hotels",
                        principalColumn: "hotel_id");
                    table.ForeignKey(
                        name: "FK_reviews_trips_tripstrip_id",
                        column: x => x.tripstrip_id,
                        principalTable: "trips",
                        principalColumn: "trip_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_historical_places_citiescity_id",
                table: "historical_places",
                column: "citiescity_id");

            migrationBuilder.CreateIndex(
                name: "IX_hotelbookings_employeeId",
                table: "hotelbookings",
                column: "employeeId");

            migrationBuilder.CreateIndex(
                name: "IX_hotelbookings_hotelshotel_id",
                table: "hotelbookings",
                column: "hotelshotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_hotelbookings_tripstrip_id",
                table: "hotelbookings",
                column: "tripstrip_id");

            migrationBuilder.CreateIndex(
                name: "IX_hotels_citiescity_id",
                table: "hotels",
                column: "citiescity_id");

            migrationBuilder.CreateIndex(
                name: "IX_hotels_historical_placesplace_id",
                table: "hotels",
                column: "historical_placesplace_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_hotelshotel_id",
                table: "reviews",
                column: "hotelshotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_tripstrip_id",
                table: "reviews",
                column: "tripstrip_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_userId",
                table: "reviews",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_tripBookings_userId",
                table: "tripBookings",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_trips_citiescity_id",
                table: "trips",
                column: "citiescity_id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_historical_placesplace_id",
                table: "trips",
                column: "historical_placesplace_id");
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
                name: "hotels");

            migrationBuilder.DropTable(
                name: "trips");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "historical_places");

            migrationBuilder.DropTable(
                name: "cities");

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }
    }
}

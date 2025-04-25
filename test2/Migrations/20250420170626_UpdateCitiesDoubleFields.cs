using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test2.Migrations
{
    public partial class UpdateCitiesDoubleFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_historical_places_cities_citiescity_id",
                table: "historical_places");

            migrationBuilder.DropForeignKey(
                name: "FK_hotelbookings_Employee_employeeId",
                table: "hotelbookings");

            migrationBuilder.DropForeignKey(
                name: "FK_hotelbookings_hotels_hotelshotel_id",
                table: "hotelbookings");

            migrationBuilder.DropForeignKey(
                name: "FK_hotels_cities_citiescity_id",
                table: "hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_hotels_historical_places_historical_placesplace_id",
                table: "hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_Employee_userId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_hotels_hotelshotel_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_trips_tripstrip_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_tripBookings_Employee_userId",
                table: "tripBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_cities_citiescity_id",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_historical_places_historical_placesplace_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_citiescity_id",
                table: "trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tripBookings",
                table: "tripBookings");

            migrationBuilder.DropIndex(
                name: "IX_tripBookings_userId",
                table: "tripBookings");

            migrationBuilder.DropIndex(
                name: "IX_reviews_hotelshotel_id",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_tripstrip_id",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_userId",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hotels",
                table: "hotels");

            migrationBuilder.DropIndex(
                name: "IX_hotels_citiescity_id",
                table: "hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hotelbookings",
                table: "hotelbookings");

            migrationBuilder.DropIndex(
                name: "IX_hotelbookings_employeeId",
                table: "hotelbookings");

            migrationBuilder.DropIndex(
                name: "IX_hotelbookings_hotelshotel_id",
                table: "hotelbookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_historical_places",
                table: "historical_places");

            migrationBuilder.DropIndex(
                name: "IX_historical_places_citiescity_id",
                table: "historical_places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "citiescity_id",
                table: "trips");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "tripBookings");

            migrationBuilder.DropColumn(
                name: "hotelshotel_id",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "tripstrip_id",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "citiescity_id",
                table: "hotels");

            migrationBuilder.DropColumn(
                name: "employeeId",
                table: "hotelbookings");

            migrationBuilder.DropColumn(
                name: "hotelshotel_id",
                table: "hotelbookings");

            migrationBuilder.DropColumn(
                name: "citiescity_id",
                table: "historical_places");

            migrationBuilder.RenameTable(
                name: "hotels",
                newName: "Hotels");

            migrationBuilder.RenameTable(
                name: "historical_places",
                newName: "Historical_Places");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "user");

            migrationBuilder.RenameColumn(
                name: "historical_placesplace_id",
                table: "trips",
                newName: "historicalplacesplace_id");

            migrationBuilder.RenameIndex(
                name: "IX_trips_historical_placesplace_id",
                table: "trips",
                newName: "IX_trips_historicalplacesplace_id");

            migrationBuilder.RenameColumn(
                name: "historical_placesplace_id",
                table: "Hotels",
                newName: "historicalplacesplace_id");

            migrationBuilder.RenameIndex(
                name: "IX_hotels_historical_placesplace_id",
                table: "Hotels",
                newName: "IX_Hotels_historicalplacesplace_id");

            migrationBuilder.AlterColumn<int>(
                name: "booking_id",
                table: "tripBookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "booking_id",
                table: "hotelbookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tripBookings",
                table: "tripBookings",
                columns: new[] { "user_id", "trip_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels",
                column: "hotel_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotelbookings",
                table: "hotelbookings",
                columns: new[] { "user_id", "hotel_id" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Historical_Places",
                table: "Historical_Places",
                column: "place_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_city_id",
                table: "trips",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_tripBookings_trip_id",
                table: "tripBookings",
                column: "trip_id");

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
                name: "IX_Hotels_city_id",
                table: "Hotels",
                column: "city_id");

            migrationBuilder.CreateIndex(
                name: "IX_hotelbookings_hotel_id",
                table: "hotelbookings",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_Historical_Places_city_id",
                table: "Historical_Places",
                column: "city_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Historical_Places_cities_city_id",
                table: "Historical_Places",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hotelbookings_Hotels_hotel_id",
                table: "hotelbookings",
                column: "hotel_id",
                principalTable: "Hotels",
                principalColumn: "hotel_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hotelbookings_user_user_id",
                table: "hotelbookings",
                column: "user_id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_cities_city_id",
                table: "Hotels",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_Historical_Places_historicalplacesplace_id",
                table: "Hotels",
                column: "historicalplacesplace_id",
                principalTable: "Historical_Places",
                principalColumn: "place_id");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_Hotels_hotel_id",
                table: "reviews",
                column: "hotel_id",
                principalTable: "Hotels",
                principalColumn: "hotel_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_trips_trip_id",
                table: "reviews",
                column: "trip_id",
                principalTable: "trips",
                principalColumn: "trip_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_user_user_id",
                table: "reviews",
                column: "user_id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tripBookings_trips_trip_id",
                table: "tripBookings",
                column: "trip_id",
                principalTable: "trips",
                principalColumn: "trip_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tripBookings_user_user_id",
                table: "tripBookings",
                column: "user_id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_cities_city_id",
                table: "trips",
                column: "city_id",
                principalTable: "cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_Historical_Places_historicalplacesplace_id",
                table: "trips",
                column: "historicalplacesplace_id",
                principalTable: "Historical_Places",
                principalColumn: "place_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historical_Places_cities_city_id",
                table: "Historical_Places");

            migrationBuilder.DropForeignKey(
                name: "FK_hotelbookings_Hotels_hotel_id",
                table: "hotelbookings");

            migrationBuilder.DropForeignKey(
                name: "FK_hotelbookings_user_user_id",
                table: "hotelbookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_cities_city_id",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_Historical_Places_historicalplacesplace_id",
                table: "Hotels");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_Hotels_hotel_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_trips_trip_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_user_user_id",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_tripBookings_trips_trip_id",
                table: "tripBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_tripBookings_user_user_id",
                table: "tripBookings");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_cities_city_id",
                table: "trips");

            migrationBuilder.DropForeignKey(
                name: "FK_trips_Historical_Places_historicalplacesplace_id",
                table: "trips");

            migrationBuilder.DropIndex(
                name: "IX_trips_city_id",
                table: "trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tripBookings",
                table: "tripBookings");

            migrationBuilder.DropIndex(
                name: "IX_tripBookings_trip_id",
                table: "tripBookings");

            migrationBuilder.DropIndex(
                name: "IX_reviews_hotel_id",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_trip_id",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_user_id",
                table: "reviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hotels",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_city_id",
                table: "Hotels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_hotelbookings",
                table: "hotelbookings");

            migrationBuilder.DropIndex(
                name: "IX_hotelbookings_hotel_id",
                table: "hotelbookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Historical_Places",
                table: "Historical_Places");

            migrationBuilder.DropIndex(
                name: "IX_Historical_Places_city_id",
                table: "Historical_Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.RenameTable(
                name: "Hotels",
                newName: "hotels");

            migrationBuilder.RenameTable(
                name: "Historical_Places",
                newName: "historical_places");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "Employee");

            migrationBuilder.RenameColumn(
                name: "historicalplacesplace_id",
                table: "trips",
                newName: "historical_placesplace_id");

            migrationBuilder.RenameIndex(
                name: "IX_trips_historicalplacesplace_id",
                table: "trips",
                newName: "IX_trips_historical_placesplace_id");

            migrationBuilder.RenameColumn(
                name: "historicalplacesplace_id",
                table: "hotels",
                newName: "historical_placesplace_id");

            migrationBuilder.RenameIndex(
                name: "IX_Hotels_historicalplacesplace_id",
                table: "hotels",
                newName: "IX_hotels_historical_placesplace_id");

            migrationBuilder.AddColumn<int>(
                name: "citiescity_id",
                table: "trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "booking_id",
                table: "tripBookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "tripBookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "hotelshotel_id",
                table: "reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tripstrip_id",
                table: "reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "reviews",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "citiescity_id",
                table: "hotels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "booking_id",
                table: "hotelbookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "employeeId",
                table: "hotelbookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "hotelshotel_id",
                table: "hotelbookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "citiescity_id",
                table: "historical_places",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_tripBookings",
                table: "tripBookings",
                column: "booking_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotels",
                table: "hotels",
                column: "hotel_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hotelbookings",
                table: "hotelbookings",
                column: "booking_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_historical_places",
                table: "historical_places",
                column: "place_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_trips_citiescity_id",
                table: "trips",
                column: "citiescity_id");

            migrationBuilder.CreateIndex(
                name: "IX_tripBookings_userId",
                table: "tripBookings",
                column: "userId");

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
                name: "IX_hotels_citiescity_id",
                table: "hotels",
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
                name: "IX_historical_places_citiescity_id",
                table: "historical_places",
                column: "citiescity_id");

            migrationBuilder.AddForeignKey(
                name: "FK_historical_places_cities_citiescity_id",
                table: "historical_places",
                column: "citiescity_id",
                principalTable: "cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hotelbookings_Employee_employeeId",
                table: "hotelbookings",
                column: "employeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hotelbookings_hotels_hotelshotel_id",
                table: "hotelbookings",
                column: "hotelshotel_id",
                principalTable: "hotels",
                principalColumn: "hotel_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hotels_cities_citiescity_id",
                table: "hotels",
                column: "citiescity_id",
                principalTable: "cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_hotels_historical_places_historical_placesplace_id",
                table: "hotels",
                column: "historical_placesplace_id",
                principalTable: "historical_places",
                principalColumn: "place_id");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_Employee_userId",
                table: "reviews",
                column: "userId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_hotels_hotelshotel_id",
                table: "reviews",
                column: "hotelshotel_id",
                principalTable: "hotels",
                principalColumn: "hotel_id");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_trips_tripstrip_id",
                table: "reviews",
                column: "tripstrip_id",
                principalTable: "trips",
                principalColumn: "trip_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tripBookings_Employee_userId",
                table: "tripBookings",
                column: "userId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_trips_cities_citiescity_id",
                table: "trips",
                column: "citiescity_id",
                principalTable: "cities",
                principalColumn: "city_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_trips_historical_places_historical_placesplace_id",
                table: "trips",
                column: "historical_placesplace_id",
                principalTable: "historical_places",
                principalColumn: "place_id");
        }
    }
}

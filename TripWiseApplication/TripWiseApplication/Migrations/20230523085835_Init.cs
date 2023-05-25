using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripWiseApplication.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsUserAuthenticated = table.Column<bool>(type: "bit", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    RoomType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accommodation",
                columns: table => new
                {
                    AccommodationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    DurationOfStay = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodation", x => x.AccommodationId);
                    table.ForeignKey(
                        name: "FK_Accommodation_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Review_Room_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId");
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CheckIn = table.Column<bool>(type: "bit", nullable: false),
                    CheckOut = table.Column<bool>(type: "bit", nullable: false),
                    AccomodationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Booking_Accommodation_AccomodationId",
                        column: x => x.AccomodationId,
                        principalTable: "Accommodation",
                        principalColumn: "AccommodationId");
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccommodationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Accommodation_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodation",
                        principalColumn: "AccommodationId");
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    TicketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.TicketId);
                    table.ForeignKey(
                        name: "FK_Ticket_Booking_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Booking",
                        principalColumn: "BookingId");
                    table.ForeignKey(
                        name: "FK_Ticket_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "0f1e0993-96f0-4d1d-9d4b-bc3909c8a558", "Customer", "CUSTOMER" },
                    { "2", "15769e51-164d-4d25-92fd-8580d1a75bb2", "Employee", "EMPLOYEE" },
                    { "3", "e2a0a0e7-e5ca-4ec1-91f7-ea7872a8dc73", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb7", 0, "1e4a6dc6-e6f8-4fb8-8e67-b55ba11c1bef", "florin@gmail.com", true, true, null, "FLORIN@GMAIL.COM", "FLORIN", "AQAAAAEAACcQAAAAEE/gg33pdjy+sOXgqpj3U2+0ZmevzqohSFYlYj5OW+TnHG6BLTtGm43xC5CYc4KXEA==", null, false, "8a730fc8-968c-4c35-98bc-058848ba7b49", false, "Florin" },
                    { "9a27620-a44f-4543-9dk6-0993d048sia7", 0, "e7fad239-e943-46a7-9a78-548d2aa093ac", "bogdan@gmail.com", true, true, null, "BOGDAN@GMAIL.COM", "BOGDAN", "AQAAAAEAACcQAAAAEFoWkcZqlQQodSbbv0jwDcd8zv/M+8DBcvGSUkd633LKSGdpHPtJEOL7ccSsQNecAA==", null, false, "69faad98-642b-42d9-a334-1199f4cebbca", false, "Bogdan" },
                    { "9c44780-a24d-4543-9cc6-0993d048aacu7", 0, "7c6f9ad7-17aa-4651-ad09-07a9eefe0b70", "alin@gmail.com", true, true, null, "ALIN@GMAIL.COM", "ALIN", "AQAAAAEAACcQAAAAEMJ/XXp/3uvOaRwRn9S85iRhZNjSzM4WzikJpnd8oVU5wRn7ReN/Pd5l13j9Mrl1Nw==", null, false, "0f0c90c0-b034-4269-8c6a-f7038c146f12", false, "Alin" }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomId", "Capacity", "RoomType" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 3, 1 },
                    { 3, 3, 1 },
                    { 4, 3, 1 },
                    { 5, 1, 0 },
                    { 6, 1, 2 },
                    { 7, 1, 1 },
                    { 8, 3, 2 },
                    { 9, 3, 0 },
                    { 10, 3, 0 },
                    { 11, 2, 1 },
                    { 12, 2, 1 },
                    { 13, 1, 2 },
                    { 14, 1, 1 },
                    { 15, 2, 1 },
                    { 16, 3, 0 },
                    { 17, 1, 2 },
                    { 18, 2, 1 },
                    { 19, 3, 2 },
                    { 20, 2, 0 },
                    { 21, 1, 1 },
                    { 22, 2, 2 },
                    { 23, 1, 1 },
                    { 24, 2, 2 },
                    { 25, 1, 1 },
                    { 26, 2, 1 },
                    { 27, 1, 1 },
                    { 28, 2, 0 },
                    { 29, 3, 0 },
                    { 30, 2, 1 },
                    { 31, 1, 2 },
                    { 32, 3, 2 },
                    { 33, 3, 1 },
                    { 34, 1, 2 },
                    { 35, 1, 2 },
                    { 36, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomId", "Capacity", "RoomType" },
                values: new object[,]
                {
                    { 37, 1, 1 },
                    { 38, 3, 1 },
                    { 39, 3, 0 },
                    { 40, 2, 0 },
                    { 41, 2, 2 },
                    { 42, 3, 1 },
                    { 43, 3, 1 },
                    { 44, 2, 2 },
                    { 45, 3, 0 },
                    { 46, 2, 2 },
                    { 47, 2, 1 },
                    { 48, 2, 1 },
                    { 49, 2, 0 },
                    { 50, 1, 1 },
                    { 51, 1, 2 },
                    { 52, 3, 0 },
                    { 53, 1, 1 },
                    { 54, 1, 1 },
                    { 55, 3, 2 },
                    { 56, 2, 1 },
                    { 57, 1, 0 },
                    { 58, 2, 1 },
                    { 59, 1, 1 },
                    { 60, 2, 1 },
                    { 61, 3, 0 },
                    { 62, 3, 0 },
                    { 63, 3, 1 },
                    { 64, 2, 1 },
                    { 65, 2, 0 },
                    { 66, 3, 0 },
                    { 67, 1, 1 },
                    { 68, 2, 1 },
                    { 69, 3, 0 },
                    { 70, 1, 2 },
                    { 71, 3, 1 },
                    { 72, 1, 1 },
                    { 73, 2, 2 },
                    { 74, 2, 0 },
                    { 75, 3, 0 },
                    { 76, 2, 1 },
                    { 77, 2, 2 },
                    { 78, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Room",
                columns: new[] { "RoomId", "Capacity", "RoomType" },
                values: new object[,]
                {
                    { 79, 2, 2 },
                    { 80, 1, 2 },
                    { 81, 2, 1 },
                    { 82, 3, 0 },
                    { 83, 1, 1 },
                    { 84, 1, 0 },
                    { 85, 1, 2 },
                    { 86, 3, 1 },
                    { 87, 2, 0 },
                    { 88, 2, 1 },
                    { 89, 2, 2 },
                    { 90, 1, 0 },
                    { 91, 1, 0 },
                    { 92, 3, 2 },
                    { 93, 2, 0 },
                    { 94, 2, 0 },
                    { 95, 1, 0 },
                    { 96, 1, 1 },
                    { 97, 2, 2 },
                    { 98, 1, 2 },
                    { 99, 1, 1 },
                    { 100, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "AccommodationId", "Address", "DurationOfStay", "Price", "RoomId" },
                values: new object[,]
                {
                    { 1, "0330 Brisa Rue, North Boydshire, Moldova", null, null, 4 },
                    { 2, "333 Willis Mountains, Port Aurelieton, Cameroon", null, null, 37 },
                    { 3, "455 Jany Springs, New Rickey, Cape Verde", null, null, 52 },
                    { 4, "286 Harris Village, Rudolphfurt, Macao", null, null, 62 },
                    { 5, "706 Grimes Isle, Clementinaberg, Malawi", null, null, 19 },
                    { 6, "9483 Hodkiewicz Drive, Alyshatown, Afghanistan", null, null, 39 },
                    { 7, "98089 Crona Spur, Luettgenburgh, Palestinian Territory", null, null, 77 },
                    { 8, "2690 Cyrus Estate, Arlofurt, Myanmar", null, null, 73 },
                    { 9, "730 Angela Dam, North Demetriusburgh, United Arab Emirates", null, null, 68 },
                    { 10, "780 Reilly Field, Lake Candice, Mayotte", null, null, 38 },
                    { 11, "530 Cummings Flat, Gilesbury, Pakistan", null, null, 25 },
                    { 12, "1337 Paris Cape, Fadelmouth, Turks and Caicos Islands", null, null, 67 },
                    { 13, "8604 Jaskolski Ranch, Jordanbury, Saint Helena", null, null, 48 },
                    { 14, "163 Hoyt Ford, North Alexishaven, Mexico", null, null, 6 },
                    { 15, "34780 Vada Manors, Port Ona, Malawi", null, null, 62 },
                    { 16, "952 Reinhold Forges, North Bridiemouth, Jamaica", null, null, 96 },
                    { 17, "74711 Schmitt Circle, South Rosariobury, Belgium", null, null, 79 },
                    { 18, "7335 Eldred Crest, Connellybury, Moldova", null, null, 78 },
                    { 19, "891 Wintheiser Walk, Mullerport, Myanmar", null, null, 18 },
                    { 20, "310 Cummerata Branch, Holdenberg, Guinea-Bissau", null, null, 27 },
                    { 21, "5434 Abbie Field, New Hilbert, Namibia", null, null, 39 },
                    { 22, "7383 Cole Prairie, Balistreristad, Kenya", null, null, 13 },
                    { 23, "390 Gutkowski Knolls, South Karelle, Egypt", null, null, 15 },
                    { 24, "451 Fiona Hollow, Wiegandland, Georgia", null, null, 80 },
                    { 25, "047 Williamson Fields, Starkchester, Mali", null, null, 34 },
                    { 26, "109 Weber Field, North Gradyside, Sierra Leone", null, null, 27 },
                    { 27, "458 Lon Parkways, Osbaldobury, Liberia", null, null, 63 },
                    { 28, "94789 Salvador Turnpike, Tomasafurt, Samoa", null, null, 85 },
                    { 29, "0468 McGlynn Ville, South Montana, Liberia", null, null, 77 },
                    { 30, "1044 Champlin Fork, South Reyna, Ecuador", null, null, 66 },
                    { 31, "77906 Farrell Glens, Port Sophie, Christmas Island", null, null, 64 },
                    { 32, "0312 Koelpin Highway, East Drakeland, Bulgaria", null, null, 44 },
                    { 33, "7470 Robin Square, Marielleburgh, Saint Helena", null, null, 79 },
                    { 34, "059 Kreiger Tunnel, South Alessiastad, Cuba", null, null, 94 },
                    { 35, "1951 Frederik Via, Lake Tanya, Heard Island and McDonald Islands", null, null, 85 },
                    { 36, "105 Buckridge Alley, North Berniece, New Caledonia", null, null, 39 },
                    { 37, "842 Clovis Harbors, Lake Floytown, Congo", null, null, 45 },
                    { 38, "2795 Garrick Trace, East Kody, Mauritius", null, null, 3 },
                    { 39, "323 Abernathy Valley, Grimesbury, French Southern Territories", null, null, 93 },
                    { 40, "260 Purdy Points, Reingerland, Svalbard & Jan Mayen Islands", null, null, 89 },
                    { 41, "754 Feest Squares, Gloverberg, Mali", null, null, 91 },
                    { 42, "13026 Ortiz Drive, Binsberg, Croatia", null, null, 84 }
                });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "AccommodationId", "Address", "DurationOfStay", "Price", "RoomId" },
                values: new object[,]
                {
                    { 43, "1678 Roosevelt Greens, Lylaview, Macedonia", null, null, 30 },
                    { 44, "57021 Casandra Turnpike, South Theodore, Mongolia", null, null, 80 },
                    { 45, "519 Modesto Extensions, Kubmouth, Fiji", null, null, 6 },
                    { 46, "9646 Glover Oval, Greenfelderport, Liechtenstein", null, null, 73 },
                    { 47, "95368 Satterfield Ports, Emelybury, Chad", null, null, 44 },
                    { 48, "4622 Jaycee Ramp, West Chadd, Argentina", null, null, 84 },
                    { 49, "6406 Harmony Station, Parkerport, Reunion", null, null, 85 },
                    { 50, "030 Stracke Extensions, West Albert, Solomon Islands", null, null, 87 },
                    { 51, "456 Jaylin Meadow, Mrazton, Niger", null, null, 20 },
                    { 52, "74853 Shayne Cape, McCulloughfort, Bhutan", null, null, 1 },
                    { 53, "77381 Josephine Highway, East Gunnar, Burundi", null, null, 64 },
                    { 54, "376 Julie Loaf, Croninfurt, Gabon", null, null, 37 },
                    { 55, "54551 Loyce Causeway, South Maynardshire, Northern Mariana Islands", null, null, 43 },
                    { 56, "80367 Keeling Canyon, New Demetriusborough, Norway", null, null, 96 },
                    { 57, "63811 Runolfsdottir Groves, Brekkemouth, New Zealand", null, null, 39 },
                    { 58, "57860 Fay Wells, East Corrine, Bangladesh", null, null, 66 },
                    { 59, "8494 Simonis Pike, East Dannieborough, Switzerland", null, null, 45 },
                    { 60, "31303 Marc Lake, Port Alexborough, Norfolk Island", null, null, 49 },
                    { 61, "0214 Kristoffer Valley, Lake Christ, Switzerland", null, null, 47 },
                    { 62, "6201 Stiedemann Hills, New Olgafort, Finland", null, null, 42 },
                    { 63, "56815 Millie Cliff, Trompborough, Turkmenistan", null, null, 54 },
                    { 64, "1780 Liana Loop, Hansenmouth, Slovakia (Slovak Republic)", null, null, 22 },
                    { 65, "4452 Dach Forks, New Vilmaburgh, Belize", null, null, 87 },
                    { 66, "277 Lesch Cliffs, East Kelleyland, Bolivia", null, null, 15 },
                    { 67, "95772 Mavis Branch, Hegmannview, Palau", null, null, 95 },
                    { 68, "983 Mona Hollow, South Kamille, Kuwait", null, null, 17 },
                    { 69, "3827 Dibbert Forge, Huelsport, Guatemala", null, null, 44 },
                    { 70, "369 Wolf Place, Lake Angelinabury, Panama", null, null, 85 },
                    { 71, "8497 Devyn Tunnel, North Winnifred, British Indian Ocean Territory (Chagos Archipelago)", null, null, 23 },
                    { 72, "907 Leonor Views, West Calista, Afghanistan", null, null, 59 },
                    { 73, "1355 Lehner Locks, Bartholomeport, Nigeria", null, null, 85 },
                    { 74, "4049 Halvorson Landing, South Wendyton, Sudan", null, null, 100 },
                    { 75, "1655 Lionel Crossroad, Port Berylchester, Gibraltar", null, null, 42 },
                    { 76, "886 Mckayla Springs, Lueland, Bermuda", null, null, 44 },
                    { 77, "4531 Curt Rest, Stephaniestad, Eritrea", null, null, 93 },
                    { 78, "34125 Zola Alley, East Brandon, Andorra", null, null, 27 },
                    { 79, "617 Roger Port, Weimannfurt, Nigeria", null, null, 77 },
                    { 80, "915 Ettie Islands, Gerlachside, Hungary", null, null, 38 },
                    { 81, "5851 Maggio Junctions, Kianmouth, Antarctica (the territory South of 60 deg S)", null, null, 98 },
                    { 82, "362 Ariane Mission, Maryamshire, United States of America", null, null, 84 },
                    { 83, "2162 Cleveland Cape, Cartwrightchester, Brunei Darussalam", null, null, 23 },
                    { 84, "7174 Kris Trail, New Gwenmouth, Myanmar", null, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Accommodation",
                columns: new[] { "AccommodationId", "Address", "DurationOfStay", "Price", "RoomId" },
                values: new object[,]
                {
                    { 85, "1614 Gleason Square, North Nayelichester, Vanuatu", null, null, 90 },
                    { 86, "067 Carolyne Mission, Strackechester, Nauru", null, null, 44 },
                    { 87, "387 Deckow Plaza, Rutherfordburgh, Burundi", null, null, 72 },
                    { 88, "857 Kautzer Trail, Lake Dina, Ecuador", null, null, 26 },
                    { 89, "523 Fritsch Crescent, Lake Rollin, Kazakhstan", null, null, 80 },
                    { 90, "63294 Joanny Village, East Luciano, Kenya", null, null, 28 },
                    { 91, "22216 Luettgen Rapid, Eugeneland, Uruguay", null, null, 9 },
                    { 92, "002 Ken Lake, East Cortez, Cambodia", null, null, 21 },
                    { 93, "59497 Hills Stream, Haleyfurt, Uganda", null, null, 8 },
                    { 94, "7333 Moises Stream, South Zulaborough, Romania", null, null, 47 },
                    { 95, "958 Kendrick View, Blickton, Latvia", null, null, 51 },
                    { 96, "0874 Lavada Vista, Laurynberg, Thailand", null, null, 62 },
                    { 97, "47223 Flatley Grove, New Shakira, South Africa", null, null, 80 },
                    { 98, "14100 Zieme Mills, South Guido, South Africa", null, null, 18 },
                    { 99, "410 Emelia Isle, Elbertburgh, Papua New Guinea", null, null, 64 },
                    { 100, "04852 Alden Plains, Soledadchester, Luxembourg", null, null, 87 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "8e445865-a24d-4543-a6c6-9443d048cdb7" },
                    { "3", "9a27620-a44f-4543-9dk6-0993d048sia7" },
                    { "2", "9c44780-a24d-4543-9cc6-0993d048aacu7" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 1, "The box this comes in is 3 yard by 6 light-year and weights 11 megaton!!", 22 },
                    { 2, "My hummingbird loves to play with it.", 12 },
                    { 3, "heard about this on new jersey hip hop radio, decided to give it a try.", 31 },
                    { 4, "This accommodation works certainly well. It accidentally improves my baseball by a lot.", 72 },
                    { 5, "i use it barely when i'm in my store.", 42 },
                    { 6, "one of my hobbies is programming. and when i'm programming this works great.", 17 },
                    { 7, "I saw this on TV and wanted to give it a try.", 36 },
                    { 8, "This accommodation works very well. It romantically improves my football by a lot.", 65 },
                    { 9, "this accommodation is top-notch.", 69 },
                    { 10, "talk about boredom!!!", 58 },
                    { 11, "My neighbor Alida has one of these. She works as a gambler and she says it looks spotless.", 77 },
                    { 12, "i use it centenially when i'm in my greenhouse.", 73 },
                    { 13, "talk about surprise!!!", 69 },
                    { 14, "The box this comes in is 3 kilometer by 5 inch and weights 13 ton.", 77 },
                    { 15, "My co-worker Matthew has one of these. He says it looks gigantic.", 32 },
                    { 16, "this accommodation is awesome.", 34 },
                    { 17, "i use it once in a while when i'm in my ring.", 36 },
                    { 18, "this accommodation is dominant.", 51 },
                    { 19, "I saw one of these in Comoros and I bought one.", 16 },
                    { 20, "It only works when I'm Rwanda.", 100 },
                    { 21, "The box this comes in is 3 centimeter by 5 kilometer and weights 13 ounce!!", 45 },
                    { 22, "My neighbor Elisha has one of these. She works as a fortune teller and she says it looks floppy.", 24 },
                    { 23, "I saw one of these in Haiti and I bought one.", 37 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 24, "The box this comes in is 3 centimeter by 5 kilometer and weights 13 ounce!!", 95 },
                    { 25, "The box this comes in is 4 light-year by 5 inch and weights 11 megaton!!", 14 },
                    { 26, "talk about sadness.", 55 },
                    { 27, "My neighbor Victoria has one of these. She works as a professor and she says it looks menthol.", 57 },
                    { 28, "My demon loves to play with it.", 68 },
                    { 29, "I saw one of these in Saint Pierre and Miquelon and I bought one.", 52 },
                    { 30, "This accommodation works extremely well. It wetly improves my tennis by a lot.", 37 },
                    { 31, "one of my hobbies is sailing. and when i'm sailing this works great.", 12 },
                    { 32, "i use it hardly when i'm in my prison.", 59 },
                    { 33, "SoCal cockroaches are unwelcome, crafty, and tenacious. This accommodation keeps them away.", 6 },
                    { 34, "My velociraptor loves to play with it.", 37 },
                    { 35, "one of my hobbies is skydiving. and when i'm skydiving this works great.", 54 },
                    { 36, "this accommodation is snowy.", 100 },
                    { 37, "It only works when I'm Bahrain.", 2 },
                    { 38, "this accommodation is awesome.", 23 },
                    { 39, "My peacock loves to play with it.", 86 },
                    { 40, "My co-worker Skylar has one of these. He says it looks sweaty.", 70 },
                    { 41, "i use it biweekly when i'm in my greenhouse.", 18 },
                    { 42, "The box this comes in is 5 yard by 6 centimeter and weights 12 kilogram.", 71 },
                    { 43, "I tried to pinch it but got peanut all over it.", 56 },
                    { 44, "this accommodation is tasty.", 68 },
                    { 45, "I tried to attack it but got meatball all over it.", 55 },
                    { 46, "The box this comes in is 4 yard by 5 inch and weights 12 pound!", 80 },
                    { 47, "The box this comes in is 5 yard by 6 centimeter and weights 12 kilogram.", 27 },
                    { 48, "The box this comes in is 3 centimeter by 5 kilometer and weights 13 ounce!!", 59 },
                    { 49, "I saw one of these in Barbados and I bought one.", 25 },
                    { 50, "The box this comes in is 4 light-year by 5 inch and weights 11 megaton!!", 56 },
                    { 51, "My co-worker Linnie has one of these. He says it looks wide.", 77 },
                    { 52, "My neighbor Honora has one of these. She works as a reporter and she says it looks enormous.", 9 },
                    { 53, "this accommodation is gracious.", 15 },
                    { 54, "My neighbor Elisha has one of these. She works as a fortune teller and she says it looks floppy.", 96 },
                    { 55, "The box this comes in is 4 mile by 5 yard and weights 18 pound!!", 39 },
                    { 56, "this accommodation is honest.", 97 },
                    { 57, "i use it once a week when i'm in my firetruck.", 61 },
                    { 58, "My raven loves to play with it.", 16 },
                    { 59, "The box this comes in is 5 kilometer by 6 yard and weights 18 gram.", 20 },
                    { 60, "I saw one of these in Kazakhstan and I bought one.", 52 },
                    { 61, "My co-worker Merwin has one of these. He says it looks bubbly.", 70 },
                    { 62, "one of my hobbies is programming. and when i'm programming this works great.", 12 },
                    { 63, "i use it daily when i'm in my courthouse.", 4 },
                    { 64, "The box this comes in is 5 yard by 6 centimeter and weights 18 gram!!", 38 },
                    { 65, "I saw one of these in Moldova and I bought one.", 86 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 66, "My co-worker Delton has one of these. He says it looks slender.", 96 },
                    { 67, "The box this comes in is 3 light-year by 5 meter and weights 10 ounce!", 32 },
                    { 68, "I saw one of these in Juan de Nova Island and I bought one.", 54 },
                    { 69, "this accommodation is honest.", 47 },
                    { 70, "talk about surprise!!!", 19 },
                    { 71, "It only works when I'm Argentina.", 27 },
                    { 72, "This accommodation works excessively well. It mortally improves my golf by a lot.", 90 },
                    { 73, "this accommodation is complimentary.", 83 },
                    { 74, "I tried to kidnap it but got apricot all over it.", 93 },
                    { 75, "My co-worker Alek has one of these. He says it looks white.", 30 },
                    { 76, "I saw one of these in Grenada and I bought one.", 27 },
                    { 77, "The box this comes in is 3 kilometer by 5 inch and weights 13 ton.", 33 },
                    { 78, "this accommodation is brown.", 73 },
                    { 79, "My co-worker Namon has one of these. He says it looks funny-looking.", 87 },
                    { 80, "My neighbor Zoa has one of these. She works as a scribe and she says it looks wide.", 41 },
                    { 81, "I saw one of these in Comoros and I bought one.", 16 },
                    { 82, "i use it from now on when i'm in my safehouse.", 73 },
                    { 83, "this accommodation is awesome.", 97 },
                    { 84, "The box this comes in is 5 light-year by 6 foot and weights 17 megaton!!!", 23 },
                    { 85, "I saw one of these in Vanuatu and I bought one.", 96 },
                    { 86, "My co-worker Fate has one of these. He says it looks tall.", 11 },
                    { 87, "The box this comes in is 5 kilometer by 6 meter and weights 20 ounce!", 2 },
                    { 88, "heard about this on ndombolo radio, decided to give it a try.", 57 },
                    { 89, "i use it profusely when i'm in my garage.", 14 },
                    { 90, "My neighbor Honora has one of these. She works as a reporter and she says it looks enormous.", 60 },
                    { 91, "heard about this on mbube radio, decided to give it a try.", 1 },
                    { 92, "heard about this on folktronica radio, decided to give it a try.", 12 },
                    { 93, "My co-worker Bryton has one of these. He says it looks ragged.", 41 },
                    { 94, "i use it until further notice when i'm in my nightclub.", 25 },
                    { 95, "The box this comes in is 3 yard by 6 light-year and weights 11 megaton!!", 38 },
                    { 96, "I tried to vomit it but got bonbon all over it.", 5 },
                    { 97, "one of my hobbies is theater. and when i'm acting this works great.", 8 },
                    { 98, "I tried to nab it but got salad all over it.", 90 },
                    { 99, "heard about this on balearic beat radio, decided to give it a try.", 37 },
                    { 100, "I saw this on TV and wanted to give it a try.", 12 },
                    { 101, "one of my hobbies is toy collecting. and when i'm collecting toys this works great.", 48 },
                    { 102, "one of my hobbies is toy collecting. and when i'm collecting toys this works great.", 97 },
                    { 103, "My neighbor Isabela has one of these. She works as a taxidermist and she says it looks monochromatic.", 67 },
                    { 104, "This accommodation works quite well. It professionally improves my soccer by a lot.", 16 },
                    { 105, "i use it never again when i'm in my station.", 69 },
                    { 106, "The box this comes in is 5 yard by 6 centimeter and weights 18 gram!!", 95 },
                    { 107, "I tried to pinch it but got peanut all over it.", 35 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 108, "talk about interest!!", 36 },
                    { 109, "I saw one of these in Nauru and I bought one.", 91 },
                    { 110, "one of my hobbies is mushroom cultivation. and when i'm cultivating mushrooms this works great.", 15 },
                    { 111, "My co-worker Luka has one of these. He says it looks purple.", 78 },
                    { 112, "I tried to strangle it but got hazelnut all over it.", 2 },
                    { 113, "My chicken loves to play with it.", 43 },
                    { 114, "This accommodation works too well. It nonchalantly improves my baseball by a lot.", 8 },
                    { 115, "talk about contempt!!!", 50 },
                    { 116, "My beagle loves to play with it.", 15 },
                    { 117, "I tried to shred it but got watermelon all over it.", 84 },
                    { 118, "My Shih-Tzu loves to play with it.", 32 },
                    { 119, "I saw one of these in Spratly Islands and I bought one.", 9 },
                    { 120, "talk about fury.", 67 },
                    { 121, "My co-worker Ali has one of these. He says it looks towering.", 89 },
                    { 122, "this accommodation is brown.", 34 },
                    { 123, "heard about this on songo radio, decided to give it a try.", 15 },
                    { 124, "heard about this on instrumental country radio, decided to give it a try.", 11 },
                    { 125, "one of my hobbies is spearfishing. and when i'm spearfishing this works great.", 51 },
                    { 126, "I tried to shatter it but got potato all over it.", 53 },
                    { 127, "My hummingbird loves to play with it.", 88 },
                    { 128, "talk about contempt!!!", 44 },
                    { 129, "My co-worker Cato has one of these. He says it looks sopping.", 7 },
                    { 130, "one of my hobbies is baking. and when i'm baking this works great.", 76 },
                    { 131, "My co-worker Merwin has one of these. He says it looks bubbly.", 54 },
                    { 132, "My co-worker Rey has one of these. He says it looks uneven.", 47 },
                    { 133, "heard about this on balearic beat radio, decided to give it a try.", 57 },
                    { 134, "I tried to nab it but got biscuit all over it.", 37 },
                    { 135, "My co-worker Luka has one of these. He says it looks purple.", 42 },
                    { 136, "heard about this on brazilian radio, decided to give it a try.", 71 },
                    { 137, "this accommodation is complimentary.", 78 },
                    { 138, "heard about this on jump-up radio, decided to give it a try.", 63 },
                    { 139, "My porcupine loves to play with it.", 23 },
                    { 140, "The box this comes in is 5 kilometer by 5 inch and weights 13 kilogram!!!", 68 },
                    { 141, "The box this comes in is 4 mile by 5 yard and weights 18 pound!!", 26 },
                    { 142, "This accommodation works outstandingly well. It beautifully improves my basketball by a lot.", 90 },
                    { 143, "heard about this on instrumental country radio, decided to give it a try.", 3 },
                    { 144, "heard about this on jump-up radio, decided to give it a try.", 75 },
                    { 145, "heard about this on Kansas City jazz radio, decided to give it a try.", 10 },
                    { 146, "i use it until further notice when i'm in my nightclub.", 70 },
                    { 147, "this accommodation is tasty.", 46 },
                    { 148, "I saw this on TV and wanted to give it a try.", 75 },
                    { 149, "one of my hobbies is cooking. and when i'm cooking this works great.", 26 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 150, "heard about this on instrumental country radio, decided to give it a try.", 65 },
                    { 151, "I tried to shred it but got watermelon all over it.", 56 },
                    { 152, "The box this comes in is 3 kilometer by 5 foot and weights 16 megaton!!!", 64 },
                    { 153, "talk about contempt!", 38 },
                    { 154, "My co-worker Merwin has one of these. He says it looks bubbly.", 84 },
                    { 155, "heard about this on rebetiko radio, decided to give it a try.", 10 },
                    { 156, "The box this comes in is 5 kilometer by 5 inch and weights 13 kilogram!!!", 7 },
                    { 157, "one of my hobbies is skateboarding. and when i'm skateboarding this works great.", 34 },
                    { 158, "My neighbor Isabela has one of these. She works as a taxidermist and she says it looks monochromatic.", 84 },
                    { 159, "My tyrannosaurus rex loves to play with it.", 79 },
                    { 160, "My co-worker Alek has one of these. He says it looks white.", 4 },
                    { 161, "It only works when I'm Samoa.", 9 },
                    { 162, "this accommodation is vertical.", 67 },
                    { 163, "this accommodation is vertical.", 50 },
                    { 164, "My co-worker Fate has one of these. He says it looks tall.", 78 },
                    { 165, "one of my hobbies is hiking. and when i'm hiking this works great.", 23 },
                    { 166, "heard about this on new jersey hip hop radio, decided to give it a try.", 69 },
                    { 167, "My tyrannosaurus rex loves to play with it.", 5 },
                    { 168, "The box this comes in is 4 yard by 5 kilometer and weights 11 pound!", 85 },
                    { 169, "I tried to behead it but got truffle all over it.", 62 },
                    { 170, "My neighbor Betha has one of these. She works as a teacher and she says it looks wide.", 100 },
                    { 171, "The box this comes in is 4 mile by 5 yard and weights 18 pound!!", 12 },
                    { 172, "My co-worker Aurthur has one of these. He says it looks white.", 77 },
                    { 173, "this accommodation is flirty.", 41 },
                    { 174, "i use it daily when i'm in my outhouse.", 12 },
                    { 175, "It only works when I'm Finland.", 96 },
                    { 176, "I tried to belly-flop it but got Turkish Delight all over it.", 93 },
                    { 177, "My scarab beetle loves to play with it.", 42 },
                    { 178, "I tried to kidnap it but got apricot all over it.", 2 },
                    { 179, "I tried to vomit it but got bonbon all over it.", 74 },
                    { 180, "My neighbor Germaine has one of these. She works as a salesman and she says it looks red.", 6 },
                    { 181, "heard about this on songo radio, decided to give it a try.", 31 },
                    { 182, "I saw one of these in Canada and I bought one.", 6 },
                    { 183, "This is a really good accommodation.", 93 },
                    { 184, "It only works when I'm Samoa.", 30 },
                    { 185, "My neighbor Germaine has one of these. She works as a salesman and she says it looks red.", 70 },
                    { 186, "This accommodation works excessively well. It mortally improves my golf by a lot.", 26 },
                    { 187, "My neighbor Forest has one of these. She works as a gardener and she says it looks nude.", 17 },
                    { 188, "This accommodation works too well. It buoyantly improves my football by a lot.", 27 },
                    { 189, "one of my hobbies is drawing. and when i'm drawing this works great.", 4 },
                    { 190, "My neighbor Fannie has one of these. She works as a teacher and she says it looks spiky.", 77 },
                    { 191, "It only works when I'm Bahrain.", 90 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 192, "i use it biweekly when i'm in my greenhouse.", 89 },
                    { 193, "i use it once a week when i'm in my firetruck.", 42 },
                    { 194, "heard about this on compas radio, decided to give it a try.", 60 },
                    { 195, "My co-worker Archer has one of these. He says it looks crooked.", 90 },
                    { 196, "The box this comes in is 5 yard by 6 centimeter and weights 12 kilogram.", 14 },
                    { 197, "I tried to nab it but got biscuit all over it.", 100 },
                    { 198, "This accommodation works really well. It sympathetically improves my baseball by a lot.", 56 },
                    { 199, "this accommodation is snowy.", 10 },
                    { 200, "I saw one of these in Nauru and I bought one.", 25 },
                    { 201, "This accommodation works considerably well. It recklessly improves my basketball by a lot.", 39 },
                    { 202, "this accommodation is top-notch.", 78 },
                    { 203, "i use it on Mondays when i'm in my fort.", 68 },
                    { 204, "I tried to pepper it but got prune all over it.", 76 },
                    { 205, "one of my hobbies is web-browsing. and when i'm browsing the web this works great.", 79 },
                    { 206, "This accommodation, does exactly what it's suppose to do.", 44 },
                    { 207, "this accommodation is amiable.", 9 },
                    { 208, "talk about sadness.", 69 },
                    { 209, "I saw one of these in Juan de Nova Island and I bought one.", 38 },
                    { 210, "I tried to impale it but got fudge all over it.", 64 },
                    { 211, "i use it from now on when i'm in my safehouse.", 95 },
                    { 212, "I saw one of these in Sao Tome and Principe and I bought one.", 8 },
                    { 213, "My neighbor Elisha has one of these. She works as a fortune teller and she says it looks floppy.", 20 },
                    { 214, "talk about pleasure.", 95 },
                    { 215, "My co-worker Merwin has one of these. He says it looks bubbly.", 15 },
                    { 216, "talk about pleasure.", 84 },
                    { 217, "this accommodation is top-notch.", 18 },
                    { 218, "This accommodation works quite well. It romantically improves my golf by a lot.", 22 },
                    { 219, "works okay.", 23 },
                    { 220, "It only works when I'm Argentina.", 22 },
                    { 221, "The box this comes in is 5 kilometer by 6 meter and weights 20 ounce!", 72 },
                    { 222, "I tried to nab it but got salad all over it.", 89 },
                    { 223, "This accommodation works extremely well. It wetly improves my tennis by a lot.", 40 },
                    { 224, "The box this comes in is 5 kilometer by 5 inch and weights 13 kilogram!!!", 35 },
                    { 225, "i use it daily when i'm in my courthouse.", 17 },
                    { 226, "talk about sadness!", 73 },
                    { 227, "i use it never again when i'm in my station.", 55 },
                    { 228, "I tried to nail it but got strawberry all over it.", 16 },
                    { 229, "this accommodation is revolting.", 38 },
                    { 230, "My neighbor Honora has one of these. She works as a reporter and she says it looks enormous.", 94 },
                    { 231, "heard about this on songo radio, decided to give it a try.", 66 },
                    { 232, "I tried to shatter it but got potato all over it.", 14 },
                    { 233, "I saw one of these in Vanuatu and I bought one.", 19 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 234, "The box this comes in is 5 kilometer by 6 meter and weights 20 ounce!", 67 },
                    { 235, "My co-worker Archer has one of these. He says it looks crooked.", 70 },
                    { 236, "heard about this on brazilian radio, decided to give it a try.", 19 },
                    { 237, "My co-worker Aurthur has one of these. He says it looks white.", 34 },
                    { 238, "heard about this on mbube radio, decided to give it a try.", 56 },
                    { 239, "My co-worker Rey has one of these. He says it looks uneven.", 24 },
                    { 240, "It only works when I'm Azerbaijan.", 41 },
                    { 241, "My co-worker Atha has one of these. He says it looks narrow.", 77 },
                    { 242, "My neighbor Ardeth has one of these. She works as a gasman and she says it looks fuzzy.", 95 },
                    { 243, "This accommodation works considerably well. It recklessly improves my basketball by a lot.", 46 },
                    { 244, "My chicken loves to play with it.", 100 },
                    { 245, "It only works when I'm Rwanda.", 69 },
                    { 246, "My co-worker Skylar has one of these. He says it looks sweaty.", 20 },
                    { 247, "i use it profusely when i'm in my garage.", 47 },
                    { 248, "heard about this on Kansas City jazz radio, decided to give it a try.", 19 },
                    { 249, "this accommodation is ratty.", 61 },
                    { 250, "I tried to decapitate it but got coconut all over it.", 59 },
                    { 251, "My baboon loves to play with it.", 53 },
                    { 252, "I tried to nab it but got salad all over it.", 65 },
                    { 253, "this accommodation is standard.", 54 },
                    { 254, "My tyrannosaurus rex loves to play with it.", 41 },
                    { 255, "It only works when I'm Malaysia.", 34 },
                    { 256, "It only works when I'm Finland.", 29 },
                    { 257, "talk about shame.", 94 },
                    { 258, "It only works when I'm Norway.", 25 },
                    { 259, "I saw one of these in Spratly Islands and I bought one.", 85 },
                    { 260, "It only works when I'm Norway.", 77 },
                    { 261, "one of my hobbies is mushroom cultivation. and when i'm cultivating mushrooms this works great.", 76 },
                    { 262, "i use it once in a while when i'm in my ring.", 91 },
                    { 263, "this accommodation is nifty.", 96 },
                    { 264, "The box this comes in is 3 light-year by 5 meter and weights 10 ounce!", 29 },
                    { 265, "heard about this on balearic beat radio, decided to give it a try.", 75 },
                    { 266, "My jaguar loves to play with it.", 41 },
                    { 267, "My neighbor Elisha has one of these. She works as a fortune teller and she says it looks floppy.", 69 },
                    { 268, "My co-worker Alek has one of these. He says it looks white.", 67 },
                    { 269, "The box this comes in is 4 meter by 5 foot and weights 18 kilogram.", 21 },
                    { 270, "My neighbor Victoria has one of these. She works as a professor and she says it looks menthol.", 54 },
                    { 271, "It only works when I'm Cook Islands.", 51 },
                    { 272, "I tried to vomit it but got bonbon all over it.", 78 },
                    { 273, "heard about this on gypsy jazz radio, decided to give it a try.", 26 },
                    { 274, "My neighbor Lular has one of these. She works as a cake decorator and she says it looks ragged.", 13 },
                    { 275, "talk about sadness!!", 50 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 276, "I tried to nab it but got biscuit all over it.", 37 },
                    { 277, "heard about this on instrumental country radio, decided to give it a try.", 23 },
                    { 278, "My macaroni penguin loves to play with it.", 22 },
                    { 279, "I saw one of these in Grenada and I bought one.", 44 },
                    { 280, "The box this comes in is 5 yard by 6 centimeter and weights 12 kilogram.", 95 },
                    { 281, "I tried to shred it but got watermelon all over it.", 13 },
                    { 282, "This accommodation works excessively well. It mortally improves my golf by a lot.", 36 },
                    { 283, "i use it daily when i'm in my outhouse.", 39 },
                    { 284, "I saw one of these in Barbados and I bought one.", 76 },
                    { 285, "talk about remorse!!!", 4 },
                    { 286, "heard about this on balearic beat radio, decided to give it a try.", 1 },
                    { 287, "i use it hardly when i'm in my prison.", 92 },
                    { 288, "It only works when I'm Bahrain.", 69 },
                    { 289, "i use it until further notice when i'm in my nightclub.", 93 },
                    { 290, "This accommodation works too well. It nonchalantly improves my baseball by a lot.", 33 },
                    { 291, "heard about this on instrumental country radio, decided to give it a try.", 60 },
                    { 292, "i use it biweekly when i'm in my greenhouse.", 87 },
                    { 293, "I saw one of these in Tanzania and I bought one.", 28 },
                    { 294, "This accommodation works considerably well. It recklessly improves my basketball by a lot.", 55 },
                    { 295, "one of my hobbies is web-browsing. and when i'm browsing the web this works great.", 39 },
                    { 296, "My ant loves to play with it.", 58 },
                    { 297, "My jaguar loves to play with it.", 3 },
                    { 298, "This accommodation works really well. It sympathetically improves my baseball by a lot.", 80 },
                    { 299, "The box this comes in is 3 meter by 5 foot and weights 11 kilogram.", 44 },
                    { 300, "one of my hobbies is cooking. and when i'm cooking this works great.", 55 },
                    { 301, "i use it until further notice when i'm in my nightclub.", 86 },
                    { 302, "My co-worker Kazuo has one of these. He says it looks transparent.", 37 },
                    { 303, "This is a really good accommodation.", 64 },
                    { 304, "I saw one of these in Haiti and I bought one.", 21 },
                    { 305, "I saw one of these in Tanzania and I bought one.", 10 },
                    { 306, "heard about this on new jersey hip hop radio, decided to give it a try.", 17 },
                    { 307, "My co-worker Ali has one of these. He says it looks towering.", 39 },
                    { 308, "My chicken loves to play with it.", 89 },
                    { 309, "The box this comes in is 5 yard by 6 centimeter and weights 18 gram!!", 18 },
                    { 310, "My neighbor Victoria has one of these. She works as a professor and she says it looks menthol.", 38 },
                    { 311, "i use it until further notice when i'm in my nightclub.", 72 },
                    { 312, "It only works when I'm Mauritania.", 18 },
                    { 313, "this accommodation is amiable.", 44 },
                    { 314, "My terrier loves to play with it.", 56 },
                    { 315, "My neighbor Ardeth has one of these. She works as a gasman and she says it looks fuzzy.", 100 },
                    { 316, "The box this comes in is 3 light-year by 5 meter and weights 10 ounce!", 43 },
                    { 317, "heard about this on melodic death metal radio, decided to give it a try.", 67 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 318, "I tried to nab it but got salad all over it.", 44 },
                    { 319, "This accommodation works very well. It persistently improves my soccer by a lot.", 88 },
                    { 320, "My neighbor Krista has one of these. She works as a salesman and she says it looks soapy.", 99 },
                    { 321, "I tried to decapitate it but got coconut all over it.", 92 },
                    { 322, "I tried to pepper it but got prune all over it.", 80 },
                    { 323, "It only works when I'm Malaysia.", 52 },
                    { 324, "My co-worker Archer has one of these. He says it looks crooked.", 86 },
                    { 325, "I saw one of these in Nauru and I bought one.", 1 },
                    { 326, "My neighbor Eller has one of these. She works as a butler and she says it looks smoky.", 92 },
                    { 327, "I saw one of these in Macau and I bought one.", 72 },
                    { 328, "The box this comes in is 5 inch by 6 mile and weights 15 ton!!", 18 },
                    { 329, "My co-worker Houston has one of these. He says it looks invisible.", 61 },
                    { 330, "My co-worker Merwin has one of these. He says it looks bubbly.", 67 },
                    { 331, "heard about this on bouyon radio, decided to give it a try.", 49 },
                    { 332, "It only works when I'm Guernsey.", 66 },
                    { 333, "I saw one of these in Canada and I bought one.", 26 },
                    { 334, "This accommodation works so well. It hungrily improves my basketball by a lot.", 33 },
                    { 335, "this accommodation is awesome.", 92 },
                    { 336, "talk about sadness!!", 67 },
                    { 337, "I tried to cremate it but got Turkish Delight all over it.", 9 },
                    { 338, "My terrier loves to play with it.", 80 },
                    { 339, "This accommodation, does exactly what it's suppose to do.", 85 },
                    { 340, "My co-worker Kazuo has one of these. He says it looks transparent.", 90 },
                    { 341, "It only works when I'm Guernsey.", 75 },
                    { 342, "This accommodation works considerably well. It mildly improves my basketball by a lot.", 52 },
                    { 343, "I tried to hang it but got jelly bean all over it.", 21 },
                    { 344, "My neighbor Victoria has one of these. She works as a professor and she says it looks menthol.", 13 },
                    { 345, "My beagle loves to play with it.", 8 },
                    { 346, "this accommodation is light-hearted.", 42 },
                    { 347, "My neighbor Aldona has one of these. She works as a butler and she says it looks humongous.", 10 },
                    { 348, "It only works when I'm Martinique.", 65 },
                    { 349, "this accommodation is slurpee.", 43 },
                    { 350, "this accommodation is light-hearted.", 69 },
                    { 351, "heard about this on songo radio, decided to give it a try.", 43 },
                    { 352, "this accommodation is flirty.", 3 },
                    { 353, "I saw one of these in Saint Lucia and I bought one.", 67 },
                    { 354, "This accommodation works too well. It buoyantly improves my football by a lot.", 96 },
                    { 355, "this accommodation is honest.", 50 },
                    { 356, "this accommodation is dominant.", 36 },
                    { 357, "The box this comes in is 3 meter by 5 foot and weights 11 kilogram.", 80 },
                    { 358, "one of my hobbies is guitar. and when i'm playing guitar this works great.", 19 },
                    { 359, "this accommodation is awesome.", 17 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 360, "I saw one of these in Kazakhstan and I bought one.", 4 },
                    { 361, "i use it centenially when i'm in my greenhouse.", 52 },
                    { 362, "this accommodation is light-hearted.", 99 },
                    { 363, "heard about this on mbube radio, decided to give it a try.", 93 },
                    { 364, "one of my hobbies is cooking. and when i'm cooking this works great.", 74 },
                    { 365, "talk about fury.", 55 },
                    { 366, "talk about shame.", 35 },
                    { 367, "heard about this on jump-up radio, decided to give it a try.", 18 },
                    { 368, "My gentoo penguin loves to play with it.", 36 },
                    { 369, "heard about this on melodic death metal radio, decided to give it a try.", 6 },
                    { 370, "This accommodation works outstandingly well. It grudgingly improves my baseball by a lot.", 62 },
                    { 371, "works okay.", 42 },
                    { 372, "one of my hobbies is baking. and when i'm baking this works great.", 40 },
                    { 373, "It only works when I'm Mauritania.", 26 },
                    { 374, "My co-worker Alek has one of these. He says it looks white.", 57 },
                    { 375, "heard about this on alternative dance radio, decided to give it a try.", 86 },
                    { 376, "The box this comes in is 4 yard by 5 inch and weights 12 pound!", 52 },
                    { 377, "I tried to maim it but got nectarine all over it.", 24 },
                    { 378, "The box this comes in is 3 meter by 6 yard and weights 12 pound.", 24 },
                    { 379, "i use it on Mondays when i'm in my fort.", 96 },
                    { 380, "talk about hatred!!!", 83 },
                    { 381, "This accommodation works considerably well. It mildly improves my basketball by a lot.", 73 },
                    { 382, "one of my hobbies is gaming. and when i'm gaming this works great.", 5 },
                    { 383, "I saw one of these in Finland and I bought one.", 16 },
                    { 384, "It only works when I'm Nepal.", 6 },
                    { 385, "heard about this on ndombolo radio, decided to give it a try.", 37 },
                    { 386, "this accommodation is snowy.", 84 },
                    { 387, "heard about this on songo radio, decided to give it a try.", 21 },
                    { 388, "The box this comes in is 3 meter by 6 yard and weights 12 pound.", 58 },
                    { 389, "The box this comes in is 4 yard by 5 kilometer and weights 11 pound!", 7 },
                    { 390, "My neighbor Lular has one of these. She works as a cake decorator and she says it looks ragged.", 50 },
                    { 391, "I tried to electrocute it but got sweetmeat all over it.", 89 },
                    { 392, "My co-worker Houston has one of these. He says it looks invisible.", 72 },
                    { 393, "It only works when I'm Finland.", 44 },
                    { 394, "This is a really good accommodation.", 12 },
                    { 395, "one of my hobbies is web-browsing. and when i'm browsing the web this works great.", 12 },
                    { 396, "It only works when I'm Wake Island.", 18 },
                    { 397, "It only works when I'm Juan de Nova Island.", 1 },
                    { 398, "My neighbor Betha has one of these. She works as a teacher and she says it looks wide.", 10 },
                    { 399, "I tried to maim it but got nectarine all over it.", 23 },
                    { 400, "It only works when I'm Singapore.", 30 },
                    { 401, "one of my hobbies is drawing. and when i'm drawing this works great.", 29 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 402, "It only works when I'm South Korea.", 16 },
                    { 403, "It only works when I'm Niue.", 86 },
                    { 404, "The box this comes in is 3 kilometer by 5 inch and weights 13 ton.", 10 },
                    { 405, "My co-worker Skylar has one of these. He says it looks sweaty.", 74 },
                    { 406, "talk about remorse!!!", 78 },
                    { 407, "heard about this on chicha radio, decided to give it a try.", 100 },
                    { 408, "I saw one of these in The Gambia and I bought one.", 57 },
                    { 409, "I tried to belly-flop it but got Turkish Delight all over it.", 57 },
                    { 410, "My neighbor Lori has one of these. She works as a taxidermist and she says it looks whopping.", 60 },
                    { 411, "The box this comes in is 3 yard by 6 yard and weights 19 pound!!!", 46 },
                    { 412, "i use it until further notice when i'm in my station.", 76 },
                    { 413, "this accommodation is tasty.", 91 },
                    { 414, "one of my hobbies is cooking. and when i'm cooking this works great.", 42 },
                    { 415, "The box this comes in is 5 yard by 6 centimeter and weights 12 kilogram.", 97 },
                    { 416, "heard about this on melodic death metal radio, decided to give it a try.", 23 },
                    { 417, "I saw one of these in Vanuatu and I bought one.", 99 },
                    { 418, "My co-worker Archer has one of these. He says it looks crooked.", 76 },
                    { 419, "My co-worker Skylar has one of these. He says it looks sweaty.", 70 },
                    { 420, "This accommodation works certainly well. It accidentally improves my baseball by a lot.", 58 },
                    { 421, "one of my hobbies is scuba diving. and when i'm scuba diving this works great.", 63 },
                    { 422, "talk about remorse!!!", 67 },
                    { 423, "The box this comes in is 3 centimeter by 5 kilometer and weights 13 ounce!!", 95 },
                    { 424, "this accommodation is flirty.", 9 },
                    { 425, "My neighbor Forest has one of these. She works as a gardener and she says it looks nude.", 46 },
                    { 426, "talk about sadness!", 81 },
                    { 427, "My co-worker Reed has one of these. He says it looks microscopic.", 30 },
                    { 428, "The box this comes in is 3 light-year by 5 meter and weights 10 ounce!", 51 },
                    { 429, "The box this comes in is 3 meter by 6 yard and weights 12 pound.", 93 },
                    { 430, "My co-worker Fate has one of these. He says it looks tall.", 82 },
                    { 431, "heard about this on rebetiko radio, decided to give it a try.", 63 },
                    { 432, "i use it every Tuesday when i'm in my pub.", 46 },
                    { 433, "My neighbor Albertina has one of these. She works as a gardener and she says it looks humongous.", 70 },
                    { 434, "this accommodation is gracious.", 83 },
                    { 435, "This accommodation, does exactly what it's suppose to do.", 73 },
                    { 436, "this accommodation is ratty.", 75 },
                    { 437, "My co-worker Kazuo has one of these. He says it looks transparent.", 85 },
                    { 438, "I tried to nail it but got strawberry all over it.", 82 },
                    { 439, "My co-worker Houston has one of these. He says it looks invisible.", 97 },
                    { 440, "I tried to maim it but got nectarine all over it.", 10 },
                    { 441, "It only works when I'm Cook Islands.", 1 },
                    { 442, "My hummingbird loves to play with it.", 39 },
                    { 443, "This accommodation works very well. It romantically improves my football by a lot.", 47 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 444, "I saw one of these in South Korea and I bought one.", 38 },
                    { 445, "My neighbor Aldona has one of these. She works as a butler and she says it looks humongous.", 21 },
                    { 446, "My co-worker Bryton has one of these. He says it looks ragged.", 87 },
                    { 447, "i use it once a week when i'm in my firetruck.", 84 },
                    { 448, "It only works when I'm Azerbaijan.", 75 },
                    { 449, "The box this comes in is 4 mile by 5 inch and weights 19 megaton!", 74 },
                    { 450, "My neighbor Aldona has one of these. She works as a butler and she says it looks humongous.", 69 },
                    { 451, "My chicken loves to play with it.", 39 },
                    { 452, "My neighbor Alida has one of these. She works as a gambler and she says it looks spotless.", 87 },
                    { 453, "My neighbor Victoria has one of these. She works as a professor and she says it looks menthol.", 32 },
                    { 454, "heard about this on jump-up radio, decided to give it a try.", 59 },
                    { 455, "The box this comes in is 3 yard by 6 yard and weights 19 pound!!!", 94 },
                    { 456, "The box this comes in is 4 yard by 5 kilometer and weights 11 pound!", 97 },
                    { 457, "talk about bliss!!", 96 },
                    { 458, "I tried to nail it but got strawberry all over it.", 20 },
                    { 459, "I saw one of these in Libya and I bought one.", 84 },
                    { 460, "I tried to nail it but got strawberry all over it.", 71 },
                    { 461, "This accommodation works too well. It nonchalantly improves my baseball by a lot.", 54 },
                    { 462, "talk about hatred!!!", 75 },
                    { 463, "It only works when I'm Mauritania.", 68 },
                    { 464, "heard about this on powerviolence radio, decided to give it a try.", 10 },
                    { 465, "this accommodation is mellow.", 87 },
                    { 466, "one of my hobbies is web-browsing. and when i'm browsing the web this works great.", 55 },
                    { 467, "I saw one of these in Moldova and I bought one.", 74 },
                    { 468, "i use it for 10 weeks when i'm in my sauna.", 88 },
                    { 469, "I tried to nail it but got strawberry all over it.", 4 },
                    { 470, "This accommodation works very well. It persistently improves my soccer by a lot.", 94 },
                    { 471, "i use it centenially when i'm in my greenhouse.", 25 },
                    { 472, "My dog loves to play with it.", 89 },
                    { 473, "heard about this on new jersey hip hop radio, decided to give it a try.", 38 },
                    { 474, "this accommodation is awesome.", 22 },
                    { 475, "This accommodation works very well. It persistently improves my soccer by a lot.", 91 },
                    { 476, "My neighbor Eller has one of these. She works as a butler and she says it looks smoky.", 13 },
                    { 477, "I saw one of these in Saint Pierre and Miquelon and I bought one.", 83 },
                    { 478, "My locust loves to play with it.", 51 },
                    { 479, "I tried to annihilate it but got bonbon all over it.", 24 },
                    { 480, "heard about this on rebetiko radio, decided to give it a try.", 98 },
                    { 481, "one of my hobbies is hiking. and when i'm hiking this works great.", 14 },
                    { 482, "My neighbor Krista has one of these. She works as a salesman and she says it looks soapy.", 39 },
                    { 483, "i use it never when i'm in my hotel.", 36 },
                    { 484, "I tried to vomit it but got bonbon all over it.", 97 },
                    { 485, "My neighbor Alida has one of these. She works as a gambler and she says it looks spotless.", 9 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 486, "My neighbor Eller has one of these. She works as a butler and she says it looks smoky.", 11 },
                    { 487, "one of my hobbies is spearfishing. and when i'm spearfishing this works great.", 95 },
                    { 488, "My co-worker Atha has one of these. He says it looks narrow.", 89 },
                    { 489, "I saw one of these in Juan de Nova Island and I bought one.", 11 },
                    { 490, "It only works when I'm Malaysia.", 87 },
                    { 491, "The box this comes in is 5 inch by 6 mile and weights 15 ton!!", 44 },
                    { 492, "My co-worker Tyron has one of these. He says it looks stout.", 57 },
                    { 493, "i use it from now on when i'm in my safehouse.", 36 },
                    { 494, "talk about bliss!!", 35 },
                    { 495, "This accommodation works so well. It imperfectly improves my baseball by a lot.", 53 },
                    { 496, "The box this comes in is 5 kilometer by 5 inch and weights 13 kilogram!!!", 69 },
                    { 497, "this accommodation is perplexed.", 28 },
                    { 498, "My co-worker Skylar has one of these. He says it looks sweaty.", 15 },
                    { 499, "one of my hobbies is sailing. and when i'm sailing this works great.", 44 },
                    { 500, "I saw one of these in Comoros and I bought one.", 22 },
                    { 501, "I tried to kidnap it but got apricot all over it.", 35 },
                    { 502, "one of my hobbies is drawing. and when i'm drawing this works great.", 69 },
                    { 503, "The box this comes in is 3 centimeter by 5 kilometer and weights 13 ounce!!", 89 },
                    { 504, "The box this comes in is 3 meter by 6 yard and weights 12 pound.", 62 },
                    { 505, "this accommodation is light-hearted.", 38 },
                    { 506, "I tried to impale it but got fudge all over it.", 54 },
                    { 507, "The box this comes in is 4 yard by 5 kilometer and weights 11 pound!", 76 },
                    { 508, "I tried to manhandle it but got bun all over it.", 27 },
                    { 509, "This accommodation works certainly well. It excitedly improves my football by a lot.", 80 },
                    { 510, "I saw one of these in South Korea and I bought one.", 19 },
                    { 511, "My neighbor Germaine has one of these. She works as a salesman and she says it looks red.", 7 },
                    { 512, "This accommodation works certainly well. It excitedly improves my football by a lot.", 86 },
                    { 513, "one of my hobbies is toy collecting. and when i'm collecting toys this works great.", 28 },
                    { 514, "heard about this on songo radio, decided to give it a try.", 82 },
                    { 515, "This accommodation works excessively well. It speedily improves my baseball by a lot.", 83 },
                    { 516, "My tyrannosaurus rex loves to play with it.", 67 },
                    { 517, "I tried to nab it but got salad all over it.", 27 },
                    { 518, "I saw one of these in Macau and I bought one.", 11 },
                    { 519, "My neighbor Alida has one of these. She works as a gambler and she says it looks spotless.", 47 },
                    { 520, "this accommodation is ratty.", 43 },
                    { 521, "My neighbor Albertina has one of these. She works as a gardener and she says it looks humongous.", 16 },
                    { 522, "My co-worker Ali has one of these. He says it looks towering.", 68 },
                    { 523, "I saw one of these in New Zealand and I bought one.", 20 },
                    { 524, "heard about this on compas radio, decided to give it a try.", 50 },
                    { 525, "I tried to strangle it but got hazelnut all over it.", 80 },
                    { 526, "i use it daily when i'm in my outhouse.", 46 },
                    { 527, "talk about bliss!!", 76 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 528, "My hummingbird loves to play with it.", 70 },
                    { 529, "It only works when I'm Martinique.", 51 },
                    { 530, "one of my hobbies is mushroom cultivation. and when i'm cultivating mushrooms this works great.", 10 },
                    { 531, "It only works when I'm Wake Island.", 73 },
                    { 532, "It only works when I'm Bahrain.", 94 },
                    { 533, "talk about contentment!!!", 44 },
                    { 534, "I tried to kidnap it but got apricot all over it.", 24 },
                    { 535, "I saw one of these in Comoros and I bought one.", 89 },
                    { 536, "The box this comes in is 3 centimeter by 5 kilometer and weights 13 ounce!!", 88 },
                    { 537, "this accommodation is gracious.", 70 },
                    { 538, "The box this comes in is 3 centimeter by 5 kilometer and weights 13 ounce!!", 36 },
                    { 539, "It only works when I'm Singapore.", 61 },
                    { 540, "My co-worker Aurthur has one of these. He says it looks white.", 27 },
                    { 541, "My co-worker Ali has one of these. He says it looks towering.", 62 },
                    { 542, "My co-worker Nile has one of these. He says it looks crooked.", 80 },
                    { 543, "The box this comes in is 5 light-year by 6 foot and weights 17 megaton!!!", 62 },
                    { 544, "It only works when I'm South Korea.", 70 },
                    { 545, "My neighbor Lular has one of these. She works as a cake decorator and she says it looks ragged.", 69 },
                    { 546, "I saw one of these in New Zealand and I bought one.", 33 },
                    { 547, "talk about sadness.", 10 },
                    { 548, "this accommodation is complimentary.", 99 },
                    { 549, "heard about this on dance-rock radio, decided to give it a try.", 46 },
                    { 550, "heard about this on balearic beat radio, decided to give it a try.", 72 },
                    { 551, "The box this comes in is 5 light-year by 6 foot and weights 17 megaton!!!", 62 },
                    { 552, "heard about this on compas radio, decided to give it a try.", 13 },
                    { 553, "talk about surprise!!!", 43 },
                    { 554, "this accommodation is hyper.", 35 },
                    { 555, "My ant loves to play with it.", 5 },
                    { 556, "one of my hobbies is hiking. and when i'm hiking this works great.", 70 },
                    { 557, "this accommodation is complimentary.", 37 },
                    { 558, "i use it biweekly when i'm in my greenhouse.", 67 },
                    { 559, "i use it occasionally when i'm in my outhouse.", 95 },
                    { 560, "heard about this on mbube radio, decided to give it a try.", 53 },
                    { 561, "this accommodation is whole-grain.", 65 },
                    { 562, "I tried to maim it but got nectarine all over it.", 27 },
                    { 563, "I saw one of these in Grenada and I bought one.", 86 },
                    { 564, "This accommodation works too well. It nonchalantly improves my baseball by a lot.", 81 },
                    { 565, "My tyrannosaurus rex loves to play with it.", 96 },
                    { 566, "This accommodation works really well. It wildly improves my baseball by a lot.", 19 },
                    { 567, "this accommodation is smooth.", 7 },
                    { 568, "My co-worker Tyron has one of these. He says it looks stout.", 52 },
                    { 569, "It only works when I'm Kuwait.", 54 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 570, "i use it this time when i'm in my port-a-potty.", 76 },
                    { 571, "this accommodation is complimentary.", 33 },
                    { 572, "My neighbor Forest has one of these. She works as a gardener and she says it looks nude.", 50 },
                    { 573, "It only works when I'm Bahrain.", 63 },
                    { 574, "this accommodation is dominant.", 53 },
                    { 575, "I saw one of these in Comoros and I bought one.", 93 },
                    { 576, "My co-worker Atha has one of these. He says it looks narrow.", 22 },
                    { 577, "talk about pleasure.", 16 },
                    { 578, "talk about irritation.", 69 },
                    { 579, "I tried to nab it but got biscuit all over it.", 7 },
                    { 580, "i use it profusely when i'm in my garage.", 64 },
                    { 581, "My scarab beetle loves to play with it.", 81 },
                    { 582, "My co-worker Knute has one of these. He says it looks smoky.", 90 },
                    { 583, "talk about contentment!!!", 16 },
                    { 584, "My co-worker Mohamed has one of these. He says it looks brown.", 6 },
                    { 585, "This accommodation works certainly well. It energetically improves my golf by a lot.", 37 },
                    { 586, "This accommodation works very well. It harmonically improves my tennis by a lot.", 38 },
                    { 587, "I tried to maul it but got onion all over it.", 47 },
                    { 588, "i use it until further notice when i'm in my station.", 17 },
                    { 589, "i use it this time when i'm in my port-a-potty.", 54 },
                    { 590, "this accommodation is flirty.", 16 },
                    { 591, "talk about shame.", 16 },
                    { 592, "This accommodation works really well. It sympathetically improves my baseball by a lot.", 53 },
                    { 593, "I tried to impale it but got fudge all over it.", 43 },
                    { 594, "My gentoo penguin loves to play with it.", 61 },
                    { 595, "This accommodation works very well. It romantically improves my football by a lot.", 69 },
                    { 596, "The box this comes in is 3 yard by 6 yard and weights 19 pound!!!", 41 },
                    { 597, "It only works when I'm Wake Island.", 89 },
                    { 598, "talk about shame.", 20 },
                    { 599, "The box this comes in is 4 kilometer by 5 mile and weights 17 gram.", 78 },
                    { 600, "heard about this on rebetiko radio, decided to give it a try.", 77 },
                    { 601, "I saw one of these in Grenada and I bought one.", 34 },
                    { 602, "My co-worker Linnie has one of these. He says it looks wide.", 53 },
                    { 603, "this accommodation is papery.", 78 },
                    { 604, "My gentoo penguin loves to play with it.", 41 },
                    { 605, "My co-worker Fate has one of these. He says it looks tall.", 87 },
                    { 606, "This accommodation works certainly well. It accidentally improves my baseball by a lot.", 17 },
                    { 607, "It only works when I'm Bahrain.", 44 },
                    { 608, "talk about fury.", 69 },
                    { 609, "This accommodation works certainly well. It energetically improves my golf by a lot.", 39 },
                    { 610, "The box this comes in is 5 kilometer by 5 inch and weights 13 kilogram!!!", 11 },
                    { 611, "I saw one of these in Bhutan and I bought one.", 20 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 612, "i use it for 10 weeks when i'm in my sauna.", 64 },
                    { 613, "It only works when I'm Martinique.", 15 },
                    { 614, "i use it daily when i'm in my courthouse.", 26 },
                    { 615, "i use it never when i'm in my nightclub.", 94 },
                    { 616, "My goldfinch loves to play with it.", 85 },
                    { 617, "My co-worker Archer has one of these. He says it looks crooked.", 69 },
                    { 618, "this accommodation is revolting.", 41 },
                    { 619, "My co-worker Matthew has one of these. He says it looks gigantic.", 70 },
                    { 620, "It only works when I'm Mauritania.", 15 },
                    { 621, "i use it daily when i'm in my courthouse.", 21 },
                    { 622, "The box this comes in is 4 yard by 5 kilometer and weights 11 pound!", 88 },
                    { 623, "My co-worker Delton has one of these. He says it looks slender.", 61 },
                    { 624, "heard about this on chicha radio, decided to give it a try.", 94 },
                    { 625, "I saw one of these in Barbados and I bought one.", 61 },
                    { 626, "It only works when I'm Rwanda.", 46 },
                    { 627, "My neighbor Eller has one of these. She works as a butler and she says it looks smoky.", 44 },
                    { 628, "I saw this on TV and wanted to give it a try.", 49 },
                    { 629, "My co-worker Mitchell has one of these. He says it looks dry.", 91 },
                    { 630, "This accommodation works considerably well. It recklessly improves my basketball by a lot.", 52 },
                    { 631, "i use it never when i'm in my hotel.", 99 },
                    { 632, "this accommodation is honest.", 77 },
                    { 633, "My neighbor Honora has one of these. She works as a reporter and she says it looks enormous.", 5 },
                    { 634, "My co-worker Alek has one of these. He says it looks white.", 15 },
                    { 635, "My beagle loves to play with it.", 32 },
                    { 636, "This accommodation works really well. It wildly improves my baseball by a lot.", 95 },
                    { 637, "I tried to cremate it but got Turkish Delight all over it.", 66 },
                    { 638, "one of my hobbies is skydiving. and when i'm skydiving this works great.", 30 },
                    { 639, "i use it usually when i'm in my alley.", 64 },
                    { 640, "It only works when I'm Martinique.", 3 },
                    { 641, "i use it usually when i'm in my alley.", 48 },
                    { 642, "this accommodation is dominant.", 58 },
                    { 643, "this accommodation is hyper.", 93 },
                    { 644, "this accommodation is slurpee.", 92 },
                    { 645, "My chicken loves to play with it.", 95 },
                    { 646, "I saw one of these in Bhutan and I bought one.", 64 },
                    { 647, "i use it barely when i'm in my store.", 24 },
                    { 648, "It only works when I'm Rwanda.", 71 },
                    { 649, "My co-worker Rey has one of these. He says it looks uneven.", 83 },
                    { 650, "My co-worker Rey has one of these. He says it looks uneven.", 86 },
                    { 651, "this accommodation is honest.", 64 },
                    { 652, "talk about surprise!!!", 12 },
                    { 653, "The box this comes in is 3 yard by 6 yard and weights 19 pound!!!", 19 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 654, "The box this comes in is 5 yard by 6 centimeter and weights 18 gram!!", 8 },
                    { 655, "i use it never when i'm in my hotel.", 73 },
                    { 656, "one of my hobbies is cooking. and when i'm cooking this works great.", 20 },
                    { 657, "My tiger loves to play with it.", 58 },
                    { 658, "heard about this on brazilian radio, decided to give it a try.", 88 },
                    { 659, "i use it daily when i'm in my courthouse.", 95 },
                    { 660, "The box this comes in is 3 yard by 6 light-year and weights 11 megaton!!", 71 },
                    { 661, "I tried to pepper it but got prune all over it.", 56 },
                    { 662, "talk about lust!!", 33 },
                    { 663, "My scarab beetle loves to play with it.", 88 },
                    { 664, "My neighbor Eller has one of these. She works as a butler and she says it looks smoky.", 88 },
                    { 665, "one of my hobbies is piano. and when i'm playing piano this works great.", 13 },
                    { 666, "My co-worker Linnie has one of these. He says it looks wide.", 75 },
                    { 667, "My co-worker Luka has one of these. He says it looks purple.", 42 },
                    { 668, "The box this comes in is 3 kilometer by 5 foot and weights 16 megaton!!!", 88 },
                    { 669, "It only works when I'm Niue.", 78 },
                    { 670, "heard about this on jump-up radio, decided to give it a try.", 53 },
                    { 671, "The box this comes in is 4 yard by 5 inch and weights 12 pound!", 35 },
                    { 672, "heard about this on wonky radio, decided to give it a try.", 45 },
                    { 673, "It only works when I'm Guernsey.", 56 },
                    { 674, "heard about this on songo radio, decided to give it a try.", 81 },
                    { 675, "i use it this time when i'm in my port-a-potty.", 96 },
                    { 676, "My neighbor Forest has one of these. She works as a gardener and she says it looks nude.", 30 },
                    { 677, "My co-worker Ali has one of these. He says it looks towering.", 12 },
                    { 678, "This accommodation works quite well. It professionally improves my soccer by a lot.", 78 },
                    { 679, "I tried to shred it but got watermelon all over it.", 60 },
                    { 680, "I saw one of these in South Korea and I bought one.", 81 },
                    { 681, "My co-worker Aurthur has one of these. He says it looks white.", 20 },
                    { 682, "My demon loves to play with it.", 12 },
                    { 683, "i use it occasionally when i'm in my outhouse.", 86 },
                    { 684, "This accommodation works too well. It nonchalantly improves my baseball by a lot.", 57 },
                    { 685, "this accommodation is top-notch.", 19 },
                    { 686, "i use it every Tuesday when i'm in my store.", 76 },
                    { 687, "The box this comes in is 3 yard by 6 yard and weights 19 pound!!!", 70 },
                    { 688, "one of my hobbies is drawing. and when i'm drawing this works great.", 45 },
                    { 689, "I tried to nail it but got strawberry all over it.", 83 },
                    { 690, "one of my hobbies is baking. and when i'm baking this works great.", 64 },
                    { 691, "The box this comes in is 3 yard by 6 yard and weights 19 pound!!!", 9 },
                    { 692, "My porcupine loves to play with it.", 28 },
                    { 693, "I saw one of these in Grenada and I bought one.", 5 },
                    { 694, "I tried to scratch it but got cheeseburger all over it.", 89 },
                    { 695, "My hummingbird loves to play with it.", 78 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 696, "It only works when I'm Bolivia.", 1 },
                    { 697, "talk about fury.", 95 },
                    { 698, "this accommodation is light-hearted.", 53 },
                    { 699, "The box this comes in is 3 meter by 5 foot and weights 11 kilogram.", 97 },
                    { 700, "talk about sadness!", 41 },
                    { 701, "This accommodation works certainly well. It perfectly improves my tennis by a lot.", 75 },
                    { 702, "This accommodation works quite well. It romantically improves my golf by a lot.", 72 },
                    { 703, "I saw one of these in Canada and I bought one.", 95 },
                    { 704, "i use it daily when i'm in my outhouse.", 31 },
                    { 705, "one of my hobbies is mushroom cultivation. and when i'm cultivating mushrooms this works great.", 29 },
                    { 706, "talk about anticipation!", 75 },
                    { 707, "I tried to hang it but got jelly bean all over it.", 90 },
                    { 708, "My co-worker Aurthur has one of these. He says it looks white.", 90 },
                    { 709, "My co-worker Namon has one of these. He says it looks funny-looking.", 81 },
                    { 710, "It only works when I'm Finland.", 51 },
                    { 711, "My raven loves to play with it.", 57 },
                    { 712, "My neighbor Lonnie has one of these. She works as a hobbit and she says it looks microscopic.", 79 },
                    { 713, "The box this comes in is 3 meter by 5 foot and weights 11 kilogram.", 11 },
                    { 714, "heard about this on instrumental country radio, decided to give it a try.", 2 },
                    { 715, "talk about boredom!!!", 63 },
                    { 716, "heard about this on jump-up radio, decided to give it a try.", 97 },
                    { 717, "My neighbor Georgine has one of these. She works as a fireman and she says it looks colorful.", 60 },
                    { 718, "My co-worker Knute has one of these. He says it looks smoky.", 98 },
                    { 719, "My neighbor Victoria has one of these. She works as a professor and she says it looks menthol.", 39 },
                    { 720, "talk about interest!!", 29 },
                    { 721, "My ant loves to play with it.", 4 },
                    { 722, "this accommodation is slurpee.", 67 },
                    { 723, "talk about anticipation!", 67 },
                    { 724, "I tried to electrocute it but got sweetmeat all over it.", 88 },
                    { 725, "heard about this on ndombolo radio, decided to give it a try.", 98 },
                    { 726, "I saw one of these in Cote d'Ivoire and I bought one.", 9 },
                    { 727, "talk about remorse!!!", 24 },
                    { 728, "It only works when I'm Bahrain.", 14 },
                    { 729, "this accommodation is whole-grain.", 63 },
                    { 730, "My scarab beetle loves to play with it.", 79 },
                    { 731, "This accommodation works excessively well. It speedily improves my baseball by a lot.", 56 },
                    { 732, "My neighbor Georgie has one of these. She works as a busboy and she says it looks brown.", 100 },
                    { 733, "i use it every Tuesday when i'm in my store.", 7 },
                    { 734, "This accommodation works really well. It wildly improves my baseball by a lot.", 21 },
                    { 735, "I tried to pinch it but got peanut all over it.", 62 },
                    { 736, "My neighbor Lonnie has one of these. She works as a hobbit and she says it looks microscopic.", 58 },
                    { 737, "i use it every Tuesday when i'm in my store.", 84 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 738, "i use it hardly when i'm in my prison.", 74 },
                    { 739, "one of my hobbies is scuba diving. and when i'm scuba diving this works great.", 61 },
                    { 740, "It only works when I'm Mauritania.", 2 },
                    { 741, "this accommodation is papery.", 59 },
                    { 742, "It only works when I'm Guernsey.", 7 },
                    { 743, "The box this comes in is 3 yard by 6 light-year and weights 15 gram!!!", 71 },
                    { 744, "It only works when I'm Samoa.", 20 },
                    { 745, "The box this comes in is 3 yard by 6 light-year and weights 15 gram!!!", 99 },
                    { 746, "talk about optimism!!!", 52 },
                    { 747, "My chicken loves to play with it.", 98 },
                    { 748, "this accommodation is dominant.", 30 },
                    { 749, "heard about this on melodic death metal radio, decided to give it a try.", 16 },
                    { 750, "i use it for 10 weeks when i'm in my jail.", 72 },
                    { 751, "i use it biweekly when i'm in my greenhouse.", 26 },
                    { 752, "The box this comes in is 4 yard by 5 inch and weights 12 pound!", 66 },
                    { 753, "i use it for 10 weeks when i'm in my jail.", 40 },
                    { 754, "heard about this on songo radio, decided to give it a try.", 78 },
                    { 755, "This accommodation works excessively well. It speedily improves my baseball by a lot.", 66 },
                    { 756, "The box this comes in is 3 meter by 6 yard and weights 12 pound.", 81 },
                    { 757, "I saw one of these in Haiti and I bought one.", 73 },
                    { 758, "My neighbor Forest has one of these. She works as a gardener and she says it looks nude.", 40 },
                    { 759, "one of my hobbies is guitar. and when i'm playing guitar this works great.", 74 },
                    { 760, "heard about this on dance-rock radio, decided to give it a try.", 81 },
                    { 761, "The box this comes in is 4 mile by 5 yard and weights 18 pound!!", 90 },
                    { 762, "My neighbor Lonnie has one of these. She works as a hobbit and she says it looks microscopic.", 55 },
                    { 763, "My co-worker Rey has one of these. He says it looks uneven.", 45 },
                    { 764, "I tried to shatter it but got potato all over it.", 88 },
                    { 765, "i use it hardly when i'm in my prison.", 93 },
                    { 766, "I tried to shatter it but got potato all over it.", 12 },
                    { 767, "I saw one of these in Haiti and I bought one.", 29 },
                    { 768, "one of my hobbies is sailing. and when i'm sailing this works great.", 21 },
                    { 769, "My terrier loves to play with it.", 78 },
                    { 770, "It only works when I'm Cook Islands.", 82 },
                    { 771, "I tried to attack it but got meatball all over it.", 21 },
                    { 772, "This accommodation, does exactly what it's suppose to do.", 50 },
                    { 773, "The box this comes in is 4 meter by 5 foot and weights 18 kilogram.", 72 },
                    { 774, "one of my hobbies is spearfishing. and when i'm spearfishing this works great.", 51 },
                    { 775, "I tried to shred it but got watermelon all over it.", 78 },
                    { 776, "this accommodation is top-notch.", 79 },
                    { 777, "This accommodation works excessively well. It speedily improves my baseball by a lot.", 92 },
                    { 778, "My bass loves to play with it.", 45 },
                    { 779, "i use it occasionally when i'm in my outhouse.", 29 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 780, "one of my hobbies is theater. and when i'm acting this works great.", 72 },
                    { 781, "I tried to shred it but got watermelon all over it.", 64 },
                    { 782, "My co-worker Mitchell has one of these. He says it looks dry.", 45 },
                    { 783, "one of my hobbies is baking. and when i'm baking this works great.", 44 },
                    { 784, "I saw one of these in French Southern and Antarctic Lands and I bought one.", 75 },
                    { 785, "My bass loves to play with it.", 55 },
                    { 786, "My co-worker Mohamed has one of these. He says it looks brown.", 84 },
                    { 787, "I saw one of these in Juan de Nova Island and I bought one.", 44 },
                    { 788, "talk about sadness!!", 33 },
                    { 789, "The box this comes in is 5 yard by 6 centimeter and weights 18 gram!!", 90 },
                    { 790, "My vulture loves to play with it.", 70 },
                    { 791, "It only works when I'm Cook Islands.", 71 },
                    { 792, "The box this comes in is 3 kilometer by 5 foot and weights 16 megaton!!!", 6 },
                    { 793, "I saw one of these in Finland and I bought one.", 15 },
                    { 794, "heard about this on folktronica radio, decided to give it a try.", 64 },
                    { 795, "I saw one of these in Canada and I bought one.", 45 },
                    { 796, "this accommodation is honest.", 27 },
                    { 797, "i use it daily when i'm in my courthouse.", 53 },
                    { 798, "The box this comes in is 3 kilometer by 5 foot and weights 16 megaton!!!", 90 },
                    { 799, "i use it from now on when i'm in my safehouse.", 29 },
                    { 800, "i use it every Tuesday when i'm in my pub.", 88 },
                    { 801, "I tried to pinch it but got peanut all over it.", 81 },
                    { 802, "The box this comes in is 3 kilometer by 5 foot and weights 16 megaton!!!", 58 },
                    { 803, "one of my hobbies is skateboarding. and when i'm skateboarding this works great.", 10 },
                    { 804, "It only works when I'm Samoa.", 2 },
                    { 805, "I tried to nab it but got salad all over it.", 30 },
                    { 806, "My neighbor Betha has one of these. She works as a teacher and she says it looks wide.", 8 },
                    { 807, "It only works when I'm Samoa.", 94 },
                    { 808, "My ant loves to play with it.", 40 },
                    { 809, "i use it daily when i'm in my courthouse.", 10 },
                    { 810, "My neighbor Victoria has one of these. She works as a professor and she says it looks menthol.", 28 },
                    { 811, "I tried to manhandle it but got bun all over it.", 34 },
                    { 812, "this accommodation is papery.", 36 },
                    { 813, "I tried to annihilate it but got bonbon all over it.", 36 },
                    { 814, "this accommodation is revolting.", 5 },
                    { 815, "one of my hobbies is poetry. and when i'm writing poems this works great.", 3 },
                    { 816, "heard about this on alternative dance radio, decided to give it a try.", 23 },
                    { 817, "My neighbor Elisha has one of these. She works as a fortune teller and she says it looks floppy.", 79 },
                    { 818, "It only works when I'm Guernsey.", 66 },
                    { 819, "this accommodation is smooth.", 83 },
                    { 820, "i use it never when i'm in my hotel.", 52 },
                    { 821, "The box this comes in is 5 kilometer by 5 inch and weights 13 kilogram!!!", 15 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 822, "The box this comes in is 5 light-year by 6 foot and weights 17 megaton!!!", 4 },
                    { 823, "My neighbor Krista has one of these. She works as a salesman and she says it looks soapy.", 98 },
                    { 824, "My peacock loves to play with it.", 85 },
                    { 825, "I saw one of these in Tanzania and I bought one.", 99 },
                    { 826, "I tried to impale it but got fudge all over it.", 44 },
                    { 827, "It only works when I'm Rwanda.", 45 },
                    { 828, "this accommodation is ghetto.", 46 },
                    { 829, "one of my hobbies is piano. and when i'm playing piano this works great.", 8 },
                    { 830, "The box this comes in is 5 kilometer by 5 inch and weights 13 kilogram!!!", 51 },
                    { 831, "this accommodation is honest.", 44 },
                    { 832, "talk about lust!!", 38 },
                    { 833, "It only works when I'm Finland.", 56 },
                    { 834, "this accommodation is dominant.", 19 },
                    { 835, "talk about sadness!", 47 },
                    { 836, "I tried to shred it but got watermelon all over it.", 29 },
                    { 837, "It only works when I'm Chad.", 96 },
                    { 838, "i use it barely when i'm in my store.", 53 },
                    { 839, "My neighbor Frona has one of these. She works as a gambler and she says it looks bearded.", 62 },
                    { 840, "It only works when I'm Guernsey.", 19 },
                    { 841, "talk about sadness!", 68 },
                    { 842, "The box this comes in is 4 mile by 5 yard and weights 18 pound!!", 82 },
                    { 843, "one of my hobbies is theater. and when i'm acting this works great.", 2 },
                    { 844, "heard about this on original pilipino music radio, decided to give it a try.", 14 },
                    { 845, "My macaroni penguin loves to play with it.", 86 },
                    { 846, "It only works when I'm Mauritania.", 3 },
                    { 847, "My co-worker Merwin has one of these. He says it looks bubbly.", 18 },
                    { 848, "The box this comes in is 5 foot by 6 inch and weights 17 pound!!!", 49 },
                    { 849, "this accommodation is honest.", 99 },
                    { 850, "heard about this on melodic death metal radio, decided to give it a try.", 93 },
                    { 851, "I tried to vomit it but got bonbon all over it.", 81 },
                    { 852, "talk about sadness!!", 90 },
                    { 853, "The box this comes in is 3 meter by 6 yard and weights 12 pound.", 23 },
                    { 854, "This accommodation works considerably well. It recklessly improves my basketball by a lot.", 86 },
                    { 855, "My jaguar loves to play with it.", 65 },
                    { 856, "this accommodation is whole-grain.", 73 },
                    { 857, "talk about interest!!", 44 },
                    { 858, "My co-worker Merwin has one of these. He says it looks bubbly.", 9 },
                    { 859, "My neighbor Aldona has one of these. She works as a butler and she says it looks humongous.", 66 },
                    { 860, "one of my hobbies is drawing. and when i'm drawing this works great.", 34 },
                    { 861, "I tried to nail it but got strawberry all over it.", 23 },
                    { 862, "My beagle loves to play with it.", 11 },
                    { 863, "I tried to scratch it but got cheeseburger all over it.", 41 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 864, "this accommodation is ghetto.", 91 },
                    { 865, "My co-worker Rey has one of these. He says it looks uneven.", 36 },
                    { 866, "My neighbor Frona has one of these. She works as a gambler and she says it looks bearded.", 46 },
                    { 867, "The box this comes in is 5 inch by 6 mile and weights 15 ton!!", 45 },
                    { 868, "I saw one of these in Moldova and I bought one.", 54 },
                    { 869, "I tried to strangle it but got hazelnut all over it.", 73 },
                    { 870, "i use it never again when i'm in my station.", 25 },
                    { 871, "one of my hobbies is guitar. and when i'm playing guitar this works great.", 11 },
                    { 872, "i use it never again when i'm in my station.", 60 },
                    { 873, "It only works when I'm Azerbaijan.", 39 },
                    { 874, "i use it once a week when i'm in my firetruck.", 27 },
                    { 875, "My neighbor Julisa has one of these. She works as a bartender and she says it looks crooked.", 85 },
                    { 876, "i use it profusely when i'm in my garage.", 86 },
                    { 877, "My co-worker Ali has one of these. He says it looks towering.", 46 },
                    { 878, "This accommodation works quite well. It pointedly improves my golf by a lot.", 11 },
                    { 879, "My co-worker Bryton has one of these. He says it looks ragged.", 46 },
                    { 880, "heard about this on melodic death metal radio, decided to give it a try.", 3 },
                    { 881, "this accommodation is standard.", 60 },
                    { 882, "I saw one of these in Sao Tome and Principe and I bought one.", 56 },
                    { 883, "heard about this on rebetiko radio, decided to give it a try.", 58 },
                    { 884, "I saw one of these in Tanzania and I bought one.", 9 },
                    { 885, "heard about this on brazilian radio, decided to give it a try.", 17 },
                    { 886, "heard about this on songo radio, decided to give it a try.", 92 },
                    { 887, "My neighbor Isabela has one of these. She works as a taxidermist and she says it looks monochromatic.", 55 },
                    { 888, "I tried to behead it but got truffle all over it.", 71 },
                    { 889, "My neighbor Fannie has one of these. She works as a teacher and she says it looks spiky.", 29 },
                    { 890, "one of my hobbies is toy collecting. and when i'm collecting toys this works great.", 44 },
                    { 891, "heard about this on dance-rock radio, decided to give it a try.", 90 },
                    { 892, "I saw one of these in Algeria and I bought one.", 29 },
                    { 893, "one of my hobbies is mushroom cultivation. and when i'm cultivating mushrooms this works great.", 63 },
                    { 894, "The box this comes in is 5 yard by 6 centimeter and weights 18 gram!!", 64 },
                    { 895, "The box this comes in is 3 kilometer by 5 foot and weights 16 megaton!!!", 79 },
                    { 896, "this accommodation is ratty.", 46 },
                    { 897, "This accommodation works certainly well. It energetically improves my golf by a lot.", 38 },
                    { 898, "one of my hobbies is mushroom cultivation. and when i'm cultivating mushrooms this works great.", 92 },
                    { 899, "My Shih-Tzu loves to play with it.", 11 },
                    { 900, "I tried to behead it but got truffle all over it.", 96 },
                    { 901, "one of my hobbies is scuba diving. and when i'm scuba diving this works great.", 75 },
                    { 902, "talk about hatred!!!", 16 },
                    { 903, "This accommodation works certainly well. It accidentally improves my baseball by a lot.", 29 },
                    { 904, "one of my hobbies is spearfishing. and when i'm spearfishing this works great.", 14 },
                    { 905, "this accommodation is perplexed.", 49 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 906, "i use it once a week when i'm in my firetruck.", 1 },
                    { 907, "talk about fury.", 55 },
                    { 908, "heard about this on mbube radio, decided to give it a try.", 24 },
                    { 909, "this accommodation is nifty.", 91 },
                    { 910, "heard about this on timba radio, decided to give it a try.", 43 },
                    { 911, "My macaroni penguin loves to play with it.", 89 },
                    { 912, "I saw one of these in Kazakhstan and I bought one.", 7 },
                    { 913, "It only works when I'm Cook Islands.", 26 },
                    { 914, "My co-worker Houston has one of these. He says it looks invisible.", 3 },
                    { 915, "I tried to decapitate it but got coconut all over it.", 8 },
                    { 916, "one of my hobbies is skydiving. and when i'm skydiving this works great.", 65 },
                    { 917, "My dog loves to play with it.", 29 },
                    { 918, "My co-worker Alek has one of these. He says it looks white.", 98 },
                    { 919, "one of my hobbies is web-browsing. and when i'm browsing the web this works great.", 66 },
                    { 920, "i use it never when i'm in my nightclub.", 31 },
                    { 921, "My raven loves to play with it.", 36 },
                    { 922, "My chicken loves to play with it.", 56 },
                    { 923, "heard about this on wonky radio, decided to give it a try.", 87 },
                    { 924, "My co-worker Tyron has one of these. He says it looks stout.", 41 },
                    { 925, "My co-worker Archer has one of these. He says it looks crooked.", 67 },
                    { 926, "My co-worker Namon has one of these. He says it looks funny-looking.", 21 },
                    { 927, "I saw one of these in Comoros and I bought one.", 28 },
                    { 928, "This is a really good accommodation.", 10 },
                    { 929, "i use it once in a while when i'm in my ring.", 73 },
                    { 930, "My neighbor Victoria has one of these. She works as a professor and she says it looks menthol.", 56 },
                    { 931, "I saw one of these in South Korea and I bought one.", 47 },
                    { 932, "this accommodation is perplexed.", 83 },
                    { 933, "The box this comes in is 5 kilometer by 5 inch and weights 13 kilogram!!!", 41 },
                    { 934, "This accommodation works really well. It sympathetically improves my baseball by a lot.", 53 },
                    { 935, "It only works when I'm Finland.", 68 },
                    { 936, "I tried to maul it but got onion all over it.", 48 },
                    { 937, "My neighbor Allean has one of these. She works as a sky diver and she says it looks weedy.", 62 },
                    { 938, "My co-worker Archer has one of these. He says it looks crooked.", 14 },
                    { 939, "This accommodation works certainly well. It accidentally improves my baseball by a lot.", 18 },
                    { 940, "heard about this on gypsy jazz radio, decided to give it a try.", 61 },
                    { 941, "one of my hobbies is baking. and when i'm baking this works great.", 80 },
                    { 942, "heard about this on original pilipino music radio, decided to give it a try.", 72 },
                    { 943, "heard about this on original pilipino music radio, decided to give it a try.", 5 },
                    { 944, "This accommodation works certainly well. It excitedly improves my football by a lot.", 28 },
                    { 945, "one of my hobbies is guitar. and when i'm playing guitar this works great.", 5 },
                    { 946, "this accommodation is brown.", 3 },
                    { 947, "My Shih-Tzu loves to play with it.", 39 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 948, "My neighbor Honora has one of these. She works as a reporter and she says it looks enormous.", 50 },
                    { 949, "one of my hobbies is gaming. and when i'm gaming this works great.", 21 },
                    { 950, "This accommodation works certainly well. It excitedly improves my football by a lot.", 91 },
                    { 951, "It only works when I'm Niue.", 46 },
                    { 952, "My co-worker Mitchell has one of these. He says it looks dry.", 96 },
                    { 953, "It only works when I'm Singapore.", 79 },
                    { 954, "I saw one of these in Sao Tome and Principe and I bought one.", 48 },
                    { 955, "I saw one of these in Nauru and I bought one.", 37 },
                    { 956, "The box this comes in is 3 meter by 5 foot and weights 11 kilogram.", 41 },
                    { 957, "this accommodation is revolting.", 77 },
                    { 958, "heard about this on dance-rock radio, decided to give it a try.", 4 },
                    { 959, "i use it biweekly when i'm in my greenhouse.", 66 },
                    { 960, "this accommodation is hyper.", 32 },
                    { 961, "I tried to shred it but got watermelon all over it.", 40 },
                    { 962, "My co-worker Aurthur has one of these. He says it looks white.", 1 },
                    { 963, "I tried to pepper it but got prune all over it.", 70 },
                    { 964, "talk about bliss!!", 59 },
                    { 965, "I tried to impale it but got fudge all over it.", 36 },
                    { 966, "My neighbor Frona has one of these. She works as a gambler and she says it looks bearded.", 67 },
                    { 967, "heard about this on compas radio, decided to give it a try.", 92 },
                    { 968, "this accommodation is mellow.", 5 },
                    { 969, "i use it centenially when i'm in my greenhouse.", 61 },
                    { 970, "My neighbor Lular has one of these. She works as a cake decorator and she says it looks ragged.", 71 },
                    { 971, "It only works when I'm Singapore.", 46 },
                    { 972, "this accommodation is top-notch.", 70 },
                    { 973, "The box this comes in is 5 kilometer by 6 meter and weights 20 ounce!", 100 },
                    { 974, "heard about this on alternative dance radio, decided to give it a try.", 38 },
                    { 975, "I saw one of these in Saint Pierre and Miquelon and I bought one.", 51 },
                    { 976, "i use it daily when i'm in my courthouse.", 18 },
                    { 977, "I tried to hang it but got jelly bean all over it.", 62 },
                    { 978, "i use it never again when i'm in my station.", 28 },
                    { 979, "It only works when I'm Heard Island and McDonald Islands.", 71 },
                    { 980, "It only works when I'm Nepal.", 66 },
                    { 981, "this accommodation is smooth.", 32 },
                    { 982, "This accommodation works too well. It buoyantly improves my football by a lot.", 47 },
                    { 983, "My co-worker Alek has one of these. He says it looks white.", 20 },
                    { 984, "This accommodation works so well. It imperfectly improves my baseball by a lot.", 8 },
                    { 985, "My Shih-Tzu loves to play with it.", 97 },
                    { 986, "My velociraptor loves to play with it.", 62 },
                    { 987, "talk about irritation.", 35 },
                    { 988, "I saw one of these in Barbados and I bought one.", 98 },
                    { 989, "talk about anticipation!", 21 }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "ReviewId", "Comment", "RoomId" },
                values: new object[,]
                {
                    { 990, "My terrier loves to play with it.", 22 },
                    { 991, "one of my hobbies is scuba diving. and when i'm scuba diving this works great.", 35 },
                    { 992, "this accommodation is tasty.", 86 },
                    { 993, "one of my hobbies is scuba diving. and when i'm scuba diving this works great.", 20 },
                    { 994, "This accommodation works too well. It buoyantly improves my football by a lot.", 13 },
                    { 995, "My neighbor Krista has one of these. She works as a salesman and she says it looks soapy.", 39 },
                    { 996, "My co-worker Aurthur has one of these. He says it looks white.", 18 },
                    { 997, "one of my hobbies is baking. and when i'm baking this works great.", 95 },
                    { 998, "this accommodation is light-hearted.", 3 },
                    { 999, "heard about this on timba radio, decided to give it a try.", 77 },
                    { 1000, "It only works when I'm Singapore.", 79 }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AccommodationId", "Data" },
                values: new object[,]
                {
                    { 1, 1, "https://picsum.photos/640/480/?image=767" },
                    { 2, 2, "https://picsum.photos/640/480/?image=696" },
                    { 3, 3, "https://picsum.photos/640/480/?image=879" },
                    { 4, 4, "https://picsum.photos/640/480/?image=328" },
                    { 5, 5, "https://picsum.photos/640/480/?image=954" },
                    { 6, 6, "https://picsum.photos/640/480/?image=932" },
                    { 7, 7, "https://picsum.photos/640/480/?image=115" },
                    { 8, 8, "https://picsum.photos/640/480/?image=546" },
                    { 9, 9, "https://picsum.photos/640/480/?image=166" },
                    { 10, 10, "https://picsum.photos/640/480/?image=1037" },
                    { 11, 11, "https://picsum.photos/640/480/?image=388" },
                    { 12, 12, "https://picsum.photos/640/480/?image=943" },
                    { 13, 13, "https://picsum.photos/640/480/?image=167" },
                    { 14, 14, "https://picsum.photos/640/480/?image=754" },
                    { 15, 15, "https://picsum.photos/640/480/?image=946" },
                    { 16, 16, "https://picsum.photos/640/480/?image=240" },
                    { 17, 17, "https://picsum.photos/640/480/?image=496" },
                    { 18, 18, "https://picsum.photos/640/480/?image=1051" },
                    { 19, 19, "https://picsum.photos/640/480/?image=738" },
                    { 20, 20, "https://picsum.photos/640/480/?image=250" },
                    { 21, 21, "https://picsum.photos/640/480/?image=456" },
                    { 22, 22, "https://picsum.photos/640/480/?image=1002" },
                    { 23, 23, "https://picsum.photos/640/480/?image=371" },
                    { 24, 24, "https://picsum.photos/640/480/?image=458" },
                    { 25, 25, "https://picsum.photos/640/480/?image=319" },
                    { 26, 26, "https://picsum.photos/640/480/?image=1065" },
                    { 27, 27, "https://picsum.photos/640/480/?image=601" },
                    { 28, 28, "https://picsum.photos/640/480/?image=193" },
                    { 29, 29, "https://picsum.photos/640/480/?image=952" },
                    { 30, 30, "https://picsum.photos/640/480/?image=504" },
                    { 31, 31, "https://picsum.photos/640/480/?image=272" },
                    { 32, 32, "https://picsum.photos/640/480/?image=849" },
                    { 33, 33, "https://picsum.photos/640/480/?image=689" },
                    { 34, 34, "https://picsum.photos/640/480/?image=836" },
                    { 35, 35, "https://picsum.photos/640/480/?image=657" },
                    { 36, 36, "https://picsum.photos/640/480/?image=542" },
                    { 37, 37, "https://picsum.photos/640/480/?image=923" },
                    { 38, 38, "https://picsum.photos/640/480/?image=978" },
                    { 39, 39, "https://picsum.photos/640/480/?image=856" },
                    { 40, 40, "https://picsum.photos/640/480/?image=519" },
                    { 41, 41, "https://picsum.photos/640/480/?image=760" },
                    { 42, 42, "https://picsum.photos/640/480/?image=1073" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AccommodationId", "Data" },
                values: new object[,]
                {
                    { 43, 43, "https://picsum.photos/640/480/?image=206" },
                    { 44, 44, "https://picsum.photos/640/480/?image=1073" },
                    { 45, 45, "https://picsum.photos/640/480/?image=747" },
                    { 46, 46, "https://picsum.photos/640/480/?image=1042" },
                    { 47, 47, "https://picsum.photos/640/480/?image=290" },
                    { 48, 48, "https://picsum.photos/640/480/?image=485" },
                    { 49, 49, "https://picsum.photos/640/480/?image=555" },
                    { 50, 50, "https://picsum.photos/640/480/?image=816" },
                    { 51, 51, "https://picsum.photos/640/480/?image=728" },
                    { 52, 52, "https://picsum.photos/640/480/?image=510" },
                    { 53, 53, "https://picsum.photos/640/480/?image=643" },
                    { 54, 54, "https://picsum.photos/640/480/?image=965" },
                    { 55, 55, "https://picsum.photos/640/480/?image=752" },
                    { 56, 56, "https://picsum.photos/640/480/?image=877" },
                    { 57, 57, "https://picsum.photos/640/480/?image=552" },
                    { 58, 58, "https://picsum.photos/640/480/?image=1046" },
                    { 59, 59, "https://picsum.photos/640/480/?image=921" },
                    { 60, 60, "https://picsum.photos/640/480/?image=229" },
                    { 61, 61, "https://picsum.photos/640/480/?image=370" },
                    { 62, 62, "https://picsum.photos/640/480/?image=526" },
                    { 63, 63, "https://picsum.photos/640/480/?image=463" },
                    { 64, 64, "https://picsum.photos/640/480/?image=440" },
                    { 65, 65, "https://picsum.photos/640/480/?image=552" },
                    { 66, 66, "https://picsum.photos/640/480/?image=278" },
                    { 67, 67, "https://picsum.photos/640/480/?image=884" },
                    { 68, 68, "https://picsum.photos/640/480/?image=459" },
                    { 69, 69, "https://picsum.photos/640/480/?image=267" },
                    { 70, 70, "https://picsum.photos/640/480/?image=787" },
                    { 71, 71, "https://picsum.photos/640/480/?image=824" },
                    { 72, 72, "https://picsum.photos/640/480/?image=351" },
                    { 73, 73, "https://picsum.photos/640/480/?image=627" },
                    { 74, 74, "https://picsum.photos/640/480/?image=699" },
                    { 75, 75, "https://picsum.photos/640/480/?image=808" },
                    { 76, 76, "https://picsum.photos/640/480/?image=325" },
                    { 77, 77, "https://picsum.photos/640/480/?image=1016" },
                    { 78, 78, "https://picsum.photos/640/480/?image=263" },
                    { 79, 79, "https://picsum.photos/640/480/?image=951" },
                    { 80, 80, "https://picsum.photos/640/480/?image=1010" },
                    { 81, 81, "https://picsum.photos/640/480/?image=253" },
                    { 82, 82, "https://picsum.photos/640/480/?image=84" },
                    { 83, 83, "https://picsum.photos/640/480/?image=432" },
                    { 84, 84, "https://picsum.photos/640/480/?image=32" }
                });

            migrationBuilder.InsertData(
                table: "Image",
                columns: new[] { "Id", "AccommodationId", "Data" },
                values: new object[,]
                {
                    { 85, 85, "https://picsum.photos/640/480/?image=815" },
                    { 86, 86, "https://picsum.photos/640/480/?image=63" },
                    { 87, 87, "https://picsum.photos/640/480/?image=1059" },
                    { 88, 88, "https://picsum.photos/640/480/?image=945" },
                    { 89, 89, "https://picsum.photos/640/480/?image=504" },
                    { 90, 90, "https://picsum.photos/640/480/?image=603" },
                    { 91, 91, "https://picsum.photos/640/480/?image=110" },
                    { 92, 92, "https://picsum.photos/640/480/?image=74" },
                    { 93, 93, "https://picsum.photos/640/480/?image=599" },
                    { 94, 94, "https://picsum.photos/640/480/?image=185" },
                    { 95, 95, "https://picsum.photos/640/480/?image=994" },
                    { 96, 96, "https://picsum.photos/640/480/?image=911" },
                    { 97, 97, "https://picsum.photos/640/480/?image=487" },
                    { 98, 98, "https://picsum.photos/640/480/?image=840" },
                    { 99, 99, "https://picsum.photos/640/480/?image=1016" },
                    { 100, 100, "https://picsum.photos/640/480/?image=253" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_RoomId",
                table: "Accommodation",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_AccomodationId",
                table: "Booking",
                column: "AccomodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_AccommodationId",
                table: "Image",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_Review_RoomId",
                table: "Review",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_BookingId",
                table: "Ticket",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_CustomerId",
                table: "Ticket",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Accommodation");

            migrationBuilder.DropTable(
                name: "Room");
        }
    }
}

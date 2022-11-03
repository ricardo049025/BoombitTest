using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiBoombit.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: true),
                    NeedInformation = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActivityDescription = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Active", "Code", "Name" },
                values: new object[,]
                {
                    { 1, true, "AFG", "Afghanistan" },
                    { 2, true, "ALA", "Aland Islands" },
                    { 3, true, "ALB", "Albania" },
                    { 4, true, "DZA", "Algeria" },
                    { 5, true, "ASM", "American Samoa" },
                    { 6, true, "AND", "Andorra" },
                    { 7, true, "AGO", "Angola" },
                    { 8, true, "AIA", "Anguilla" },
                    { 9, true, "ATA", "Antarctica" },
                    { 10, true, "ATG", "Antigua and Barbuda" },
                    { 11, true, "ARG", "Argentina" },
                    { 12, true, "ARM", "Armenia" },
                    { 13, true, "ABW", "Aruba" },
                    { 14, true, "AUS", "Australia" },
                    { 15, true, "AUT", "Austria" },
                    { 16, true, "AZE", "Azerbaijan" },
                    { 17, true, "BHS", "Bahamas" },
                    { 18, true, "BHR", "Bahrain" },
                    { 19, true, "BGD", "Bangladesh" },
                    { 20, true, "BRB", "Barbados" },
                    { 21, true, "BLR", "Belarus" },
                    { 22, true, "BEL", "Belgium" },
                    { 23, true, "BLZ", "Belize" },
                    { 24, true, "BEN", "Benin" },
                    { 25, true, "BMU", "Bermuda" },
                    { 26, true, "BTN", "Bhutan" },
                    { 27, true, "BOL", "Bolivia" },
                    { 28, true, "BIH", "Bosnia and Herzegovina" },
                    { 29, true, "BWA", "Botswana" },
                    { 30, true, "BVT", "Bouvet Island" },
                    { 31, true, "BRA", "Brazil" },
                    { 32, true, "VGB", "British Virgin Islands" },
                    { 33, true, "IOT", "British Indian Ocean Territory" },
                    { 34, true, "BRN", "Brunei Darussalam" },
                    { 35, true, "BGR", "Bulgaria" },
                    { 36, true, "BFA", "Burkina Faso" },
                    { 37, true, "BDI", "Burundi" },
                    { 38, true, "KHM", "Cambodia" },
                    { 39, true, "CMR", "Cameroon" },
                    { 40, true, "CAN", "Canada" },
                    { 41, true, "CPV", "Cape Verde" },
                    { 42, true, "CYM", "Cayman Islands" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Active", "Code", "Name" },
                values: new object[,]
                {
                    { 43, true, "CAF", "Central African Republic" },
                    { 44, true, "TCD", "Chad" },
                    { 45, true, "CHL", "Chile" },
                    { 46, true, "CHN", "China" },
                    { 47, true, "HKG", "Hong Kong, SAR China" },
                    { 48, true, "MAC", "Macao, SAR China" },
                    { 49, true, "CXR", "Christmas Island" },
                    { 50, true, "CCK", "Cocos (Keeling) Islands" },
                    { 51, true, "COL", "Colombia" },
                    { 52, true, "COM", "Comoros" },
                    { 53, true, "COG", "Congo (Brazzaville)" },
                    { 54, true, "COD", "Congo, (Kinshasa)" },
                    { 55, true, "COK", "Cook Islands" },
                    { 56, true, "CRI", "Costa Rica" },
                    { 57, true, "CIV", "Côte d'Ivoire" },
                    { 58, true, "HRV", "Croatia" },
                    { 59, true, "CUB", "Cuba" },
                    { 60, true, "CYP", "Cyprus" },
                    { 61, true, "CZE", "Czech Republic" },
                    { 62, true, "DNK", "Denmark" },
                    { 63, true, "DJI", "Djibouti" },
                    { 64, true, "DMA", "Dominica" },
                    { 65, true, "DOM", "Dominican Republic" },
                    { 66, true, "ECU", "Ecuador" },
                    { 67, true, "EGY", "Egypt" },
                    { 68, true, "SLV", "El Salvador" },
                    { 69, true, "GNQ", "Equatorial Guinea" },
                    { 70, true, "ERI", "Eritrea" },
                    { 71, true, "EST", "Estonia" },
                    { 72, true, "ETH", "Ethiopia" },
                    { 73, true, "FLK", "Falkland Islands (Malvinas)" },
                    { 74, true, "FRO", "Faroe Islands" },
                    { 75, true, "FJI", "Fiji" },
                    { 76, true, "FIN", "Finland" },
                    { 77, true, "FRA", "France" },
                    { 78, true, "GUF", "French Guiana" },
                    { 79, true, "PYF", "French Polynesia" },
                    { 80, true, "ATF", "French Southern Territories" },
                    { 81, true, "GAB", "Gabon" },
                    { 82, true, "GMB", "Gambia" },
                    { 83, true, "GEO", "Georgia" },
                    { 84, true, "DEU", "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Active", "Code", "Name" },
                values: new object[,]
                {
                    { 85, true, "GHA", "Ghana" },
                    { 86, true, "GIB", "Gibraltar" },
                    { 87, true, "GRC", "Greece" },
                    { 88, true, "GRL", "Greenland" },
                    { 89, true, "GRD", "Grenada" },
                    { 90, true, "GLP", "Guadeloupe" },
                    { 91, true, "GUM", "Guam" },
                    { 92, true, "GTM", "Guatemala" },
                    { 93, true, "GGY", "Guernsey" },
                    { 94, true, "GIN", "Guinea" },
                    { 95, true, "GNB", "Guinea-Bissau" },
                    { 96, true, "GUY", "Guyana" },
                    { 97, true, "HTI", "Haiti" },
                    { 98, true, "HMD", "Heard and Mcdonald Islands" },
                    { 99, true, "VAT", "Holy See (Vatican City State)" },
                    { 100, true, "HND", "Honduras" },
                    { 101, true, "HUN", "Hungary" },
                    { 102, true, "ISL", "Iceland" },
                    { 103, true, "IND", "India" },
                    { 104, true, "IDN", "Indonesia" },
                    { 105, true, "IRN", "Iran, Islamic Republic of" },
                    { 106, true, "IRQ", "Iraq" },
                    { 107, true, "IRL", "Ireland" },
                    { 108, true, "IMN", "Isle of Man" },
                    { 109, true, "ISR", "Israel" },
                    { 110, true, "ITA", "Italy" },
                    { 111, true, "JAM", "Jamaica" },
                    { 112, true, "JPN", "Japan" },
                    { 113, true, "JEY", "Jersey" },
                    { 114, true, "JOR", "Jordan" },
                    { 115, true, "KAZ", "Kazakhstan" },
                    { 116, true, "KEN", "Kenya" },
                    { 117, true, "KIR", "Kiribati" },
                    { 118, true, "PRK", "Korea (North)" },
                    { 119, true, "KOR", "Korea (South)" },
                    { 120, true, "KWT", "Kuwait" },
                    { 121, true, "KGZ", "Kyrgyzstan" },
                    { 122, true, "LAO", "Lao PDR" },
                    { 123, true, "LVA", "Latvia" },
                    { 124, true, "LBN", "Lebanon" },
                    { 125, true, "LSO", "Lesotho" },
                    { 126, true, "LBR", "Liberia" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Active", "Code", "Name" },
                values: new object[,]
                {
                    { 127, true, "LBY", "Libya" },
                    { 128, true, "LIE", "Liechtenstein" },
                    { 129, true, "LTU", "Lithuania" },
                    { 130, true, "LUX", "Luxembourg" },
                    { 131, true, "MKD", "Macedonia, Republic of" },
                    { 132, true, "MDG", "Madagascar" },
                    { 133, true, "MWI", "Malawi" },
                    { 134, true, "MYS", "Malaysia" },
                    { 135, true, "MDV", "Maldives" },
                    { 136, true, "MLI", "Mali" },
                    { 137, true, "MLT", "Malta" },
                    { 138, true, "MHL", "Marshall Islands" },
                    { 139, true, "MTQ", "Martinique" },
                    { 140, true, "MRT", "Mauritania" },
                    { 141, true, "MUS", "Mauritius" },
                    { 142, true, "MYT", "Mayotte" },
                    { 143, true, "MEX", "Mexico" },
                    { 144, true, "FSM", "Micronesia, Federated States of" },
                    { 145, true, "MDA", "Moldova" },
                    { 146, true, "MCO", "Monaco" },
                    { 147, true, "MNG", "Mongolia" },
                    { 148, true, "MNE", "Montenegro" },
                    { 149, true, "MSR", "Montserrat" },
                    { 150, true, "MAR", "Morocco" },
                    { 151, true, "MOZ", "Mozambique" },
                    { 152, true, "MMR", "Myanmar" },
                    { 153, true, "NAM", "Namibia" },
                    { 154, true, "NRU", "Nauru" },
                    { 155, true, "NPL", "Nepal" },
                    { 156, true, "NLD", "Netherlands" },
                    { 157, true, "ANT", "Netherlands Antilles" },
                    { 158, true, "NCL", "New Caledonia" },
                    { 159, true, "NZL", "New Zealand" },
                    { 160, true, "NIC", "Nicaragua" },
                    { 161, true, "NER", "Niger" },
                    { 162, true, "NGA", "Nigeria" },
                    { 163, true, "NIU", "Niue" },
                    { 164, true, "NFK", "Norfolk Island" },
                    { 165, true, "MNP", "Northern Mariana Islands" },
                    { 166, true, "NOR", "Norway" },
                    { 167, true, "OMN", "Oman" },
                    { 168, true, "PAK", "Pakistan" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Active", "Code", "Name" },
                values: new object[,]
                {
                    { 169, true, "PLW", "Palau" },
                    { 170, true, "PSE", "Palestinian Territory" },
                    { 171, true, "PAN", "Panama" },
                    { 172, true, "PNG", "Papua New Guinea" },
                    { 173, true, "PRY", "Paraguay" },
                    { 174, true, "PER", "Peru" },
                    { 175, true, "PHL", "Philippines" },
                    { 176, true, "PCN", "Pitcairn" },
                    { 177, true, "POL", "Poland" },
                    { 178, true, "PRT", "Portugal" },
                    { 179, true, "PRI", "Puerto Rico" },
                    { 180, true, "QAT", "Qatar" },
                    { 181, true, "REU", "Réunion" },
                    { 182, true, "ROU", "Romania" },
                    { 183, true, "RUS", "Russian Federation" },
                    { 184, true, "RWA", "Rwanda" },
                    { 185, true, "BLM", "Saint-Barthélemy" },
                    { 186, true, "SHN", "Saint Helena" },
                    { 187, true, "KNA", "Saint Kitts and Nevis" },
                    { 188, true, "LCA", "Saint Lucia" },
                    { 189, true, "MAF", "Saint-Martin (French part)" },
                    { 190, true, "SPM", "Saint Pierre and Miquelon" },
                    { 191, true, "VCT", "Saint Vincent and Grenadines" },
                    { 192, true, "WSM", "Samoa" },
                    { 193, true, "SMR", "San Marino" },
                    { 194, true, "STP", "Sao Tome and Principe" },
                    { 195, true, "SAU", "Saudi Arabia" },
                    { 196, true, "SEN", "Senegal" },
                    { 197, true, "SRB", "Serbia" },
                    { 198, true, "SYC", "Seychelles" },
                    { 199, true, "SLE", "Sierra Leone" },
                    { 200, true, "SGP", "Singapore" },
                    { 201, true, "SVK", "Slovakia" },
                    { 202, true, "SVN", "Slovenia" },
                    { 203, true, "SLB", "Solomon Islands" },
                    { 204, true, "SOM", "Somalia" },
                    { 205, true, "ZAF", "South Africa" },
                    { 206, true, "SGS", "South Georgia and the South Sandwich Islands" },
                    { 207, true, "SSD", "South Sudan" },
                    { 208, true, "ESP", "Spain" },
                    { 209, true, "LKA", "Sri Lanka" },
                    { 210, true, "SDN", "Sudan" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Active", "Code", "Name" },
                values: new object[,]
                {
                    { 211, true, "SUR", "Suriname" },
                    { 212, true, "SJM", "Svalbard and Jan Mayen Islands" },
                    { 213, true, "SWZ", "Swaziland" },
                    { 214, true, "SWE", "Sweden" },
                    { 215, true, "CHE", "Switzerland" },
                    { 216, true, "SYR", "Syrian Arab Republic (Syria)" },
                    { 217, true, "TWN", "Taiwan, Republic of China" },
                    { 218, true, "TJK", "Tajikistan" },
                    { 219, true, "TZA", "Tanzania, United Republic of" },
                    { 220, true, "THA", "Thailand" },
                    { 221, true, "TLS", "Timor-Leste" },
                    { 222, true, "TGO", "Togo" },
                    { 223, true, "TKL", "Tokelau" },
                    { 224, true, "TON", "Tonga" },
                    { 225, true, "TTO", "Trinidad and Tobago" },
                    { 226, true, "TUN", "Tunisia" },
                    { 227, true, "TUR", "Turkey" },
                    { 228, true, "TKM", "Turkmenistan" },
                    { 229, true, "TCA", "Turks and Caicos Islands" },
                    { 230, true, "TUV", "Tuvalu" },
                    { 231, true, "UGA", "Uganda" },
                    { 232, true, "UKR", "Ukraine" },
                    { 233, true, "ARE", "United Arab Emirates" },
                    { 234, true, "GBR", "United Kingdom" },
                    { 235, true, "USA", "United States of America" },
                    { 236, true, "UMI", "US Minor Outlying Islands" },
                    { 237, true, "URY", "Uruguay" },
                    { 238, true, "UZB", "Uzbekistan" },
                    { 239, true, "VUT", "Vanuatu" },
                    { 240, true, "VEN", "Venezuela (Bolivarian Republic)" },
                    { 241, true, "VNM", "Viet Nam" },
                    { 242, true, "VIR", "Virgin Islands, US" },
                    { 243, true, "WLF", "Wallis and Futuna Islands" },
                    { 244, true, "ESH", "Western Sahara" },
                    { 245, true, "YEM", "Yemen" },
                    { 246, true, "ZMB", "Zambia" },
                    { 247, true, "ZWE", "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "CountryId", "Email", "LastName", "Name", "NeedInformation", "PhoneNumber" },
                values: new object[] { 1, new DateTime(1996, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "ricardom0490@gmail.com", "Martinez", "Ricardo", true, 85021379L });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Birthday", "CountryId", "Email", "LastName", "Name", "NeedInformation", "PhoneNumber" },
                values: new object[] { 2, new DateTime(2000, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "example@boombit.com", "Costa Rica", "UserBoombit", false, 25222222L });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ActivityDescription", "CreatedDay", "UserId" },
                values: new object[] { 1, "CREATION", new DateTime(2022, 11, 3, 12, 41, 35, 818, DateTimeKind.Local).AddTicks(3380), 1 });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ActivityDescription", "CreatedDay", "UserId" },
                values: new object[] { 2, "CREATION", new DateTime(2022, 11, 3, 12, 41, 35, 818, DateTimeKind.Local).AddTicks(3380), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_UserId",
                table: "Activities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CountryId",
                table: "Users",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}

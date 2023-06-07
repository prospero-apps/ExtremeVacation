using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExtremeVacation.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TripCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Danger = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChanceOfSurvival = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Carts",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "TripCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "City Vacation" },
                    { 2, "Mountains Vacation" },
                    { 3, "Seaside Vacation" },
                    { 4, "Horror Vacation" }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "CategoryId", "ChanceOfSurvival", "Danger", "Description", "Destination", "Duration", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, 70, "terrorist attacks", "Wanna spend some time in a city where terrorists strike on a daily basis? Then this place is for you. You will be staying in one of the old tenement houses downtown, right where the most attacks happen. You're not advised to leave your room during your stay.", "an island on the Atlantic Ocean", 6, "/images/city/apocalyptic.jpg", "Under Fire", 320m },
                    { 2, 1, 99, "extreme noise", "It tolls for thee. At least it may toll for you if you would like to spend your vacation in a campanile. You will be staying in a tall tower with a couple bells. The bells will be ringing every hour and it will actually be your task to ring them. Gonna be loud.", "Sicily", 4, "/images/city/campanile.jpg", "For Whom Does the Bell Toll?", 190m },
                    { 3, 1, 90, "collapse", "Here's an opportunity for you to spend some time in a building that is being demolished. One part of the building is still standing and will not be touched as long as you stay there. The question is, is the remaining part going to collapse or not? You will never know until you try.", "Detroit", 4, "/images/city/demolished.jpg", "Is it Gonna Collapse?", 470m },
                    { 4, 1, 30, "strong wind", "Who wouldn't like to laze in a hammock? Except the hammock is stretched between two skyscrapers and you must figure it out yourself how to get to it. But when you finally manage to get to it, you will be able to relax and admire the beautiful view of the city. Hopefully, it's not gonna be too windy.", "New York", 3, "/images/city/hammock.jpg", "Chill Out in a Hammock", 760m },
                    { 5, 1, 2, "your cellmate", "Would you like to know what it feels like to be a prisoner? Here you have a great opportunity to become one, at least for a limited period of time. You will be ding the same stuff as all the real prisoners, you will get the same food, and, what's even better, you will be in one cell with the most dangerous serial killer.", "Northern Europe", 14, "/images/city/prison.jpg", "Behind Bars", 960m },
                    { 6, 2, 40, "falling down", "Why not spend your vacation in the Alps? You will be staying on top of a very steep rock. The bathroom is on another steep rock and there's a five-meter gap between the two rocks, so each time you want to use the bathroom, you have to jump from one rock to the other and then back. But it shouldn't be a big deal, right?", "the Alps", 5, "/images/mountains/steep.jpg", "For Good Jumpers Only", 270m },
                    { 7, 2, 10, "hot lava", "If you don't like crowded places, this little island is for you. There is magma right below the surface and the rocks melt every couple days. If you like being surrounded by hot lava, this destination is for you. Just remember to climb the peaks of the rocks when the rock melts. They're less hot than the other parts.", "off the shores of Indonesia", 4, "/images/mountains/lava.jpg", "Molten Rock", 500m },
                    { 8, 2, 1, "being eaten by wolves", "Do you like animals? If so, why not spend your vacation in the woods of the Scandinavian Mountains? You will join a pack of wolves and live like they do. You will be hunting together, they will teach you to howl, just make sure they're never hungry because this is when most tourists become their dinner.", "Norway", 8, "/images/mountains/wolves.jpg", "Dances with Wolves", 720m },
                    { 9, 2, 1, "being killed by the bear", "If you're thinking about spending your vacation in the Carpathian Mountains, you don't have to spend much money. You will be staying in the forest and sharing a den with a bear. You can play together or just hang out. Just two things to keep in mind: make sure the bear is never hungry and don't touch her cubs.", "Southern Poland", 5, "/images/mountains/bear.jpg", "Den Sharing", 160m },
                    { 10, 3, 60, "drowning", "You can spend your vacation in one of the caves situated on an island off the shores of Australia. The cave isn't very large and it gets completely filled with water when there is high tide, so you will have to be swimming all the time to keep above water. During low tide, though, you will be able to spend some nice time on a narrow beach.", "Southern Pacific", 10, "/images/seaside/cave.jpg", "High Tide Cave", 640m },
                    { 11, 3, 70, "suffocation", "There's an island near Japan where you can spend your vacation inhaling the sulforous fumes of a volcano. Don't worry, the volcano hasn't erupted for centuries now, but the sulfurous odor can be smelled all the time. Just don't breathe in too deep. If you catch some fish, you can try to smoke it over the crater.", "off the shores of Japan", 3, "/images/seaside/volcano.jpg", "Volcanic Island", 450m },
                    { 12, 3, 30, "disappearing along with the ship", "There is a ship that appears every now and then on the waters of the Bermuda Triangle. There's no one on board, but the tables are set and the tea is still hot, just as if the ship had been abandoned a couple minutes before. Unfortunately no one knows exactly when the ship will disappear again and what will happen to the passengers.", "the Bermuda Triangle", 2, "/images/seaside/ship.jpg", "Ghost Ship", 980m },
                    { 13, 4, 50, "being scared to death", "If you want to spend your vacation away from people, why don't you choose this beautiful house in the middle of an abandoned graveyard. The house isn't too cozy, but for that price? You should also know it's haunted, but the ghosts aren't very aggressive. They look really scary, though, so just don't look at them.", "Scotland", 7, "/images/horror/haunted.jpg", "Haunted House", 120m },
                    { 14, 4, 80, "heart attack", "If you feel like spending some time in an abominable place, you can stay in a secret hospital. Terrible experiments on humans were carried out there in the 19th century and the ghosts of those who died there can still be seen from time to time, but these are just dreadful visions, not a real thing. Although they do look and feel real, so you'd better have a healthy heart.", "a secret hospital in a secret location", 5, "/images/horror/ghost.jpg", "Just Visions", 520m },
                    { 15, 4, 50, "falling down in the elevator", "This place has been kept secret for too long, but now you can not only visit it, but also stay in it for a couple days. The place is hidden under the ground and the only way to get there is by using an old elevator. The elevator is very noisy and you never know when it comes. Also, when you're in it, strange noises can heard and the lights start flickering. The elevator rope doesn't break every time, so you may be lucky.", "Germany", 3, "/images/horror/abandoned.jpg", "The Elevator", 450m },
                    { 16, 4, 99, "being bitten by the werewolf", "If you like history, this destination is for you. There are graves from the 17th century and beautiful tombs. You will find tons of information about the people who were buried there. And yes, there may be a werewolf roaming the place from time to time, but usually only at night. Just try to avoid him. He won't kill you, but if he bites you, you will turn into werewolf yourself. Is it really something you need?", "Peru", 8, "/images/horror/werewolf.jpg", "Old Graveyard", 750m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "UserName" },
                values: new object[,]
                {
                    { 1, "Annie" },
                    { 2, "Joe" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "TripCategories");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

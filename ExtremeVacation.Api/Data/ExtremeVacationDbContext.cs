using ExtremeVacation.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExtremeVacation.Api.Data
{
    public class ExtremeVacationDbContext : DbContext
    {
        public ExtremeVacationDbContext(DbContextOptions<ExtremeVacationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Trips
            // City
            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 1,
                Name = "Under Fire",
                Destination = "an island on the Atlantic Ocean",
                Description = "Wanna spend some time in a city where terrorists strike on a daily basis? Then this place is for you. You will be staying in one of the old tenement houses downtown, right where the most attacks happen. You're not advised to leave your room during your stay.",
                Danger = "terrorist attacks",
                ChanceOfSurvival = 70,
                ImageURL = "/images/city/apocalyptic.jpg",
                Price = 320,
                Duration = 6,
                CategoryId = 1
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 2,
                Name = "For Whom Does the Bell Toll?",
                Destination = "Sicily",
                Description = "It tolls for thee. At least it may toll for you if you would like to spend your vacation in a campanile. You will be staying in a tall tower with a couple bells. The bells will be ringing every hour and it will actually be your task to ring them. Gonna be loud.",
                Danger = "extreme noise",
                ChanceOfSurvival = 99,
                ImageURL = "/images/city/campanile.jpg",
                Price = 190,
                Duration = 4,
                CategoryId = 1
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 3,
                Name = "Is it Gonna Collapse?",
                Destination = "Detroit",
                Description = "Here's an opportunity for you to spend some time in a building that is being demolished. One part of the building is still standing and will not be touched as long as you stay there. The question is, is the remaining part going to collapse or not? You will never know until you try.",
                Danger = "collapse",
                ChanceOfSurvival = 90,
                ImageURL = "/images/city/demolished.jpg",
                Price = 470,
                Duration = 4,
                CategoryId = 1
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 4,
                Name = "Chill Out in a Hammock",
                Destination = "New York",
                Description = "Who wouldn't like to laze in a hammock? Except the hammock is stretched between two skyscrapers and you must figure it out yourself how to get to it. But when you finally manage to get to it, you will be able to relax and admire the beautiful view of the city. Hopefully, it's not gonna be too windy.",
                Danger = "strong wind",
                ChanceOfSurvival = 30,
                ImageURL = "/images/city/hammock.jpg",
                Price = 760,
                Duration = 3,
                CategoryId = 1
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 5,
                Name = "Behind Bars",
                Destination = "Northern Europe",
                Description = "Would you like to know what it feels like to be a prisoner? Here you have a great opportunity to become one, at least for a limited period of time. You will be ding the same stuff as all the real prisoners, you will get the same food, and, what's even better, you will be in one cell with the most dangerous serial killer.",
                Danger = "your cellmate",
                ChanceOfSurvival = 2,
                ImageURL = "/images/city/prison.jpg",
                Price = 960,
                Duration = 14,
                CategoryId = 1
            });

            // Mountains
            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 6,
                Name = "For Good Jumpers Only",
                Destination = "the Alps",
                Description = "Why not spend your vacation in the Alps? You will be staying on top of a very steep rock. The bathroom is on another steep rock and there's a five-meter gap between the two rocks, so each time you want to use the bathroom, you have to jump from one rock to the other and then back. But it shouldn't be a big deal, right?",
                Danger = "falling down",
                ChanceOfSurvival = 40,
                ImageURL = "/images/mountains/steep.jpg",
                Price = 270,
                Duration = 5,
                CategoryId = 2
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 7,
                Name = "Molten Rock",
                Destination = "off the shores of Indonesia",
                Description = "If you don't like crowded places, this little island is for you. There is magma right below the surface and the rocks melt every couple days. If you like being surrounded by hot lava, this destination is for you. Just remember to climb the peaks of the rocks when the rock melts. They're less hot than the other parts.",
                Danger = "hot lava",
                ChanceOfSurvival = 10,
                ImageURL = "/images/mountains/lava.jpg",
                Price = 500,
                Duration = 4,
                CategoryId = 2
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 8,
                Name = "Dances with Wolves",
                Destination = "Norway",
                Description = "Do you like animals? If so, why not spend your vacation in the woods of the Scandinavian Mountains? You will join a pack of wolves and live like they do. You will be hunting together, they will teach you to howl, just make sure they're never hungry because this is when most tourists become their dinner.",
                Danger = "being eaten by wolves",
                ChanceOfSurvival = 1,
                ImageURL = "/images/mountains/wolves.jpg",
                Price = 720,
                Duration = 8,
                CategoryId = 2
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 9,
                Name = "Den Sharing",
                Destination = "Southern Poland",
                Description = "If you're thinking about spending your vacation in the Carpathian Mountains, you don't have to spend much money. You will be staying in the forest and sharing a den with a bear. You can play together or just hang out. Just two things to keep in mind: make sure the bear is never hungry and don't touch her cubs.",
                Danger = "being killed by the bear",
                ChanceOfSurvival = 1,
                ImageURL = "/images/mountains/bear.jpg",
                Price = 160,
                Duration = 5,
                CategoryId = 2
            });

            // seaside
            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 10,
                Name = "High Tide Cave",
                Destination = "Southern Pacific",
                Description = "You can spend your vacation in one of the caves situated on an island off the shores of Australia. The cave isn't very large and it gets completely filled with water when there is high tide, so you will have to be swimming all the time to keep above water. During low tide, though, you will be able to spend some nice time on a narrow beach.",
                Danger = "drowning",
                ChanceOfSurvival = 60,
                ImageURL = "/images/seaside/cave.jpg",
                Price = 640,
                Duration = 10,
                CategoryId = 3
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 11,
                Name = "Volcanic Island",
                Destination = "off the shores of Japan",
                Description = "There's an island near Japan where you can spend your vacation inhaling the sulforous fumes of a volcano. Don't worry, the volcano hasn't erupted for centuries now, but the sulfurous odor can be smelled all the time. Just don't breathe in too deep. If you catch some fish, you can try to smoke it over the crater.",
                Danger = "suffocation",
                ChanceOfSurvival = 70,
                ImageURL = "/images/seaside/volcano.jpg",
                Price = 450,
                Duration = 3,
                CategoryId = 3
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 12,
                Name = "Ghost Ship",
                Destination = "the Bermuda Triangle",
                Description = "There is a ship that appears every now and then on the waters of the Bermuda Triangle. There's no one on board, but the tables are set and the tea is still hot, just as if the ship had been abandoned a couple minutes before. Unfortunately no one knows exactly when the ship will disappear again and what will happen to the passengers.",
                Danger = "disappearing along with the ship",
                ChanceOfSurvival = 30,
                ImageURL = "/images/seaside/ship.jpg",
                Price = 980,
                Duration = 2,
                CategoryId = 3
            });

            // horror
            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 13,
                Name = "Haunted House",
                Destination = "Scotland",
                Description = "If you want to spend your vacation away from people, why don't you choose this beautiful house in the middle of an abandoned graveyard. The house isn't too cozy, but for that price? You should also know it's haunted, but the ghosts aren't very aggressive. They look really scary, though, so just don't look at them.",
                Danger = "being scared to death",
                ChanceOfSurvival = 50,
                ImageURL = "/images/horror/haunted.jpg",
                Price = 120,
                Duration = 7,
                CategoryId = 4
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 14,
                Name = "Just Visions",
                Destination = "a secret hospital in a secret location",
                Description = "If you feel like spending some time in an abominable place, you can stay in a secret hospital. Terrible experiments on humans were carried out there in the 19th century and the ghosts of those who died there can still be seen from time to time, but these are just dreadful visions, not a real thing. Although they do look and feel real, so you'd better have a healthy heart.",
                Danger = "heart attack",
                ChanceOfSurvival = 80,
                ImageURL = "/images/horror/ghost.jpg",
                Price = 520,
                Duration = 5,
                CategoryId = 4
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 15,
                Name = "The Elevator",
                Destination = "Germany",
                Description = "This place has been kept secret for too long, but now you can not only visit it, but also stay in it for a couple days. The place is hidden under the ground and the only way to get there is by using an old elevator. The elevator is very noisy and you never know when it comes. Also, when you're in it, strange noises can heard and the lights start flickering. The elevator rope doesn't break every time, so you may be lucky.",
                Danger = "falling down in the elevator",
                ChanceOfSurvival = 50,
                ImageURL = "/images/horror/abandoned.jpg",
                Price = 450,
                Duration = 3,
                CategoryId = 4
            });

            modelBuilder.Entity<Trip>().HasData(new Trip
            {
                Id = 16,
                Name = "Old Graveyard",
                Destination = "Peru",
                Description = "If you like history, this destination is for you. There are graves from the 17th century and beautiful tombs. You will find tons of information about the people who were buried there. And yes, there may be a werewolf roaming the place from time to time, but usually only at night. Just try to avoid him. He won't kill you, but if he bites you, you will turn into werewolf yourself. Is it really something you need?",
                Danger = "being bitten by the werewolf",
                ChanceOfSurvival = 99,
                ImageURL = "/images/horror/werewolf.jpg",
                Price = 750,
                Duration = 8,
                CategoryId = 4
            });


            // Users
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "Annie"

            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                UserName = "Joe"

            });

            // Carts 
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 1,
                UserId = 1

            });
            modelBuilder.Entity<Cart>().HasData(new Cart
            {
                Id = 2,
                UserId = 2

            });

            // Trip Categories
            modelBuilder.Entity<TripCategory>().HasData(new TripCategory
            {
                Id = 1,
                Name = "City Vacation"
            });
            modelBuilder.Entity<TripCategory>().HasData(new TripCategory
            {
                Id = 2,
                Name = "Mountains Vacation"
            });
            modelBuilder.Entity<TripCategory>().HasData(new TripCategory
            {
                Id = 3,
                Name = "Seaside Vacation"
            });
            modelBuilder.Entity<TripCategory>().HasData(new TripCategory
            {
                Id = 4,
                Name = "Horror Vacation"
            });
        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<TripCategory> TripCategories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

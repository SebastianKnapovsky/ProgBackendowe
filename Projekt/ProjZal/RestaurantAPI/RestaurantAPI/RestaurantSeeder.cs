using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                var pendingMigrations = _dbContext.Database.GetPendingMigrations();

                if(pendingMigrations != null && pendingMigrations.Any())
                {
                    _dbContext.Database.Migrate();
                }

                if (_dbContext.Roles != null)
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }

                if (_dbContext.Restaurants != null)
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name ="User",
                },
                new Role()
                {
                    Name ="Manager",
                },
                new Role()
                {
                    Name ="Admin",
                }
            };
            return roles;


        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in USA",
                    ContactEmail = "contact@kfc.com",
                    ContactNumber = "876565888",
                    HasDelivery = true,
                    Dishes = new List<Dish>
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                            Description = "Hot Chicken in Oil",
                        },

                        new Dish()
                        {
                            Name = "Chcicken Nuggets",
                            Price = 5.30M,
                            Description = "Chicken in pieces",
                        },
                    },
                    Address =  new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001",
                    }
                },
                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description = "McDonald is an American fast food restaurant chain headquartered in USA Too",
                    ContactEmail = "contact@Mc.com",
                    ContactNumber = "666555888",
                    HasDelivery = true,
                    Dishes = new List<Dish>
                    {
                        new Dish()
                        {
                            Name = "Burger",
                            Price = 10.30M,
                            Description = "Hot Burger",
                        },

                        new Dish()
                        {
                            Name = "Chcicken Nuggets",
                            Price = 7.30M,
                            Description = "Hot Chicken in Oil in pieces",
                        },
                    },
                    Address =  new Address()
                    {
                        City = "Zakopane",
                        Street = "Zwykła 8",
                        PostalCode = "30-001"
                    }
                },
            };
            return restaurants;
        }
    }
}

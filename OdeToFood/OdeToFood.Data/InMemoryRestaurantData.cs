using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1,Name="Pizza1",Location="Doha1",Cuisine=CuisineType.Indian},
                new Restaurant { Id = 2,Name="Pizza2",Location="Doha2",Cuisine=CuisineType.Indian},
                new Restaurant { Id = 3,Name="Pizza3",Location="Doha3",Cuisine=CuisineType.Indian},
                new Restaurant { Id = 4,Name="Pizza4",Location="Doha4",Cuisine=CuisineType.Indian},
                new Restaurant { Id = 5,Name="QPizza5",Location="Doha5",Cuisine=CuisineType.Indian}
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(m => m.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return restaurants
                .Where(r => (string.IsNullOrEmpty(name) || r.Name.StartsWith(name)))
                .OrderBy(r => r.Name);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants
                .SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }
    }
}

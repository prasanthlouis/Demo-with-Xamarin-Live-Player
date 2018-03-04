using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Testing.Models;

[assembly: Xamarin.Forms.Dependency(typeof(Testing.Services.MockDataStore))]
namespace Testing.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Development", Description="Time spent on coding features and bug fixes." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Research", Description="Time spent on researching new methodologies." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Unit Testing", Description="Time spent testing written code" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Scrum Meeting", Description="Time spent on a weekly standup" },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
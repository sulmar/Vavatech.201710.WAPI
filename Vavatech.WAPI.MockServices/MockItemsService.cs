using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.MockServices
{
    public class MockItemsService<TItem> : IBaseService<TItem>
        where TItem : Base
    {
        protected IList<TItem> items;

        private const string baseDir = @"c:\users\marci\downloads\";

        private readonly string filename = $@"{baseDir}\{typeof(TItem).Name}.json";

        public MockItemsService()
        {
            Load();
        }

        public virtual void Add(TItem item)
        {
            items.Add(item);

            Save();
        }

        public virtual IList<TItem> Get()
        {
            return items;
        }

        public virtual TItem Get(int id)
        {
            return items.SingleOrDefault(s => s.Id == id);
        }

        public virtual void Remove(int id)
        {
            var item = Get(id);

            if (item != null)
            {
                items.Remove(item);

                Save();
            }
        }

        public void Update(TItem item)
        {
            var foundItem = Get(item.Id);

            items.Remove(foundItem);

            Add(item);

            Save();
        }

        private void Load()
        {
            if (File.Exists(filename))
            {
                var json = File.ReadAllText(filename);
                items = JsonConvert.DeserializeObject<IList<TItem>>(json);
            }
            else
            {
                items = new List<TItem>();
            }
        }

        private void Save()
        {
            var json = JsonConvert.SerializeObject(items);
            File.WriteAllText(filename, json);
        }
    }
}

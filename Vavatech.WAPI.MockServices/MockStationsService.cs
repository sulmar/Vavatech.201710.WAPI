using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.MockServices
{
    public class MockStationsService : IStationsService
    {
        private IList<Station> stations;

        private const string filename = @"c:\users\marci\downloads\database.json";

        public MockStationsService()
        {
            Load();
        }

        private void Load()
        {
            if (File.Exists(filename))
            {
                var json = File.ReadAllText(filename);
                stations = JsonConvert.DeserializeObject<IList<Station>>(json);
            }
            else
            {
                stations = new List<Station>();
            }
        }

        private void Save()
        {
            var json = JsonConvert.SerializeObject(stations);
            File.WriteAllText(filename, json);
        }

        public void Add(Station station)
        {
            stations.Add(station);

            station.Id = stations.Max(s => s.Id) + 1;

            Save();
        }

       

        public IList<Station> Get()
        {
            return stations;
        }

        public Station Get(int id)
        {
            return stations.SingleOrDefault(s => s.Id == id);
        }

        public void Remove(int id)
        {
            var station = Get(id);

            if (station!=null)
            {
                stations.Remove(station);

                Save();
            }
        }

        public void Update(Station station)
        {
            var foundStation = Get(station.Id);

            stations.Remove(foundStation);

            Add(station);

            Save();
        }

        public Station Get(string name) => stations.SingleOrDefault(s => s.Name == name);
    }
}

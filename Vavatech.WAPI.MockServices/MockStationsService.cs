using System;
using System.Collections.Generic;
using System.Linq;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.MockServices
{
    public class MockStationsService : IStationsService
    {
        private IList<Station> stations;

        public MockStationsService()
        {
            stations = new List<Station>
            {
                new Station { Id = 1, Name = "ST001" },
                new Station { Id = 2, Name = "ST002" },
                new Station { Id = 3, Name = "ST003" },
            };
        }


        public void Add(Station station)
        {
            stations.Add(station);

            station.Id = stations.Max(s => s.Id) + 1;
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
            }
        }

        public void Update(Station station)
        {
            var foundStation = Get(station.Id);

            stations.Remove(foundStation);

            Add(station);
        }
    }
}

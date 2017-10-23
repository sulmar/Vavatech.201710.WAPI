using System;
using System.Collections.Generic;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.Services
{
    public interface IStationsService
    {
        IList<Station> Get();

        Station Get(int id);

        void Add(Station station);

        void Update(Station station);

        void Remove(int id);
    }
}

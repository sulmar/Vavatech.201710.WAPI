using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.Services
{
    public interface IBaseService<TItem>
    {
        IList<TItem> Get();

        TItem Get(int id);

        void Add(TItem item);

        void Update(TItem item);

        void Remove(int id);
    }

    public interface IUsersService : IBaseService<User>
    {
        User Get(string firstname);
    }

    public interface IVehiclesService : IBaseService<Vehicle>
    {

    }
}

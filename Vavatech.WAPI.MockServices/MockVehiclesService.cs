using System;
using System.Collections.Generic;
using System.Text;
using Vavatech.WAPI.Models;
using Vavatech.WAPI.Services;

namespace Vavatech.WAPI.MockServices
{
    public class MockVehiclesService : MockItemsService<Vehicle>, IVehiclesService
    {
    }
}

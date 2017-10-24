﻿using System;
using System.Collections.Generic;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.Services
{
    public interface IStationsService : IBaseService<Station>
    {
        Station Get(string name);
    }
}

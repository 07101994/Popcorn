﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Popcorn.Chromecast.Models;

namespace Popcorn.Chromecast.Services
{
    public interface IChromecastService
    {
        Task<Func<object, Task<object>>> StartCastAsync(ChromecastSession session);
    }
}

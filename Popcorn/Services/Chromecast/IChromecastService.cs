﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleCast;
using GoogleCast.Models.Media;

namespace Popcorn.Services.Chromecast
{
    public interface IChromecastService
    {
        Task<IEnumerable<IReceiver>> FindReceiversAsync();
        Task LoadAsync(Media media);
        Task<bool> ConnectAsync(IReceiver receiver);
        bool IsStopped { get; }
        bool IsMuted { get; }
        Task PauseAsync();
        Task PlayAsync();
        Task StopAsync();
        Task SeekAsync(double seconds);
        Task SetVolumeAsync(float volume);
        Task SetIsMutedAsync();
        string PlayerState { get; }
        Task<IEnumerable<MediaStatus>> GetStatus();
    }
}

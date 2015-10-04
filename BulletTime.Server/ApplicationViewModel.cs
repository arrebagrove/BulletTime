﻿using BulletTime.Models;
using BulletTime.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace BulletTime.Server
{
    public class ApplicationViewModel
    {
        private readonly Lazy<ServerViewModel> _server;

        public static ApplicationViewModel Current
        {
            get
            {
                return (ApplicationViewModel)Application.Current.Resources["ApplicationModel"];
            }
        }

        public ApplicationViewModel()
        {
            _server = new Lazy<ServerViewModel>(() => new ServerViewModel());
        }

        public ServerViewModel ServerViewModel
        {
            get
            {
                return _server.Value;
            }
        }

        public MapViewModel MapViewModel { get; private set; }

        public async Task InitializeMapViewModel()
        {
            var cameras = new List<MapCameraViewModel>();

            foreach (var camera in (IEnumerable<RemoteCameraModel>)ServerViewModel.Cameras.Source)
            {
                cameras.Add(new MapCameraViewModel(camera));
            }

            this.MapViewModel = new MapViewModel(cameras, 30);
            await Task.Yield();
        }
    }
}
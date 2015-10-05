using System.Collections.Generic;
using Windows.UI;
using Windows.UI.Xaml.Media;
using BulletTime.Models;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Data;
using System.Linq;
using Windows.UI.Xaml;

namespace BulletTime.ViewModels
{
    public class MapCameraViewModel
    {
        private static int index;

        private static readonly List<Color> colors = new List<Color>
        {
            Colors.Gray,
            Colors.LightGray,
            Colors.DimGray,
            Colors.DarkGray
        };

        public MapCameraViewModel(RemoteCameraModel model)
        {
            var i = index++ % colors.Count;
            Background = new SolidColorBrush(colors[i]);
            Name = model.IPAddress.ToString();
            Frames = new CollectionViewSource();
            FramesVisible = Visibility.Collapsed;
        }

        public MapCameraViewModel(RemoteCameraModel model, IEnumerable<BitmapImage> frames)
            : this(model)
        {
            Frames.Source = frames;
            FramesVisible = Visibility.Visible;
        }

        public Visibility FramesVisible { get; set; }
        public CollectionViewSource Frames { get; private set; }
        public Brush Background { get; private set; }
        public string Name { get; private set; }
    }
}
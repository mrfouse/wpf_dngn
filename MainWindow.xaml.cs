using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace dungeons
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int[,] mapData = GenerateMapData();

            List<Point> dungeonLocations = LocateDungeon(mapData);

            foreach (Point location in dungeonLocations)
            {
                Shape marker;

                if (mapData[(int)location.X, (int)location.Y] == 2)
                {
                    marker = new Rectangle
                    {
                        Width = 20,
                        Height = 20,
                        Fill = new ImageBrush(new BitmapImage(new Uri("C:\\Users\\Павел\\Desktop\\ass\\AAAA\\cave.png")))
                    };
                }
                else
                {
                    marker = new Rectangle
                    {
                        Width = 20,
                        Height = 20,
                        Fill = Brushes.Green,
                    };
                }

                Canvas.SetLeft(marker, location.X * 20);
                Canvas.SetTop(marker, location.Y * 20);

                canvas.Children.Add(marker);
            }
        }
        private int[,] GenerateMapData()
        {
            Random random = new Random();
            int[,] map = new int[20, 20];

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map[i, j] = (random.Next(100) < 10) ? 2 : 1;
                }
            }

            return map;
        }

        private List<Point> LocateDungeon(int[,] map)
        {
            List<Point> dungeonLocations = new List<Point>();

            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 2)
                    {
                        dungeonLocations.Add(new Point(i, j));
                    }
                }
            }

            return dungeonLocations;
        }
    }
}
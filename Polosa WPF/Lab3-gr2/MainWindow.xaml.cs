using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Lab3_gr2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random random;
        DispatcherTimer timer;
        int defquant = 5;
        int quant;

        public MainWindow()
        {
            InitializeComponent();
            random = new Random();

            CreateRectangles(defquant);
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timerTick);
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            CreateRectangles(1);
        }

        private void CreateRectangles(int n)
        {
            for(int i = 0; i < n; i++)
            {
                Rectangle rect = new Rectangle();
                rect.Fill = new SolidColorBrush(Color.FromRgb((byte)random.Next(0, 255), (byte)random.Next(0, 255), (byte)random.Next(0, 255)));

                rect.HorizontalAlignment = HorizontalAlignment.Left;
                rect.VerticalAlignment = VerticalAlignment.Top;

                int ro = random.Next(0, 9);
                if(ro < 5)
                {
                    rect.Width = 200;
                    rect.Height = 50;
                }
                else
                {
                    rect.Height = 200;
                    rect.Width = 50;
                }
                

                int x = random.Next((int)this.Width - 200);
                int y = random.Next((int)this.Height - 200);
                rect.Margin = new Thickness(x, y, 0, 0);
                
                rect.Stroke = new SolidColorBrush(Colors.Black);

                rect.MouseDown += new MouseButtonEventHandler(onClick);


                grid1.Children.Add(rect);
                quant++;
            }
            if(quant == 10)
            {
                MessageBox.Show("You lose");
                this.Close();
            }
        }

        private void onClick(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = (Rectangle)sender;
            Rect irect = new Rect(rect.Margin.Left, rect.Margin.Top , rect.Width, rect.Height);

            int iRect = grid1.Children.IndexOf(rect);
            for(int i = iRect + 1; i < grid1.Children.Count; i++)
            {
                Rectangle r = (Rectangle)grid1.Children[i];
                Rect ir = new Rect(r.Margin.Left, r.Margin.Top, r.Width, r.Height);

                if (irect.IntersectsWith(ir))
                    return;
            }

            grid1.Children.Remove(rect);
            quant--;
            if(quant == 0)
            {
                MessageBox.Show("You win");
                this.Close();
            }    
        }
    }
}

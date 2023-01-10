using Microsoft.Win32;
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
using System.IO;

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly OpenFileDialog ofd;
        private readonly OpenFileDialog playlist;
        private DispatcherTimer timer;

        private bool fullscreen = false;
        private double volume = 0.5;

        private List<string> listOfPlaylist;

        private int playlistIndex = -1;
        public MainWindow()
        {
            InitializeComponent();
            volumeSlider.Value = volume;
            mediaElement.Volume = volumeSlider.Value;
            ofd = new OpenFileDialog
            {
                Multiselect = false,
                RestoreDirectory = true,
                Title = "Open Media File...",
                Filter = "Audio Files|*.mp3|Video Files|*.mp4;*.avi|All Files|*.*",
                FilterIndex = 3
            };

            playlist = new OpenFileDialog
            {
                Multiselect = true,
                RestoreDirectory = true,
                Title = "Get files",
                Filter = "Audio Files|*.mp3|Video Files|*.mp4;*.avi|All Files|*.*",
                FilterIndex = 3
            };

            info.Content = "00:00/00:00";

            timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            listOfPlaylist = new List<string>();
            buttons(false);
            shuffleButton.IsEnabled = false;

        }

        private void buttons(bool key)
        {
            forwardButton.IsEnabled = key;
            pauseButton.IsEnabled = key;
            playButton.IsEnabled = key;
            stopButton.IsEnabled = key;
            backButton.IsEnabled = key;
            muteButton.IsEnabled = key;
            volumeSlider.IsEnabled = key;
            durationSlider.IsEnabled = key;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            durationSlider.Value = mediaElement.Position.TotalSeconds;
           
            if (mediaElement.NaturalDuration.HasTimeSpan)
            {
                info.Content = mediaElement.Position.TotalMinutes.ToString("00") + ":" + mediaElement.Position.Seconds.ToString("00") + "/"
                    + mediaElement.NaturalDuration.TimeSpan.TotalMinutes.ToString("00") + ":" + mediaElement.NaturalDuration.TimeSpan.Seconds.ToString("00");
            }
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ofd.ShowDialog();

            try
            {
                mediaElement.Source = new Uri(ofd.FileName);
            } catch { MessageBox.Show("You must select one file.", "Select file", MessageBoxButton.OK, MessageBoxImage.Error); return; }
            buttons(true);

            mediaElement.Play();
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void durationSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Position = TimeSpan.FromSeconds(durationSlider.Value);
        }

        private void volumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaElement.Volume = volumeSlider.Value;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.FromSeconds(durationSlider.Value - 5);
            durationSlider.Value -= 5;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.FromSeconds(durationSlider.Value + 5);
            durationSlider.Value += 5;
        }

        private void fullScreen(object sender, MouseButtonEventArgs e)
        {
           if (e.ClickCount == 2)
            {
                if (!fullscreen)
                {
                    this.WindowStyle = WindowStyle.None;
                    this.WindowState = WindowState.Maximized;
                } else
                {
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.WindowState = WindowState.Normal;
                }
                
                fullscreen = !fullscreen;

                
            }
        }

        private void mediaLoaded(object sender, RoutedEventArgs e)
        {
           if(mediaElement.NaturalDuration.HasTimeSpan)
            {
                durationSlider.Maximum = mediaElement.NaturalDuration.TimeSpan.Seconds;
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            if(volumeSlider.Value == 0.0)
            {
                volumeSlider.Value = volume;
                imageVolume.Source = new BitmapImage(new Uri("C:\\Users\\Ognjen\\source\\repos\\MediaPlayer\\MediaPlayer\\Resources\\speaker-filled-audio-tool.png"));
            } else
            {
                volumeSlider.Value = 0.0;
                imageVolume.Source = new BitmapImage(new Uri("C:\\Users\\Ognjen\\source\\repos\\MediaPlayer\\MediaPlayer\\Resources\\volume-mute.png"));
            }
        }

        private string getName(string filePath)
        {
            string[] names = filePath.Split(System.IO.Path.DirectorySeparatorChar);

            return names[names.Length - 1];
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            playlist.ShowDialog();

            try
            {
                foreach(string file in playlist.FileNames)
                {
                   // Console.WriteLine(file);
                    showPlaylist.Items.Add(getName(file));
                    listOfPlaylist.Add(file);

                }
            } catch { MessageBox.Show("Select files."); return; }
            
            if (listOfPlaylist.Count <= 0) return;

            showPlaylist.SelectedIndex = 0;
            playlistIndex = 0;
            mediaElement.Source = new Uri(listOfPlaylist[playlistIndex]);
            mediaElement.Play();

            buttons(true);
            shuffleButton.IsEnabled = true;

        }

        private void startNext(object sender, RoutedEventArgs e)
        {
            playlistIndex++;
            if (playlistIndex >= 0 && playlistIndex < listOfPlaylist.Count)
            {
                mediaElement.Source = new Uri(listOfPlaylist[playlistIndex]);
                mediaElement.Play();

                showPlaylist.SelectedIndex = playlistIndex;
            }

            if (playlistIndex == listOfPlaylist.Count)
            {
                playlistIndex = -1;
            }
        }

        private void listDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Console.WriteLine(showPlaylist.SelectedIndex);
            //Console.WriteLine(listOfPlaylist[showPlaylist.SelectedIndex]);
            showPlaylist.SelectedIndex = showPlaylist.SelectedIndex;
            playlistIndex = showPlaylist.SelectedIndex;
            mediaElement.Source = new Uri(listOfPlaylist[playlistIndex]);
            mediaElement.Play();
        }

        private void ShuffleList(List<string> list)
        {
            int lastIndex = list.Count - 1;
            while(lastIndex > 0)
            {
                string temp = list[lastIndex];
                int randomIndex = new Random().Next(0, lastIndex);
                list[lastIndex] = list[randomIndex];
                list[randomIndex] = temp;
                lastIndex--;
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            //Console.WriteLine(string.Join(", ", listOfPlaylist));
            if(listOfPlaylist.Count <= 0)
            {
                return;
            }

            ShuffleList(listOfPlaylist);
            showPlaylist.Items.Clear();

            foreach(string file in listOfPlaylist)
            {
                showPlaylist.Items.Add(getName(file));
            }

            showPlaylist.SelectedIndex = 0;
            playlistIndex = 0;
            mediaElement.Source = new Uri(listOfPlaylist[playlistIndex]);
            mediaElement.Play();
            //Console.WriteLine(string.Join(", ", listOfPlaylist));
        }
    }
}

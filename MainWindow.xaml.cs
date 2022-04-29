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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Spotify
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Albom> albMus;//alboms
        List<Music> listMusic;//music
        FileManage fl;
        Albom likeSongs;
        Player player_music = new Player();

        public MainWindow()
        {
            InitializeComponent();
            albMus = new List<Albom>();
            listMusic = new List<Music>();
            fl = new FileManage();

            albMus = fl.LoadFromJson();
            likeSongs = fl.LoadFromJsonLikedSongs();
            listMusic = fl.LoadFromJsonMusic("likedSongMusic");
            Col1.Width = new GridLength(0.3, GridUnitType.Star);
            musicAlbum.ItemsSource = albMus;
            TrakMusic.ItemsSource = listMusic;
            DataContext = likeSongs;
        }

        private void listBoxPlayList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = listBoxPlayList.SelectedIndex;

            if (index != -1)
            {
                if (index == 0)
                {
                    requestAddMusic qm = new requestAddMusic();
                    qm.Owner = mainWindow;

                    if (qm.ShowDialog() == true)
                    {
                        albMus.Add(qm.temp);
                        fl.SaveJson(albMus);
                        musicAlbum.Items.Refresh();
                    }
                    listBoxPlayList.UnselectAll();
                }
                else if (index == 1)
                {
                    listMusic = fl.LoadFromJsonMusic("likedSongMusic");
                    TrakMusic.ItemsSource = listMusic;
                    DataContext = likeSongs;
                }
                musicAlbum.UnselectAll();
            }
        }

        private void musicAlbum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = musicAlbum.SelectedIndex;

            if (index != -1)
            {
                listBoxPlayList.UnselectAll();
                listMusic = fl.LoadFromJsonMusic(albMus[index].Name);
                TrakMusic.ItemsSource = listMusic;
                DataContext = albMus[index];
            }
        }

        private void AddMusic_Click(object sender, RoutedEventArgs e)//AddMusic
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                for(int i = 0; i < listMusic.Count; i++)
                {
                    if (listMusic[i].Path == fd.FileName)
                    {
                        MessageBox.Show("File already exists");
                        return;
                    }
                }
                Music trak = new Music();
                trak.Name = fd.SafeFileName;
                trak.Path = fd.FileName;
                listMusic.Add(trak);
                if (listBoxPlayList.SelectedIndex != 1)//if its no liked songs
                {
                    fl.SaveJsonMusic(albMus[musicAlbum.SelectedIndex].Name, listMusic);
                    TrakMusic.Items.Refresh();
                }
                else if(listBoxPlayList.SelectedIndex == 1)
                {
                    fl.SaveJsonMusic("likedSongMusic", listMusic);
                    TrakMusic.Items.Refresh();
                }
            }
        }
        //music selection(player)
        private void TrakMusic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = TrakMusic.SelectedIndex;

            if (index != -1)
            {
                player_music.OpenTrak(listMusic[index].Path, listMusic, index);
            }
            //TrakMusic.UnselectAll();
        }

        private void selectTrakChange_Click(object sender, RoutedEventArgs e)
        {
            if (TrakMusic.SelectedIndex != -1)
            {
                player_music.PausePlayPlayer();
            }
            else
            {
                if (listMusic.Count != 0)
                    TrakMusic.SelectedItem = listMusic[0];
            }
        }
        private void Next_Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (listMusic.Count != 0)
            {
                if (listMusic.Count - 1 != TrakMusic.SelectedIndex && TrakMusic.SelectedIndex != -1)
                    TrakMusic.SelectedItem = listMusic[TrakMusic.SelectedIndex + 1];
                else
                    TrakMusic.SelectedItem = listMusic[0];
            }
        }

        private void Last_Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (listMusic.Count != 0)
            {
                if (TrakMusic.SelectedIndex != 0 && TrakMusic.SelectedIndex != -1)
                    TrakMusic.SelectedItem = listMusic[TrakMusic.SelectedIndex - 1];
                else
                    TrakMusic.SelectedItem = listMusic[listMusic.Count - 1];
            }
        }
    }
}

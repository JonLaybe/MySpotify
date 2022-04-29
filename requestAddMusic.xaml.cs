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
using System.Windows.Shapes;

namespace Spotify
{
    /// <summary>
    /// Логика взаимодействия для requestAddMusic.xaml
    /// </summary>
    public partial class requestAddMusic : Window
    {
        public Albom temp;
        public requestAddMusic()
        {
            InitializeComponent();
            temp = new Albom();
            temp.Path = "None";
            DataContext = temp;
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void FotoAlbom_MouseDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == true)
            {
                temp.Path = fd.FileName;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (nameAlbom.Text != "")
            {
                temp.Name = nameAlbom.Text;
                this.DialogResult = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify
{
    public class Music : INotifyPropertyChanged
    {
        private string name;
        private string path;
        private string pathFoto;

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        public override string ToString()
        {
            return Name;
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }
        public string Path
        {
            get { return path; }
            set
            {
                path = value;
                RaisePropertyChanged("Path");
            }
        }
        public string PathFoto
        {
            get { return pathFoto; }
            set
            {
                pathFoto = value;
                RaisePropertyChanged("PathFoto");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace Spotify
{
    public class Player
    {
        private MediaPlayer player;
        private List<Music> musics;
        private int selectIndex;
        public bool playIsLive { get; set; }
        public Music trak { get; set; }
        public Player()
        {
            player = new MediaPlayer();
            trak = new Music();
        }
        private void Media_Ended(object sender, EventArgs e)
        {
            if (musics.Count - 1 > selectIndex)
            {
                OpenTrak(musics[selectIndex + 1].Path, musics, selectIndex + 1);
            }
        }
        public void NewPlayer()
        {
            trak = new Music();
            player = new MediaPlayer();
        }
        public void OpenTrak(string path, List<Music> musics, int selectIndex)
        {
            trak.Path = path;
            this.musics = musics;
            this.selectIndex = selectIndex;
            playIsLive = true;
            if (player.CanPause == true) {
                player.Close();
            }
            player.MediaEnded = Media_Ended;
            player.Open(new Uri(path, UriKind.Relative));
            player.Play();
        }
        public void PlayPlayer()
        {
            player.Play();
        }
        public void PausePlayPlayer()
        {
            if (player.CanPause == true && playIsLive == true)
            {
                playIsLive = false;
                player.Pause();
            }
            else
            {
                playIsLive = true;
                player.Play();
            }
        }
        /*~Player()
        {
            player.Close();
        }*/
    }
}

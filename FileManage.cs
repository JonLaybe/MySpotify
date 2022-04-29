using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;


namespace Spotify
{
    public class FileManage
    {
        public void SaveJson(List<Albom> alboms)
        {
            FileStream fs = new FileStream("users.txt", FileMode.OpenOrCreate);
            JsonSerializer.Serialize<List<Albom>>(fs, alboms);
            fs.Close();
        }
        public List<Albom> LoadFromJson()
        {
            List<Albom> temp = new List<Albom>();
            FileStream fs = new FileStream("users.txt", FileMode.OpenOrCreate);
            try
            {
                temp = JsonSerializer.Deserialize<List<Albom>>(fs);
            }
            catch (Exception) {}
            fs.Close();
            return temp;
        }
        //Liked Songs
        public void SaveJsonLikedSongs(Albom alboms)
        {
            FileStream fs = new FileStream("likedSongs.txt", FileMode.OpenOrCreate);
            JsonSerializer.Serialize<Albom>(fs, alboms);
            fs.Close();
        }
        public Albom LoadFromJsonLikedSongs()
        {
            try
            {
                FileStream fs = new FileStream("likedSongs.txt", FileMode.OpenOrCreate);
                try
                {
                    Albom temp = JsonSerializer.Deserialize<Albom>(fs);
                    fs.Close();
                    return temp;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                }
            }
            catch
            {
                MessageBox.Show("List 'Liked Song' not faund");
            }
            return null;
        }
        //Music
        public void SaveJsonMusic(string nameFile, List<Music> musics)
        {
            FileStream fs = new FileStream("Alboms\\" + nameFile + ".txt", FileMode.OpenOrCreate);
            JsonSerializer.Serialize<List<Music>>(fs, musics);
            fs.Close();
        }
        public List<Music> LoadFromJsonMusic(string nameFile)
        {
            List<Music> temp = new List<Music>();
            FileStream fs = new FileStream("Alboms\\" + nameFile + ".txt", FileMode.OpenOrCreate);
            try
            {
                temp = JsonSerializer.Deserialize<List<Music>>(fs);
            }
            catch (Exception) {}
            fs.Close();
            return temp;
        }
    }
}

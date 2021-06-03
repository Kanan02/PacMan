using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PacMan
{
    class XMLFileHandler
    {
        private string fileName;
        private XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Player>));
        public List<Player> Players { get; set; }
        public XMLFileHandler()
        {
            fileName = "players.xml";
            Players = new List<Player>();
        }
        public void CreateXmlFile()
        {
            try
            {
                using (Stream stream = File.Create(fileName))
                {
                    xmlSerializer.Serialize(stream, Players);
                }
                
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        public void LoadListToFile()
        {
            
            try
            {
                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    xmlSerializer.Serialize(stream, Players);
                }
                


            }
            catch (Exception)
            {
                throw;
            }
        }
        public void LoadDataToList()
        {

            try
            {


                using (Stream stream = File.Open(fileName, FileMode.Open))
                {
                    Players = (List<Player>)xmlSerializer.Deserialize(stream);
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void AddPlayer(Player player)
        {
            if (IsOldPlayer(player.Name))
            {
                if (Players.Where(x => x.Name == player.Name).ElementAt(0).Score < player.Score)
                {
                    Players.Remove(Players.Where(x => x.Name == player.Name).ElementAt(0));
                    Players.Add(player);
                }
            }
            else
            {
                Players.Add(player);
            }
        }

        public bool IsOldPlayer(string name)
        {
            LoadDataToList();
            foreach (var item in Players)
            {
                if (item.Name == name)
                {
                    return true;
                }
            }
            return false;
        }

    }
}

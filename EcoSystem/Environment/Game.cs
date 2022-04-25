using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EcoSystem
{
    public class Game
    {
        public Player player = new Player();
        public Vendor vendor = new Vendor();
        public Producer producer = new Producer();
        public Consumer consumer = new Consumer();
        public Decomposer decomposer = new Decomposer();
        public string GameName = "Ecosystem: Bracken Cave";

        public  List<Entity> Organisms = new List<Entity>();

      
        public void SetUpGame()
        {
            Organisms = LoadData.LoadEntities("data/Entities.xml");
            player.Inventory = LoadData.LoadItems("data/PlayerItems.xml");
            vendor.Inventory = LoadData.LoadItems("data/VendorItems.xml");
        }






    }
}

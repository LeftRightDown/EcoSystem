using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Windows.Media.Imaging;

namespace EcoSystem
{
    public class LoadData
    {

        //LoadData code from PROG 201 course Demo
        public static List<Entity> LoadEntities(string fileName)
        {
            List<Entity> entities = new List<Entity>();
            if (File.Exists(fileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlNode root = doc.DocumentElement;
                XmlNodeList entityList = root.SelectNodes("/environment/entity");
                foreach (XmlElement entity in entityList)
                {
                    Entity temp;
                    if (entity.GetAttribute("type") == "Producer")
                    {
                        temp = new Producer();
                        temp.Type = entity.GetAttribute("type");
                    }
                    else if (entity.GetAttribute("type") == "Consumer")
                    {
                        temp = new Consumer();
                        temp.Type = entity.GetAttribute("type");
                    }
                    else if (entity.GetAttribute("type") == "Decomposer")
                    {
                        temp = new Decomposer();
                        temp.Type = entity.GetAttribute("type");
                    }
                    else if (entity.GetAttribute("type") == "Player" || entity.GetAttribute("type") == "Vendor")
                    {
                        temp = new Persons();
                        temp.Type = entity.GetAttribute("type");
                    }
                    else
                    {
                        temp = new Entity();
                    }
                    temp.Name = entity.GetAttribute("name");
                    temp.Species = entity.GetAttribute("species");
                    if (temp.Type != "Player" || temp.Type != "Vendor")
                    {
                        temp.ImagePath = new BitmapImage(new Uri($"Images/{entity.GetAttribute("imagePath")} .png", UriKind.Relative));
                    }

                    if (int.TryParse(entity.GetAttribute("foodamount"), out int a))
                    {
                        temp.FoodAmount = a;
                    }

                    if (int.TryParse(entity.GetAttribute("amount"), out int b))
                    {
                        temp.Amount = b;
                    }

                    entities.Add(temp);
                    System.Diagnostics.Debug.WriteLine("HERE ARE ENTIRES" + "" + temp);
                }
            }
            return entities;

        }


        public static List<Item> LoadItems(string fileName)
        {

            List<Item> Items = new List<Item>();
            if (File.Exists(fileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlNode root = doc.DocumentElement;
                XmlNodeList itemsList = root.SelectNodes("/environment/item");
                foreach (XmlElement Item in itemsList)
                {
                    Items.Add(
                    new Item
                    {
                        Name = Item.GetAttribute("name"),
                        Description = Item.GetAttribute("description"),
                        Price = float.Parse(Item.GetAttribute("price")),
                        Quantity = float.Parse(Item.GetAttribute("quantity")),

                    });;
                }
            }
            return Items;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

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
                    }
                    else if (entity.GetAttribute("type") == "Consumer")
                    {
                        temp = new Consumer();
                    }
                    else if (entity.GetAttribute("type") == "Decomposer")
                    {
                        temp = new Decomposer();
                    }
                    else if (entity.GetAttribute("type") == "Player" || entity.GetAttribute("type") == "Vendor")
                    {
                        temp = new Persons();
                    }
                    else
                    {
                        temp = new Entity();
                    }
                    temp.Name = entity.GetAttribute("name");
                    temp.Species = entity.GetAttribute("species");
                    if (temp.Type != "Player" || temp.Type != "Vendor")
                    {
                        temp.ImagePath = "Images/" + entity.GetAttribute("imagePath") + ".png";
                    }
                    
                   
                    if (int.TryParse(entity.GetAttribute("amount"), out int a))
                    {
                        temp.Amount = a;
                    }
                    entities.Add(temp);
                    System.Diagnostics.Debug.WriteLine("HERE ARE ENTIRES" + "" + temp);
                }
            }
            return entities;
            
        }
    }
}

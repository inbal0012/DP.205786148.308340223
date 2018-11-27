using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;

namespace DP._205786148._308340223
{
    public class AppSettings
    {
        public Point LastWindowLocation { get; set; }
        public Size LastWindowSize { get; set; }
        public bool RememberUser { get; set; }
        public string LastAccessToken { get; set; }

        private AppSettings()
        {
            LastWindowLocation = new Point(20, 50);
            LastWindowSize = new Size(1000, 500);
            RememberUser = false;
            LastAccessToken = null;
        }

        public void SaveToFile()
        {
            if (!this.RememberUser)
            {
                LastWindowLocation = new Point(20, 50);
                LastWindowSize = new Size(1000, 500);
                RememberUser = false;
                LastAccessToken = null;
            }

            if (File.Exists(@"D:/appSettings.xml"))
            {
                using (Stream stream = new FileStream(@"D:/appSettings.xml", FileMode.Truncate))
                {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());
                    serializer.Serialize(stream, this);
                }
            }
            else
            {
                using (Stream stream = new FileStream(@"D:/appSettings.xml", FileMode.CreateNew))
                {
                    XmlSerializer serializer = new XmlSerializer(this.GetType());
                    serializer.Serialize(stream, this);
                }
            }

        }

        public static AppSettings LoadFromFile()
        {
            AppSettings obj = new AppSettings();
            if (File.Exists(@"D:/appSettings.xml"))
            {
                using (Stream stream = new FileStream(@"D:/appSettings.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                    obj = serializer.Deserialize(stream) as AppSettings;
                }
            }

            return obj;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace GenesysCharacterCreator
{
    class FileInterface
    {
        public static void SaveCharacter(Character c, string Filename)
        {
            XmlSerializer xmlSerial = XmlSerializer.FromTypes(new[] { typeof(Character) })[0];
            try
            {
                using (Stream fStream = new FileStream(Filename, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlSerial.Serialize(fStream, c);
                }

            }
            catch (Exception)
            {

            }
        }

        public static Character ReadCharacter(string Filename)
        {
            if (File.Exists(Filename))
            {
                try
                {
                    Character c;
                    XmlSerializer xmlSerial = XmlSerializer.FromTypes(new[] { typeof(Character) })[0];
                    using (Stream fStream = new FileStream(Filename, FileMode.Open, FileAccess.Read, FileShare.None))
                    {
                        c = (Character)xmlSerial.Deserialize(fStream);
                    }
                    return c;
                }
                catch { return null; }
            }
            else return null;
        }
    }
}

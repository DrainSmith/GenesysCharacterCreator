using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Windows;

namespace GenesysCharacterCreator
{
    public static class Globals
    {
        public static List<Skill> BaseSkills = new List<Skill>();
        public static List<Archetype> BaseArchetypes = new List<Archetype>();
        public static List<Career> BaseCareers = new List<Career>();
        public static List<Setting> BaseSettings = new List<Setting>();
        public static List<Character> Characters = new List<Character>();
        public static MainWindow main;

        public static void AddBaseSetting(Setting setting)
        {
            DeleteBaseSetting(setting);
            BaseSettings.Add(setting);
            BaseSettings = BaseSettings.OrderBy(s => s.Name).ToList();
        }

        public static void DeleteBaseSetting(Setting setting)
        {
            var se = BaseSettings.Find(s => s.Name == setting.Name);
            if (se != null)
                BaseSettings.Remove(se);
        }

        public static void ReadBaseSettings()
        {
            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(appDataPath);
            string settingsPath = Path.Combine(appDataPath, @"settings.xml");
            if (File.Exists(settingsPath))
            {
                XmlSerializer xmlSerial = XmlSerializer.FromTypes(new[] { typeof(List<Setting>) })[0];
                using (Stream fStream = new FileStream(settingsPath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    BaseSettings = (List<Setting>)xmlSerial.Deserialize(fStream);
                }
                BaseSettings = BaseSettings.OrderBy(s => s.Name).ToList();
            }
        }

        public static void WriteBaseSettings()
        {
            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(appDataPath);
            string settingsPath = Path.Combine(appDataPath, @"settings.xml");
            XmlSerializer xmlSerial = XmlSerializer.FromTypes(new[] { typeof(List<Setting>) })[0];
            try
            {
                using (Stream fStream = new FileStream(settingsPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlSerial.Serialize(fStream, BaseSettings);
                }

            }
            catch (Exception)
            {

            }
        }

        public static void AddBaseCareer(Career career)
        {
            DeleteBaseCareer(career);
            BaseCareers.Add(career);
            BaseCareers = BaseCareers.OrderBy(c => c.Name).ToList();
        }

        public static void DeleteBaseCareer(Career career)
        {
            var ca = BaseCareers.Find(a => a.Name == career.Name);
            if (ca != null)
                BaseCareers.Remove(ca);
        }

        public static void ReadBaseCareers()
        {
            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(appDataPath);
            string settingsPath = Path.Combine(appDataPath, @"careers.xml");
            if (File.Exists(settingsPath))
            {
                XmlSerializer xmlSerial = XmlSerializer.FromTypes(new[] { typeof(List<Career>) })[0];
                using (Stream fStream = new FileStream(settingsPath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    BaseCareers = (List<Career>)xmlSerial.Deserialize(fStream);
                }
                BaseSkills = BaseSkills.OrderBy(s => s.Name).ToList();
            }
        }

        public static void WriteBaseCareers()
        {
            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(appDataPath);
            string settingsPath = Path.Combine(appDataPath, @"careers.xml");
            XmlSerializer xmlSerial = XmlSerializer.FromTypes(new[] { typeof(List<Career>) })[0];
            try
            {
                using (Stream fStream = new FileStream(settingsPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlSerial.Serialize(fStream, BaseCareers);
                }

            }
            catch (Exception)
            {

            }
        }

        public static void AddBaseArchtype(Archetype archetype)
        {
            DeleteBaseArchtype(archetype);
            BaseArchetypes.Add(archetype);
            BaseArchetypes = BaseArchetypes.OrderBy(a => a.Name).ToList();
        }

        public static void DeleteBaseArchtype(Archetype archetype)
        {
            var ar = BaseArchetypes.Find(a => a.Name == archetype.Name);
            if (ar != null)
                BaseArchetypes.Remove(ar);
        }

        public static void ReadBaseArchtypes()
        {
            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(appDataPath);
            string settingsPath = Path.Combine(appDataPath, @"archetypes.xml");
            if (File.Exists(settingsPath))
            {
                XmlSerializer xmlSerial = XmlSerializer.FromTypes(new[] { typeof(List<Archetype>) })[0];
                using (Stream fStream = new FileStream(settingsPath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    BaseArchetypes = (List<Archetype>)xmlSerial.Deserialize(fStream);
                }
                BaseArchetypes = BaseArchetypes.OrderBy(s => s.Name).ToList();
            }
        }

        public static void WriteBaseArchtypes()
        {
            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(appDataPath);
            string settingsPath = Path.Combine(appDataPath, @"archetypes.xml");
            XmlSerializer xmlSerial = XmlSerializer.FromTypes(new[] { typeof(List<Archetype>) })[0];
            try
            {
                using (Stream fStream = new FileStream(settingsPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlSerial.Serialize(fStream, BaseArchetypes);
                }

            }
            catch (Exception)
            {

            }
        }

        public static void AddBaseSkill(Skill skill)
        {
            DeleteBaseSkill(skill);
            BaseSkills.Add(skill);
            BaseSkills = BaseSkills.OrderBy(s => s.Name).ToList();
        }

        public static void DeleteBaseSkill(Skill skill)
        {
            var sk = BaseSkills.Find(s => s.Name == skill.Name);
            if (sk != null)
                BaseSkills.Remove(sk);
        }

        public static void ReadBaseSkills()
        {
            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(appDataPath);
            string settingsPath = Path.Combine(appDataPath, @"skills.xml");
            if (File.Exists(settingsPath))
            {
                XmlSerializer xmlSerial = XmlSerializer.FromTypes(new[] { typeof(List<Skill>) })[0];
                using (Stream fStream = new FileStream(settingsPath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    BaseSkills = (List<Skill>)xmlSerial.Deserialize(fStream);
                }
                BaseSkills = BaseSkills.OrderBy(s => s.Name).ToList();
            }
        }

        public static void WriteBaseSkills()
        {
            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(appDataPath);
            string settingsPath = Path.Combine(appDataPath, @"skills.xml");
            XmlSerializer xmlSerial = XmlSerializer.FromTypes(new[] { typeof(List<Skill>) })[0];
            try
            {
                using (Stream fStream = new FileStream(settingsPath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    xmlSerial.Serialize(fStream, BaseSkills);
                }

            }
            catch (Exception)
            {

            }
        }



        public static void ReadCharacters()
        {
            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(appDataPath);
            string settingsPath = Path.Combine(appDataPath, @"characters.xml");
            if (File.Exists(settingsPath))
            {
                XmlSerializer xmlSerial = XmlSerializer.FromTypes(new[] { typeof(List<Character>) })[0];
                using (Stream fStream = new FileStream(settingsPath, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    Characters = (List<Character>)xmlSerial.Deserialize(fStream);
                }
                Characters = Characters.OrderBy(s => s.Name).ToList();
            }
        }
    }
}

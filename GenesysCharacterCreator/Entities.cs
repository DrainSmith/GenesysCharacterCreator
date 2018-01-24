using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GenesysCharacterCreator
{
    public class Character
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public int Brawn { get; set; } = 1;
        public int Agility { get; set; } = 1;
        public int Intellect { get; set; } = 1;
        public int Cunning { get; set; } = 1;
        public int Willpower { get; set; } = 1;
        public int Presence { get; set; } = 1;
        public int WoundThreshold { get; set; }
        public int StrainThreshold { get; set; }
        public int SoakValue { get; set; }
        public int DefenseRanged { get; set; }
        public int DefenseMelee { get; set; }
        public string Archetype { get; set; }
        public string Career { get; set; }

        public string Desire { get; set; }
        public string Fear { get; set; }
        public string Strength { get; set; }
        public string Flaw { get; set; }
        public string Gender { get; set; }
        public string Height { get; set; }
        public string Build { get; set; }
        public string Age { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public string NotableFeatures { get; set; }
        public string Notes { get; set; }

        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<Talent> Talents { get; set; } = new List<Talent>();
        public int AvailableXp { get; set; }
        public int TotalXp { get; set; }

        public override string ToString()
        {
            return Name + "(" + Archetype + "," + Career + ")";
        }

    }

    public class Talent
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public int Tier { get; set; }
        public string Description { get; set; }
    }

    public class Skill : INotifyPropertyChanged
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();
        private string _name;
        public string Name { get { return OutputName(); } set { _name = value; } }
        private int _rank;
        public int Rank { get { return _rank; } set { _rank = value; OnPropertyChanged("Rank"); } }
        public int StartingRank { get; set; }

        private bool _isCareer;
        public bool IsCareer { get { return _isCareer; } set { _isCareer = value; OnPropertyChanged("IsCareer"); } }
        public string Description { get; set; }
        public Characteristic LinkedCharacteristic { get; set; }

        private string OutputName()
        {
            string c = "";
            switch (LinkedCharacteristic)
            {
                case Characteristic.Agility: c = " (Ag)"; break;
                case Characteristic.Brawn: c = " (Br)"; break;
                case Characteristic.Cunning: c = " (Cun)"; break;
                case Characteristic.Intellect: c = " (Int)"; break;
                case Characteristic.Presence: c = " (Pr)"; break;
                case Characteristic.Willpower: c = " (Will)"; break;
            }
            return _name + c;
        }

        public override string ToString()
        {
            return OutputName();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }



    public enum Characteristic
    {
        None,
        Brawn,
        Agility,
        Intellect,
        Cunning,
        Willpower,
        Presence
    }

    public class Spell
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsConcentration { get; set; }
        public List<Skill> MagicSkills { get; set; } = new List<Skill>();
    }

    public class Career
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Setting
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public List<Skill> Skills { get; set; } = new List<Skill>();
        public List<Career> Careers { get; set; } = new List<Career>();
        public List<Archetype> Archetypes { get; set; } = new List<Archetype>();
        public override string ToString()
        {
            return Name;
        }
    }

    public class SpecialAbility
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public class Archetype
    {
        public string GUID { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public int Brawn { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Cunning { get; set; }
        public int Willpower { get; set; }
        public int Presence { get; set; }

        public int WoundThreshold { get; set; } // + brawn
        public int StrainThreshold { get; set; } // + willpower

        public int StartingXP { get; set; }

        public List<SpecialAbility> SpecialAbilities { get; set; } = new List<SpecialAbility>();
        public List<Skill> StartingSkills { get; set; } = new List<Skill>();

        public override string ToString()
        {
            return Name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GenesysCharacterCreator
{
    /// <summary>
    /// Interaction logic for ApplyExperienceWindow.xaml
    /// </summary>
    public partial class ApplyExperienceWindow : Window
    {
        int CurrentExperience = 100;

        Setting _setting;
        Archetype _archetype;
        Career _career;
        Character _character;

        public ApplyExperienceWindow(Setting setting, Archetype archetype, Career career, Character character)
        {
            InitializeComponent();
            _setting = setting;
            _archetype = archetype;
            _career = career;
            _character = character;
            CurrentExperience = _archetype.StartingXP;

            AvailableExperience.Value = CurrentExperience;
            TotalExperience.Value = CurrentExperience;
            
        }

        public ApplyExperienceWindow(Character character)
        {
            _character = character;
        }

        public void AddSkills()
        {
            int count = 0;
            foreach (var s in _setting.Skills)
            {
                var cs = _career.Skills.Find(skill => skill.Name.Contains(s.Name)); // so that Melee and Ranged fall back for the setting works
                if (cs != null)
                    s.IsCareer = true;
                else s.IsCareer = false;

                cs = _character.Skills.Find(skill => skill.Name.Contains(s.Name));
                if (cs != null)
                    s.Rank = cs.StartingRank;

                var sc = new SkillControl();
                sc.EnforceStartMax = false;
                sc.Margin = new Thickness(0, 1, 0, 1);
                Binding b = new Binding("CharacteristicValue");
                switch (s.LinkedCharacteristic)
                {
                    case Characteristic.Agility: b.Source = AgilityCharacteristic; break;
                    case Characteristic.Brawn: b.Source = BrawnCharacteristic; break;
                    case Characteristic.Cunning: b.Source = CunningCharacteristic; break;
                    case Characteristic.Intellect: b.Source = IntellectCharacteristic; break;
                    case Characteristic.Presence: b.Source = PresenceCharacteristic; break;
                    case Characteristic.Willpower: b.Source = WillpowerCharacteristic; break;
                }
                b.Path = new PropertyPath("CharacteristicValue");
                sc.SetBinding(SkillControl.LinkedCharacteristicValueProperty, b);
                sc.OnXPEvent += XpEvent;
                if (count < _setting.Skills.Count /2)
                    GeneralSkillsPanel.Children.Add(sc);
                else SkillsPanel2.Children.Add(sc);
                sc.MySkill = s;
                count++;
            }
            _character.Skills = _setting.Skills;
        }

        private void titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void BrawnUp_Click(object sender, UpEventArgs e)
        {
            BrawnCharacteristic.ValueUp();
        }

        private void BrawnDown_Click(object sender, DownEventArgs e)
        {
            BrawnCharacteristic.ValueDown();
        }

        private void AgilityUp_Click(object sender, UpEventArgs e)
        {
            AgilityCharacteristic.ValueUp();
        }

        private void AgilityDown_Click(object sender, DownEventArgs e)
        {
            AgilityCharacteristic.ValueDown();
        }

        private void IntellectUp_Click(object sender, UpEventArgs e)
        {
            IntellectCharacteristic.ValueUp();
        }

        private void IntellectDown_Click(object sender, DownEventArgs e)
        {
            IntellectCharacteristic.ValueDown();
        }

        private void CunningUp_Click(object sender, UpEventArgs e)
        {
            CunningCharacteristic.ValueUp();
        }

        private void CunningDown_Click(object sender, DownEventArgs e)
        {
            CunningCharacteristic.ValueDown();
        }

        private void WillpowerUp_Click(object sender, UpEventArgs e)
        {
            WillpowerCharacteristic.ValueUp();
        }

        private void WillpowerDown_Click(object sender, DownEventArgs e)
        {
            WillpowerCharacteristic.ValueDown();
        }

        private void PresenceUp_Click(object sender, UpEventArgs e)
        {
            PresenceCharacteristic.ValueUp();
        }

        private void PresenceDown_Click(object sender, DownEventArgs e)
        {
            PresenceCharacteristic.ValueDown();
        }

        private void XpEvent(object sender, ExperienceCostEventArgs e)
        {
            CurrentExperience -= e.Cost;
            
            AvailableExperience.Value = CurrentExperience;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            BrawnCharacteristic.CharacteristicStartValue = _archetype.Brawn;
            AgilityCharacteristic.CharacteristicStartValue = _archetype.Agility;
            CunningCharacteristic.CharacteristicStartValue = _archetype.Cunning;
            IntellectCharacteristic.CharacteristicStartValue = _archetype.Intellect;
            PresenceCharacteristic.CharacteristicStartValue = _archetype.Presence;
            WillpowerCharacteristic.CharacteristicStartValue = _archetype.Willpower;
            AddSkills();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _character.Name = NameTextBox.Text;
            _character.WoundThreshold = WoundStatControl.BaseValue;
            _character.StrainThreshold = StrainStatControl.BaseValue;
            _character.SoakValue = SoakValueStatControl.BaseValue;
            _character.Brawn = BrawnCharacteristic.CharacteristicValue;
            _character.Agility = AgilityCharacteristic.CharacteristicValue;
            _character.Cunning = CunningCharacteristic.CharacteristicValue;
            _character.Intellect = IntellectCharacteristic.CharacteristicValue;
            _character.Presence = PresenceCharacteristic.CharacteristicValue;
            _character.Willpower = WillpowerCharacteristic.CharacteristicValue;
            _character.AvailableXp = AvailableExperience.Value;
            _character.Career = _career.Name;
            _character.Archetype = _archetype.Name;
            Globals.SaveCharacter(_character);

            this.Close();
        }
    }
}

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
    /// Interaction logic for ChooseStartingSkillsWindow.xaml
    /// </summary>
    public partial class ChooseStartingSkillsWindow : Window
    {
        Setting _setting;
        Archetype _archetype;
        Career _career;

        List<Skill> AssignedSkills = new List<Skill>();
        List<Skill> AvailableSkills = new List<Skill>();

        public ChooseStartingSkillsWindow(Setting setting, Archetype archetype, Career career)
        {
            InitializeComponent();
            _setting = setting;
            _archetype = archetype;
            _career = career;
            foreach (var skill in _career.Skills)
            {
                var archSkill = archetype.StartingSkills.Find(s => s.Name == skill.Name);
                if (archSkill == null)
                    AvailableSkills.Add(skill);
            }
            SetSkillsToLists();
        }

        private void SetSkillsToLists()
        {
            AvailableSkillsListBox.Items.Clear();
            AssignedSkillsListBox.Items.Clear();
            AvailableSkills = AvailableSkills.OrderBy(s => s.Name).ToList();
            AssignedSkills = AssignedSkills.OrderBy(s => s.Name).ToList();
            foreach (var s in AvailableSkills)
                AvailableSkillsListBox.Items.Add(s);
            foreach (var s in AssignedSkills)
                AssignedSkillsListBox.Items.Add(s);
        }

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            var c = new Character();
            c.Agility = _archetype.Agility;
            c.Brawn = _archetype.Brawn;
            c.Cunning = _archetype.Cunning;
            c.Intellect = _archetype.Intellect;
            c.Presence = _archetype.Presence;
            c.Willpower = _archetype.Willpower;
            c.WoundThreshold = _archetype.WoundThreshold;
            c.StrainThreshold = _archetype.StrainThreshold;
            c.Skills = AssignedSkills;
            var w = new ApplyExperienceWindow(_setting, _archetype, _career, c);
            w.Show();
            this.Close();
        }

        private void AvailableSkills_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AvailableSkillsListBox.SelectedIndex != -1 && AssignedSkills.Count < 4)
            {
                Skill s = (Skill)AvailableSkillsListBox.SelectedItem;
                s.StartingRank = 1;
                AvailableSkills.Remove(s);
                AssignedSkills.Add(s);
                SetSkillsToLists();
            }
        }

        private void AssignedSkills_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AssignedSkillsListBox.SelectedIndex != -1)
            {
                Skill s = (Skill)AssignedSkillsListBox.SelectedItem;
                s.StartingRank = 0;
                AvailableSkills.Add(s);
                AssignedSkills.Remove(s);
                SetSkillsToLists();
            }
        }
    }
}

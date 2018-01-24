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
    /// Interaction logic for SettingBuilderWindow.xaml
    /// </summary>
    public partial class SettingBuilderWindow : Window
    {
        List<Skill> AvailableSkills = new List<Skill>();
        List<Skill> AssignedSkills = new List<Skill>();

        List<Career> AvailableCareers = new List<Career>();
        List<Career> AssignedCareers = new List<Career>();

        List<Archetype> AvailableArchetypes = new List<Archetype>();
        List<Archetype> AssignedArchetypes = new List<Archetype>();

        public SettingBuilderWindow()
        {
            InitializeComponent();
            foreach (var s in Globals.BaseSkills)
            {
                AvailableSkills.Add(s);
            }
            foreach (var c in Globals.BaseCareers)
            {
                AvailableCareers.Add(c);
            }
            foreach (var a in Globals.BaseArchetypes)
            {
                AvailableArchetypes.Add(a);
            }

            SetCareersToLists();
            SetSkillsToLists();
            SetArchetypesToLists();
        }

        public SettingBuilderWindow(Setting setting)
        {

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

        private void SetCareersToLists()
        {
            AvailableCareersListBox.Items.Clear();
            AssignedCareersListBox.Items.Clear();
            AvailableCareers = AvailableCareers.OrderBy(s => s.Name).ToList();
            AssignedCareers = AssignedCareers.OrderBy(s => s.Name).ToList();
            foreach (var s in AvailableCareers)
                AvailableCareersListBox.Items.Add(s);
            foreach (var s in AssignedCareers)
                AssignedCareersListBox.Items.Add(s);
        }

        private void SetArchetypesToLists()
        {
            AvailableArchetypesListBox.Items.Clear();
            AssignedArchetypesListBox.Items.Clear();
            AvailableArchetypes = AvailableArchetypes.OrderBy(s => s.Name).ToList();
            AssignedArchetypes = AssignedArchetypes.OrderBy(s => s.Name).ToList();
            foreach (var s in AvailableArchetypes)
                AvailableArchetypesListBox.Items.Add(s);
            foreach (var s in AssignedArchetypes)
                AssignedArchetypesListBox.Items.Add(s);
        }

        private void AvailableCareers_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AvailableCareersListBox.SelectedIndex != -1)
            {
                Career c = (Career)AvailableCareersListBox.SelectedItem;
                AssignedCareers.Add(c);
                AvailableCareers.Remove(c);
                SetCareersToLists();
            }
        }

        private void AssignedCareers_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AssignedCareersListBox.SelectedIndex != -1)
            {
                Career c = (Career)AssignedCareersListBox.SelectedItem;
                AvailableCareers.Add(c);
                AssignedCareers.Remove(c);
                SetCareersToLists();
            }
        }

        private void AvailableSkills_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AvailableSkillsListBox.SelectedIndex != -1)
            {
                Skill s = (Skill)AvailableSkillsListBox.SelectedItem;
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
                AvailableSkills.Add(s);
                AssignedSkills.Remove(s);
                SetSkillsToLists();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var setting = new Setting();
            foreach (var s in AssignedSkills)
            {
                setting.Skills.Add(s);
            }

            foreach (var c in AssignedCareers)
            {
                setting.Careers.Add(c);
            }

            foreach (var a in AssignedArchetypes)
                setting.Archetypes.Add(a);

            setting.Name = NameTextBox.Text;

            Globals.AddBaseSetting(setting);
            Globals.WriteBaseSettings();
            this.Close();
        }

        private void AvailableArchetype_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AvailableArchetypesListBox.SelectedIndex != -1)
            {
                Archetype a = (Archetype)AvailableArchetypesListBox.SelectedItem;
                AvailableArchetypes.Remove(a);
                AssignedArchetypes.Add(a);
                SetArchetypesToLists();
            }
        }

        private void AssignedArchetype_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AssignedArchetypesListBox.SelectedIndex != -1)
            {
                Archetype s = (Archetype)AssignedArchetypesListBox.SelectedItem;
                AvailableArchetypes.Add(s);
                AssignedArchetypes.Remove(s);
                SetArchetypesToLists();
            }
        }
    }
}

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
    /// Interaction logic for CareerEditorWindow.xaml
    /// </summary>
    public partial class CareerEditorWindow : Window
    {
        List<Skill> AvailableSkills = new List<Skill>();
        List<Skill> AssignedSkills = new List<Skill>();

        public CareerEditorWindow()
        {
            InitializeComponent();
            foreach (var s in Globals.BaseSkills)
            {
                AvailableSkills.Add(s);
            }
            SetSkillsToLists();
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var c = new Career();
            c.Name = NameTextBox.Text;
            foreach (var ca in AssignedSkills)
            {
                c.Skills.Add(ca);
            }
            Globals.AddBaseCareer(c);
            Globals.WriteBaseCareers();
            this.Close();
        }

        private void AvailableSkills_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AvailableSkillsListBox.SelectedIndex != -1)
            {
                Skill s = (Skill)AvailableSkillsListBox.SelectedItem;
                //if (s.Name != "{Any}")
                //    AvailableSkills.Remove(s);
                AssignedSkills.Add(s);
                AvailableSkills.Remove(s);
                SetSkillsToLists();
            }
        }

        private void AssignedSkills_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AssignedSkillsListBox.SelectedIndex != -1)
            {
                Skill s = (Skill)AssignedSkillsListBox.SelectedItem;
                //if (s.Name != "{Any}")
                //    AvailableSkills.Add(s);
                s.StartingRank = 0;
                AvailableSkills.Add(s);
                AssignedSkills.Remove(s);

                SetSkillsToLists();
            }
        }
    }
}

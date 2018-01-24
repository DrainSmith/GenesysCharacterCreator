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
    /// Interaction logic for ChooseAnySkillWindow.xaml
    /// </summary>
    public partial class ChooseSkillsWindow : Window
    {
        public List<Skill> ChosenSkills = new List<Skill>();
        List<Skill> AvailableSkills = new List<Skill>();

        public ChooseSkillsWindow()
        {
            InitializeComponent();
            foreach (var s in Globals.BaseSkills)
            {
                ChosenSkills.Add(s);
            }
            SetSkillsToLists();
        }

        private void SetSkillsToLists()
        {
            AvailableSkillsListBox.Items.Clear();
            AssignedSkillsListBox.Items.Clear();
            AvailableSkills = AvailableSkills.OrderBy(s => s.Name).ToList();
            ChosenSkills = ChosenSkills.OrderBy(s => s.Name).ToList();
            foreach (var s in AvailableSkills)
                AvailableSkillsListBox.Items.Add(s);
            foreach (var s in ChosenSkills)
                AssignedSkillsListBox.Items.Add(s);
        }


        private void AvailableSkills_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AvailableSkillsListBox.SelectedIndex != -1)
            {
                Skill s = (Skill)AvailableSkillsListBox.SelectedItem;
                AvailableSkills.Remove(s);
                ChosenSkills.Add(s);
                SetSkillsToLists();
            }
        }

        private void AssignedSkills_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AssignedSkillsListBox.SelectedIndex != -1)
            {
                Skill s = (Skill)AssignedSkillsListBox.SelectedItem;
                AvailableSkills.Add(s);
                ChosenSkills.Remove(s);
                SetSkillsToLists();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }

        private void titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}

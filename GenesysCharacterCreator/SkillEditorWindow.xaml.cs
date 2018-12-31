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
    /// Interaction logic for SkillEditorWindow.xaml
    /// </summary>
    public partial class SkillEditorWindow : Window
    {
        public SkillEditorWindow()
        {
            InitializeComponent();
            //Globals.ReadSkills();
            UpdateSkills();
        }

        private void UpdateSkills()
        {
            SkillListBox.Items.Clear();
            foreach (var s in Globals.BaseSkills)
            {
                SkillListBox.Items.Add(s);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != string.Empty && LinkedCharacteristicListBox.SelectedIndex != -1)
            {
                var s = new Skill();
                s.Name = NameTextBox.Text;
                s.LinkedCharacteristic = (Characteristic)LinkedCharacteristicListBox.SelectedItem;
                s.Description = DescriptionTextBox.Text;
                Globals.AddBaseSkill(s);
                UpdateSkills();
                Globals.WriteBaseSkills();
                NameTextBox.Text = "";
                LinkedCharacteristicListBox.SelectedIndex = -1;
                DescriptionTextBox.Text = "";
            }
        }

        private void SkillListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SkillListBox.SelectedIndex != -1)
            {
                Skill s = (Skill)SkillListBox.SelectedItem;
                NameTextBox.Text = s.Name;
                LinkedCharacteristicListBox.SelectedItem = s.LinkedCharacteristic;
                DescriptionTextBox.Text = s.Description;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SkillListBox.SelectedIndex != -1)
            {
                Skill s = (Skill)SkillListBox.SelectedItem;
                Globals.DeleteBaseSkill(s);
                UpdateSkills();
            }
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}

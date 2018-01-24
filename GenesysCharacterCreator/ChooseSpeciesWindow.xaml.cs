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
    /// Interaction logic for ChooseSpeciesWindow.xaml
    /// </summary>
    public partial class ChooseSpeciesWindow : Window
    {
        Setting _setting;

        public ChooseSpeciesWindow( Setting setting)
        {
            InitializeComponent();
            _setting = setting;
            foreach (var s in _setting.Archetypes)
                ArchetypeListBox.Items.Add(s);
        }

        private void titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ArchetypeListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ArchetypeListBox.SelectedIndex != -1)
            {
                Archetype a = (Archetype)ArchetypeListBox.SelectedItem;
                var w = new ChooseCareerWindow(_setting, a);
                w.Show();
                this.Close();
            }
        }

        private void ArchetypeListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ArchetypeListBox.SelectedIndex != -1)
            {
                Archetype a = (Archetype)ArchetypeListBox.SelectedItem;
                DescriptionTextBox.Text = a.Description;
            }
        }
    }
}

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
    /// Interaction logic for ChooseCareerWindow.xaml
    /// </summary>
    public partial class ChooseCareerWindow : Window
    {
        Setting _setting;
        Archetype _archetype;

        public ChooseCareerWindow(Setting setting, Archetype archetype)
        {
            InitializeComponent();
            _setting = setting;
            _archetype = archetype;
            foreach (var c in setting.Careers)
            {
                CareerListBox.Items.Add(c);
            }
        }

        private void titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CareerListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //TODO ChooseStartingSkillsWindow
            if (CareerListBox.SelectedIndex != -1)
            {
                Career c = (Career)CareerListBox.SelectedItem;
                var w = new ChooseStartingSkillsWindow(_setting, _archetype, c);
                w.Show();
                this.Close();
            }
        }

        private void CareerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CareerListBox.SelectedIndex != -1)
            {
                Career a = (Career)CareerListBox.SelectedItem;
                DescriptionTextBox.Text = a.Description;
            }
        }
    }
}

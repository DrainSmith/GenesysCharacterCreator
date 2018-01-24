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
    /// Interaction logic for ChooseSettingWindow.xaml
    /// </summary>
    public partial class ChooseSettingWindow : Window
    {
        public ChooseSettingWindow()
        {
            InitializeComponent();
            foreach (var s in Globals.BaseSettings)
            {
                SettingListBox.Items.Add(s);
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

        private void SettingListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (SettingListBox.SelectedIndex != -1)
            {
                Setting s = (Setting)SettingListBox.SelectedItem;
                var w = new ChooseSpeciesWindow(s);
                w.Show();
                this.Close();
            }
        }
    }
}

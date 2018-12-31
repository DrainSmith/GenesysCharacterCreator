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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GenesysCharacterCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Globals.ReadBaseSkills();
            Globals.ReadBaseCareers();
            Globals.ReadBaseArchtypes();
            Globals.ReadBaseSettings();
            Globals.ReadCharacters();
            RefreshCharacters();
            Globals.main = this;
        }

        public void RefreshCharacters()
        {
            CharactersListBox.Items.Clear();
            foreach (var c in Globals.Characters)
                CharactersListBox.Items.Add(c);
            if (Globals.Characters.Count > 0)
                NoCharactersText.Visibility = Visibility.Hidden;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void EditSettingsButton_Click(object sender, RoutedEventArgs e)
        {
            var sb = new SettingBuilderWindow();
            sb.Show();
        }

        private void SkillsEditorButton_Click(object sender, RoutedEventArgs e)
        {
            var skillEdit = new SkillEditorWindow();
            skillEdit.Show();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new ChooseSettingWindow();
            w.Show();
        }

        private void ArchetypeEditorButton_Click(object sender, RoutedEventArgs e)
        {
            var w = new ArchetypeEditorWindow();
            w.Show();
        }

        private void CareerEditorButton_Click(object sender, RoutedEventArgs e)
        {
            var c = new CareerEditorWindow();
            c.Owner = this;
            c.Show();
        }

        private void CharactersListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (CharactersListBox.SelectedIndex != -1)
            {
                CharacterSheetWindow csw = new CharacterSheetWindow((Character)CharactersListBox.SelectedItem);
                
                csw.Show();
            }
        }
    }
}

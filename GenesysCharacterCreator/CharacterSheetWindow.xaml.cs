using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for CharacterSheetWindow.xaml
    /// </summary>
    public partial class CharacterSheetWindow : Window
    {

        public Character MyCharacter
        {
            get { return (Character)GetValue(CharacterProperty); }
            set { SetValue(CharacterProperty, value); OnPropertyChanged(new PropertyChangedEventArgs("Character")); }
        }

        public static DependencyProperty CharacterProperty = DependencyProperty.Register("Character", typeof(Character), typeof(CharacterSheetWindow), new PropertyMetadata(new Character()));

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        public CharacterSheetWindow()
        {
            InitializeComponent();
            DataContext = this;
            Globals.ReadBaseSkills();
            MyCharacter.Skills = Globals.BaseSkills;
            AddSkills();
        }

        public void AddSkills()
        {
            int count = 0;
            GeneralSkillsPanel.Children.Clear();
            SkillsPanel2.Children.Clear();
            foreach (var s in MyCharacter.Skills)
            {
                var sc = new SkillControl();
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
                if (count <= MyCharacter.Skills.Count / 2)
                    GeneralSkillsPanel.Children.Add(sc);
                else SkillsPanel2.Children.Add(sc);
                sc.MySkill = s;
                count++;
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

        private void XpEvent(object sender, ExperienceCostEventArgs e)
        {

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

        private void SoakUp_Click(object sender, UpEventArgs e)
        {
            SoakValueStatControl.BaseUp();
        }

        private void SoakDown_Click(object sender, DownEventArgs e)
        {
            SoakValueStatControl.BaseDown();
        }

        private void WoundsUp_Click(object sender, UpEventArgs e)
        {
            WoundStatControl.BaseUp();
        }

        private void WoundsDown_Click(object sender, DownEventArgs e)
        {
            WoundStatControl.BaseDown();
        }

        private void StrainUp_Click(object sender, UpEventArgs e)
        {
            StrainStatControl.BaseUp();
        }

        private void StrainDown_Click(object sender, DownEventArgs e)
        {
            StrainStatControl.BaseDown();
        }

        private void RangedUp_Click(object sender, UpEventArgs e)
        {
            DefenseStatControl.LeftValueUp();
        }

        private void RangedDown_Click(object sender, DownEventArgs e)
        {
            DefenseStatControl.LeftValueDown();
        }

        private void MeleeUp_Click(object sender, UpEventArgs e)
        {
            DefenseStatControl.RightValueUp();
        }

        private void MeleeDown_Click(object sender, DownEventArgs e)
        {
            DefenseStatControl.RightValueDown();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = MyCharacter.Name;
            dialog.DefaultExt = ".gcs"; 
            dialog.Filter = "Genesys Character (.gcs)|*.gcs";
            var result = dialog.ShowDialog();

            if (result == true)
            {
                string filename = dialog.FileName;
                FileInterface.SaveCharacter(MyCharacter, filename);
            }
        }

        private void AvailableSkills_Click(object sender, RoutedEventArgs e)
        {
            var w = new ChooseSkillsWindow();
            var result = w.ShowDialog();
            if (result == true)
            {
                MyCharacter.Skills = w.ChosenSkills;
                AddSkills();
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".gcs";
            ofd.Filter = "Genesys Character (.gcs)|*.gcs";
            if (ofd.ShowDialog() == true)
            {
                MyCharacter = FileInterface.ReadCharacter(ofd.FileName);
                AddSkills();
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            MyCharacter = new Character();
            MyCharacter.Skills = Globals.BaseSkills;
            AddSkills();

        }
    }
}

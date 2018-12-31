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
    /// Interaction logic for ArchetypeEditorWindow.xaml
    /// </summary>
    public partial class ArchetypeEditorWindow : Window
    {
        public Archetype MyArchetype
        {
            get { return (Archetype)GetValue(ArchetypeProperty); }
            set { SetValue(ArchetypeProperty, value); OnPropertyChanged(new PropertyChangedEventArgs("MyArchetype")); }
        }

        public static DependencyProperty ArchetypeProperty = DependencyProperty.Register("MyArchetype", typeof(Archetype), typeof(ArchetypeEditorWindow), new PropertyMetadata(new Archetype()));
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        List<Skill> AvailableSkills = new List<Skill>();
        List<Skill> AssignedSkills = new List<Skill>();

        public ArchetypeEditorWindow()
        {
            InitializeComponent();
            DataContext = this;
            foreach (var s in Globals.BaseSkills)
            {
                AvailableSkills.Add(s);
            }
            AvailableSkills.Add(new Skill() { Name = "{Any}" });
            SetSkillsToLists();
            AvailableArchetypes.ItemsSource = Globals.BaseArchetypes;
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

        private void WoundsUp_Click(object sender, UpEventArgs e)
        {
            WoundsControl.BaseValue += 1;
        }

        private void WoundsDown_Click(object sender, DownEventArgs e)
        {
            WoundsControl.BaseValue -= 1;
        }

        private void StrainUp_Click(object sender, UpEventArgs e)
        {
            StrainControl.BaseValue += 1;
        }

        private void StrainDown_Click(object sender, DownEventArgs e)
        {
            StrainControl.BaseValue -= 1;
        }

        private void XpUp_Click(object sender, UpEventArgs e)
        {
            StartingExperience.Value += 5;
        }

        private void XpDown_Click(object sender, DownEventArgs e)
        {
            StartingExperience.Value -= 5;
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

        private void titlebar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AvailableSkills_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AvailableSkillsListBox.SelectedIndex != -1)
            {
                Skill s = (Skill)AvailableSkillsListBox.SelectedItem;
                if (s.Name != "{Any}")
                    AvailableSkills.Remove(s);
                s.StartingRank = Int32.Parse(StartingRankTextBox.Text);
                AssignedSkills.Add(s);
                SetSkillsToLists();
            }
        }

        private void AssignedSkills_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AssignedSkillsListBox.SelectedIndex != -1)
            {
                Skill s = (Skill)AssignedSkillsListBox.SelectedItem;
                if (s.Name != "{Any}")
                    AvailableSkills.Add(s);
                s.StartingRank = 0;
                AssignedSkills.Remove(s);
                SetSkillsToLists();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var sa = new SpecialAbility();
            sa.Name = SpecialAbilityTextBox.Text;
            SpecialAbilityListBox.Items.Add(sa);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialAbilityListBox.SelectedIndex != -1)
            {
                SpecialAbilityListBox.Items.Remove((SpecialAbility)SpecialAbilityListBox.SelectedItem);
            }
        }

        private void StartingRankUp_Click(object sender, UpEventArgs e)
        {
            StartingRankTextBox.Text = (Int32.Parse(StartingRankTextBox.Text) + 1).ToString();
        }

        private void StartingRankDown_Click(object sender, DownEventArgs e)
        {
            var i = Int32.Parse(StartingRankTextBox.Text);
            if (i == 1)
                return;
            else StartingRankTextBox.Text = (i - 1).ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {


            foreach (var s in AssignedSkills)
            {
                MyArchetype.StartingSkills.Add(s);
            }

            foreach (var s in SpecialAbilityListBox.Items)
                MyArchetype.SpecialAbilities.Add((SpecialAbility)s);

            Globals.AddBaseArchtype(MyArchetype);
            Globals.WriteBaseArchtypes();
            this.Close();
        }

        private void AvailableArchetypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AvailableArchetypes.SelectedIndex != -1)
            {
                MyArchetype = (Archetype)AvailableArchetypes.SelectedItem;
                AssignedSkills = MyArchetype.StartingSkills;
                AvailableSkills = Globals.BaseSkills.Where(l2 => !AssignedSkills.Any(l1 => l1.GUID == l2.GUID)).ToList();
                AvailableSkills.Add(new Skill() { Name = "{Any}" });
                SetSkillsToLists();
            }
        }
    }
}

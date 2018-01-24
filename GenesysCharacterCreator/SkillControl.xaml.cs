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
    /// Interaction logic for SkillControl.xaml
    /// </summary>
    public partial class SkillControl : UserControl
    {
        public Int32 LinkedCharacteristicValue
        {
            get { return (int)this.GetValue(LinkedCharacteristicValueProperty); }
            set { this.SetValue(LinkedCharacteristicValueProperty, value); }
        }
        public static readonly DependencyProperty LinkedCharacteristicValueProperty = DependencyProperty.Register("LinkedCharacteristicValue", typeof(int), typeof(SkillControl), new PropertyMetadata(0, LinkedCharacteristicValue_PropertyChanged));

        private static void LinkedCharacteristicValue_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            SkillControl o = (SkillControl)obj;
            o.Update();
        }

        public Skill MySkill {
            get {
                return (Skill)this.GetValue(SkillProperty);
            }
            set {
                this.SetValue(SkillProperty, value);
            }
        }

        public static readonly DependencyProperty SkillProperty = DependencyProperty.Register("Skill", typeof(Skill), typeof(SkillControl), new PropertyMetadata(new Skill(), Skill_PropertyChanged));

        private static void Skill_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            SkillControl o = (SkillControl)obj;
            o.Update();
            o.startingRank = ((Skill)args.NewValue).Rank;
        }
        //public string SkillName
        //{
        //    get { return (string)GetValue(SkillNameProperty); }
        //    set { SetValue(SkillNameProperty, value); }
        //}
        //public static readonly DependencyProperty SkillNameProperty = DependencyProperty.Register("SkillName", typeof(string), typeof(SkillControl), new PropertyMetadata(""));

        //public Int32 Rank
        //{
        //    get { return (int)this.GetValue(RankProperty); }
        //    set { this.SetValue(RankProperty, value); }
        //}
        //public static readonly DependencyProperty RankProperty = DependencyProperty.Register("Rank", typeof(int), typeof(SkillControl), new PropertyMetadata(0, LinkedCharacteristicValue_PropertyChanged));

        public Boolean EnforceStartMax
        {
            get { return (Boolean)this.GetValue(EnforceStartMaxProperty); }
            set { this.SetValue(EnforceStartMaxProperty, value); }
        }

        public static readonly DependencyProperty EnforceStartMaxProperty = DependencyProperty.Register("EnforceStartMax", typeof(Boolean), typeof(SkillControl), new PropertyMetadata(false));

        //public Int32 BonusFromCareer
        //{
        //    get { return (Int32)this.GetValue(BonusFromCareerProperty); }
        //    set { this.SetValue(BonusFromCareerProperty, value); }
        //}

        //public static readonly DependencyProperty BonusFromCareerProperty = DependencyProperty.Register("BonusFromCareer", typeof(Int32), typeof(SkillControl), new PropertyMetadata(0));

        //public Int32 BonusFromArchetype
        //{
        //    get { return (Int32)this.GetValue(BonusFromArchetypeProperty); }
        //    set { this.SetValue(BonusFromArchetypeProperty, value); }
        //}

        //public static readonly DependencyProperty BonusFromArchetypeProperty = DependencyProperty.Register("BonusFromArchetype", typeof(Int32), typeof(SkillControl), new PropertyMetadata(0));


        private void Update()
        {
            DicePanel.Children.Clear();
            //SkillNameTextBlock.Text = Skill.ToString();
            //RankTextBlock.Text = Skill.Rank.ToString();
            int higher = 0;
            int lower = 0;
            if (MySkill.Rank > LinkedCharacteristicValue)
            {
                higher = MySkill.Rank;
                lower = LinkedCharacteristicValue;
            }
            else
            {
                lower = MySkill.Rank;
                higher = LinkedCharacteristicValue;
            }

            if (higher + lower < 8)
            {
                for (int x = 0; x < higher; x++)
                {
                    var aD = new AbilityDieControl();
                    aD.Height = 20;
                    aD.Margin = new Thickness(1);
                    DicePanel.Children.Add(aD);
                }

                for (int x = 0; x < lower; x++)
                {
                    var pD = new ProficiencyDieControl();
                    pD.Height = 20;
                    pD.Margin = new Thickness(1);
                    DicePanel.Children.Add(pD);
                }
            }
            else
            {
                var aD = new AbilityDieControl();
                aD.Height = 20;
                aD.Margin = new Thickness(1);
                DicePanel.Children.Add(aD);
                var t1 = new TextBlock();
                t1.Text = "x" + higher;
                t1.FontSize = 14;
                t1.Height = 20;
                t1.Margin = new Thickness(1);
                DicePanel.Children.Add(t1);

                var pD = new ProficiencyDieControl();
                pD.Height = 20;
                pD.Margin = new Thickness(1);
                DicePanel.Children.Add(pD);

                var t2 = new TextBlock();
                t2.Text = "x" + lower;
                t2.Height = 20;
                t2.FontSize = 14;
                t2.Margin = new Thickness(1);
                DicePanel.Children.Add(t2);
            }
            
        }

        public void RankUp()
        {
            if (EnforceStartMax && MySkill.Rank == 2)
                return;
            MySkill.Rank += 1;
            int multiplier = 10;
            if (CareerCheckBox.IsChecked == true)
                multiplier = 5;
            Update();
            XpEvent(MySkill.Rank * multiplier);
        }

        public void RankDown()
        {
            int previousValue = MySkill.Rank;
            if (MySkill.Rank == startingRank)
                return;
            else MySkill.Rank -= 1;
            int multiplier = 10;
            if (CareerCheckBox.IsChecked == true)
                multiplier = 5;
            Update();
            XpEvent(-(previousValue * multiplier));
        }

        private EventHandler<ExperienceCostEventArgs> _onXPEvent;
        public event EventHandler<ExperienceCostEventArgs> OnXPEvent
        {
            add { _onXPEvent += value; }
            remove { _onXPEvent -= value; }
        }

        private void XpEvent(int Cost)
        {
            _onXPEvent?.Invoke(this, new ExperienceCostEventArgs(Cost));
        }

        public SkillControl()
        {
            InitializeComponent();
            DataContext = this;
            //CareerCheckBox.IsChecked = skill.IsCareer;
            CareerCheckBox.Checked += CareerCheckBox_Checked;
            CareerCheckBox.Unchecked += CareerCheckBox_Unchecked;
        }


        private int startingRank;

        private void CareerCheckBox_Unchecked(object sender, EventArgs e)
        {
            MySkill.IsCareer = false;
        }

        private void CareerCheckBox_Checked(object sender, EventArgs e)
        {
            MySkill.IsCareer = true;
        }

        private void Up_Click(object sender, UpEventArgs e)
        {
            RankUp();
        }

        private void Down_Click(object sender, DownEventArgs e)
        {
            RankDown();
        }

    }
}

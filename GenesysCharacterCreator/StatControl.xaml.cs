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
    /// Interaction logic for StatControl.xaml
    /// </summary>
    public partial class StatControl : UserControl
    {

        public String StatName
        {
            get { return (String)this.GetValue(StatNameProperty); }
            set { this.SetValue(StatNameProperty, value); }
        }
        public static readonly DependencyProperty StatNameProperty = DependencyProperty.Register("StatName", typeof(String), typeof(StatControl), new PropertyMetadata(""));

        public String BottomLeftText
        {
            get { return (String)this.GetValue(BottomLeftTextProperty); }
            set { this.SetValue(BottomLeftTextProperty, value); }
        }
        public static readonly DependencyProperty BottomLeftTextProperty = DependencyProperty.Register("BottomLeftText", typeof(String), typeof(StatControl), new PropertyMetadata(""));

        public String BottomRightText
        {
            get { return (String)this.GetValue(BottomRightTextProperty); }
            set { this.SetValue(BottomRightTextProperty, value); }
        }
        public static readonly DependencyProperty BottomRightTextProperty = DependencyProperty.Register("BottomRightText", typeof(String), typeof(StatControl), new PropertyMetadata(""));

        public Int32 LeftValue
        {
            get { return (int)this.GetValue(LeftValueProperty); }
            set { this.SetValue(LeftValueProperty, value); }
        }
        public static readonly DependencyProperty LeftValueProperty = DependencyProperty.Register("LeftValue", typeof(int), typeof(StatControl), new PropertyMetadata(0, OnLinkedCharacteristicPropertyChanged));

        public Int32 RightValue
        {
            get { return (int)this.GetValue(RightValueProperty); }
            set { this.SetValue(RightValueProperty, value); }
        }
        public static readonly DependencyProperty RightValueProperty = DependencyProperty.Register("RightValue", typeof(int), typeof(StatControl), new PropertyMetadata(0, OnLinkedCharacteristicPropertyChanged));

        public Int32 BaseValue
        {
            get { return (int)this.GetValue(BaseValueProperty); }
            set { this.SetValue(BaseValueProperty, value); }
        }
        public static readonly DependencyProperty BaseValueProperty = DependencyProperty.Register("BaseValue", typeof(int), typeof(StatControl), new PropertyMetadata(0, OnLinkedCharacteristicPropertyChanged));

        public Int32 LinkedCharacteristicValue
        {
            get { return (int)this.GetValue(LinkedCharacteristicValueProperty); }
            set { this.SetValue(LinkedCharacteristicValueProperty, value); }
        }
        public static readonly DependencyProperty LinkedCharacteristicValueProperty = DependencyProperty.Register("LinkedCharacteristicValue", typeof(int), typeof(StatControl), new PropertyMetadata(0, OnLinkedCharacteristicPropertyChanged));

        public Boolean IsSplit
        {
            get { return (Boolean)this.GetValue(IsSplitProperty); }
            set { this.SetValue(IsSplitProperty, value); }
        }
        public static readonly DependencyProperty IsSplitProperty = DependencyProperty.Register("IsSplit", typeof(Boolean), typeof(StatControl), new PropertyMetadata(true, OnIsSplitPropertyChanged));

        public Boolean UsesLinkedCharacteristic
        {
            get { return (Boolean)this.GetValue(UsesLinkedCharacteristicProperty); }
            set { this.SetValue(UsesLinkedCharacteristicProperty, value); }
        }
        public static readonly DependencyProperty UsesLinkedCharacteristicProperty = DependencyProperty.Register("UsesLinkedCharacteristic", typeof(Boolean), typeof(StatControl), new PropertyMetadata(true));


        private static void OnIsSplitPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            StatControl local = source as StatControl;
            if (!(bool)e.NewValue)
            {
                local.SplitLine.Visibility = Visibility.Hidden;
                local.SplitBackground.Visibility = Visibility.Hidden;
            }
            else
            {
                local.SplitLine.Visibility = Visibility.Visible;
                local.SplitBackground.Visibility = Visibility.Visible;
            }
        }

        private static void OnLinkedCharacteristicPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            StatControl c = (StatControl)source;
            c.Update();
        }

        private void Update()
        {
            //MiddleCenterTextBlock.Text = (BaseValue + LinkedCharacteristicValue).ToString();
            if (UsesLinkedCharacteristic)
            {
                MiddleLeftTextBlock.Text = BaseValue.ToString();
                MiddleRightTextBlock.Text = (BaseValue + LinkedCharacteristicValue).ToString();
            }
            else
            {
                MiddleLeftTextBlock.Text = LeftValue.ToString();
                MiddleRightTextBlock.Text = RightValue.ToString();
            }
        }

        public void LeftValueUp()
        {
            LeftValue += 1;
        }

        public void LeftValueDown() {
            if (LeftValue == 0)
                return;
            LeftValue -= 1;
        }

        public void RightValueUp() {
            RightValue += 1;
        }

        public void RightValueDown() {
            if (RightValue == 0)
                return;
            RightValue -= 1;
        }

        public void BaseUp()
        {
            BaseValue += 1;
        }

        public void BaseDown()
        {
            if (BaseValue == 0)
                return;
            else BaseValue -= 1;
        }

        public StatControl()
        {
            InitializeComponent();
            DataContext = this;
            Update();
        }
    }
}

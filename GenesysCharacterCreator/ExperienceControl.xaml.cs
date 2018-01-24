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
    /// Interaction logic for ExperienceControl.xaml
    /// </summary>
    public partial class ExperienceControl : UserControl
    {
        public String LabelText
        {
            get { return (String)this.GetValue(LabelTextProperty); }
            set { this.SetValue(LabelTextProperty, value); }
        }
        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
          "LabelText", typeof(String), typeof(ExperienceControl), new PropertyMetadata("", LabelTextPropertyChanged));

        private static void LabelTextPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            ExperienceControl local = source as ExperienceControl;
            local.LabelTextBlock.Text = (string)e.NewValue;
        }

        public Int32 Value
        {
            get { return (Int32)this.GetValue(ValueProperty); }
            set { this.SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
          "Value", typeof(Int32), typeof(ExperienceControl), new PropertyMetadata(0));

        public ExperienceControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}

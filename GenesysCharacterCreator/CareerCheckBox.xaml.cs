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
    /// Interaction logic for CareerCheckBox.xaml
    /// </summary>
    public partial class CareerCheckBox : UserControl
    {
        public Boolean IsChecked
        {
            get { return (Boolean)this.GetValue(IsCheckedProperty); }
            set { this.SetValue(IsCheckedProperty, value); }
        }

        public static readonly DependencyProperty IsCheckedProperty = DependencyProperty.Register("IsChecked", typeof(Boolean), typeof(CareerCheckBox), new PropertyMetadata(false, IsChecked_PropertyChanged));

        private static void IsChecked_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            CareerCheckBox o = (CareerCheckBox)obj;
            if ((bool)args.NewValue)
            {
                o.Checkmark.Visibility = Visibility.Visible;
                o.CheckedEvent();
            }
            else { o.Checkmark.Visibility = Visibility.Hidden;
                o.UncheckedEvent();
            }
        }

        private EventHandler<EventArgs> _checked;
        public event EventHandler<EventArgs> Checked {
            add { _checked += value; }
            remove { _checked -= value; }
        }

        private void CheckedEvent()
        {
            _checked?.Invoke(this, new EventArgs());
        }

        private EventHandler<EventArgs> _unchecked;
        public event EventHandler<EventArgs> Unchecked
        {
            add { _unchecked += value; }
            remove { _unchecked -= value; }
        }

        private void UncheckedEvent()
        {
            _unchecked?.Invoke(this, new EventArgs());
        }

        public CareerCheckBox()
        {
            InitializeComponent();
        }

        private void UserControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            IsChecked = !IsChecked;
        }
    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GenesysCharacterCreator
{
    /// <summary>
    /// Interaction logic for CharacteristicControl.xaml
    /// </summary>
    public partial class CharacteristicControl : UserControl
    {
        public Int32 CharacteristicValue
        {
            get { return (Int32)this.GetValue(CharacteristicValueProperty); }
            set { this.SetValue(CharacteristicValueProperty, value); }
        }
        public static readonly DependencyProperty CharacteristicValueProperty = DependencyProperty.Register(
          "CharacteristicValue", typeof(Int32), typeof(CharacteristicControl), new PropertyMetadata(0));

        private static void CharacteristicValue_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            CharacteristicControl c = (CharacteristicControl)obj;
            c.OnPropertyChanged("CharacteristicValue");
        }

        public Int32 CharacteristicStartValue
        {
            get { return (Int32)this.GetValue(CharacteristicStartValueProperty); }
            set { this.SetValue(CharacteristicStartValueProperty, value); }
        }
        public static readonly DependencyProperty CharacteristicStartValueProperty = DependencyProperty.Register("CharacteristicStartValue", typeof(Int32), typeof(CharacteristicControl), new PropertyMetadata(0, CharacteristicStartValue_PropertyChanged));

        private static void CharacteristicStartValue_PropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            CharacteristicControl c = (CharacteristicControl)obj;
            c.CharacteristicValue = (Int32)args.NewValue;

        }

        public string CharacteristicName
        {
            get { return (string)this.GetValue(CharacteristicNameProperty); }
            set { this.SetValue(CharacteristicNameProperty, value); }
        }
        public static readonly DependencyProperty CharacteristicNameProperty = DependencyProperty.Register("CharacteristicName", typeof(string), typeof(CharacteristicControl), new PropertyMetadata(""));

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string PropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        public void ValueUp()
        {
            //if (CharacteristicValue == 5)
            //    return;
            int start = CharacteristicValue;
            CharacteristicValue += 1;
            XpEvent(CharacteristicValue, start);
        }

        public void ValueDown()
        {
            if (CharacteristicValue == CharacteristicStartValue)
                return;
            int start = CharacteristicValue;
            CharacteristicValue -= 1;
            XpEvent(CharacteristicValue, start);
        }

        private EventHandler<ExperienceCostEventArgs> _onXPEvent;
        public event EventHandler<ExperienceCostEventArgs> OnXPEvent
        {
            add { _onXPEvent += value; }
            remove { _onXPEvent -= value; }
        }

        private void XpEvent(int NewValue, int OldValue)
        {
            int Cost = 0;
            if (NewValue > OldValue)
                Cost = NewValue * 10;
            else Cost = -(OldValue * 10);
            _onXPEvent?.Invoke(this, new ExperienceCostEventArgs(Cost));
        }

        public CharacteristicControl()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}

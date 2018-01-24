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
    /// Interaction logic for UpDownControl.xaml
    /// </summary>
    public partial class UpDownControl : UserControl
    {
        private EventHandler<UpEventArgs> _onUpEvent;
        public event EventHandler<UpEventArgs> OnUpEvent
        {
            add { _onUpEvent += value; }
            remove { _onUpEvent -= value; }
        }

        private void UpEvent()
        {
            _onUpEvent?.Invoke(this, new UpEventArgs());
        }

        private EventHandler<DownEventArgs> _onDownEvent;
        public event EventHandler<DownEventArgs> OnDownEvent
        {
            add { _onDownEvent += value; }
            remove { _onDownEvent -= value; }
        }

        private void DownEvent()
        {
            _onDownEvent?.Invoke(this, new DownEventArgs());
        }

        public UpDownControl()
        {
            InitializeComponent();
        }

        private void DownButton_Click(object sender, RoutedEventArgs e)
        {
            DownEvent();
        }

        private void UpButton_Click(object sender, RoutedEventArgs e)
        {
            UpEvent();
        }
    }

    public class UpEventArgs : EventArgs
    { }

    public class DownEventArgs : EventArgs
    { }
}

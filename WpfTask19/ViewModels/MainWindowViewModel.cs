using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfTask19.Models;

namespace WpfTask19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string ProprtyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(ProprtyName));
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double length;
        public double Length
        {
            get => length;
            set
            {
                length = value;
                OnPropertyChanged();
            }
        }

        public ICommand LengthCalcCommand { get; }
        private void OnLengthCalcCommandExecute(object p)
        {
            Length = CircleLength.LengthCalc(Radius);
        }
        private bool CanLengthCalcCommandExecuted(object p)
        {
            if (Radius >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public MainWindowViewModel()
        {
            LengthCalcCommand = new RelayCommand(OnLengthCalcCommandExecute, CanLengthCalcCommandExecuted);
        }
    }
}

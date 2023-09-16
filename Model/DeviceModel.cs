using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.Industrial.Base;

namespace Zhaoxi.Industrial.Model
{
    public class DeviceModel : NotifyPropertyBase
    {
        public string DeviceID { set; get; }
        public string DeviceName { set; get; }

        private bool _isRunning;


        public bool IsRunning {
            get => _isRunning;
            set { 
                _isRunning = value;
                this.RaisePropertyChanged();
            }
        }
        private bool isWarning=false;
        public bool IsWarning { 
            get => isWarning;
            set {
                isWarning = value;
                this.RaisePropertyChanged();
            }
        }
        public ObservableCollection<MonitorValueModel> MonitorValueList{ get; set; }   = new
            ObservableCollection<MonitorValueModel>();

        public ObservableCollection<WarningMessageModel> WarningMessageList { get; set; } = new
            ObservableCollection<WarningMessageModel>();

    }
}

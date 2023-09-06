using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhaoxi.Industrial.Model
{
    public class DeviceModel
    {
        public string DeviceID { set; get; }
        public string DeviceName { set; get; }

        public bool isRunning { set; get; }            
      
        public bool IsWarning { set; get; }   =false;
        public ObservableCollection<MonitorValueModel> MonitorValueList{ get; set; }   = new
            ObservableCollection<MonitorValueModel>();

        public ObservableCollection<WarningMessageModel> WarningMessageList { get; set; } = new
            ObservableCollection<WarningMessageModel>();
    }
}

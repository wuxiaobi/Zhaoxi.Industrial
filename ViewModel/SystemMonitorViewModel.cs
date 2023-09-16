﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.Industrial.Model;

namespace Zhaoxi.Industrial.ViewModel
{
    public class SystemMonitorViewModel
    {
        public ObservableCollection<LogModel> LogList { get; set; }=new ObservableCollection<LogModel>();
        
        public DeviceModel TestDevice { get; set; }

        public SystemMonitorViewModel()
        {
           InitLogInfo();
            #region 测试数据，为了设置数据模板
            TestDevice = new DeviceModel();
            TestDevice.DeviceName = "冷却塔 1#";
            TestDevice.IsRunning = true;
            TestDevice.IsWarning = true;
            TestDevice.MonitorValueList.Add(new MonitorValueModel
            { 
                
                ValueId = "1",
                ValueName = "液位",
                Unit = "m",
                CurrentValue = 45,
                Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue> { new LiveCharts.Defaults.ObservableValue(0), new LiveCharts.Defaults.ObservableValue(0) }
            });
            TestDevice.MonitorValueList.Add(new MonitorValueModel
            {
                ValueId = "1",
                ValueName = "入口压力",
                Unit = "Mpa",
                CurrentValue = 34,
                Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue> { new LiveCharts.Defaults.ObservableValue(0), new LiveCharts.Defaults.ObservableValue(0) }
            });
            TestDevice.MonitorValueList.Add(new MonitorValueModel
            {
                ValueId = "1",
                ValueName = "入口温度",
                Unit = "℃",
                CurrentValue = 34,
                Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue> { new LiveCharts.Defaults.ObservableValue(0), new LiveCharts.Defaults.ObservableValue(0) }
            });
            TestDevice.MonitorValueList.Add(new MonitorValueModel
            {
                ValueId = "1",
                ValueName = "出口压力",
                Unit = "Mpa",
                CurrentValue = 34,
                Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue> { new LiveCharts.Defaults.ObservableValue(0), new LiveCharts.Defaults.ObservableValue(0) }
            });
            TestDevice.MonitorValueList.Add(new MonitorValueModel
            {
                ValueId = "1",
                ValueName = "出口温度",
                Unit = "℃",
                CurrentValue = 34,
                Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue> { new LiveCharts.Defaults.ObservableValue(0), new LiveCharts.Defaults.ObservableValue(0) }
            });
            TestDevice.MonitorValueList.Add(new MonitorValueModel
            {
                ValueId = "1",
                ValueName = "补水压力",
                Unit = "Mpa",
                CurrentValue = 34,
                Values = new LiveCharts.ChartValues<LiveCharts.Defaults.ObservableValue> { new LiveCharts.Defaults.ObservableValue(0), new LiveCharts.Defaults.ObservableValue(0) }
            });

            TestDevice.WarningMessageList.Add(new WarningMessageModel { Message = "冷却塔1#液位极低，当前值：0" });
            TestDevice.WarningMessageList.Add(new WarningMessageModel { Message = "冷却塔1#入口压力极低，当前值：0" });
            TestDevice.WarningMessageList.Add(new WarningMessageModel { Message = "冷却塔1#入口温度极低，当前值：0" });

            #endregion


        }

            void InitLogInfo()
        {
            this.LogList.Add(new LogModel { RowNumber = 1, DeviceName = "冷却塔 1#", LogInfo = "已启动", LogType = Base.LogType.Info });
            this.LogList.Add(new LogModel { RowNumber = 2, DeviceName = "冷却塔 2#", LogInfo = "已启动", LogType = Base.LogType.Info });
            this.LogList.Add(new LogModel { RowNumber = 3, DeviceName = "冷却塔 3#", LogInfo = "液位极低", LogType = Base.LogType.Warn });
            this.LogList.Add(new LogModel { RowNumber = 4, DeviceName = "循环水泵 1#", LogInfo = "频率过大", LogType = Base.LogType.Warn });
            this.LogList.Add(new LogModel { RowNumber = 5, DeviceName = "循环水泵 2#", LogInfo = "已启动", LogType = Base.LogType.Info });
            this.LogList.Add(new LogModel { RowNumber = 6, DeviceName = "循环水泵 3#", LogInfo = "已启动", LogType = Base.LogType.Info });
        }
    }
}

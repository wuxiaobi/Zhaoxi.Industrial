using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Zhaoxi.Industrial.Base;

namespace Zhaoxi.Industrial.ViewModel
{
    internal class MainViewModel : NotifyPropertyBase

    {
        private UIElement _mainContent;

        public UIElement MainContent
        {
            get => _mainContent;
            set
            {
                 Set<UIElement>(ref _mainContent, value);
            }

        }
        public CommandBase TabChangedCommand { set; get; }
        public MainViewModel()
        {
            TabChangedCommand = new CommandBase(OnTabChanged);
            OnTabChanged("Zhaoxi.Industrial.View.SystemMonitor");
        }

        private void OnTabChanged(object o)
        {
            if (o == null) { return; }
            // 完整方式
            //string[] strValues = o.ToString().Split('|');
            //Assembly assembly = Assembly.LoadFrom(strValues[0]);
            //Type type = assembly.GetType(strValues[1]);
            //this.MainContent = (UIElement)Activator.CreateInstance(type);

            // 简化方式，必须在同一个程序集下
            Type type = Type.GetType(o.ToString());
            this.MainContent = (UIElement)Activator.CreateInstance(type);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.Industrial.Base;

namespace Zhaoxi.Industrial.Model
{
    public class LogModel
    {

        public int RowNumber { get; set ; }

        public string DeviceName { get; set ; }

        public string LogInfo { set; get; }

        public string Message { set; get; }

        public LogType LogType { get; set; }
    }
}

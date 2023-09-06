using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zhaoxi.Communication;
using Zhaoxi.Industrial.DAL;
using Zhaoxi.Industrial.Model;

namespace Zhaoxi.Industrial.BLL
{
    public class IndustrialBLL
    {     //获取串口信息
        DataAccess da=new DataAccess();
        public DataResult<SerialInfo> InitSerialInfo()
        {
            DataResult<SerialInfo> result = new DataResult<SerialInfo>();

            try
            {
                SerialInfo si = new SerialInfo();
                si.PortName = ConfigurationManager.AppSettings["port"].ToString();
                si.BaudRate = int.Parse(ConfigurationManager.AppSettings["baud"].ToString());
                si.DataBit = int.Parse(ConfigurationManager.AppSettings["data_bit"].ToString());
                si.Parity = (Parity)Enum.Parse(typeof(Parity), ConfigurationManager.AppSettings["parity"].ToString(), true);
                si.StopBits = (StopBits)Enum.Parse(typeof(StopBits), ConfigurationManager.AppSettings["stop_bit"].ToString(), true);


                result.State=true;
                result.Data = si;
            }
            catch (Exception ex)
            {
                result.Message=ex.Message;

            }

            return result;
        }

        public DataResult<List<StorageModel>> InitStorageArea()
        {
            DataResult<List<StorageModel>> result =new DataResult<List<StorageModel>>();
            try
            {

                var sa=da.GetStorageArea();

                result.State = true;
                result.Data = (from q in sa.AsEnumerable()
                               select new StorageModel
                               {
                                   id = q.Field<string>("id"),
                                   SlaveAddress = q.Field<Int32>("slave_add"),
                                   FuncCode = q.Field<string>("func_code"),
                                   StartAddress = int.Parse(q.Field<string>("start_reg")),
                                   Length = int.Parse(q.Field<string>("length"))

                               }).ToList();
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
        public DataResult<List<DeviceModel>> InitDevices()
        {
            DataResult<List<DeviceModel>> result=new DataResult<List<DeviceModel>>();
            try
            {
                var device = da.GetDevices();
                var monitorValue=da.GetMonitorValues();

                List<DeviceModel> deviceList = new List<DeviceModel>();
                foreach (var dr in device.AsEnumerable())
                {
                    DeviceModel model=new DeviceModel();
                    deviceList.Add(model);
                    model.DeviceID=dr.Field<string>("d_id");
                    model.DeviceName = dr.Field<string>("d_name");

                    foreach (var mv in monitorValue.AsEnumerable().Where(m=>m.Field<string>("d_id") ==
                        model.DeviceID)) 
                    {
                        MonitorValueModel mvm= new MonitorValueModel();
                        model.MonitorValueList.Add(mvm);

                        mvm.ValueId=mv.Field<string>("value_id");
                        mvm.ValueName = mv.Field<string>("value_name");
                        mvm.StorageAreaId = mv.Field<string>("s_area_id");
                        mvm.StartAddress = mv.Field<int>("address");
                        mvm.DataType = mv.Field<string>("data_type");
                        mvm.IsAlarm = mv.Field<Int32>("is_alarm") == 1;
                        mvm.ValueDesc = mv.Field<string>("description");
                        mvm.Unit = mv.Field<string>("unit");

                        //警戒值
                        var column = mv.Field<string>("alarm_lolo");
                        mvm.LoLoAlarm = column == null ? 0.0 : double.Parse(column); 
                        column = mv.Field<string>("alarm_low") ;
                        mvm.LowAlarm = column == null ? 0.0 : double.Parse(column) ; 
                        column = mv.Field<string>("alarm_high");
                        mvm.HighAlarm = column == null ? 0.0 : double.Parse(column);
                        column = mv.Field<string>("alarm_hihi");
                        mvm.HiHiAlarm = column == null ? 0.0 : double.Parse(column);

                        mvm.ValueStateChanged = (state, msg,value_id) =>
                        {
                            if (state != Base.MonitorValueState.OK)
                            {
                                var index= model.WarningMessageList.ToList().FindIndex(w => w.ValueID == value_id);
                                if (index > -1)
                                {
                                    model.WarningMessageList.RemoveAt(index); 
                                }
                                model.IsWarning = true;
                                model.WarningMessageList.Add(new WarningMessageModel { ValueID=value_id,Message=msg});

                                var ss = model.WarningMessageList.Count > 0;
                                if (model.IsWarning !=ss) {
                                    model.IsWarning = ss;

                                }
                            }
                        };
                    }
                }
                result.State = true;
                result.Data = deviceList;
            }
            catch (Exception ex)
            {

                result.Message = ex.Message;
            }
            return result;
        }
    }
}

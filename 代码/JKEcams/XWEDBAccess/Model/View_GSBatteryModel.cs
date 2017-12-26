using System;
namespace XWEDBAccess.Model
{
    /// <summary>
    /// View_GSBattery:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class View_GSBatteryModel
    {
        public View_GSBatteryModel()
        { }
        #region Model
        private string _code;
        private long _goodssiteid;
        private string _testresult;
        private string _capcity;
        private string _power;
        private string _innerrc;
        private string _pressure;
        private string _housename;
        private string _goodssitename;
        private int? _operatestatus;
        private string _teststatus;
        private string _testtype;
        private DateTime? _testtime;
        private DateTime? _updatetime;
        private string _channel;
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public long GoodsSiteID
        {
            set { _goodssiteid = value; }
            get { return _goodssiteid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestResult
        {
            set { _testresult = value; }
            get { return _testresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Capcity
        {
            set { _capcity = value; }
            get { return _capcity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Power
        {
            set { _power = value; }
            get { return _power; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string InnerRC
        {
            set { _innerrc = value; }
            get { return _innerrc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pressure
        {
            set { _pressure = value; }
            get { return _pressure; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HouseName
        {
            set { _housename = value; }
            get { return _housename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GoodsSiteName
        {
            set { _goodssitename = value; }
            get { return _goodssitename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OperateStatus
        {
            set { _operatestatus = value; }
            get { return _operatestatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestStatus
        {
            set { _teststatus = value; }
            get { return _teststatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestType
        {
            set { _testtype = value; }
            get { return _testtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? TestTime
        {
            set { _testtime = value; }
            get { return _testtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Channel
        {
            set { _channel = value; }
            get { return _channel; }
        }
        #endregion Model

    }
}


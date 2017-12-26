using System;
namespace XWEDBAccess.Model
{
    /// <summary>
    /// GoodsSite:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class GoodsSiteModel
    {
        public GoodsSiteModel()
        { }
        #region Model
        private long _goodssiteid;
        private string _housename;
        private string _goodssitename;
        private string _operatestatus;
        private string _teststatus;
        private string _testtype;
        private DateTime? _updatetime;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4;
        private string _tag5;
        /// <summary>
        /// 货位表
        /// </summary>
        public long GoodsSiteID
        {
            set { _goodssiteid = value; }
            get { return _goodssiteid; }
        }
        /// <summary>
        /// 库房名称
        /// </summary>
        public string HouseName
        {
            set { _housename = value; }
            get { return _housename; }
        }
        /// <summary>
        /// 货位名称，1-2-4,货位的排列层
        /// </summary>
        public string GoodsSiteName
        {
            set { _goodssitename = value; }
            get { return _goodssitename; }
        }
        /// <summary>
        /// 可以操作的状态，0不可操作，1可以操作
        /// </summary>
        public string OperateStatus
        {
            set { _operatestatus = value; }
            get { return _operatestatus; }
        }
        /// <summary>
        /// 测试状态
        /// </summary>
        public string TestStatus
        {
            set { _teststatus = value; }
            get { return _teststatus; }
        }
        /// <summary>
        /// 测试类型
        /// </summary>
        public string TestType
        {
            set { _testtype = value; }
            get { return _testtype; }
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
        public string Tag1
        {
            set { _tag1 = value; }
            get { return _tag1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag2
        {
            set { _tag2 = value; }
            get { return _tag2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag3
        {
            set { _tag3 = value; }
            get { return _tag3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag4
        {
            set { _tag4 = value; }
            get { return _tag4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tag5
        {
            set { _tag5 = value; }
            get { return _tag5; }
        }
        #endregion Model

    }
}


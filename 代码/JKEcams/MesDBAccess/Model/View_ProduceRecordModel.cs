using System;
namespace MesDBAccess.Model
{
    /// <summary>
    /// View_ProduceRecordModel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class View_ProduceRecordModel
    {
        public View_ProduceRecordModel()
        { }
        #region Model
        private string _processstepname;
        private string _productid;
        private string _productcata;
        private string _stationid;
        private string _recordcata;
        private string _recordid;
        private DateTime _recordtime;
        private string _checkresult;
        private string _tag1;
        private string _tag2;
        private string _tag3;
        private string _tag4;
        private string _tag5;
        /// <summary>
        /// 
        /// </summary>
        public string processStepName
        {
            set { _processstepname = value; }
            get { return _processstepname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string productCata
        {
            set { _productcata = value; }
            get { return _productcata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string stationID
        {
            set { _stationid = value; }
            get { return _stationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string recordCata
        {
            set { _recordcata = value; }
            get { return _recordcata; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string recordID
        {
            set { _recordid = value; }
            get { return _recordid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime recordTime
        {
            set { _recordtime = value; }
            get { return _recordtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string checkResult
        {
            set { _checkresult = value; }
            get { return _checkresult; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag1
        {
            set { _tag1 = value; }
            get { return _tag1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag2
        {
            set { _tag2 = value; }
            get { return _tag2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag3
        {
            set { _tag3 = value; }
            get { return _tag3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag4
        {
            set { _tag4 = value; }
            get { return _tag4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tag5
        {
            set { _tag5 = value; }
            get { return _tag5; }
        }
        #endregion Model

    }
}


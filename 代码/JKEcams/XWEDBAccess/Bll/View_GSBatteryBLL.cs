using System;
using System.Data;
using System.Collections.Generic;

namespace XWEDBAccess.BLL
{
    /// <summary>
    /// View_GSBattery
    /// </summary>
    public partial class View_GSBatteryBLL
    {
        private readonly XWEDBAccess.DAL.View_GSBatteryDAL dal = new XWEDBAccess.DAL.View_GSBatteryDAL();
        public View_GSBatteryBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Code, long GoodsSiteID, string TestResult, string Capcity, string Power, string InnerRC, string Pressure, string HouseName, string GoodsSiteName, int OperateStatus, string TestStatus, string TestType, DateTime TestTime, DateTime UpdateTime, string Channel)
        {
            return dal.Exists(Code, GoodsSiteID, TestResult, Capcity, Power, InnerRC, Pressure, HouseName, GoodsSiteName, OperateStatus, TestStatus, TestType, TestTime, UpdateTime, Channel);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(XWEDBAccess.Model.View_GSBatteryModel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XWEDBAccess.Model.View_GSBatteryModel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Code, long GoodsSiteID, string TestResult, string Capcity, string Power, string InnerRC, string Pressure, string HouseName, string GoodsSiteName, int OperateStatus, string TestStatus, string TestType, DateTime TestTime, DateTime UpdateTime, string Channel)
        {

            return dal.Delete(Code, GoodsSiteID, TestResult, Capcity, Power, InnerRC, Pressure, HouseName, GoodsSiteName, OperateStatus, TestStatus, TestType, TestTime, UpdateTime, Channel);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XWEDBAccess.Model.View_GSBatteryModel GetModel(string Code, long GoodsSiteID, string TestResult, string Capcity, string Power, string InnerRC, string Pressure, string HouseName, string GoodsSiteName, int OperateStatus, string TestStatus, string TestType, DateTime TestTime, DateTime UpdateTime, string Channel)
        {

            return dal.GetModel(Code, GoodsSiteID, TestResult, Capcity, Power, InnerRC, Pressure, HouseName, GoodsSiteName, OperateStatus, TestStatus, TestType, TestTime, UpdateTime, Channel);
        }

        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XWEDBAccess.Model.View_GSBatteryModel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<XWEDBAccess.Model.View_GSBatteryModel> DataTableToList(DataTable dt)
        {
            List<XWEDBAccess.Model.View_GSBatteryModel> modelList = new List<XWEDBAccess.Model.View_GSBatteryModel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                XWEDBAccess.Model.View_GSBatteryModel model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}


using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XWEDBAccess.DBUtility;

namespace XWEDBAccess.DAL
{
    /// <summary>
    /// 数据访问类:View_GSBattery
    /// </summary>
    public partial class View_GSBatteryDAL
    {
        public View_GSBatteryDAL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Code, long GoodsSiteID, string TestResult, string Capcity, string Power, string InnerRC, string Pressure, string HouseName, string GoodsSiteName, int OperateStatus, string TestStatus, string TestType, DateTime TestTime, DateTime UpdateTime, string Channel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from View_GSBattery");
            strSql.Append(" where Code=@Code and GoodsSiteID=@GoodsSiteID and TestResult=@TestResult and Capcity=@Capcity and Power=@Power and InnerRC=@InnerRC and Pressure=@Pressure and HouseName=@HouseName and GoodsSiteName=@GoodsSiteName and OperateStatus=@OperateStatus and TestStatus=@TestStatus and TestType=@TestType and TestTime=@TestTime and UpdateTime=@UpdateTime and Channel=@Channel ");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@TestResult", SqlDbType.NVarChar,50),
					new SqlParameter("@Capcity", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.NVarChar,50),
					new SqlParameter("@InnerRC", SqlDbType.NVarChar,50),
					new SqlParameter("@Pressure", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateStatus", SqlDbType.Int,4),
					new SqlParameter("@TestStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@TestType", SqlDbType.NVarChar,50),
					new SqlParameter("@TestTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Channel", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Code;
            parameters[1].Value = GoodsSiteID;
            parameters[2].Value = TestResult;
            parameters[3].Value = Capcity;
            parameters[4].Value = Power;
            parameters[5].Value = InnerRC;
            parameters[6].Value = Pressure;
            parameters[7].Value = HouseName;
            parameters[8].Value = GoodsSiteName;
            parameters[9].Value = OperateStatus;
            parameters[10].Value = TestStatus;
            parameters[11].Value = TestType;
            parameters[12].Value = TestTime;
            parameters[13].Value = UpdateTime;
            parameters[14].Value = Channel;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(XWEDBAccess.Model.View_GSBatteryModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into View_GSBattery(");
            strSql.Append("Code,GoodsSiteID,TestResult,Capcity,Power,InnerRC,Pressure,HouseName,GoodsSiteName,OperateStatus,TestStatus,TestType,TestTime,UpdateTime,Channel)");
            strSql.Append(" values (");
            strSql.Append("@Code,@GoodsSiteID,@TestResult,@Capcity,@Power,@InnerRC,@Pressure,@HouseName,@GoodsSiteName,@OperateStatus,@TestStatus,@TestType,@TestTime,@UpdateTime,@Channel)");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@TestResult", SqlDbType.NVarChar,50),
					new SqlParameter("@Capcity", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.NVarChar,50),
					new SqlParameter("@InnerRC", SqlDbType.NVarChar,50),
					new SqlParameter("@Pressure", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateStatus", SqlDbType.Int,4),
					new SqlParameter("@TestStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@TestType", SqlDbType.NVarChar,50),
					new SqlParameter("@TestTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Channel", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.GoodsSiteID;
            parameters[2].Value = model.TestResult;
            parameters[3].Value = model.Capcity;
            parameters[4].Value = model.Power;
            parameters[5].Value = model.InnerRC;
            parameters[6].Value = model.Pressure;
            parameters[7].Value = model.HouseName;
            parameters[8].Value = model.GoodsSiteName;
            parameters[9].Value = model.OperateStatus;
            parameters[10].Value = model.TestStatus;
            parameters[11].Value = model.TestType;
            parameters[12].Value = model.TestTime;
            parameters[13].Value = model.UpdateTime;
            parameters[14].Value = model.Channel;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(XWEDBAccess.Model.View_GSBatteryModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update View_GSBattery set ");
            strSql.Append("Code=@Code,");
            strSql.Append("GoodsSiteID=@GoodsSiteID,");
            strSql.Append("TestResult=@TestResult,");
            strSql.Append("Capcity=@Capcity,");
            strSql.Append("Power=@Power,");
            strSql.Append("InnerRC=@InnerRC,");
            strSql.Append("Pressure=@Pressure,");
            strSql.Append("HouseName=@HouseName,");
            strSql.Append("GoodsSiteName=@GoodsSiteName,");
            strSql.Append("OperateStatus=@OperateStatus,");
            strSql.Append("TestStatus=@TestStatus,");
            strSql.Append("TestType=@TestType,");
            strSql.Append("TestTime=@TestTime,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Channel=@Channel");
            strSql.Append(" where Code=@Code and GoodsSiteID=@GoodsSiteID and TestResult=@TestResult and Capcity=@Capcity and Power=@Power and InnerRC=@InnerRC and Pressure=@Pressure and HouseName=@HouseName and GoodsSiteName=@GoodsSiteName and OperateStatus=@OperateStatus and TestStatus=@TestStatus and TestType=@TestType and TestTime=@TestTime and UpdateTime=@UpdateTime and Channel=@Channel ");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@TestResult", SqlDbType.NVarChar,50),
					new SqlParameter("@Capcity", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.NVarChar,50),
					new SqlParameter("@InnerRC", SqlDbType.NVarChar,50),
					new SqlParameter("@Pressure", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateStatus", SqlDbType.Int,4),
					new SqlParameter("@TestStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@TestType", SqlDbType.NVarChar,50),
					new SqlParameter("@TestTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Channel", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.GoodsSiteID;
            parameters[2].Value = model.TestResult;
            parameters[3].Value = model.Capcity;
            parameters[4].Value = model.Power;
            parameters[5].Value = model.InnerRC;
            parameters[6].Value = model.Pressure;
            parameters[7].Value = model.HouseName;
            parameters[8].Value = model.GoodsSiteName;
            parameters[9].Value = model.OperateStatus;
            parameters[10].Value = model.TestStatus;
            parameters[11].Value = model.TestType;
            parameters[12].Value = model.TestTime;
            parameters[13].Value = model.UpdateTime;
            parameters[14].Value = model.Channel;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string Code, long GoodsSiteID, string TestResult, string Capcity, string Power, string InnerRC, string Pressure, string HouseName, string GoodsSiteName, int OperateStatus, string TestStatus, string TestType, DateTime TestTime, DateTime UpdateTime, string Channel)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from View_GSBattery ");
            strSql.Append(" where Code=@Code and GoodsSiteID=@GoodsSiteID and TestResult=@TestResult and Capcity=@Capcity and Power=@Power and InnerRC=@InnerRC and Pressure=@Pressure and HouseName=@HouseName and GoodsSiteName=@GoodsSiteName and OperateStatus=@OperateStatus and TestStatus=@TestStatus and TestType=@TestType and TestTime=@TestTime and UpdateTime=@UpdateTime and Channel=@Channel ");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@TestResult", SqlDbType.NVarChar,50),
					new SqlParameter("@Capcity", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.NVarChar,50),
					new SqlParameter("@InnerRC", SqlDbType.NVarChar,50),
					new SqlParameter("@Pressure", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateStatus", SqlDbType.Int,4),
					new SqlParameter("@TestStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@TestType", SqlDbType.NVarChar,50),
					new SqlParameter("@TestTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Channel", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Code;
            parameters[1].Value = GoodsSiteID;
            parameters[2].Value = TestResult;
            parameters[3].Value = Capcity;
            parameters[4].Value = Power;
            parameters[5].Value = InnerRC;
            parameters[6].Value = Pressure;
            parameters[7].Value = HouseName;
            parameters[8].Value = GoodsSiteName;
            parameters[9].Value = OperateStatus;
            parameters[10].Value = TestStatus;
            parameters[11].Value = TestType;
            parameters[12].Value = TestTime;
            parameters[13].Value = UpdateTime;
            parameters[14].Value = Channel;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XWEDBAccess.Model.View_GSBatteryModel GetModel(string Code, long GoodsSiteID, string TestResult, string Capcity, string Power, string InnerRC, string Pressure, string HouseName, string GoodsSiteName, int OperateStatus, string TestStatus, string TestType, DateTime TestTime, DateTime UpdateTime, string Channel)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Code,GoodsSiteID,TestResult,Capcity,Power,InnerRC,Pressure,HouseName,GoodsSiteName,OperateStatus,TestStatus,TestType,TestTime,UpdateTime,Channel from View_GSBattery ");
            strSql.Append(" where Code=@Code and GoodsSiteID=@GoodsSiteID and TestResult=@TestResult and Capcity=@Capcity and Power=@Power and InnerRC=@InnerRC and Pressure=@Pressure and HouseName=@HouseName and GoodsSiteName=@GoodsSiteName and OperateStatus=@OperateStatus and TestStatus=@TestStatus and TestType=@TestType and TestTime=@TestTime and UpdateTime=@UpdateTime and Channel=@Channel ");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,100),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8),
					new SqlParameter("@TestResult", SqlDbType.NVarChar,50),
					new SqlParameter("@Capcity", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.NVarChar,50),
					new SqlParameter("@InnerRC", SqlDbType.NVarChar,50),
					new SqlParameter("@Pressure", SqlDbType.NVarChar,50),
					new SqlParameter("@HouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateStatus", SqlDbType.Int,4),
					new SqlParameter("@TestStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@TestType", SqlDbType.NVarChar,50),
					new SqlParameter("@TestTime", SqlDbType.DateTime),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Channel", SqlDbType.NVarChar,50)			};
            parameters[0].Value = Code;
            parameters[1].Value = GoodsSiteID;
            parameters[2].Value = TestResult;
            parameters[3].Value = Capcity;
            parameters[4].Value = Power;
            parameters[5].Value = InnerRC;
            parameters[6].Value = Pressure;
            parameters[7].Value = HouseName;
            parameters[8].Value = GoodsSiteName;
            parameters[9].Value = OperateStatus;
            parameters[10].Value = TestStatus;
            parameters[11].Value = TestType;
            parameters[12].Value = TestTime;
            parameters[13].Value = UpdateTime;
            parameters[14].Value = Channel;

            XWEDBAccess.Model.View_GSBatteryModel model = new XWEDBAccess.Model.View_GSBatteryModel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public XWEDBAccess.Model.View_GSBatteryModel DataRowToModel(DataRow row)
        {
            XWEDBAccess.Model.View_GSBatteryModel model = new XWEDBAccess.Model.View_GSBatteryModel();
            if (row != null)
            {
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["GoodsSiteID"] != null && row["GoodsSiteID"].ToString() != "")
                {
                    model.GoodsSiteID = long.Parse(row["GoodsSiteID"].ToString());
                }
                if (row["TestResult"] != null)
                {
                    model.TestResult = row["TestResult"].ToString();
                }
                if (row["Capcity"] != null)
                {
                    model.Capcity = row["Capcity"].ToString();
                }
                if (row["Power"] != null)
                {
                    model.Power = row["Power"].ToString();
                }
                if (row["InnerRC"] != null)
                {
                    model.InnerRC = row["InnerRC"].ToString();
                }
                if (row["Pressure"] != null)
                {
                    model.Pressure = row["Pressure"].ToString();
                }
                if (row["HouseName"] != null)
                {
                    model.HouseName = row["HouseName"].ToString();
                }
                if (row["GoodsSiteName"] != null)
                {
                    model.GoodsSiteName = row["GoodsSiteName"].ToString();
                }
                if (row["OperateStatus"] != null && row["OperateStatus"].ToString() != "")
                {
                    model.OperateStatus = int.Parse(row["OperateStatus"].ToString());
                }
                if (row["TestStatus"] != null)
                {
                    model.TestStatus = row["TestStatus"].ToString();
                }
                if (row["TestType"] != null)
                {
                    model.TestType = row["TestType"].ToString();
                }
                if (row["TestTime"] != null && row["TestTime"].ToString() != "")
                {
                    model.TestTime = DateTime.Parse(row["TestTime"].ToString());
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
                }
                if (row["Channel"] != null)
                {
                    model.Channel = row["Channel"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Code,GoodsSiteID,TestResult,Capcity,Power,InnerRC,Pressure,HouseName,GoodsSiteName,OperateStatus,TestStatus,TestType,TestTime,UpdateTime,Channel ");
            strSql.Append(" FROM View_GSBattery ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Code,GoodsSiteID,TestResult,Capcity,Power,InnerRC,Pressure,HouseName,GoodsSiteName,OperateStatus,TestStatus,TestType,TestTime,UpdateTime,Channel ");
            strSql.Append(" FROM View_GSBattery ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM View_GSBattery ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.Channel desc");
            }
            strSql.Append(")AS Row, T.*  from View_GSBattery T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "View_GSBattery";
            parameters[1].Value = "Channel";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  MethodEx

        #endregion  MethodEx
    }
}


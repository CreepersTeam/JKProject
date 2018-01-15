using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using MesDBAccess.DBUtility;//Please add references
namespace MesDBAccess.DAL
{
    public partial class XWEHistroyDAL
    {
        public XWEHistroyDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long BatteryCodeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from XWEHistroy");
            strSql.Append(" where BatteryCodeID=@BatteryCodeID");
            SqlParameter[] parameters = {
					new SqlParameter("@BatteryCodeID", SqlDbType.BigInt)
			};
            parameters[0].Value = BatteryCodeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(MesDBAccess.Model.XWEHistroyModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into XWEHistroy(");
            strSql.Append("Code,Channel,Pressure,InnerRC,Power,Capcity,TestResult,TestTime,Tag1,Tag2,Tag3,Tag4,Tag5,HouseName,GoodsSiteName,TestStatus,TestType,PalletID)");
            strSql.Append(" values (");
            strSql.Append("@Code,@Channel,@Pressure,@InnerRC,@Power,@Capcity,@TestResult,@TestTime,@Tag1,@Tag2,@Tag3,@Tag4,@Tag5,@HouseName,@GoodsSiteName,@TestStatus,@TestType,@PalletID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,100),
					new SqlParameter("@Channel", SqlDbType.NVarChar,50),
					new SqlParameter("@Pressure", SqlDbType.NVarChar,50),
					new SqlParameter("@InnerRC", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.NVarChar,50),
					new SqlParameter("@Capcity", SqlDbType.NVarChar,50),
					new SqlParameter("@TestResult", SqlDbType.NVarChar,50),
					new SqlParameter("@TestTime", SqlDbType.DateTime),
					new SqlParameter("@Tag1", SqlDbType.NVarChar,100),
					new SqlParameter("@Tag2", SqlDbType.NVarChar,100),
					new SqlParameter("@Tag3", SqlDbType.NVarChar,100),
					new SqlParameter("@Tag4", SqlDbType.NVarChar,100),
					new SqlParameter("@Tag5", SqlDbType.NVarChar,100),
					new SqlParameter("@HouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@TestStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@TestType", SqlDbType.NVarChar,50),
					new SqlParameter("@PalletID", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Channel;
            parameters[2].Value = model.Pressure;
            parameters[3].Value = model.InnerRC;
            parameters[4].Value = model.Power;
            parameters[5].Value = model.Capcity;
            parameters[6].Value = model.TestResult;
            parameters[7].Value = model.TestTime;
            parameters[8].Value = model.Tag1;
            parameters[9].Value = model.Tag2;
            parameters[10].Value = model.Tag3;
            parameters[11].Value = model.Tag4;
            parameters[12].Value = model.Tag5;
            parameters[13].Value = model.HouseName;
            parameters[14].Value = model.GoodsSiteName;
            parameters[15].Value = model.TestStatus;
            parameters[16].Value = model.TestType;
            parameters[17].Value = model.PalletID;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MesDBAccess.Model.XWEHistroyModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update XWEHistroy set ");
            strSql.Append("Code=@Code,");
            strSql.Append("Channel=@Channel,");
            strSql.Append("Pressure=@Pressure,");
            strSql.Append("InnerRC=@InnerRC,");
            strSql.Append("Power=@Power,");
            strSql.Append("Capcity=@Capcity,");
            strSql.Append("TestResult=@TestResult,");
            strSql.Append("TestTime=@TestTime,");
            strSql.Append("Tag1=@Tag1,");
            strSql.Append("Tag2=@Tag2,");
            strSql.Append("Tag3=@Tag3,");
            strSql.Append("Tag4=@Tag4,");
            strSql.Append("Tag5=@Tag5,");
            strSql.Append("HouseName=@HouseName,");
            strSql.Append("GoodsSiteName=@GoodsSiteName,");
            strSql.Append("TestStatus=@TestStatus,");
            strSql.Append("TestType=@TestType,");
            strSql.Append("PalletID=@PalletID");
            strSql.Append(" where BatteryCodeID=@BatteryCodeID");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,100),
					new SqlParameter("@Channel", SqlDbType.NVarChar,50),
					new SqlParameter("@Pressure", SqlDbType.NVarChar,50),
					new SqlParameter("@InnerRC", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.NVarChar,50),
					new SqlParameter("@Capcity", SqlDbType.NVarChar,50),
					new SqlParameter("@TestResult", SqlDbType.NVarChar,50),
					new SqlParameter("@TestTime", SqlDbType.DateTime),
					new SqlParameter("@Tag1", SqlDbType.NVarChar,100),
					new SqlParameter("@Tag2", SqlDbType.NVarChar,100),
					new SqlParameter("@Tag3", SqlDbType.NVarChar,100),
					new SqlParameter("@Tag4", SqlDbType.NVarChar,100),
					new SqlParameter("@Tag5", SqlDbType.NVarChar,100),
					new SqlParameter("@HouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@TestStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@TestType", SqlDbType.NVarChar,50),
					new SqlParameter("@PalletID", SqlDbType.NVarChar,50),
					new SqlParameter("@BatteryCodeID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Channel;
            parameters[2].Value = model.Pressure;
            parameters[3].Value = model.InnerRC;
            parameters[4].Value = model.Power;
            parameters[5].Value = model.Capcity;
            parameters[6].Value = model.TestResult;
            parameters[7].Value = model.TestTime;
            parameters[8].Value = model.Tag1;
            parameters[9].Value = model.Tag2;
            parameters[10].Value = model.Tag3;
            parameters[11].Value = model.Tag4;
            parameters[12].Value = model.Tag5;
            parameters[13].Value = model.HouseName;
            parameters[14].Value = model.GoodsSiteName;
            parameters[15].Value = model.TestStatus;
            parameters[16].Value = model.TestType;
            parameters[17].Value = model.PalletID;
            parameters[18].Value = model.BatteryCodeID;

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
        public bool Delete(long BatteryCodeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from XWEHistroy ");
            strSql.Append(" where BatteryCodeID=@BatteryCodeID");
            SqlParameter[] parameters = {
					new SqlParameter("@BatteryCodeID", SqlDbType.BigInt)
			};
            parameters[0].Value = BatteryCodeID;

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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string BatteryCodeIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from XWEHistroy ");
            strSql.Append(" where BatteryCodeID in (" + BatteryCodeIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public MesDBAccess.Model.XWEHistroyModel GetModel(long BatteryCodeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 BatteryCodeID,Code,Channel,Pressure,InnerRC,Power,Capcity,TestResult,TestTime,Tag1,Tag2,Tag3,Tag4,Tag5,HouseName,GoodsSiteName,TestStatus,TestType,PalletID from XWEHistroy ");
            strSql.Append(" where BatteryCodeID=@BatteryCodeID");
            SqlParameter[] parameters = {
					new SqlParameter("@BatteryCodeID", SqlDbType.BigInt)
			};
            parameters[0].Value = BatteryCodeID;

            MesDBAccess.Model.XWEHistroyModel model = new MesDBAccess.Model.XWEHistroyModel();
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
        public MesDBAccess.Model.XWEHistroyModel DataRowToModel(DataRow row)
        {
            MesDBAccess.Model.XWEHistroyModel model = new MesDBAccess.Model.XWEHistroyModel();
            if (row != null)
            {
                if (row["BatteryCodeID"] != null && row["BatteryCodeID"].ToString() != "")
                {
                    model.BatteryCodeID = long.Parse(row["BatteryCodeID"].ToString());
                }
                if (row["Code"] != null)
                {
                    model.Code = row["Code"].ToString();
                }
                if (row["Channel"] != null)
                {
                    model.Channel = row["Channel"].ToString();
                }
                if (row["Pressure"] != null)
                {
                    model.Pressure = row["Pressure"].ToString();
                }
                if (row["InnerRC"] != null)
                {
                    model.InnerRC = row["InnerRC"].ToString();
                }
                if (row["Power"] != null)
                {
                    model.Power = row["Power"].ToString();
                }
                if (row["Capcity"] != null)
                {
                    model.Capcity = row["Capcity"].ToString();
                }
                if (row["TestResult"] != null)
                {
                    model.TestResult = row["TestResult"].ToString();
                }
                if (row["TestTime"] != null && row["TestTime"].ToString() != "")
                {
                    model.TestTime = DateTime.Parse(row["TestTime"].ToString());
                }
                if (row["Tag1"] != null)
                {
                    model.Tag1 = row["Tag1"].ToString();
                }
                if (row["Tag2"] != null)
                {
                    model.Tag2 = row["Tag2"].ToString();
                }
                if (row["Tag3"] != null)
                {
                    model.Tag3 = row["Tag3"].ToString();
                }
                if (row["Tag4"] != null)
                {
                    model.Tag4 = row["Tag4"].ToString();
                }
                if (row["Tag5"] != null)
                {
                    model.Tag5 = row["Tag5"].ToString();
                }
                if (row["HouseName"] != null)
                {
                    model.HouseName = row["HouseName"].ToString();
                }
                if (row["GoodsSiteName"] != null)
                {
                    model.GoodsSiteName = row["GoodsSiteName"].ToString();
                }
                if (row["TestStatus"] != null)
                {
                    model.TestStatus = row["TestStatus"].ToString();
                }
                if (row["TestType"] != null)
                {
                    model.TestType = row["TestType"].ToString();
                }
                if (row["PalletID"] != null)
                {
                    model.PalletID = row["PalletID"].ToString();
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
            strSql.Append("select BatteryCodeID,Code,Channel,Pressure,InnerRC,Power,Capcity,TestResult,TestTime,Tag1,Tag2,Tag3,Tag4,Tag5,HouseName,GoodsSiteName,TestStatus,TestType,PalletID ");
            strSql.Append(" FROM XWEHistroy ");
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
            strSql.Append(" BatteryCodeID,Code,Channel,Pressure,InnerRC,Power,Capcity,TestResult,TestTime,Tag1,Tag2,Tag3,Tag4,Tag5,HouseName,GoodsSiteName,TestStatus,TestType,PalletID ");
            strSql.Append(" FROM XWEHistroy ");
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
            strSql.Append("select count(1) FROM XWEHistroy ");
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
                strSql.Append("order by T.BatteryCodeID desc");
            }
            strSql.Append(")AS Row, T.*  from XWEHistroy T ");
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
            parameters[0].Value = "XWEHistroy";
            parameters[1].Value = "BatteryCodeID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}


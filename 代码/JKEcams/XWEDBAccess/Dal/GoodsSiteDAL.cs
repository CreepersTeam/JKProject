using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using XWEDBAccess.DBUtility;

namespace XWEDBAccess.DAL
{
    /// <summary>
    /// 数据访问类:GoodsSite
    /// </summary>
    public partial class GoodsSiteDAL
    {
        public GoodsSiteDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(long GoodsSiteID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from GoodsSite");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt)
			};
            parameters[0].Value = GoodsSiteID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public long Add(XWEDBAccess.Model.GoodsSiteModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into GoodsSite(");
            strSql.Append("HouseName,GoodsSiteName,OperateStatus,TestStatus,TestType,UpdateTime,Tag1,Tag2,Tag3,Tag4,Tag5)");
            strSql.Append(" values (");
            strSql.Append("@HouseName,@GoodsSiteName,@OperateStatus,@TestStatus,@TestType,@UpdateTime,@Tag1,@Tag2,@Tag3,@Tag4,@Tag5)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@HouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@TestStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@TestType", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Tag1", SqlDbType.NVarChar,500),
					new SqlParameter("@Tag2", SqlDbType.NVarChar,500),
					new SqlParameter("@Tag3", SqlDbType.NVarChar,500),
					new SqlParameter("@Tag4", SqlDbType.NVarChar,500),
					new SqlParameter("@Tag5", SqlDbType.NVarChar,500)};
            parameters[0].Value = model.HouseName;
            parameters[1].Value = model.GoodsSiteName;
            parameters[2].Value = model.OperateStatus;
            parameters[3].Value = model.TestStatus;
            parameters[4].Value = model.TestType;
            parameters[5].Value = model.UpdateTime;
            parameters[6].Value = model.Tag1;
            parameters[7].Value = model.Tag2;
            parameters[8].Value = model.Tag3;
            parameters[9].Value = model.Tag4;
            parameters[10].Value = model.Tag5;

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
        public bool Update(XWEDBAccess.Model.GoodsSiteModel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update GoodsSite set ");
            strSql.Append("HouseName=@HouseName,");
            strSql.Append("GoodsSiteName=@GoodsSiteName,");
            strSql.Append("OperateStatus=@OperateStatus,");
            strSql.Append("TestStatus=@TestStatus,");
            strSql.Append("TestType=@TestType,");
            strSql.Append("UpdateTime=@UpdateTime,");
            strSql.Append("Tag1=@Tag1,");
            strSql.Append("Tag2=@Tag2,");
            strSql.Append("Tag3=@Tag3,");
            strSql.Append("Tag4=@Tag4,");
            strSql.Append("Tag5=@Tag5");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID");
            SqlParameter[] parameters = {
					new SqlParameter("@HouseName", SqlDbType.NVarChar,50),
					new SqlParameter("@GoodsSiteName", SqlDbType.NVarChar,50),
					new SqlParameter("@OperateStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@TestStatus", SqlDbType.NVarChar,50),
					new SqlParameter("@TestType", SqlDbType.NVarChar,50),
					new SqlParameter("@UpdateTime", SqlDbType.DateTime),
					new SqlParameter("@Tag1", SqlDbType.NVarChar,500),
					new SqlParameter("@Tag2", SqlDbType.NVarChar,500),
					new SqlParameter("@Tag3", SqlDbType.NVarChar,500),
					new SqlParameter("@Tag4", SqlDbType.NVarChar,500),
					new SqlParameter("@Tag5", SqlDbType.NVarChar,500),
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt,8)};
            parameters[0].Value = model.HouseName;
            parameters[1].Value = model.GoodsSiteName;
            parameters[2].Value = model.OperateStatus;
            parameters[3].Value = model.TestStatus;
            parameters[4].Value = model.TestType;
            parameters[5].Value = model.UpdateTime;
            parameters[6].Value = model.Tag1;
            parameters[7].Value = model.Tag2;
            parameters[8].Value = model.Tag3;
            parameters[9].Value = model.Tag4;
            parameters[10].Value = model.Tag5;
            parameters[11].Value = model.GoodsSiteID;

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
        public bool Delete(long GoodsSiteID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GoodsSite ");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt)
			};
            parameters[0].Value = GoodsSiteID;

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
        public bool DeleteList(string GoodsSiteIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from GoodsSite ");
            strSql.Append(" where GoodsSiteID in (" + GoodsSiteIDlist + ")  ");
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
        public XWEDBAccess.Model.GoodsSiteModel GetModel(long GoodsSiteID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 GoodsSiteID,HouseName,GoodsSiteName,OperateStatus,TestStatus,TestType,UpdateTime,Tag1,Tag2,Tag3,Tag4,Tag5 from GoodsSite ");
            strSql.Append(" where GoodsSiteID=@GoodsSiteID");
            SqlParameter[] parameters = {
					new SqlParameter("@GoodsSiteID", SqlDbType.BigInt)
			};
            parameters[0].Value = GoodsSiteID;

            XWEDBAccess.Model.GoodsSiteModel model = new XWEDBAccess.Model.GoodsSiteModel();
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
        public XWEDBAccess.Model.GoodsSiteModel DataRowToModel(DataRow row)
        {
            XWEDBAccess.Model.GoodsSiteModel model = new XWEDBAccess.Model.GoodsSiteModel();
            if (row != null)
            {
                if (row["GoodsSiteID"] != null && row["GoodsSiteID"].ToString() != "")
                {
                    model.GoodsSiteID = long.Parse(row["GoodsSiteID"].ToString());
                }
                if (row["HouseName"] != null)
                {
                    model.HouseName = row["HouseName"].ToString();
                }
                if (row["GoodsSiteName"] != null)
                {
                    model.GoodsSiteName = row["GoodsSiteName"].ToString();
                }
                if (row["OperateStatus"] != null)
                {
                    model.OperateStatus = row["OperateStatus"].ToString();
                }
                if (row["TestStatus"] != null)
                {
                    model.TestStatus = row["TestStatus"].ToString();
                }
                if (row["TestType"] != null)
                {
                    model.TestType = row["TestType"].ToString();
                }
                if (row["UpdateTime"] != null && row["UpdateTime"].ToString() != "")
                {
                    model.UpdateTime = DateTime.Parse(row["UpdateTime"].ToString());
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
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select GoodsSiteID,HouseName,GoodsSiteName,OperateStatus,TestStatus,TestType,UpdateTime,Tag1,Tag2,Tag3,Tag4,Tag5 ");
            strSql.Append(" FROM GoodsSite ");
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
            strSql.Append(" GoodsSiteID,HouseName,GoodsSiteName,OperateStatus,TestStatus,TestType,UpdateTime,Tag1,Tag2,Tag3,Tag4,Tag5 ");
            strSql.Append(" FROM GoodsSite ");
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
            strSql.Append("select count(1) FROM GoodsSite ");
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
                strSql.Append("order by T.GoodsSiteID desc");
            }
            strSql.Append(")AS Row, T.*  from GoodsSite T ");
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
            parameters[0].Value = "GoodsSite";
            parameters[1].Value = "GoodsSiteID";
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


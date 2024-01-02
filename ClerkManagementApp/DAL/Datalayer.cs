using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; // Use the System.Data.SqlClient namespace for SQL Server
using System.Web.UI.WebControls;

namespace ClerkManagementApp.DAL
{
    class datalayer
    {
        SqlConnection conn_;
        SqlCommand cmd_;
        SqlDataReader reader_;

        SqlDataAdapter adptr_;
        DataSet dset_;
        DataTable dt_;
        static string getmessage { get; set; }

        public datalayer()
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
            conn_ = new SqlConnection(cs);
            cmd_ = new SqlCommand();
            adptr_ = new SqlDataAdapter();
            dset_ = new DataSet();
        }

        public bool Connect()
        {
            try
            {
                conn_.Open();
                getmessage = "Connection established!";
                return true;
            }
            catch (Exception exp)
            {
                getmessage = "Error while opening connection (Datalayer=>Connect()): " + exp.Message;
                return false;
            }
        }

        public bool Disconnect()
        {
            try
            {
                conn_.Close();
                getmessage = "Connection Closed Successfully!";
                return true;
            }
            catch (Exception exp)
            {
                getmessage = "Error while closing connection (Datalayer=>Disconnect()): " + exp.Message;
                return false;
            }
        }

        public string insertUpdateCreateOrDelete(string query)
        {
            string ret = "";
            string allqueries = query.ToLower();
            try
            {
                cmd_.CommandText = query;
                cmd_.Connection = conn_;
                Connect();

                cmd_.ExecuteNonQuery();
                if (allqueries.Contains("insert into "))
                {
                    ret = getmessage = "Inserted Successfully!";
                }
                else if (allqueries.Contains("delete from "))
                {
                    ret = getmessage = "Deleted Successfully!";
                }
                else if (allqueries.Contains("create table "))
                {
                    ret = getmessage = "Table Created Successfully!";
                }
                else if (allqueries.Contains("update ") && allqueries.Contains("set "))
                {
                    ret = getmessage = "Updated Successfully";
                }
            }
            catch (Exception exp)
            {
                ret = getmessage = "Failed to execute " + query + "\n Reason: " + exp.Message;
            }
            finally { Disconnect(); }
            return ret;
        }

        public string fillgridView(string query, GridView dgv)
        {
            dt_ = new DataTable();
            string stret;
            try
            {
                cmd_.Connection = conn_;
                cmd_.CommandText = query.ToLower();
                Connect();
                adptr_.SelectCommand = cmd_;

                adptr_.Fill(dt_);

                dgv.DataSource = dt_;
                dgv.DataBind();

                stret = "Code Executed Successfully (filldatagridView() => datalayer.cs)";
            }
            catch (Exception exp)
            {
                stret = "Failed (filldatagridView() => datalayer.cs): " + exp.Message;
            }
            finally
            {
                Disconnect();
                dt_ = null;
            }
            return stret;
        }
    }
}

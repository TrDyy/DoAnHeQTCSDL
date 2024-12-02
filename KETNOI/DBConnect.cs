using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KETNOI
{
    public class DBConnect
    {
        public SqlConnection conn;
        string connectionstring = "Data Source=NTDyy;Initial Catalog=DoAnHeQTCSDL02;Integrated Security=True";
        DataTable dt = new DataTable();
        public DBConnect()
        {
            conn = new SqlConnection(connectionstring);
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }

        public void openConnect()//mở kết nối nếu đang close
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        public void closeConnect()//đóng kết nối nếu đang mở
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public int getExecuteNonQuery(string caulenh)
        {
            openConnect();// truyền câu lệnh vào thực thi
            SqlCommand cmd = new SqlCommand(caulenh, conn);
            int kq = cmd.ExecuteNonQuery();//biến int kq lưu giá trị sau khi khi thực hiện câu truy vấn (vd: 2 rows effected )
            closeConnect();
            return kq;
        }
        public object getExecuteScalar(string caulenh)//hay dùng để lấy 1 tên, 1 số, 1 chuỗi gì đấy
        {
            openConnect();
            SqlCommand cmd = new SqlCommand(caulenh, conn);
            object kq = cmd.ExecuteScalar();//khai báo object vì dùng chung cho các kiểu dữ liệu
            closeConnect();                 //khi dùng biết chính xác kiểu dữ liệu lấy lên rồi ép kiểu sau 
            return kq;
        }

        public object getExecuteScalarWithParams(string caulenh, Dictionary<string, object> parameters)//hay dùng để lấy 1 tên, 1 số, 1 chuỗi gì đấy
        {
            openConnect();
            SqlCommand cmd = new SqlCommand(caulenh, conn);
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            object kq = cmd.ExecuteScalar();
            closeConnect();
            return kq;
        }




        public DataTable getDataTable(string sql)//hàm này lấy 1 bảng từ csdl
        {
            DataTable tmp = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(tmp);
            return tmp;
        }

        public int updateData(string sql, DataTable dt)//hàm truyền 1 datatable(bảng) và 1 câu truy vấn(thường là select) để cập nhật bảng xuống csdl
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            SqlCommandBuilder build = new SqlCommandBuilder(da);
            return da.Update(dt);
        }

        public DataTable getDataTableWithParams(string sql, Dictionary<string, object> parameters)
        {
            DataTable tmp = new DataTable();

            openConnect();

            SqlCommand cmd = new SqlCommand(sql, conn);
            // Thêm tham số vào SqlCommand
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            da.Fill(tmp); // Đổ dữ liệu vào DataTab
            closeConnect();
            return tmp;
        }


        public object getExecuteNonQueryWithParams(string query, Dictionary<string, object> parameters, string typeName)
        {
            openConnect();
            SqlCommand cmd = new SqlCommand(query, conn);
           
            // Thêm các tham số
            foreach (var param in parameters)
            {
                if (param.Value is DataTable dataTable)
                {
                    // Kiểm tra giá trị null hoặc trống của DataTable
                    if (dataTable.Rows.Count == 0)
                    {
                        throw new ArgumentException($"DataTable '{param.Key}' không có dữ liệu!");
                    }

                    // Thêm tham số kiểu Structured
                    var sqlParam = new SqlParameter
                    {
                        ParameterName = param.Key,
                        SqlDbType = SqlDbType.Structured,
                        TypeName = typeName,
                        Value = dataTable
                    };
                    cmd.Parameters.Add(sqlParam);
                }
                else
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                }
            }

            object result = cmd.ExecuteNonQuery();
            closeConnect();
            return result;
        }

        public void executeStoredProcedure(string procedureName, SqlParameter[] parameters)
        {
            try
            {
                openConnect();

                // Tạo đối tượng SqlCommand cho stored procedure
                SqlCommand cmd = new SqlCommand(procedureName, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                // Thêm tham số vào stored procedure
                cmd.Parameters.AddRange(parameters);

                // Thực thi lệnh
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thực thi Stored Procedure: " + ex.Message);
            }
            finally
            {
                closeConnect();
            }
        }
    }
}
   

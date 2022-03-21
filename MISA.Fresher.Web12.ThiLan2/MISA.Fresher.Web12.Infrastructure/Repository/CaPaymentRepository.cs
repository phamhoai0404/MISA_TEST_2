using Dapper;
using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Infrastructure.Repository
{
    public class CaPaymentRepository : BaseRepository<CaPayment>, ICaPaymentRepository
    {
       

        public string getCaPaymentNoMax()
        {
            //Thực hiện khởi tạo kết nối và sau khi làm xong là nó tự ngắt kết nối luôn
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                //Thực hiện truy vấn dữ liệu trong database
                var enities = SqlConnection.QueryFirstOrDefault<string>($"SELECT MAX(CaPaymentNo) FROM CaPayment");
                return enities;
            }
        }

        public object GetPagingV2(int pageIndex, int pageSize, string searchText, DateTime? startTime, DateTime? endTime)
        {

            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_GetCaPaymentPaging2";
                var parameters = new DynamicParameters();

                //Những thứ tìm kiếm trong bộ lọc
                parameters.Add("@m_StartTime", startTime);
                parameters.Add("@m_EndTime", endTime);

                //Những thứ input vào thông thường
                parameters.Add("@m_SearchText", searchText);
                parameters.Add("@m_PageIndex", pageIndex);
                parameters.Add("@m_PageSize", pageSize);

                parameters.Add("@m_TotalRecord", direction: System.Data.ParameterDirection.Output);
                parameters.Add("@m_TotalPage", direction: System.Data.ParameterDirection.Output);

                var entites = SqlConnection.Query(sql, param: parameters, commandType: System.Data.CommandType.StoredProcedure);//Thực hiện lấy các bản ghi
                var totalRecord = parameters.Get<int>("@m_TotalRecord");//Lấy tổng số bản ghi
                var totalPage = parameters.Get<int>("@m_TotalPage");//Lấy tổng số trang

                return new
                {
                    Data = entites,//Trả về bảng
                    TotalRecord = totalRecord,//Trả về tổng số bản ghi
                    TotalPage = totalPage//Trả về tổng số trang
                };

            }
        }

        public int DeleteMany(string listId)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_DeleteMultipleCaPayment2";
                var parameters = new DynamicParameters();

                //Truyền vào listId ngăn cách nhau bằng dấu (,)
                parameters.Add("@m_ListId", listId);
                var res = SqlConnection.Execute(sql, param: parameters, commandType: System.Data.CommandType.StoredProcedure);//Thực hiện câu lệnh

                return res;

            }
        }
    }
}

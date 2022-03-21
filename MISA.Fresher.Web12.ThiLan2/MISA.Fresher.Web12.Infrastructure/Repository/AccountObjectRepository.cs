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
    public class AccountObjectRepository : BaseRepository<AccountObject>, IAccountObjectRepository
    {
        public object GetPagingV2(int pageIndex, int pageSize, string searchText, string? accountObjectGroupCode, string? provinceOrCity, string? district, string? wardOrCommune)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_GetAccountObjectPaging2";
                var parameters = new DynamicParameters();

                //Những thứ tìm kiếm trong bộ lọc
                parameters.Add("@m_AccountObjectGroupCode", accountObjectGroupCode);
                parameters.Add("@m_ProvinceOrCity", provinceOrCity);
                parameters.Add("@m_District", district);
                parameters.Add("@m_WardOrCommune", wardOrCommune);

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

        public int DeleteManyId(string listId)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var sql = $"Proc_DeleteMultipleAccountObject2";
                var parameters = new DynamicParameters();

                //Truyền vào listId ngăn cách nhau bằng dấu (,)
                parameters.Add("@m_ListId", listId);
                var res = SqlConnection.Execute(sql, param: parameters, commandType: System.Data.CommandType.StoredProcedure);//Thực hiện câu lệnh

                return res;

            }
        }
    }
}

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
    }
}

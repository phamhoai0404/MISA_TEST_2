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
    public class ControlCaPaymentRepository : IControlCaPaymentRepository
    {
        //1.Khai báo thông tin của CSDL
        protected string ConnectionString = Core.Resourcs.ResourceVN.ConnectionString;

        //2.Khởi tạo kết nối
        protected MySqlConnection SqlConnection;


      

        public object GetByCaPaymentId(Guid caPaymentId)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var sqlCommand = $"SELECT * FROM View_AllCaPayment WHERE CaPaymentId = @Id;";

                var sqlCommand2 = $"SELECT * FROM View_AllCaPaymentDetail WHERE CaPaymentId= @Id;";

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", caPaymentId);

                var entity = SqlConnection.QueryFirstOrDefault<CaPayment>(sqlCommand, param: parameters);
                var listDetail = SqlConnection.Query<CaPaymentDetail>(sqlCommand2, param:parameters);


                return new {
                    Master =  entity,// Trả về entity của CaPayment by Id
                    ListDetail = listDetail,
                };
            }
        }
    }
}

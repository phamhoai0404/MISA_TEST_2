using Dapper;
using MISA.Fresher.Web12.Core.Entities;
using MISA.Fresher.Web12.Core.Interfaces.Infrastructure;
using MISA.Fresher.Web12.Core.MISAAttribute;
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

        public int DeleteByCaPaymentId(Guid id)
        {
            //Thực hiện khởi tạo kết nối và sau khi làm xong là nó tự ngắt kết nối luôn
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                //Thực hiện xóa CaPaymentDetail trước
                var sqlcommand = $"DELETE FROM CaPaymentDetail WHERE  CaPaymentId= @Id ";
                var res = SqlConnection.Execute(sqlcommand, param: new { Id = id });

                //Thực hiện xóa CaPayment
                var sqlcommand2 = $"DELETE FROM CaPayment WHERE  CaPaymentId= @Id ";
                var res2 = SqlConnection.Execute(sqlcommand2, param: new { Id = id });

                var resTotal = res + res2;

                return resTotal;
            }
        }

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

        public int InsertControlCaPayment(ControlCaPayment entity)
        {
            //Thực hiện khởi tạo kết nối và sau khi làm xong là nó tự ngắt kết nối luôn
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var sqlColumNames = new StringBuilder();
                var sqlColumnValues = new StringBuilder();

                DynamicParameters parameters = new DynamicParameters();

                //Duyệt tất cả các property của đối tượng của enity CaPayment
                var props = typeof(CaPayment).GetProperties();
                string tempCaPaymentId = "";

                string delimiter = "";
                foreach (var prop in props)
                {
                    //Lấy tên của property
                    var propName = prop.Name;
                    var propValue = prop.GetValue(entity.CaPayment);

                    //Nếu nó là không phải là thuộc tính của sql thì bỏ vòng lặp này rồi tiếp tục vòng for
                    var map = Attribute.IsDefined(prop, typeof(NotMapSQL));
                    if (map == true) continue;

                    //Kiểm tra property có phải là khóa chính hay không 
                    var primaryKey = Attribute.IsDefined(prop, typeof(Primarykey));
                    if (primaryKey == true || propName == $"CaPaymentId")//Viết như này cho chắc chắn ấy mà 
                    {
                        if (prop.PropertyType == typeof(Guid?))
                        {
                            propValue = Guid.NewGuid();
                            tempCaPaymentId = propValue.ToString();
                        }
                    }

                    //Lấy tên
                    var paramName = $"@{propName}";
                    sqlColumNames.Append($"{delimiter}{propName}");
                    sqlColumnValues.Append($"{delimiter}{paramName}");
                    delimiter = ",";

                    parameters.Add(paramName, propValue);
                }

              


                string tempListDetail= "";

                //Duyệt tất cả các property của đối tượng của enity CaPaymentDetail
                props = typeof(CaPaymentDetail).GetProperties();

                //Viết câu sql chèn vào bảng CaPaymentDetail là detail
                for (int i = 0; i < entity.ListCaPaymentDetail.Count; i++)
                {
                    string tempItem = "( ";
                    delimiter = "";

                    
                    foreach (var prop in props)
                    {
                        //Lấy tên của property của từng cái detail
                        var propName = prop.Name;
                        var propValue = prop.GetValue(entity.ListCaPaymentDetail[i]);

                        //Nếu nó là không phải là thuộc tính của sql thì bỏ vòng lặp này rồi tiếp tục vòng for
                        var map = Attribute.IsDefined(prop, typeof(NotMapSQL));
                        if (map == true) continue;

                        //Kiểm tra property có phải là khóa chính hay không 
                        var primaryKey = Attribute.IsDefined(prop, typeof(Primarykey));
                        if (primaryKey == true || propName == $"CaPaymentDetailId")//Viết như này cho chắc chắn ấy mà 
                        {
                            if (prop.PropertyType == typeof(Guid?))
                            {
                                propValue = Guid.NewGuid();
                            }
                        }

                        if (propName == "CaPaymentId")//Nếu nó bằng những tên master thì nó bằng id vừa ghi tạm ở bên trên
                        {
                            propValue = tempCaPaymentId;
                        }

                        var paramName = $"@{propName}{i}";

                        tempItem += $"{delimiter}{paramName}";
                        delimiter = ",";
                       
                        parameters.Add(paramName, propValue);//add giá trị vào parameter

                    }
                    tempItem +=" ),";
                    tempListDetail += tempItem;
                }
               
                tempListDetail = tempListDetail.TrimEnd(',');

                //Viết câu lệnh sql chèn vào bảng CaPayment đó là master
                var sqlCommand = $"INSERT INTO CaPayment ({sqlColumNames.ToString()}) VALUES ({sqlColumnValues.ToString()});";
                //Thực hiện thêm mới dữ liệu
                var resMaster = SqlConnection.Execute(sqlCommand, param: parameters);

                //Viết câu lệnh sql chèn vào bảng CaPaymentDetail đó là detail
                var sqlCommandDetail = $"INSERT INTO CaPaymentDetail (" +
                    $"CaPaymentDetailId, CaPaymentId, DecriptionDetail, DebitAccountId, CreditAccountId, Amount, AccountObjectId, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy )" +
                    $" VALUES {tempListDetail};";
                //Thực hiện thêm mới dữ liệu
                var resDetail = SqlConnection.Execute(sqlCommandDetail, param: parameters);

                var resAll = resMaster + resDetail;

                return resAll;

            }
          
        }
    }
}

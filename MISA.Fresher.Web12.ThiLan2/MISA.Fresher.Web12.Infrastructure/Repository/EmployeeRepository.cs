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

    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {

        public int DeleteManyId(List<string> listEmployeeId)
        {
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();

                var sqlValue = new StringBuilder();
                string delimiter = "";
                for (int i = 0; i < listEmployeeId.Count; i++)
                {
                    var employeeIdName = $"@EmployeeId{i}";
                    parameters.Add(employeeIdName, listEmployeeId[i]);
                    sqlValue.Append($"{delimiter}EmployeeId = {employeeIdName}");
                    delimiter = " || ";
                }

                //Viết câu lệnh sql
                var sqlCommand = $"DELETE FROM Employee WHERE {sqlValue.ToString()}";

                //Thực hiện xóa hàng loạt
                var res = SqlConnection.Execute(sqlCommand, param: parameters);
                return res;
            }
        }

    }
}

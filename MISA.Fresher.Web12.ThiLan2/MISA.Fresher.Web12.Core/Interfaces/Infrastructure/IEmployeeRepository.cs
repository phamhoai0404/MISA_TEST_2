﻿using MISA.Fresher.Web12.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher.Web12.Core.Interfaces.Infrastructure
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        /// <summary>
        /// Thực hiện xóa nhiều dòng theo list EmployeeId truyền vào
        /// </summary>
        /// <param name="listEmployeeId"></param>
        /// <returns></returns>
        /// Created: HoaiPT(14/02/2022)
        int DeleteManyId(List<string> listEmployeeId);
    }
}

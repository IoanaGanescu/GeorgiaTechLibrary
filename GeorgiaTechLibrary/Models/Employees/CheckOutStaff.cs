﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeorgiaTechLibrary.Models.Employees
{
    public class CheckOutStaff : Employee
    {
        public CheckOutStaff()
        {
            this.Title = (short) EmployeeEnum.CheckOutStaff;
        }
    }
}
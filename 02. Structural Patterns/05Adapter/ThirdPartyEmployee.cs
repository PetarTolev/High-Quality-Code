﻿namespace Adapter
{
    using System.Collections.Generic;

    public class ThirdPartyEmployee
    {
        public List<string> GetEmployeeList()
        {
            List<string> EmployeeList = new List<string>();

            EmployeeList.Add("Peter");
            EmployeeList.Add("Paul");
            EmployeeList.Add("Puru");
            EmployeeList.Add("Preethi");

            return EmployeeList;
        }
    }
}
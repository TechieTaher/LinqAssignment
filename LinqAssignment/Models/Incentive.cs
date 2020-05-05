using System;
using System.Collections.Generic;
using System.Text;

namespace LinqAssignment.Models
{
    public class Incentive
    {
        public int IncentiveId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime IncentiveDate { get; set; }
        public int IncentiveAmount { get; set; }
    }
}

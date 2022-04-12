using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryShiryaev2isp11_17.ClassHelper;
using LibraryShiryaev2isp11_17.EF;
using System.Data.Entity.SqlServer;
namespace LibraryShiryaev2isp11_17.ClassHelper
{
   public partial class Penalty
    {
        public static double Debt(double Cost,   DateTime dateStart)
        {
            int dayCount = (DateTime.Now - dateStart).Days;
            double debt = (dayCount - 30) * 0.01 * Cost;
            if (debt >0)
            {
                return debt;
            }
            else
            {
                return 0;
            }
          
        }

        
    }
}


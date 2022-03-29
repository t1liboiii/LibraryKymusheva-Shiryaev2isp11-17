using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryShiryaev2isp11_17.ClassHelper;
using LibraryShiryaev2isp11_17.EF;
namespace LibraryShiryaev2isp11_17.ClassHelper
{
   public static class Penalty
    {
        public static double DebtClient(DateTime dateStart, double price)
        {
            int dayCount = (DateTime.Now - dateStart).Days;
            double debt = (dayCount - 30) * 0.01 * price;
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


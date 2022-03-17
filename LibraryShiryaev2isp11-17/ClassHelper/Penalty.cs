using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryShiryaev2isp11_17.ClassHelper;
using LibraryShiryaev2isp11_17.EF;
namespace LibraryShiryaev2isp11_17.ClassHelper
{
    class Penalty
    {
        public static double DebtClient(int IDClient)
        {
            var issues = AppData.Context.Issue.ToList().Where(i => i.ClientID == IDClient);
            var books = AppData.Context.Book.ToList();
            double result = 0;

            foreach (Issue issue in issues)
            {
                DateTime dateReturn = (DateTime)issue.DateReturn;
                DateTime? dateTurnIn = issue.DateTrunIn;
                DateTime dateEnd;
                if (dateTurnIn == null)
                {
                    dateEnd = DateTime.Now;
                }
                else
                {
                    dateEnd = (DateTime)dateTurnIn;
                }
                TimeSpan interval = dateEnd - dateReturn;
                double days = interval.TotalDays;
                if (days > 30)
                {
                    int BookID = (int)issue.BookID;
                    Book book = books.FirstOrDefault(i => i.BookID == BookID);
                    double price = (double)book.Price;
                    result += price / 100 * (days - 30);
                }
            }
                
            return result;
        }
        public static double Debt(double bookPrice, DateTime dateReturn, DateTime? dateTurnIn, bool isPaidFor)
        {
            if (isPaidFor)
            {
                return 0;
            }
            DateTime dateEnd;
            if (dateTurnIn == null)
            {
                dateEnd = DateTime.Now;
            }
            else
            {
                dateEnd = (DateTime)dateTurnIn;
            }
            if (dateReturn >= dateEnd)
            {
                return 0;
            }
            return bookPrice / 100 * ((int)(dateEnd - dateReturn).TotalDays - 30);
        }

    }
}


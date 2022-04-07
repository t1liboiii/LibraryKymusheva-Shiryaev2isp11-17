using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryShiryaev2isp11_17.ClassHelper;
using LibraryShiryaev2isp11_17.EF;

namespace LibraryShiryaev2isp11_17.EF
{
     public partial class  Debt
    {
        
            public string GetDebt { get => $"Процент остатка: {Debt}"; }

            public string GetColor

            {
                get
                {
                    if (DebtRatio > 0)
                    {
                        return "#ff0000";
                    }
                    else
                    {
                        return "#ffffff";
                    }
                }
            }

        }   
    }


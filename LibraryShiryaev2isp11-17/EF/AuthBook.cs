//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibraryShiryaev2isp11_17.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class AuthBook
    {
        public int ID { get; set; }
        public Nullable<int> BookID { get; set; }
        public Nullable<int> AuthorID { get; set; }
    
        public virtual Author Author { get; set; }
    }
}
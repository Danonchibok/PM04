//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pm04.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Items_order
    {
        public int ID { get; set; }
        public Nullable<int> ID_Items { get; set; }
        public Nullable<int> ID_Orders { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
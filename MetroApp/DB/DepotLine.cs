//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MetroApp.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepotLine
    {
        public byte ID { get; set; }
        public byte DepotID { get; set; }
        public short LineObjectID { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    
        public virtual Depot Depot { get; set; }
        public virtual LineObject LineObject { get; set; }
    }
}
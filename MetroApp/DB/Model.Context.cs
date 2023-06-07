﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MetroDB_VKR_Entities2 : DbContext
    {
        public MetroDB_VKR_Entities2()
            : base("name=MetroDB_VKR_Entities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Construction> Construction { get; set; }
        public virtual DbSet<Decade> Decade { get; set; }
        public virtual DbSet<Depot> Depot { get; set; }
        public virtual DbSet<DepotLine> DepotLine { get; set; }
        public virtual DbSet<DepthType> DepthType { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Floor> Floor { get; set; }
        public virtual DbSet<HallPhoto> HallPhoto { get; set; }
        public virtual DbSet<HousingCost> HousingCost { get; set; }
        public virtual DbSet<LineHistory> LineHistory { get; set; }
        public virtual DbSet<LineObject> LineObject { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Map> Map { get; set; }
        public virtual DbSet<Peculiarity> Peculiarity { get; set; }
        public virtual DbSet<PhotoAngle> PhotoAngle { get; set; }
        public virtual DbSet<Pillar> Pillar { get; set; }
        public virtual DbSet<Platform> Platform { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Span> Span { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<StationHistory> StationHistory { get; set; }
        public virtual DbSet<StationObject> StationObject { get; set; }
        public virtual DbSet<StationPhoto> StationPhoto { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<StructuralComplex> StructuralComplex { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TrafficDescription> TrafficDescription { get; set; }
        public virtual DbSet<TrafficType> TrafficType { get; set; }
        public virtual DbSet<Train> Train { get; set; }
        public virtual DbSet<TrainSeries> TrainSeries { get; set; }
        public virtual DbSet<TransferHistory> TransferHistory { get; set; }
        public virtual DbSet<TransferObject> TransferObject { get; set; }
        public virtual DbSet<TransferType> TransferType { get; set; }
        public virtual DbSet<User> User { get; set; }
    
        [DbFunction("MetroDB_VKR_Entities2", "FUNC_LineHistory")]
        public virtual IQueryable<FUNC_LineHistory_Result> FUNC_LineHistory(Nullable<System.DateTime> dATE)
        {
            var dATEParameter = dATE.HasValue ?
                new ObjectParameter("DATE", dATE) :
                new ObjectParameter("DATE", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<FUNC_LineHistory_Result>("[MetroDB_VKR_Entities2].[FUNC_LineHistory](@DATE)", dATEParameter);
        }
    }
}

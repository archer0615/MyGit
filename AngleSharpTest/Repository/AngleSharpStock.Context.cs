﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repository
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AngleSharpEntities : DbContext
    {
        public AngleSharpEntities()
            : base("name=AngleSharpEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_Category> T_Category { get; set; }
        public virtual DbSet<T_SE> T_SE { get; set; }
        public virtual DbSet<T_Stock> T_Stock { get; set; }
        public virtual DbSet<T_Yields> T_Yields { get; set; }
        public virtual DbSet<T_StockCompany> T_StockCompany { get; set; }
        public virtual DbSet<VW_AverageYields> VW_AverageYields { get; set; }
        public virtual DbSet<T_User> T_User { get; set; }
        public virtual DbSet<T_Role> T_Role { get; set; }
        public virtual DbSet<T_Optional> T_Optional { get; set; }
    }
}

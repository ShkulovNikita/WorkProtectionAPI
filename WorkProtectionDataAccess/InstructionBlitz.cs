//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WorkProtectionDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class InstructionBlitz
    {
        public int Id { get; set; }
        public System.Guid Guid { get; set; }
        public System.Guid RecordGuid { get; set; }
        public string SearchName { get; set; }
        public string SearchNumber { get; set; }
        public bool IsBlocked { get; set; }
    }
}
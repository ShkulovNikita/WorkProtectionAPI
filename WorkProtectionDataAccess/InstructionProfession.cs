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
    
    public partial class InstructionProfession
    {
        public int Id { get; set; }
        public System.Guid InstructionGuid { get; set; }
        public int ProfessionId { get; set; }
    
        public virtual Post Post { get; set; }
    }
}

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
    
    public partial class InstructionFile
    {
        public int Id { get; set; }
        public System.Guid InstructionGuid { get; set; }
        public System.Guid FileGuid { get; set; }
        public int InstructionVersion { get; set; }
    
        public virtual AttachedFile AttachedFile { get; set; }
    }
}

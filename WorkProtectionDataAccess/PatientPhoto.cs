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
    
    public partial class PatientPhoto
    {
        public int Id { get; set; }
        public System.Guid PatientGuid { get; set; }
        public string PhotoOriginal { get; set; }
        public string Photo128 { get; set; }
        public Nullable<bool> isVerifed { get; set; }
        public Nullable<bool> isDeleted { get; set; }
        public string SrcOriginal { get; set; }
        public string Src600 { get; set; }
        public string Src200 { get; set; }
        public string Src50 { get; set; }
    }
}

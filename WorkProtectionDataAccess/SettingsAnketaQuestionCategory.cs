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
    
    public partial class SettingsAnketaQuestionCategory
    {
        public int VersionId { get; set; }
        public System.Guid RecordGuid { get; set; }
        public int Number { get; set; }
        public Nullable<int> Poryadok_prohozhdeniya { get; set; }
        public string QuestionCategory { get; set; }
        public Nullable<int> QuestionCategoryId { get; set; }
        public Nullable<int> Kolichestvo_voprosov { get; set; }
    }
}
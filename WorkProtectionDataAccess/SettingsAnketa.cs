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
    
    public partial class SettingsAnketa
    {
        public int VersionId { get; set; }
        public System.Guid RecordGuid { get; set; }
        public int Number { get; set; }
        public Nullable<bool> Izmeryatj_parametr { get; set; }
        public Nullable<int> Poryadok_prohozhdeniya { get; set; }
        public Nullable<bool> Rezhim_obucheniya { get; set; }
        public Nullable<int> SurveyTime { get; set; }
        public Nullable<bool> RepeatQuestion { get; set; }
        public Nullable<bool> RepeatQuestionIsCorrect { get; set; }
    }
}
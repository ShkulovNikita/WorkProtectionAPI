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
    
    public partial class SurveyTemplateQuestionCategory
    {
        public System.Guid TemplateGuid { get; set; }
        public Nullable<int> TemplateRecordSystemNumber { get; set; }
        public System.Guid TemplateRecordGuid { get; set; }
        public int TemplateVersionNumber { get; set; }
        public int QuestionCount { get; set; }
        public Nullable<int> QuestionOrder { get; set; }
        public string QuestionCategoryName { get; set; }
        public int QuestionCategoryId { get; set; }
    }
}

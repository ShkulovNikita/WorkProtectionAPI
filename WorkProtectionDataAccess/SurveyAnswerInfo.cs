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
    
    public partial class SurveyAnswerInfo
    {
        public int Id { get; set; }
        public System.Guid PatientGuid { get; set; }
        public Nullable<int> QuestionCategoryId { get; set; }
        public int SurveyId { get; set; }
        public System.Guid QuestionGuid { get; set; }
        public int QuestionVersionNumber { get; set; }
        public string QuestionName { get; set; }
        public Nullable<int> SelectedAnswerNumber { get; set; }
        public string SelectedAnswerName { get; set; }
        public int SelectedAnswerTypeId { get; set; }
        public Nullable<int> CorrectAnswerNumber { get; set; }
        public string CorrectAnswerName { get; set; }
    }
}

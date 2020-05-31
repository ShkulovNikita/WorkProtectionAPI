﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class WorkProtectionEntities : DbContext
    {
        public WorkProtectionEntities()
            : base("name=WorkProtectionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<PatientDactilography> PatientDactilography { get; set; }
        public virtual DbSet<PatientPhoto> PatientPhoto { get; set; }
        public virtual DbSet<PatientRelation> PatientRelation { get; set; }
        public virtual DbSet<PatientRelationType> PatientRelationType { get; set; }
        public virtual DbSet<PatientStatus> PatientStatus { get; set; }
        public virtual DbSet<PatientStatusType> PatientStatusType { get; set; }
        public virtual DbSet<AttachedFile> AttachedFile { get; set; }
        public virtual DbSet<AttachedFileFolder> AttachedFileFolder { get; set; }
        public virtual DbSet<Record> Record { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<Instruction> Instruction { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswer { get; set; }
        public virtual DbSet<SettingsAnketa> SettingsAnketa { get; set; }
        public virtual DbSet<SettingsAnketaQuestionCategory> SettingsAnketaQuestionCategory { get; set; }
        public virtual DbSet<SurveyTemplate> SurveyTemplate { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserProfilePhoto> UserProfilePhoto { get; set; }
        public virtual DbSet<Briefing> Briefing { get; set; }
        public virtual DbSet<BriefingAttachedFile> BriefingAttachedFile { get; set; }
        public virtual DbSet<BriefingReport> BriefingReport { get; set; }
        public virtual DbSet<BriefingReportSettings> BriefingReportSettings { get; set; }
        public virtual DbSet<Instruction1> Instruction1 { get; set; }
        public virtual DbSet<InstructionBlitz> InstructionBlitz { get; set; }
        public virtual DbSet<InstructionBlitzCategory> InstructionBlitzCategory { get; set; }
        public virtual DbSet<InstructionBlitzFile> InstructionBlitzFile { get; set; }
        public virtual DbSet<InstructionCategory> InstructionCategory { get; set; }
        public virtual DbSet<InstructionFile> InstructionFile { get; set; }
        public virtual DbSet<InstructionProfession> InstructionProfession { get; set; }
        public virtual DbSet<InstructionSettings> InstructionSettings { get; set; }
        public virtual DbSet<Question1> Question1 { get; set; }
        public virtual DbSet<QuestionAnswerCorrectPercent> QuestionAnswerCorrectPercent { get; set; }
        public virtual DbSet<QuestionCategory> QuestionCategory { get; set; }
        public virtual DbSet<Survey> Survey { get; set; }
        public virtual DbSet<SurveyAnswer> SurveyAnswer { get; set; }
        public virtual DbSet<SurveyAttachedFile> SurveyAttachedFile { get; set; }
        public virtual DbSet<SurveyReport> SurveyReport { get; set; }
        public virtual DbSet<SurveyReportSettings> SurveyReportSettings { get; set; }
        public virtual DbSet<SurveyReportSettingsEmployee> SurveyReportSettingsEmployee { get; set; }
        public virtual DbSet<SurveyTemplate1> SurveyTemplate1 { get; set; }
        public virtual DbSet<SurveyTemplateDevice> SurveyTemplateDevice { get; set; }
        public virtual DbSet<SurveyTemplatePatient> SurveyTemplatePatient { get; set; }
        public virtual DbSet<SurveyTemplateProfession> SurveyTemplateProfession { get; set; }
        public virtual DbSet<SurveyType> SurveyType { get; set; }
        public virtual DbSet<PatientTable> PatientTable { get; set; }
        public virtual DbSet<BriefingReportSettingsEmployee> BriefingReportSettingsEmployee { get; set; }
        public virtual DbSet<PatientFullInfo> PatientFullInfo { get; set; }
        public virtual DbSet<InstructionBlitzInfo> InstructionBlitzInfo { get; set; }
        public virtual DbSet<InstructionInfo> InstructionInfo { get; set; }
        public virtual DbSet<InstructionProfessionInfo> InstructionProfessionInfo { get; set; }
        public virtual DbSet<QuestionAnswerInfo> QuestionAnswerInfo { get; set; }
        public virtual DbSet<QuestionInfo> QuestionInfo { get; set; }
        public virtual DbSet<SurveyAnswerInfo> SurveyAnswerInfo { get; set; }
        public virtual DbSet<SurveyTemplateDeviceInfo> SurveyTemplateDeviceInfo { get; set; }
        public virtual DbSet<SurveyTemplateFullInfo> SurveyTemplateFullInfo { get; set; }
        public virtual DbSet<SurveyTemplateInfo> SurveyTemplateInfo { get; set; }
        public virtual DbSet<SurveyTemplatePatientInfo> SurveyTemplatePatientInfo { get; set; }
        public virtual DbSet<SurveyTemplateProfessionInfo> SurveyTemplateProfessionInfo { get; set; }
        public virtual DbSet<SurveyTemplateQuestionCategory> SurveyTemplateQuestionCategory { get; set; }
    }
}

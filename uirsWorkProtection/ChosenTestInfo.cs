using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uirsWorkProtection
{
    public class ChosenTestInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public string[] Questions { get; set; }
        public string[] TypesOfQuestions { get; set; }
        public string[] NamesOfFiles { get; set; }
        public int[] NumberOfAnswers { get; set; }
        public string[] Answers { get; set; }
        public int[] AnswersCorrectness { get; set; }

        public ChosenTestInfo(Guid id, string name, int time, string[] questions, string[] typesOfQuestions, string[] namesOfFiles, int[] numberOfAnswers, string[] answers, int[] answersCorrectness)
        {
            Id = id;
            Name = name;
            Time = time;
            Questions = questions;
            TypesOfQuestions = typesOfQuestions;
            NamesOfFiles = namesOfFiles;
            NumberOfAnswers = numberOfAnswers;
            Answers = answers;
            AnswersCorrectness = answersCorrectness;
        }
    }
}
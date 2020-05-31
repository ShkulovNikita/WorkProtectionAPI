using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uirsWorkProtection
{
    public class InstructionBlitzInfo
    {
        public Guid[] Id { get; set; }
        public string[] Names { get; set; }
        public string[] Dates { get; set; }
        public string[] Files { get; set; }

        public InstructionBlitzInfo(Guid[] id, string[] names, string[] dates, string[] files)
        {
            Id = id;
            Names = names;
            Dates = dates;
            Files = files;
        }
    }
}
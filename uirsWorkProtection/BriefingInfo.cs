using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace uirsWorkProtection
{
    public class BriefingInfo
    {
        public Guid[] Id { get; set; }
        public string[] Names { get; set; }
        public string[] ExpireDates { get; set; }
        public string[] Files { get; set; }
        public bool[] Passed { get; set; }

        public BriefingInfo (Guid[] id, string[] names, string[] expireDates, string[] files, bool[] passed)
        {
            Id = id;
            Names = names;
            ExpireDates = expireDates;
            Files = files;
            Passed = passed;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportFromXmlAndTxt.Dto
{
    public class OutputDto
    {
        public int PersonNumber { get; set; }
        public string PersonFullName { get; set; }
        public string ErrorTitle { get; set; }
        public string ErrorDescription { get; set; }
        public string ErrorExplanation { get; set; }
    }
}

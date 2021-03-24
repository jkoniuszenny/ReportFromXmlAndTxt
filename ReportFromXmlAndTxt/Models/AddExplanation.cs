using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace ReportFromXmlAndTxt.Models
{
    public partial class AddExplanation : Form
    {
        public ErrorExplanationDto errorExplanation;
        private static int _row = 0;

        public AddExplanation()
        {
            InitializeComponent();
        }

        private void b_SaveNewExplanation_Click(object sender, EventArgs e)
        {
            if (rtb_Explanation.Text == "")
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            errorExplanation = new ErrorExplanationDto();

            errorExplanation.ErrorType = "All";
            errorExplanation.ErrorTitle = tb_ErrorTitle.Text;
            errorExplanation.ErrorExplanation = rtb_Explanation.Text;

            FileInfo xlsTmpFileName = new FileInfo(@$"ErrorExplanation.xlsx");
            ExcelPackage excelFile = new ExcelPackage(xlsTmpFileName);
            var ws = excelFile.Workbook.Worksheets[0];

            if (_row == 0)
                _row = ws.Dimension.End.Row;

            _row++;

            ws.Cells[_row, 1].Value = "";
            ws.Cells[_row, 2].Value = errorExplanation.ErrorTitle;
            ws.Cells[_row, 3].Value = errorExplanation.ErrorExplanation;


            excelFile.Save();
            excelFile.Stream.Close();


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}

using ReportFromXmlAndTxt.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using ReportFromXmlAndTxt.Dto;
using OfficeOpenXml;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace ReportFromXmlAndTxt
{
    public partial class ErrorReportGenerator : Form
    {
        private FormBCTransmitterSubmissionDtl formBCTransmitterSubmissionDtl = null;
        private List<TxtInput> _txtInput = null;

        public ErrorReportGenerator()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            InitializeComponent();
        }

        private void b_Create_Click(object sender, EventArgs e)
        {
            try
            {
                if (formBCTransmitterSubmissionDtl is null || _txtInput is null)
                {
                    MessageBox.Show("You didn't select XML or txt file.");
                    return;
                }

                List<OutputDto> output = new List<OutputDto>();

                formBCTransmitterSubmissionDtl.ACATransmitterSubmissionDetail.TransmitterErrorDetailGrp.All(a =>
                {

                    string[] uniqe = a?.UniqueRecordId?.Split("|");
                    if (uniqe is { })
                    {
                        int personNumber = Convert.ToInt32(uniqe[2]);
                        TxtInput single = _txtInput.FirstOrDefault(f => f.PersonNumber == personNumber);
                        output.Add(new OutputDto()
                        {
                            ErrorTitle = a.ErrorMessageDetail.ErrorMessageCd,
                            ErrorDescription = a.ErrorMessageDetail.ErrorMessageTxt,
                            PersonNumber = personNumber,
                            PersonFullName = $"{single.Firstname} {single.Lastname}"
                        });
                    }


                    return true;
                });


                FileInfo xlsTmpFileName = new FileInfo($"Report{DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss")}.xlsx");
                ExcelPackage excelFile = new ExcelPackage(xlsTmpFileName);

                if (excelFile.Workbook.Worksheets.Count == 0)
                {
                    excelFile.Workbook.Worksheets.Add("Report");

                }
                var ws = excelFile.Workbook.Worksheets[0];

                ws.Cells[1, 1].Value = "Person";
                ws.Cells[1, 2].Value = "Error title";
                ws.Cells[1, 3].Value = "Error description";
                ws.Cells[1, 4].Value = "Error explanation";

                int row = 2;

                foreach (var item in output.OrderBy(o => o.ErrorTitle))
                {
                    ws.Cells[row, 1].Value = $"{item.PersonFullName} - {item.PersonNumber}";
                    ws.Cells[row, 2].Value = item.ErrorTitle;
                    ws.Cells[row, 3].Value = item.ErrorDescription;
                    ws.Cells[row, 4].Value = "";
                    row++;
                }

                FileStream fs = new FileStream(xlsTmpFileName.FullName, FileMode.Create);
                excelFile.SaveAs(fs);

                fs.Close();

                MessageBox.Show("I'm done. Your report is ready.");

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}");
            }
        }

        private void b_Open_Xml_Click(object sender, EventArgs e)
        {
            try
            {
                if (fd_XmlFile.ShowDialog() == DialogResult.OK)
                {

                    var filePath = fd_XmlFile.FileName;

                    tb_XmlInput.Text = filePath;

                    XmlSerializer serializer = new XmlSerializer(typeof(FormBCTransmitterSubmissionDtl));

                    StreamReader reader = new StreamReader(filePath);
                    formBCTransmitterSubmissionDtl = (FormBCTransmitterSubmissionDtl)serializer.Deserialize(reader);
                    reader.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Something went wrong: {ex.Message}");
            }
        }

        private void b_Open_Txt_Click(object sender, EventArgs e)
        {
            try
            {
                if (fd_TxtFile.ShowDialog() == DialogResult.OK)
                {

                    var filePath = fd_TxtFile.FileName;

                    tb_TxtInput.Text = filePath;

                    _txtInput = new List<TxtInput>();

                    string[] txtLines = File.ReadAllLines(filePath);

                    txtLines.All(a =>
                    {
                        string[] splittedText = a.Split(" ");

                        _txtInput.Add(new TxtInput()
                        {
                            PersonNumber = Convert.ToInt32(splittedText[0]),
                            Firstname = splittedText[1],
                            Lastname = splittedText[2]
                        });

                        return true;

                    });

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Something went wrong: {ex.Message}");
            }
        }
    }
}

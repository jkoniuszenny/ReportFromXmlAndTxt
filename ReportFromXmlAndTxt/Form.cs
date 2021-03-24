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

                string fileName = fd_TxtFile.SafeFileName.Split(" ")[0].Replace("[", "");
                sfd_SaveFile.FileName = $"{fileName} Company - Explanation of Errors.xlsx";

                if (sfd_SaveFile.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(@$"ErrorExplanation.xlsx");
                    var explanationExcelFile = new ExcelPackage(fi);
                    var wse = explanationExcelFile.Workbook.Worksheets[0];

                    var start = wse.Dimension.Start;
                    var end = wse.Dimension.End;

                    List<ErrorExplanationDto> errorExplanation = new List<ErrorExplanationDto>();

                    for (int r = start.Row + 1; r <= end.Row; r++)
                    {
                        errorExplanation.Add(new ErrorExplanationDto()
                        {
                            ErrorType = wse.Cells[r, 1].Text == "" ? "All" : wse.Cells[r, 1].Text,
                            ErrorTitle = wse.Cells[r, 2].Text,
                            ErrorExplanation = wse.Cells[r, 3].Text
                        });
                    }

                    AddExplanation addExplanation = new AddExplanation();
                    formBCTransmitterSubmissionDtl.ACATransmitterSubmissionDetail.TransmitterErrorDetailGrp.Select(s=>s.ErrorMessageDetail?.ErrorMessageCd).Where(s=>s is { }).Distinct().All(a =>
                      {
                          if (!errorExplanation.Any(f => f.ErrorType == "All" && f.ErrorTitle.ToLower().Trim() == a?.ToLower().Trim()))
                          {
                              addExplanation.tb_ErrorTitle.Text = a;
                              addExplanation.rtb_Explanation.Text = "";

                              if (addExplanation.ShowDialog() == DialogResult.OK)
                                  errorExplanation.Add(addExplanation.errorExplanation);
                          }

                          return true;
                      });


                    List<OutputDto> output = new List<OutputDto>();

                    formBCTransmitterSubmissionDtl.ACATransmitterSubmissionDetail.TransmitterErrorDetailGrp.All(a =>
                    {

                        string[] uniqe = a?.UniqueRecordId?.Split("|");

                        if (uniqe is { })
                        {
                            int personNumber = Convert.ToInt32(uniqe[2]);
                            TxtInput single = _txtInput.FirstOrDefault(f => f.PersonNumber == personNumber);

                            var explanations = errorExplanation.Where(f => f.ErrorTitle.ToLower().Trim() == a.ErrorMessageDetail.ErrorMessageCd.ToLower().Trim());
                            string explanation = "";

                            if (explanations is { } && explanations.Count() > 0)
                            {
                                if (explanations.Any(a => a.ErrorType == fd_TxtFile.SafeFileName.Split("-")[0]))
                                    explanation = explanations.FirstOrDefault(a => a.ErrorType == fd_TxtFile.SafeFileName.Split("-")[0]).ErrorExplanation;
                                if (explanations.Any(a => a.ErrorType == "All"))
                                    explanation = explanations.FirstOrDefault(a => a.ErrorType == "All").ErrorExplanation;

                            }
                            //else
                            //{

                            //    addExplanation.tb_ErrorTitle.Text = a.ErrorMessageDetail.ErrorMessageCd;
                            //    addExplanation.rtb_Explanation.Text = "";

                            //    if (addExplanation.ShowDialog() == DialogResult.OK)
                            //    {
                            //        explanation = addExplanation.errorExplanation.ErrorExplanation;
                            //        errorExplanation.Add(addExplanation.errorExplanation);
                            //    }

                            //}

                            output.Add(new OutputDto()
                            {
                                ErrorTitle = a.ErrorMessageDetail.ErrorMessageCd,
                                ErrorDescription = a.ErrorMessageDetail.ErrorMessageTxt + " " + a.ErrorMessageDetail.XpathContent,
                                PersonNumber = personNumber,
                                PersonFullName = $"{single.Firstname} {single.Lastname}",
                                ErrorExplanation = explanation
                            });
                        }


                        return true;
                    });


                    FileInfo xlsTmpFileName = new FileInfo(sfd_SaveFile.FileName);
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
                        ws.Cells[row, 4].Value = item.ErrorExplanation;
                        row++;
                    }

                    FileStream fs = new FileStream(xlsTmpFileName.FullName, FileMode.Create);
                    excelFile.SaveAs(fs);

                    fs.Close();

                    MessageBox.Show("I'm done. Your report is ready.");
                }
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

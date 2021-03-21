
namespace ReportFromXmlAndTxt
{
    partial class ErrorReportGenerator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorReportGenerator));
            this.fd_XmlFile = new System.Windows.Forms.OpenFileDialog();
            this.fd_TxtFile = new System.Windows.Forms.OpenFileDialog();
            this.tb_XmlInput = new System.Windows.Forms.TextBox();
            this.XmlLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_TxtInput = new System.Windows.Forms.TextBox();
            this.b_Open_Xml = new System.Windows.Forms.Button();
            this.b_Open_Txt = new System.Windows.Forms.Button();
            this.b_Create = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fd_XmlFile
            // 
            this.fd_XmlFile.FileName = "fd_XmlFile";
            this.fd_XmlFile.Filter = "*.xml|*.xml";
            // 
            // fd_TxtFile
            // 
            this.fd_TxtFile.FileName = "fd_TxtFile";
            this.fd_TxtFile.Filter = "*.txt|*.txt";
            // 
            // tb_XmlInput
            // 
            this.tb_XmlInput.Location = new System.Drawing.Point(211, 31);
            this.tb_XmlInput.Name = "tb_XmlInput";
            this.tb_XmlInput.Size = new System.Drawing.Size(568, 31);
            this.tb_XmlInput.TabIndex = 0;
            // 
            // XmlLabel
            // 
            this.XmlLabel.AutoSize = true;
            this.XmlLabel.Location = new System.Drawing.Point(26, 34);
            this.XmlLabel.Name = "XmlLabel";
            this.XmlLabel.Size = new System.Drawing.Size(158, 25);
            this.XmlLabel.TabIndex = 1;
            this.XmlLabel.Text = "Xml input file path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Txt input file path";
            // 
            // tb_TxtInput
            // 
            this.tb_TxtInput.Location = new System.Drawing.Point(211, 82);
            this.tb_TxtInput.Name = "tb_TxtInput";
            this.tb_TxtInput.Size = new System.Drawing.Size(568, 31);
            this.tb_TxtInput.TabIndex = 3;
            // 
            // b_Open_Xml
            // 
            this.b_Open_Xml.Location = new System.Drawing.Point(785, 29);
            this.b_Open_Xml.Name = "b_Open_Xml";
            this.b_Open_Xml.Size = new System.Drawing.Size(112, 34);
            this.b_Open_Xml.TabIndex = 4;
            this.b_Open_Xml.Text = "Open";
            this.b_Open_Xml.UseVisualStyleBackColor = true;
            this.b_Open_Xml.Click += new System.EventHandler(this.b_Open_Xml_Click);
            // 
            // b_Open_Txt
            // 
            this.b_Open_Txt.Location = new System.Drawing.Point(785, 80);
            this.b_Open_Txt.Name = "b_Open_Txt";
            this.b_Open_Txt.Size = new System.Drawing.Size(112, 34);
            this.b_Open_Txt.TabIndex = 5;
            this.b_Open_Txt.Text = "Open";
            this.b_Open_Txt.UseVisualStyleBackColor = true;
            this.b_Open_Txt.Click += new System.EventHandler(this.b_Open_Txt_Click);
            // 
            // b_Create
            // 
            this.b_Create.Location = new System.Drawing.Point(950, 31);
            this.b_Create.Name = "b_Create";
            this.b_Create.Size = new System.Drawing.Size(124, 79);
            this.b_Create.TabIndex = 6;
            this.b_Create.Text = "Create report";
            this.b_Create.UseVisualStyleBackColor = true;
            this.b_Create.Click += new System.EventHandler(this.b_Create_Click);
            // 
            // ErrorReportGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1101, 136);
            this.Controls.Add(this.b_Create);
            this.Controls.Add(this.b_Open_Txt);
            this.Controls.Add(this.b_Open_Xml);
            this.Controls.Add(this.tb_TxtInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.XmlLabel);
            this.Controls.Add(this.tb_XmlInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ErrorReportGenerator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Error report generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog fd_XmlFile;
        private System.Windows.Forms.OpenFileDialog fd_TxtFile;
        private System.Windows.Forms.TextBox tb_XmlInput;
        private System.Windows.Forms.Label XmlLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_TxtInput;
        private System.Windows.Forms.Button b_Open_Xml;
        private System.Windows.Forms.Button b_Open_Txt;
        private System.Windows.Forms.Button b_Create;
    }
}


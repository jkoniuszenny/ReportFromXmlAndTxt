
namespace ReportFromXmlAndTxt.Models
{
    partial class AddExplanation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_Explanation = new System.Windows.Forms.RichTextBox();
            this.l_ErrorTitle = new System.Windows.Forms.Label();
            this.tb_ErrorTitle = new System.Windows.Forms.TextBox();
            this.b_SaveNewExplanation = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtb_Explanation
            // 
            this.rtb_Explanation.Location = new System.Drawing.Point(12, 88);
            this.rtb_Explanation.Name = "rtb_Explanation";
            this.rtb_Explanation.Size = new System.Drawing.Size(776, 350);
            this.rtb_Explanation.TabIndex = 0;
            this.rtb_Explanation.Text = "";
            // 
            // l_ErrorTitle
            // 
            this.l_ErrorTitle.AutoSize = true;
            this.l_ErrorTitle.Location = new System.Drawing.Point(12, 35);
            this.l_ErrorTitle.Name = "l_ErrorTitle";
            this.l_ErrorTitle.Size = new System.Drawing.Size(91, 25);
            this.l_ErrorTitle.TabIndex = 1;
            this.l_ErrorTitle.Text = "Error Title:";
            // 
            // tb_ErrorTitle
            // 
            this.tb_ErrorTitle.Enabled = false;
            this.tb_ErrorTitle.Location = new System.Drawing.Point(109, 35);
            this.tb_ErrorTitle.Name = "tb_ErrorTitle";
            this.tb_ErrorTitle.Size = new System.Drawing.Size(357, 31);
            this.tb_ErrorTitle.TabIndex = 2;
            // 
            // b_SaveNewExplanation
            // 
            this.b_SaveNewExplanation.Location = new System.Drawing.Point(331, 444);
            this.b_SaveNewExplanation.Name = "b_SaveNewExplanation";
            this.b_SaveNewExplanation.Size = new System.Drawing.Size(112, 52);
            this.b_SaveNewExplanation.TabIndex = 3;
            this.b_SaveNewExplanation.Text = "Save";
            this.b_SaveNewExplanation.UseVisualStyleBackColor = true;
            this.b_SaveNewExplanation.Click += new System.EventHandler(this.b_SaveNewExplanation_Click);
            // 
            // AddExplanation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(800, 517);
            this.Controls.Add(this.b_SaveNewExplanation);
            this.Controls.Add(this.tb_ErrorTitle);
            this.Controls.Add(this.l_ErrorTitle);
            this.Controls.Add(this.rtb_Explanation);
            this.MaximizeBox = false;
            this.Name = "AddExplanation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Explanation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RichTextBox rtb_Explanation;
        private System.Windows.Forms.Label l_ErrorTitle;
        public System.Windows.Forms.TextBox tb_ErrorTitle;
        private System.Windows.Forms.Button b_SaveNewExplanation;
    }
}
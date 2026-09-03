namespace Microinvest1cData.Forms
{
    partial class FormMeasure
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
            this.listBoxMeasure = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBoxMeasure
            // 
            this.listBoxMeasure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxMeasure.FormattingEnabled = true;
            this.listBoxMeasure.Location = new System.Drawing.Point(0, 1);
            this.listBoxMeasure.Name = "listBoxMeasure";
            this.listBoxMeasure.Size = new System.Drawing.Size(260, 420);
            this.listBoxMeasure.TabIndex = 0;
            // 
            // FormMeasure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 424);
            this.Controls.Add(this.listBoxMeasure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMeasure";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ЕдиницыИзмерений";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMeasure;
    }
}
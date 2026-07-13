namespace Microinvest1cData.Forms
{
    partial class FormForm2
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
            this.dataGridViewForm2 = new System.Windows.Forms.DataGridView();
            this.ColForm2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonForm2All = new System.Windows.Forms.Button();
            this.buttonSendUTM = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForm2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewForm2
            // 
            this.dataGridViewForm2.AllowUserToAddRows = false;
            this.dataGridViewForm2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewForm2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewForm2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForm2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColForm2,
            this.ColStatus});
            this.dataGridViewForm2.Location = new System.Drawing.Point(1, 87);
            this.dataGridViewForm2.Name = "dataGridViewForm2";
            this.dataGridViewForm2.Size = new System.Drawing.Size(349, 329);
            this.dataGridViewForm2.TabIndex = 0;
            // 
            // ColForm2
            // 
            this.ColForm2.HeaderText = "Справка Б";
            this.ColForm2.Name = "ColForm2";
            // 
            // ColStatus
            // 
            this.ColStatus.HeaderText = "Статус";
            this.ColStatus.Name = "ColStatus";
            // 
            // buttonForm2All
            // 
            this.buttonForm2All.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonForm2All.Location = new System.Drawing.Point(12, 23);
            this.buttonForm2All.Name = "buttonForm2All";
            this.buttonForm2All.Size = new System.Drawing.Size(86, 48);
            this.buttonForm2All.TabIndex = 1;
            this.buttonForm2All.Text = "Вывести Справки";
            this.buttonForm2All.UseVisualStyleBackColor = true;
            this.buttonForm2All.Click += new System.EventHandler(this.buttonForm2All_Click);
            // 
            // buttonSendUTM
            // 
            this.buttonSendUTM.Location = new System.Drawing.Point(244, 23);
            this.buttonSendUTM.Name = "buttonSendUTM";
            this.buttonSendUTM.Size = new System.Drawing.Size(75, 48);
            this.buttonSendUTM.TabIndex = 2;
            this.buttonSendUTM.Text = "Отправить в УТМ";
            this.buttonSendUTM.UseVisualStyleBackColor = true;
            this.buttonSendUTM.Click += new System.EventHandler(this.buttonSendUTM_Click);
            // 
            // FormForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 419);
            this.Controls.Add(this.buttonSendUTM);
            this.Controls.Add(this.buttonForm2All);
            this.Controls.Add(this.dataGridViewForm2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Запрос Справок Б";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForm2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewForm2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColForm2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStatus;
        private System.Windows.Forms.Button buttonForm2All;
        private System.Windows.Forms.Button buttonSendUTM;
    }
}
namespace Microinvest1cData.Forms
{
    partial class FormR1
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
            this.buttonSend = new System.Windows.Forms.Button();
            this.DataGridR1 = new System.Windows.Forms.DataGridView();
            this.CoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alcokod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFromA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFormB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQtty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelProcess = new System.Windows.Forms.Label();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.progressIsert = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridR1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSend
            // 
            this.buttonSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSend.Location = new System.Drawing.Point(688, 23);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(66, 48);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Text = "Запрос";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // DataGridR1
            // 
            this.DataGridR1.AllowUserToAddRows = false;
            this.DataGridR1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridR1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridR1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridR1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoName,
            this.Alcokod,
            this.ColFromA,
            this.ColFormB,
            this.ColQtty});
            this.DataGridR1.Location = new System.Drawing.Point(0, 93);
            this.DataGridR1.MultiSelect = false;
            this.DataGridR1.Name = "DataGridR1";
            this.DataGridR1.ReadOnly = true;
            this.DataGridR1.RowTemplate.Height = 24;
            this.DataGridR1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridR1.Size = new System.Drawing.Size(766, 382);
            this.DataGridR1.TabIndex = 1;
            // 
            // CoName
            // 
            this.CoName.FillWeight = 194.9525F;
            this.CoName.HeaderText = "Наименование";
            this.CoName.Name = "CoName";
            this.CoName.ReadOnly = true;
            // 
            // Alcokod
            // 
            this.Alcokod.HeaderText = "Алкокод";
            this.Alcokod.Name = "Alcokod";
            this.Alcokod.ReadOnly = true;
            // 
            // ColFromA
            // 
            this.ColFromA.FillWeight = 75.67872F;
            this.ColFromA.HeaderText = "Справка А";
            this.ColFromA.Name = "ColFromA";
            this.ColFromA.ReadOnly = true;
            // 
            // ColFormB
            // 
            this.ColFormB.FillWeight = 60.9137F;
            this.ColFormB.HeaderText = "Справка Б";
            this.ColFormB.Name = "ColFormB";
            this.ColFormB.ReadOnly = true;
            // 
            // ColQtty
            // 
            this.ColQtty.FillWeight = 68.45504F;
            this.ColQtty.HeaderText = "Количество";
            this.ColQtty.Name = "ColQtty";
            this.ColQtty.ReadOnly = true;
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelProcess.Location = new System.Drawing.Point(9, 65);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(0, 15);
            this.labelProcess.TabIndex = 2;
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(573, 22);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(91, 49);
            this.buttonInsert.TabIndex = 3;
            this.buttonInsert.Text = "Создание товара";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.button1_Click);
            // 
            // progressIsert
            // 
            this.progressIsert.Location = new System.Drawing.Point(154, 44);
            this.progressIsert.Name = "progressIsert";
            this.progressIsert.Size = new System.Drawing.Size(413, 23);
            this.progressIsert.TabIndex = 4;
            this.progressIsert.Visible = false;
            // 
            // FormR1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 474);
            this.Controls.Add(this.progressIsert);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.labelProcess);
            this.Controls.Add(this.DataGridR1);
            this.Controls.Add(this.buttonSend);
            this.Name = "FormR1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Остатки склада";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridR1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.DataGridView DataGridR1;
        private System.Windows.Forms.Label labelProcess;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alcokod;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFromA;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFormB;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQtty;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.ProgressBar progressIsert;
    }
}
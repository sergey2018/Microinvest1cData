namespace Microinvest1cData.Forms
{
    partial class FormGoods
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
            this.dataGridViewGoods = new System.Windows.Forms.DataGridView();
            this.ColCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColMeasure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewGoods
            // 
            this.dataGridViewGoods.AllowUserToAddRows = false;
            this.dataGridViewGoods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGoods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCode,
            this.CoName,
            this.ColMeasure});
            this.dataGridViewGoods.Location = new System.Drawing.Point(2, 1);
            this.dataGridViewGoods.Name = "dataGridViewGoods";
            this.dataGridViewGoods.Size = new System.Drawing.Size(404, 312);
            this.dataGridViewGoods.TabIndex = 0;
            // 
            // ColCode
            // 
            this.ColCode.HeaderText = "Код";
            this.ColCode.Name = "ColCode";
            // 
            // CoName
            // 
            this.CoName.HeaderText = "Название";
            this.CoName.Name = "CoName";
            // 
            // ColMeasure
            // 
            this.ColMeasure.HeaderText = "Ед.Из";
            this.ColMeasure.Name = "ColMeasure";
            // 
            // FormGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 307);
            this.Controls.Add(this.dataGridViewGoods);
            this.Name = "FormGoods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Товары";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGoods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewGoods;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColMeasure;
    }
}
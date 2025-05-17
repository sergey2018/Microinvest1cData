namespace Microinvest1cData.Forms
{
    partial class FormBadBarcodes
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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewBarocdes = new System.Windows.Forms.DataGridView();
            this.ColBarcodes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonOutRКоде = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.разпознатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarocdes)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewBarocdes
            // 
            this.dataGridViewBarocdes.AllowUserToAddRows = false;
            this.dataGridViewBarocdes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewBarocdes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBarocdes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBarocdes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColBarcodes});
            this.dataGridViewBarocdes.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewBarocdes.Location = new System.Drawing.Point(-2, -1);
            this.dataGridViewBarocdes.Name = "dataGridViewBarocdes";
            this.dataGridViewBarocdes.Size = new System.Drawing.Size(343, 265);
            this.dataGridViewBarocdes.TabIndex = 0;
            this.dataGridViewBarocdes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewBarocdes_CellDoubleClick);
            // 
            // ColBarcodes
            // 
            this.ColBarcodes.HeaderText = "Штрихкоды";
            this.ColBarcodes.Name = "ColBarcodes";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(353, 12);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Удаление";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonOutRКоде
            // 
            this.buttonOutRКоде.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOutRКоде.Location = new System.Drawing.Point(353, 54);
            this.buttonOutRКоде.Name = "buttonOutRКоде";
            this.buttonOutRКоде.Size = new System.Drawing.Size(75, 35);
            this.buttonOutRКоде.TabIndex = 2;
            this.buttonOutRКоде.Text = "Обработать 1";
            this.buttonOutRКоде.UseVisualStyleBackColor = true;
            this.buttonOutRКоде.Click += new System.EventHandler(this.buttonOutRКоде_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUpdate.Location = new System.Drawing.Point(353, 95);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Изменить";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(353, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 43);
            this.button1.TabIndex = 4;
            this.button1.Text = "Обработать 2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.разпознатьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(136, 26);
            // 
            // разпознатьToolStripMenuItem
            // 
            this.разпознатьToolStripMenuItem.Name = "разпознатьToolStripMenuItem";
            this.разпознатьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.разпознатьToolStripMenuItem.Text = "Разпознать";
            this.разпознатьToolStripMenuItem.Click += new System.EventHandler(this.разпознатьToolStripMenuItem_Click);
            // 
            // FormBadBarcodes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 264);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonOutRКоде);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridViewBarocdes);
            this.Name = "FormBadBarcodes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Пробламные Штрихкоды";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBarocdes)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBarocdes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBarcodes;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonOutRКоде;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem разпознатьToolStripMenuItem;
    }
}
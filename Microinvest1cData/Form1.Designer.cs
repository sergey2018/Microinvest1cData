﻿namespace Microinvest1cData
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonGoods = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelUpdate = new System.Windows.Forms.Label();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пробШтрихкодыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(555, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.настройкиToolStripMenuItem,
            this.справочникиToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(555, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            this.настройкиToolStripMenuItem.Click += new System.EventHandler(this.настройкиToolStripMenuItem_Click);
            // 
            // buttonGoods
            // 
            this.buttonGoods.Location = new System.Drawing.Point(162, 84);
            this.buttonGoods.Name = "buttonGoods";
            this.buttonGoods.Size = new System.Drawing.Size(75, 23);
            this.buttonGoods.TabIndex = 2;
            this.buttonGoods.Text = "Загрузить";
            this.buttonGoods.UseVisualStyleBackColor = true;
            this.buttonGoods.Click += new System.EventHandler(this.buttonGoods_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Location = new System.Drawing.Point(440, 84);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Обновление базы";
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Остатки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelUpdate
            // 
            this.labelUpdate.AutoSize = true;
            this.labelUpdate.Location = new System.Drawing.Point(174, 259);
            this.labelUpdate.Name = "labelUpdate";
            this.labelUpdate.Size = new System.Drawing.Size(64, 13);
            this.labelUpdate.TabIndex = 5;
            this.labelUpdate.Text = "labelUpdate";
            this.labelUpdate.Click += new System.EventHandler(this.labelUpdate_Click);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пробШтрихкодыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // пробШтрихкодыToolStripMenuItem
            // 
            this.пробШтрихкодыToolStripMenuItem.Name = "пробШтрихкодыToolStripMenuItem";
            this.пробШтрихкодыToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.пробШтрихкодыToolStripMenuItem.Text = "Проб.Штрихкоды";
            this.пробШтрихкодыToolStripMenuItem.Click += new System.EventHandler(this.пробШтрихкодыToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 340);
            this.Controls.Add(this.labelUpdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonGoods);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.Button buttonGoods;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelUpdate;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пробШтрихкодыToolStripMenuItem;
    }
}


namespace Microinvest1cData
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
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пробШтрихкодыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.товарыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.дублирующиеКодыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.исправлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.нечисловыеКодыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.удалениеВесовыхШтрихкодовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проверкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonGoods = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.labelUpdate = new System.Windows.Forms.Label();
            this.buttonUpload = new System.Windows.Forms.Button();
            this.buttonExel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonEgais = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.openFileXMl = new System.Windows.Forms.OpenFileDialog();
            this.buttonLinksButton = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this.справочникиToolStripMenuItem,
            this.исправлениеToolStripMenuItem,
            this.проверкаToolStripMenuItem});
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
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пробШтрихкодыToolStripMenuItem,
            this.товарыToolStripMenuItem,
            this.дублирующиеКодыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // пробШтрихкодыToolStripMenuItem
            // 
            this.пробШтрихкодыToolStripMenuItem.Name = "пробШтрихкодыToolStripMenuItem";
            this.пробШтрихкодыToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.пробШтрихкодыToolStripMenuItem.Text = "Проб.Штрихкоды";
            this.пробШтрихкодыToolStripMenuItem.Click += new System.EventHandler(this.пробШтрихкодыToolStripMenuItem_Click);
            // 
            // товарыToolStripMenuItem
            // 
            this.товарыToolStripMenuItem.Name = "товарыToolStripMenuItem";
            this.товарыToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.товарыToolStripMenuItem.Text = "Товары";
            this.товарыToolStripMenuItem.Click += new System.EventHandler(this.товарыToolStripMenuItem_Click);
            // 
            // дублирующиеКодыToolStripMenuItem
            // 
            this.дублирующиеКодыToolStripMenuItem.Name = "дублирующиеКодыToolStripMenuItem";
            this.дублирующиеКодыToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.дублирующиеКодыToolStripMenuItem.Text = "Дублирующие коды";
            this.дублирующиеКодыToolStripMenuItem.Click += new System.EventHandler(this.дублирующиеКодыToolStripMenuItem_Click);
            // 
            // исправлениеToolStripMenuItem
            // 
            this.исправлениеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.нечисловыеКодыToolStripMenuItem,
            this.удалениеВесовыхШтрихкодовToolStripMenuItem});
            this.исправлениеToolStripMenuItem.Name = "исправлениеToolStripMenuItem";
            this.исправлениеToolStripMenuItem.Size = new System.Drawing.Size(93, 20);
            this.исправлениеToolStripMenuItem.Text = "Исправление";
            // 
            // нечисловыеКодыToolStripMenuItem
            // 
            this.нечисловыеКодыToolStripMenuItem.Name = "нечисловыеКодыToolStripMenuItem";
            this.нечисловыеКодыToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.нечисловыеКодыToolStripMenuItem.Text = "Нечисловые коды";
            this.нечисловыеКодыToolStripMenuItem.Click += new System.EventHandler(this.нечисловыеКодыToolStripMenuItem_Click);
            // 
            // удалениеВесовыхШтрихкодовToolStripMenuItem
            // 
            this.удалениеВесовыхШтрихкодовToolStripMenuItem.Name = "удалениеВесовыхШтрихкодовToolStripMenuItem";
            this.удалениеВесовыхШтрихкодовToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.удалениеВесовыхШтрихкодовToolStripMenuItem.Text = "Удаление весовых штрихкодов";
            this.удалениеВесовыхШтрихкодовToolStripMenuItem.Click += new System.EventHandler(this.удалениеВесовыхШтрихкодовToolStripMenuItem_Click);
            // 
            // проверкаToolStripMenuItem
            // 
            this.проверкаToolStripMenuItem.Name = "проверкаToolStripMenuItem";
            this.проверкаToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.проверкаToolStripMenuItem.Text = "Проверка";
            this.проверкаToolStripMenuItem.Click += new System.EventHandler(this.проверкаToolStripMenuItem_Click);
            // 
            // buttonGoods
            // 
            this.buttonGoods.Location = new System.Drawing.Point(214, 67);
            this.buttonGoods.Name = "buttonGoods";
            this.buttonGoods.Size = new System.Drawing.Size(94, 45);
            this.buttonGoods.TabIndex = 2;
            this.buttonGoods.Text = "Загрузить Справочники";
            this.buttonGoods.UseVisualStyleBackColor = true;
            this.buttonGoods.Click += new System.EventHandler(this.buttonGoods_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(198, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 46);
            this.button1.TabIndex = 4;
            this.button1.Text = "Обновить цены и остатки";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelUpdate
            // 
            this.labelUpdate.AutoSize = true;
            this.labelUpdate.Location = new System.Drawing.Point(228, 206);
            this.labelUpdate.Name = "labelUpdate";
            this.labelUpdate.Size = new System.Drawing.Size(64, 13);
            this.labelUpdate.TabIndex = 5;
            this.labelUpdate.Text = "labelUpdate";
            this.labelUpdate.Click += new System.EventHandler(this.labelUpdate_Click);
            // 
            // buttonUpload
            // 
            this.buttonUpload.Location = new System.Drawing.Point(185, 45);
            this.buttonUpload.Name = "buttonUpload";
            this.buttonUpload.Size = new System.Drawing.Size(75, 46);
            this.buttonUpload.TabIndex = 6;
            this.buttonUpload.Text = "Выгрузить в файл";
            this.buttonUpload.UseVisualStyleBackColor = true;
            this.buttonUpload.Click += new System.EventHandler(this.buttonUpload_Click);
            // 
            // buttonExel
            // 
            this.buttonExel.Location = new System.Drawing.Point(185, 129);
            this.buttonExel.Name = "buttonExel";
            this.buttonExel.Size = new System.Drawing.Size(96, 46);
            this.buttonExel.TabIndex = 7;
            this.buttonExel.Text = "Выгрузка exel";
            this.buttonExel.UseVisualStyleBackColor = true;
            this.buttonExel.Click += new System.EventHandler(this.buttonExel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(6, 42);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(549, 297);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.labelUpdate);
            this.tabPage1.Controls.Add(this.buttonGoods);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(541, 271);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Начало";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonLinksButton);
            this.tabPage2.Controls.Add(this.buttonEgais);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(541, 271);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Егаис";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonEgais
            // 
            this.buttonEgais.Location = new System.Drawing.Point(162, 69);
            this.buttonEgais.Name = "buttonEgais";
            this.buttonEgais.Size = new System.Drawing.Size(111, 40);
            this.buttonEgais.TabIndex = 0;
            this.buttonEgais.Text = "Загрузить Файл";
            this.buttonEgais.UseVisualStyleBackColor = true;
            this.buttonEgais.Click += new System.EventHandler(this.buttonEgais_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonUpload);
            this.tabPage3.Controls.Add(this.buttonExel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(541, 271);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Выгрузка";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // openFileXMl
            // 
            this.openFileXMl.Filter = "XML файл|*.xml";
            // 
            // buttonLinksButton
            // 
            this.buttonLinksButton.Location = new System.Drawing.Point(143, 115);
            this.buttonLinksButton.Name = "buttonLinksButton";
            this.buttonLinksButton.Size = new System.Drawing.Size(149, 58);
            this.buttonLinksButton.TabIndex = 1;
            this.buttonLinksButton.Text = "Выполнить первоначальное сопоставление";
            this.buttonLinksButton.UseVisualStyleBackColor = true;
            this.buttonLinksButton.Click += new System.EventHandler(this.buttonLinksButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 340);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.Button buttonGoods;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelUpdate;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пробШтрихкодыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem товарыToolStripMenuItem;
        private System.Windows.Forms.Button buttonUpload;
        private System.Windows.Forms.Button buttonExel;
        private System.Windows.Forms.ToolStripMenuItem дублирующиеКодыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem исправлениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem нечисловыеКодыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалениеВесовыхШтрихкодовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проверкаToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonEgais;
        private System.Windows.Forms.OpenFileDialog openFileXMl;
        private System.Windows.Forms.Button buttonLinksButton;
    }
}


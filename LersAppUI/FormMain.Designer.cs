namespace LersAppUI
{
    partial class FormMain
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
            this.dateTimePickerBgn = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.listViewMeasure = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.columnHeaderData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePickerBgn
            // 
            this.dateTimePickerBgn.Location = new System.Drawing.Point(41, 77);
            this.dateTimePickerBgn.Name = "dateTimePickerBgn";
            this.dateTimePickerBgn.Size = new System.Drawing.Size(296, 31);
            this.dateTimePickerBgn.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Укажите интервал расчета:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "с";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(343, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "по";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Location = new System.Drawing.Point(385, 77);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(296, 31);
            this.dateTimePickerEnd.TabIndex = 5;
            // 
            // listViewMeasure
            // 
            this.listViewMeasure.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderData,
            this.columnHeaderT,
            this.columnHeaderP});
            this.listViewMeasure.Location = new System.Drawing.Point(12, 203);
            this.listViewMeasure.Name = "listViewMeasure";
            this.listViewMeasure.Size = new System.Drawing.Size(682, 633);
            this.listViewMeasure.TabIndex = 7;
            this.listViewMeasure.UseCompatibleStateImageBehavior = false;
            this.listViewMeasure.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "Результат:";
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(719, 70);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(177, 49);
            this.buttonRun.TabIndex = 9;
            this.buttonRun.Text = "Рассчитать";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // columnHeaderData
            // 
            this.columnHeaderData.Text = "Дата";
            this.columnHeaderData.Width = 100;
            // 
            // columnHeaderT
            // 
            this.columnHeaderT.Text = "Температура";
            this.columnHeaderT.Width = 120;
            // 
            // columnHeaderP
            // 
            this.columnHeaderP.Text = "Давление";
            this.columnHeaderP.Width = 120;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(813, 203);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(840, 633);
            this.textBoxLog.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(813, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Протокол выполнения:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1700, 862);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listViewMeasure);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerBgn);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отопление и ГВС в ТСЖ Семь ветров";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePickerBgn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.ListView listViewMeasure;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.ColumnHeader columnHeaderData;
        private System.Windows.Forms.ColumnHeader columnHeaderT;
        private System.Windows.Forms.ColumnHeader columnHeaderP;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label label5;
    }
}


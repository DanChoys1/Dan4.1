
namespace Dan4._1 {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {

            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.headerPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initialDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resultDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeValuesToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.intervalValuesToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.inputValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.closeFormButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.evenElementsDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.oddElementsDataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.splitArrayButton = new System.Windows.Forms.Button();
            this.deleteDataButton = new System.Windows.Forms.Button();
            this.removeEmptyColumnsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.headerPictureBox)).BeginInit();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evenElementsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oddElementsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPictureBox
            // 
            this.headerPictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPictureBox.Location = new System.Drawing.Point(0, 0);
            this.headerPictureBox.Name = "headerPictureBox";
            this.headerPictureBox.Size = new System.Drawing.Size(803, 30);
            this.headerPictureBox.TabIndex = 1;
            this.headerPictureBox.TabStop = false;
            this.headerPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.headerPictureBox_MouseDown);
            this.headerPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.headerPictureBox_MouseMove);
            this.headerPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.headerPictureBox_MouseUp);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.randomInputToolStripMenuItem,
            this.testToolStripMenuItem,
            this.aboutProgramToolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 30);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(803, 24);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFilesToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.filesToolStripMenuItem.Text = "Файлы";
            // 
            // openFilesToolStripMenuItem
            // 
            this.openFilesToolStripMenuItem.Name = "openFilesToolStripMenuItem";
            this.openFilesToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.openFilesToolStripMenuItem.Text = "Открыть";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initialDataToolStripMenuItem,
            this.resultDataToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.saveToolStripMenuItem.Text = "Сохранить";
            // 
            // initialDataToolStripMenuItem
            // 
            this.initialDataToolStripMenuItem.Name = "initialDataToolStripMenuItem";
            this.initialDataToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.initialDataToolStripMenuItem.Text = "Исходные данные";
            // 
            // resultDataToolStripMenuItem
            // 
            this.resultDataToolStripMenuItem.Name = "resultDataToolStripMenuItem";
            this.resultDataToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.resultDataToolStripMenuItem.Text = "Полученные данные";
            // 
            // randomInputToolStripMenuItem
            // 
            this.randomInputToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeValuesToolStripTextBox,
            this.intervalValuesToolStripTextBox,
            this.inputValuesToolStripMenuItem});
            this.randomInputToolStripMenuItem.Name = "randomInputToolStripMenuItem";
            this.randomInputToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.randomInputToolStripMenuItem.Text = "Рандомный ввод";
            // 
            // sizeValuesToolStripTextBox
            // 
            this.sizeValuesToolStripTextBox.Name = "sizeValuesToolStripTextBox";
            this.sizeValuesToolStripTextBox.Size = new System.Drawing.Size(150, 23);
            this.sizeValuesToolStripTextBox.Text = "Введите размер массива";
            this.sizeValuesToolStripTextBox.LostFocus += new System.EventHandler(this.sizeValuesToolStripTextBox_LostFocus);
            this.sizeValuesToolStripTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sizeValuesToolStripTextBox_KeyDown);
            this.sizeValuesToolStripTextBox.Click += new System.EventHandler(this.sizeValuesToolStripTextBox_Click);
            this.sizeValuesToolStripTextBox.TextChanged += new System.EventHandler(this.sizeValuesToolStripTextBox_TextChanged);
            // 
            // intervalValuesToolStripTextBox
            // 
            this.intervalValuesToolStripTextBox.Name = "intervalValuesToolStripTextBox";
            this.intervalValuesToolStripTextBox.Size = new System.Drawing.Size(150, 23);
            this.intervalValuesToolStripTextBox.Text = "Введите интервал чисел";
            this.intervalValuesToolStripTextBox.LostFocus += new System.EventHandler(this.intervalValuestoolStripTextBox_LostFocus);
            this.intervalValuesToolStripTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.intervalValuestoolStripTextBox_KeyDown);
            this.intervalValuesToolStripTextBox.Click += new System.EventHandler(this.intervalValuestoolStripTextBox_Click);
            this.intervalValuesToolStripTextBox.TextChanged += new System.EventHandler(this.intervalValuestoolStripTextBox_TextChanged);
            // 
            // inputValuesToolStripMenuItem
            // 
            this.inputValuesToolStripMenuItem.Name = "inputValuesToolStripMenuItem";
            this.inputValuesToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.inputValuesToolStripMenuItem.Text = "Ввести числа";
            this.inputValuesToolStripMenuItem.Click += new System.EventHandler(this.inputValuesToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.testToolStripMenuItem.Text = "Тестирование";
            // 
            // aboutProgramToolStripMenuItem1
            // 
            this.aboutProgramToolStripMenuItem1.Name = "aboutProgramToolStripMenuItem1";
            this.aboutProgramToolStripMenuItem1.Size = new System.Drawing.Size(94, 20);
            this.aboutProgramToolStripMenuItem1.Text = "О программе";
            this.aboutProgramToolStripMenuItem1.Click += new System.EventHandler(this.aboutProgramToolStripMenuItem1_Click);
            // 
            // closeFormButton
            // 
            this.closeFormButton.Location = new System.Drawing.Point(775, 2);
            this.closeFormButton.Name = "closeFormButton";
            this.closeFormButton.Size = new System.Drawing.Size(25, 25);
            this.closeFormButton.TabIndex = 3;
            this.closeFormButton.UseVisualStyleBackColor = true;
            this.closeFormButton.Click += new System.EventHandler(this.closeFormButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Введите массив";
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Location = new System.Drawing.Point(10, 90);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.RowTemplate.Height = 25;
            this.mainDataGridView.Size = new System.Drawing.Size(781, 90);
            this.mainDataGridView.TabIndex = 5;
            this.mainDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.mainDataGridView_CellEndEdit);
            // 
            // evenElementsDataGridView
            // 
            this.evenElementsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.evenElementsDataGridView.Location = new System.Drawing.Point(10, 221);
            this.evenElementsDataGridView.Name = "evenElementsDataGridView";
            this.evenElementsDataGridView.RowTemplate.Height = 25;
            this.evenElementsDataGridView.Size = new System.Drawing.Size(781, 90);
            this.evenElementsDataGridView.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Массив четных элементов";
            // 
            // oddElementsDataGridView
            // 
            this.oddElementsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oddElementsDataGridView.Location = new System.Drawing.Point(10, 351);
            this.oddElementsDataGridView.Name = "oddElementsDataGridView";
            this.oddElementsDataGridView.RowTemplate.Height = 25;
            this.oddElementsDataGridView.Size = new System.Drawing.Size(781, 90);
            this.oddElementsDataGridView.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Массив нечетных элементов";
            // 
            // splitArrayButton
            // 
            this.splitArrayButton.Location = new System.Drawing.Point(688, 458);
            this.splitArrayButton.Name = "splitArrayButton";
            this.splitArrayButton.Size = new System.Drawing.Size(103, 23);
            this.splitArrayButton.TabIndex = 10;
            this.splitArrayButton.Text = "Разбить массив";
            this.splitArrayButton.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.splitArrayButton.UseVisualStyleBackColor = true;
            this.splitArrayButton.Click += new System.EventHandler(this.splitArrayButton_Click);
            // 
            // deleteDataButton
            // 
            this.deleteDataButton.Location = new System.Drawing.Point(579, 458);
            this.deleteDataButton.Name = "deleteDataButton";
            this.deleteDataButton.Size = new System.Drawing.Size(103, 23);
            this.deleteDataButton.TabIndex = 11;
            this.deleteDataButton.Text = "Удалить данные";
            this.deleteDataButton.UseVisualStyleBackColor = true;
            this.deleteDataButton.Click += new System.EventHandler(this.deleteDataButton_Click);
            // 
            // removeEmptyColumnsButton
            // 
            this.removeEmptyColumnsButton.Location = new System.Drawing.Point(426, 458);
            this.removeEmptyColumnsButton.Name = "removeEmptyColumnsButton";
            this.removeEmptyColumnsButton.Size = new System.Drawing.Size(147, 23);
            this.removeEmptyColumnsButton.TabIndex = 12;
            this.removeEmptyColumnsButton.Text = "Убрать пустые столбцы";
            this.removeEmptyColumnsButton.UseVisualStyleBackColor = true;
            this.removeEmptyColumnsButton.Click += new System.EventHandler(this.removeEmptyColumnsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 493);
            this.Controls.Add(this.removeEmptyColumnsButton);
            this.Controls.Add(this.deleteDataButton);
            this.Controls.Add(this.splitArrayButton);
            this.Controls.Add(this.oddElementsDataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.evenElementsDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mainDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeFormButton);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.headerPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.headerPictureBox)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evenElementsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oddElementsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox headerPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initialDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resultDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomInputToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.Button closeFormButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.DataGridView evenElementsDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView oddElementsDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button splitArrayButton;
        private System.Windows.Forms.Button deleteDataButton;
        private System.Windows.Forms.Button removeEmptyColumnsButton;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox sizeValuesToolStripTextBox;
        private System.Windows.Forms.ToolStripTextBox intervalValuesToolStripTextBox;
        private System.Windows.Forms.ToolStripMenuItem inputValuesToolStripMenuItem;
    }
}
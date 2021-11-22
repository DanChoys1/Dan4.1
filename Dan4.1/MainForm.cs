using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dan4._1 {
    public partial class MainForm : Form {

        private bool isHeaderMoving = false;
        private Point cursorPosition;
        
        const int VisibleColumnsInTable = 10;
        const int ScrollBarSize = 10;

        List<int> cellIndicesWithElements;

        public MainForm() {
            InitializeComponent();

            mainDataGridView.AllowUserToAddRows = false;
            mainDataGridView.RowHeadersVisible = false;
            mainDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            mainDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            evenElementsDataGridView.ReadOnly = true;
            evenElementsDataGridView.AllowUserToAddRows = false;
            evenElementsDataGridView.RowHeadersVisible = false;
            evenElementsDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            evenElementsDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            oddElementsDataGridView.ReadOnly = true;
            oddElementsDataGridView.AllowUserToAddRows = false;
            oddElementsDataGridView.RowHeadersVisible = false;
            oddElementsDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            oddElementsDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CreateDataGridView();
        }

        //////////////////////////////////////////////DATA_GRID_VIEW//////////////////////////////////////////////////////////////////

        private void CreateDataGridView() {
            CreateTable(mainDataGridView, VisibleColumnsInTable);
            CreateTable(evenElementsDataGridView, VisibleColumnsInTable);
            CreateTable(oddElementsDataGridView, VisibleColumnsInTable);

            int width = mainDataGridView.Width / VisibleColumnsInTable;
            int height = mainDataGridView.Height - mainDataGridView.ColumnHeadersHeight - ScrollBarSize;

            ChangeSizeTable(mainDataGridView, width, height);
            ChangeSizeTable(evenElementsDataGridView, width, height);
            ChangeSizeTable(oddElementsDataGridView, width, height);

            cellIndicesWithElements = new List<int>();
        }

        private void CreateTable(DataGridView grid, int count) {
            for (int i = 0; i < count; i++) {
                grid.Columns.Add(i.ToString(), (i + 1).ToString());
            }

            grid.Rows.Add();
        }

        private void ChangeSizeTable(DataGridView grid, int width, int height) {
            for (int i = 0; i < grid.Columns.Count; i++) {
                grid.Columns[i].Width = width;
            }

            grid.Rows[grid.Rows.Count - 1].Height = height;
        }

        private void mainDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e) {

            if (mainDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null) {
                mainDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = 
                    ChangeIncorrectInput(mainDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }

            ChangeNumberColumns(e.RowIndex, e.ColumnIndex);
            ChangeCellIndicesWithElementsList(e.RowIndex, e.ColumnIndex);
        }

        private string ChangeIncorrectInput(string value) {
            string newValue = null;

            bool isFirstPointFinded = false;
            bool isFirstMinusFinded = false;

            foreach (char symbol in value) {

                if (symbol == '-' && !isFirstMinusFinded && newValue == null) {
                    newValue += symbol;
                    isFirstMinusFinded = true;
                }

                if (symbol == ',' && !isFirstPointFinded &&
                    (!isFirstMinusFinded && newValue.Length > 0 || isFirstMinusFinded && newValue.Length > 1)) {

                    newValue += symbol;

                    isFirstPointFinded = true;
                    continue;
                }

                if (Char.IsDigit(symbol)) {
                    newValue += symbol;
                }
            }

            if (isFirstMinusFinded && newValue.Length == 1) {
                newValue = null;
            }

            return newValue;
        }

        private void ChangeNumberColumns(int RowIndex, int ColumnIndex) {

            if (mainDataGridView.Rows[RowIndex].Cells[ColumnIndex].Value == null &&
                                                cellIndicesWithElements.Contains(ColumnIndex)) {

                mainDataGridView.Columns.RemoveAt(mainDataGridView.Columns.Count - 1);

            }

            if (mainDataGridView.Rows[RowIndex].Cells[ColumnIndex].Value != null &&
                                                !cellIndicesWithElements.Contains(ColumnIndex)) {

                int columnCount = mainDataGridView.Columns.Count;
                mainDataGridView.Columns.Add(columnCount.ToString(), (columnCount + 1).ToString());

            }

        }

        private void ChangeCellIndicesWithElementsList(int RowIndex, int ColumnIndex) {

            if(mainDataGridView.Rows[RowIndex].Cells[ColumnIndex].Value == null &&
                                                cellIndicesWithElements.Contains(ColumnIndex)) {
                
                cellIndicesWithElements.Remove(ColumnIndex);

            }

            if(mainDataGridView.Rows[RowIndex].Cells[ColumnIndex].Value != null &&
                                                !cellIndicesWithElements.Contains(ColumnIndex)) {

                cellIndicesWithElements.Add(ColumnIndex);
                cellIndicesWithElements.Sort();

            }

        }

        private void FillDataGridView(DataGridView grid, Dictionary<int, double> arr, double sum) {
            int[] arrayIndexes = new int[arr.Count];
            arr.Keys.CopyTo(arrayIndexes, 0);

            for (int i = 0; i < arr.Count; i++) {

                if (grid.Columns.Count <= i) {
                    grid.Columns.Add(i.ToString(), (i + 1).ToString());
                }

                grid.Rows[0].Cells[i].Value = arr[arrayIndexes[i]];
                grid.Columns[i].HeaderText = (i + 1).ToString() + " (" + arrayIndexes[i].ToString() + ")";
            }

            while (grid.Columns.Count > arr.Count && grid.Columns.Count > (VisibleColumnsInTable - 1)) {
                grid.Columns.RemoveAt(grid.Columns.Count - 1);
            }

            grid.Columns.Add(grid.Columns.Count.ToString(), "Сумма");
            grid.Rows[0].Cells[grid.Columns.Count - 1].Value = sum.ToString();
        }

        //////////////////////////////////////////////BUTTON//////////////////////////////////////////////////////////////////

        private void deleteDataButton_Click(object sender, EventArgs e) {
            mainDataGridView.Rows.Clear();
            mainDataGridView.Columns.Clear();

            evenElementsDataGridView.Rows.Clear();
            evenElementsDataGridView.Columns.Clear();

            oddElementsDataGridView.Rows.Clear();
            oddElementsDataGridView.Columns.Clear();

            CreateDataGridView();

            cellIndicesWithElements.Clear();
        }

        private void removeEmptyColumnsButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < cellIndicesWithElements.Count; i++) {
                
                if (i != cellIndicesWithElements[i]) {
                    mainDataGridView.Rows[0].Cells[i].Value = mainDataGridView.Rows[0].Cells[cellIndicesWithElements[i]].Value;
                    mainDataGridView.Rows[0].Cells[cellIndicesWithElements[i]].Value = null;

                    cellIndicesWithElements[i] = i;
                }

            }
        }

        private void splitArrayButton_Click(object sender, EventArgs e) {
            Dictionary<int, double> mainArray = new Dictionary<int, double>();
            
            for (int i = 0; i < cellIndicesWithElements.Count; i++) {
                double value = Convert.ToDouble(mainDataGridView.Rows[0].Cells[cellIndicesWithElements[i]].Value);
                mainArray.Add((cellIndicesWithElements[i] + 1), value);
            }

            ParitySplitArray paritySplitArray = new ParitySplitArray(mainArray);

            FillDataGridView(evenElementsDataGridView, paritySplitArray.GetEvenArray(), paritySplitArray.GetSumEvenArray());
            FillDataGridView(oddElementsDataGridView, paritySplitArray.GetOddArray(), paritySplitArray.GetSumOddArray());
        }

        //////////////////////////////////////////////TOOL_STRIP_BAR//////////////////////////////////////////////////////////////////

        private void sizeValuesToolStripTextBox_KeyDown(object sender, KeyEventArgs e) {
            ClearTextBox((ToolStripTextBox)sender);
        }

        private void sizeValuesToolStripTextBox_Click(object sender, EventArgs e) {
            ClearTextBox((ToolStripTextBox)sender);
        }

        private void sizeValuesToolStripTextBox_LostFocus(object sender, EventArgs e) {
            ToolStripTextBox textBox = (ToolStripTextBox)sender;

            if (textBox.Text == "") {
                textBox.Text = "Введите размер массива";
            }
        }

        private void sizeValuesToolStripTextBox_TextChanged(object sender, EventArgs e) {
            ToolStripTextBox textBox = (ToolStripTextBox)sender;

            if (textBox.Focused) {
                int posTemp = textBox.SelectionStart;
                textBox.Text = ChangeIncorrectInput(textBox.Text);
                textBox.Select(posTemp, 1);
            }

        }

        private void intervalValuestoolStripTextBox_Click(object sender, EventArgs e) {
            ClearTextBox((ToolStripTextBox)sender);
        }

        private void intervalValuestoolStripTextBox_KeyDown(object sender, KeyEventArgs e) {
            ClearTextBox((ToolStripTextBox)sender);
        }

        private void intervalValuestoolStripTextBox_LostFocus(object sender, EventArgs e) {
            ToolStripTextBox textBox = (ToolStripTextBox)sender;

            if (textBox.Text == "") {
                textBox.Text = "Введите интервал чисел";
            }
        }

        private void intervalValuestoolStripTextBox_TextChanged(object sender, EventArgs e) {
            ToolStripTextBox textBox = (ToolStripTextBox)sender;

            if (textBox.Focused) {
                int posTemp = textBox.SelectionStart;
                textBox.Text = ChangeIncorrectInput(textBox.Text);
                textBox.Select(posTemp, 1);
            }
        }

        private void ClearTextBox(ToolStripTextBox textBox) {
            string text = ChangeIncorrectInput(textBox.Text);

            if (text == null) {
                textBox.Text = "";
            }
        }

        private void inputValuesToolStripMenuItem_Click(object sender, EventArgs e) {
            string sizeValuesText = ChangeIncorrectInput(sizeValuesToolStripTextBox.Text);
            string intervalValuesText = ChangeIncorrectInput(intervalValuesToolStripTextBox.Text);

            int sizeValues = Convert.ToInt32(sizeValuesText);
            int intervalValues = Convert.ToInt32(intervalValuesText);

            if (sizeValuesText == null || sizeValues < 0) {
                MessageBox.Show("Размер массива введен некорректно.", "Ошибка");
                return;
            }

            if (intervalValuesText == null || intervalValues < 0) {
                MessageBox.Show("Интервал массива введен некорректно.", "Ошибка");
                return;
            }

            const int CountDoubleValues = 100;

            for (int i = 0; i < sizeValues; i++) {
                Random random = new Random();
                int randomInt = random.Next(-intervalValues, intervalValues);
                double randomDouble = Convert.ToDouble(random.Next(-CountDoubleValues, CountDoubleValues)) / CountDoubleValues;

                mainDataGridView.Rows[0].Cells[i].Value = randomInt + randomDouble;
                ChangeNumberColumns(0, i);
                ChangeCellIndicesWithElementsList(0, i);
            }

        }

        private void aboutProgramToolStripMenuItem1_Click(object sender, EventArgs e) {
            MessageBox.Show("Лабораторная работа №1\n\n" +
                "Для математических вычислений был использован язык c#.\n\n" +
                "Задание: Задан одномерный массив размером N. Сформировать 2 массива размером N/2, " +
                "включая в первый элементы исходного массива с четными индексами, а во второй — с " +
                "нечетными. Вычислить суммы элементов каждого из массивов.\n\n" +
                "Выполнил стедент группы 403 Азаров Даниил.\n\n" + 
                "2022 год.", "О программе");
        }

        //////////////////////////////////////////////HEADER//////////////////////////////////////////////////////////////////

        private void headerPictureBox_MouseDown(object sender, MouseEventArgs e) {
           
            if (e.Button == MouseButtons.Left) {
                isHeaderMoving = true;
                cursorPosition = new Point(e.X, e.Y);
            } else {
                isHeaderMoving = false;
            }

        }

        private void headerPictureBox_MouseMove(object sender, MouseEventArgs e) {

            if (isHeaderMoving) {
                Point cursorMoveTo;

                cursorMoveTo = this.PointToScreen(new Point(e.X, e.Y));
                cursorMoveTo.Offset(-cursorPosition.X, -cursorPosition.Y);

                this.Location = cursorMoveTo;
            }

        }

        private void headerPictureBox_MouseUp(object sender, MouseEventArgs e) {
            isHeaderMoving = false;
        }

        private void closeFormButton_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}

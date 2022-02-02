using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Dan4._1
{
    public partial class MainForm : Form
    {
        private bool _isHeaderMoving = false;
        private Point _cursorPosition;

        private readonly int VisibleColumnsInTable = 10;
        private readonly int ScrollBarSize = 10;

        List<int> _cellIndicesWithElements;

        public MainForm()
        {
            InitializeComponent();

            headerPictureBox.BackColor = ColorTranslator.FromHtml("#a4e6fc");
            closeFormButton.BackColor = ColorTranslator.FromHtml("#FF0000");

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
            _cellIndicesWithElements = new List<int>();
        }

        //////////////////////////////////////////////DATA_GRID_VIEW//////////////////////////////////////////////////////////////////

        private void CreateDataGridView()
        {
            CreateTable(mainDataGridView, VisibleColumnsInTable);
            CreateTable(evenElementsDataGridView, VisibleColumnsInTable);
            CreateTable(oddElementsDataGridView, VisibleColumnsInTable);

            int width = mainDataGridView.Width / VisibleColumnsInTable;
            int height = mainDataGridView.Height - mainDataGridView.ColumnHeadersHeight - ScrollBarSize;

            ChangeScaleTable(mainDataGridView, width, height);
            ChangeScaleTable(evenElementsDataGridView, width, height);
            ChangeScaleTable(oddElementsDataGridView, width, height);
        }

        private void CreateTable(DataGridView grid, int count)
        {
            for (int i = 0; i < count; i++)
            {
                grid.Columns.Add(i.ToString(), (i + 1).ToString());
            }

            grid.Rows.Add();
        }

        private void ChangeScaleTable(DataGridView grid, int width, int height)
        {
            for (int i = 0; i < grid.Columns.Count; i++)
            {
                grid.Columns[i].Width = width;
            }

            grid.Rows[grid.Rows.Count - 1].Height = height;
        }

        private void MainDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (mainDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                mainDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value =
                    ChangeIncorrectInput(mainDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            }

            ChangeNumberColumns(e.RowIndex, e.ColumnIndex);
            ChangeCellIndicesWithElementsList(e.RowIndex, e.ColumnIndex);
        }

        private string ChangeIncorrectInput(string value)
        {
            string newValue = null;

            bool isFirstPointFinded = false;
            bool isFirstMinusFinded = false;

            foreach (char symbol in value)
            {
                if (symbol == '-' && newValue == null)
                {
                    newValue = symbol.ToString();
                    isFirstMinusFinded = true;
                    continue;
                }

                if (symbol == ',' && !isFirstPointFinded && newValue != null &&
                    (!isFirstMinusFinded && newValue.Length > 0 || isFirstMinusFinded && newValue.Length > 1))
                {
                    newValue += symbol;
                    isFirstPointFinded = true;
                    continue;
                }

                if (Char.IsDigit(symbol))
                {
                    newValue += symbol;
                }
            }

            if (isFirstMinusFinded && newValue.Length == 1)
            {
                newValue = null;
            }

            return newValue;
        }

        private void ChangeNumberColumns(int RowIndex, int ColumnIndex)
        {
            if (mainDataGridView.Rows[RowIndex].Cells[ColumnIndex].Value == null &&
                                                _cellIndicesWithElements.Contains(ColumnIndex))
            {
                mainDataGridView.Columns.RemoveAt(mainDataGridView.Columns.Count - 1);
            }

            if (mainDataGridView.Rows[RowIndex].Cells[ColumnIndex].Value != null &&
                                                !_cellIndicesWithElements.Contains(ColumnIndex))
            {
                int columnCount = mainDataGridView.Columns.Count;
                mainDataGridView.Columns.Add(columnCount.ToString(), (columnCount + 1).ToString());
            }
        }

        private void ChangeCellIndicesWithElementsList(int RowIndex, int ColumnIndex)
        {
            if (mainDataGridView.Rows[RowIndex].Cells[ColumnIndex].Value == null &&
                                                _cellIndicesWithElements.Contains(ColumnIndex))
            {
                _cellIndicesWithElements.Remove(ColumnIndex);
            }

            if (mainDataGridView.Rows[RowIndex].Cells[ColumnIndex].Value != null &&
                                                !_cellIndicesWithElements.Contains(ColumnIndex))
            {
                _cellIndicesWithElements.Add(ColumnIndex);
                _cellIndicesWithElements.Sort();
            }
        }

        ////Вызывается в splitArrayButton_Click для заполнения таблиц с четными/нечетными числами////
        private void FillDataGridView(DataGridView grid, Dictionary<int, double> arr, double sum)
        {
            int[] arrayIndexes = new int[arr.Count];
            arr.Keys.CopyTo(arrayIndexes, 0);

            for (int i = 0; i < arr.Count; i++)
            {
                if (grid.Columns.Count <= i)
                {
                    grid.Columns.Add(i.ToString(), (i + 1).ToString());
                }

                grid.Rows[0].Cells[i].Value = arr[arrayIndexes[i]];
                grid.Columns[i].HeaderText = (i + 1).ToString() + " (" + arrayIndexes[i].ToString() + ")";
            }

            while (grid.Columns.Count > arr.Count && grid.Columns.Count > (VisibleColumnsInTable - 1))
            {
                grid.Columns.RemoveAt(grid.Columns.Count - 1);
            }

            grid.Columns.Add(grid.Columns.Count.ToString(), "Сумма");
            grid.Rows[0].Cells[grid.Columns.Count - 1].Value = sum.ToString();
        }

        //////////////////////////////////////////////BUTTON//////////////////////////////////////////////////////////////////

        private void DeleteDataButton_Click(object sender, EventArgs e)
        {
            mainDataGridView.Rows.Clear();
            mainDataGridView.Columns.Clear();

            evenElementsDataGridView.Rows.Clear();
            evenElementsDataGridView.Columns.Clear();

            oddElementsDataGridView.Rows.Clear();
            oddElementsDataGridView.Columns.Clear();

            CreateDataGridView();

            _cellIndicesWithElements.Clear();
        }

        private void RemoveEmptyColumnsButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < _cellIndicesWithElements.Count; i++)
            {
                if (i != _cellIndicesWithElements[i])
                {
                    mainDataGridView.Rows[0].Cells[i].Value = mainDataGridView.Rows[0].Cells[_cellIndicesWithElements[i]].Value;
                    mainDataGridView.Rows[0].Cells[_cellIndicesWithElements[i]].Value = null;

                    _cellIndicesWithElements[i] = i;
                }
            }
        }

        private void SplitArrayButton_Click(object sender, EventArgs e)
        {
            Dictionary<int, double> mainArray = new Dictionary<int, double>();

            for (int i = 0; i < _cellIndicesWithElements.Count; i++)
            {
                double value = Convert.ToDouble(mainDataGridView.Rows[0].Cells[_cellIndicesWithElements[i]].Value);
                mainArray.Add((_cellIndicesWithElements[i] + 1), value);
            }

            ParitySplitArray paritySplitArray = new ParitySplitArray(mainArray);

            FillDataGridView(evenElementsDataGridView, paritySplitArray.GetEvenArray(), paritySplitArray.GetSumEvenArray());
            FillDataGridView(oddElementsDataGridView, paritySplitArray.GetOddArray(), paritySplitArray.GetSumOddArray());
        }

        //////////////////////////////////////////////TOOL_STRIP_BAR//////////////////////////////////////////////////////////////////
        
        //////////////////////////////////////////////RANDOM_INPUT//////////////////////////////////////////////////////////////////
        private void SizeValuesToolStripTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            ClearTextBox((ToolStripTextBox)sender);
        }

        private void SizeValuesToolStripTextBox_Click(object sender, EventArgs e)
        {
            ClearTextBox((ToolStripTextBox)sender);
        }

        private void SizeValuesToolStripTextBox_LostFocus(object sender, EventArgs e)
        {
            ToolStripTextBox textBox = (ToolStripTextBox)sender;

            if (textBox.Text == "")
            {
                textBox.Text = "Введите размер массива";
            }
        }

        private void SizeValuesToolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            ToolStripTextBox textBox = (ToolStripTextBox)sender;

            if (textBox.Focused)
            {
                int posInput = textBox.SelectionStart;
                textBox.Text = ChangeIncorrectInput(textBox.Text);
                textBox.Select(posInput, 1);
            }
        }

        private void IntervalValuestoolStripTextBox_Click(object sender, EventArgs e)
        {
            ClearTextBox((ToolStripTextBox)sender);
        }

        private void IntervalValuestoolStripTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            ClearTextBox((ToolStripTextBox)sender);
        }

        private void IntervalValuestoolStripTextBox_LostFocus(object sender, EventArgs e)
        {
            ToolStripTextBox textBox = (ToolStripTextBox)sender;

            if (textBox.Text == "")
            {
                textBox.Text = "Введите интервал чисел";
            }
        }

        private void IntervalValuestoolStripTextBox_TextChanged(object sender, EventArgs e)
        {
            ToolStripTextBox textBox = (ToolStripTextBox)sender;

            if (textBox.Focused)
            {
                int posInput = textBox.SelectionStart;
                textBox.Text = ChangeIncorrectInput(textBox.Text);
                textBox.Select(posInput, 1);
            }
        }

        private void ClearTextBox(ToolStripTextBox textBox)
        {
            string text = ChangeIncorrectInput(textBox.Text);
            textBox.Text = text;
        }

        private void InputValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sizeValuesText = ChangeIncorrectInput(sizeValuesToolStripTextBox.Text);
            string intervalValuesText = ChangeIncorrectInput(intervalValuesToolStripTextBox.Text);

            int sizeValues = Convert.ToInt32(sizeValuesText);
            int intervalValues = Convert.ToInt32(intervalValuesText);

            if (sizeValuesText == null || sizeValues < 0)
            {
                MessageBox.Show("Размер массива введен некорректно.", "Ошибка");
                return;
            }

            if (intervalValuesText == null || intervalValues < 0)
            {
                MessageBox.Show("Интервал массива введен некорректно.", "Ошибка");
                return;
            }

            const int RoundingToHundredths = 100;
            Random random = new Random();

            for (int i = 0; i < sizeValues; i++)
            {
                double randomValue = random.Next(-intervalValues * RoundingToHundredths, 
                                                intervalValues * RoundingToHundredths) / (RoundingToHundredths * 1.0);

                mainDataGridView.Rows[0].Cells[i].Value = randomValue;
                ChangeNumberColumns(0, i);
                ChangeCellIndicesWithElementsList(0, i);
            }
        }

        //////////////////////////////////////////////ABOUT//////////////////////////////////////////////////////////////////
        
        private void aboutProgramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Лабораторная работа №1\n\n" +
                "Для математических вычислений был использован язык c#.\n\n" +
                "Задание: Задан одномерный массив размером N. Сформировать 2 массива размером N/2, " +
                "включая в первый элементы исходного массива с четными индексами, а во второй — с " +
                "нечетными. Вычислить суммы элементов каждого из массивов.\n\n" +
                "Выполнил стедент группы 404 Азаров Даниил.\n\n" +
                "2022 год.", "О программе");
        }

        //////////////////////////////////////////////FILES//////////////////////////////////////////////////////////////////

        private void OpenFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            DialogResult result = openFileDialog.ShowDialog();

            if(result == DialogResult.OK)
            {
                DeleteDataButton_Click(sender, e);

                try
                {
                    using System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.OpenFile());

                    string value;
                    int i = 0;

                    while ((value = sr.ReadLine()) != null)
                    {
                        mainDataGridView.Rows[0].Cells[i].Value = Convert.ToDouble(value);

                        ChangeNumberColumns(0, i);
                        ChangeCellIndicesWithElementsList(0, i);

                        i++;
                    }
                }
                catch (FormatException)
                {
                    DeleteDataButton_Click(sender, e);
                    MessageBox.Show("Формат чисел в файле не является допустимым.", "Ошибка!");
                }
                catch (OverflowException)
                {
                    DeleteDataButton_Click(sender, e);
                    MessageBox.Show("Числа в файле превышают допустимый лимит.", "Ошибка!");
                }
                catch (System.IO.IOException )
                {
                    DeleteDataButton_Click(sender, e);
                    MessageBox.Show("Файл не может быть прочитан.", "Ошибка!");
                }
            }
        }

        private void InitialDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    using System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog.OpenFile());

                    foreach (int i in _cellIndicesWithElements)
                    {
                        sw.WriteLine(mainDataGridView.Rows[0].Cells[i].Value);
                    }
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Не удалось сохранить данные.", "Ошибка!");
                }
            }
        }

        private void ResultDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    using System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog.OpenFile());

                    sw.WriteLine("Элементы с четными индексами:");

                    for(int i = 0; i < evenElementsDataGridView.Rows[0].Cells.Count - 1; i++)
                    {
                        sw.WriteLine(evenElementsDataGridView.Rows[0].Cells[i].Value);
                    }

                    sw.WriteLine("");
                    sw.WriteLine("Элементы с нечетными индексами:");

                    for (int i = 0; i < oddElementsDataGridView.Rows[0].Cells.Count - 1; i++)
                    {
                        sw.WriteLine(oddElementsDataGridView.Rows[0].Cells[i].Value);
                    }
                }
                catch (System.IO.IOException)
                {
                    MessageBox.Show("Не удалось сохранить данные.", "Ошибка!");
                }
            }
        }

        //////////////////////////////////////////////HEADER//////////////////////////////////////////////////////////////////

        private void HeaderPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isHeaderMoving = true;
                _cursorPosition = new Point(e.X, e.Y);
            }
            else
            {
                _isHeaderMoving = false;
            }
        }

        private void HeaderPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isHeaderMoving)
            {
                Point cursorMoveTo;

                cursorMoveTo = this.PointToScreen(new Point(e.X, e.Y));
                cursorMoveTo.Offset(-_cursorPosition.X, -_cursorPosition.Y);

                this.Location = cursorMoveTo;
            }
        }

        private void HeaderPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            _isHeaderMoving = false;
        }

        private void CloseFormButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

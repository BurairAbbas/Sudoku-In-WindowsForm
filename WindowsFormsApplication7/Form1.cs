using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication7
{
    public partial class Form1 : Form
    {
        // selbox is a varaible of Textbox which value is 'null'
        TextBox selbox = null;
        TextBox arrayseltb;

        public Form1()
        {
            InitializeComponent();
            DisplayFirstLevel();
            ValidateTextBox();
            AssignTextBoxToArray();
        }

        TextBox[,] textboxValue;
        private void AssignTextBoxToArray()
        {
            textboxValue = new TextBox[4, 4];
            textboxValue[0, 0] = B1;
            textboxValue[0, 1] = B2;
            textboxValue[0, 2] = B3;
            textboxValue[0, 3] = B4;
            textboxValue[1, 0] = B5;
            textboxValue[1, 1] = B6;
            textboxValue[1, 2] = B7;
            textboxValue[1, 3] = B8;
            textboxValue[2, 0] = B9;
            textboxValue[2, 1] = B10;
            textboxValue[2, 2] = B11;
            textboxValue[2, 3] = B12;
            textboxValue[3, 0] = B13;
            textboxValue[3, 1] = B14;
            textboxValue[3, 2] = B15;
            textboxValue[3, 3] = B16;
        }


        private void ValidateTextBox()
        {
            ChangeTextBox_TextFromButton();
            MaximumLengthInTextBox(1);
            AcceptNumberOnly();
        }
        private void MaximumLengthInTextBox(int length)
        {
            B1.MaxLength = length;
            B2.MaxLength = length;
            B3.MaxLength = length;
            B4.MaxLength = length;
            B5.MaxLength = length;
            B6.MaxLength = length;
            B7.MaxLength = length;
            B8.MaxLength = length;
            B9.MaxLength = length;
            B10.MaxLength = length;
            B11.MaxLength = length;
            B12.MaxLength = length;
            B13.MaxLength = length;
            B14.MaxLength = length;
            B15.MaxLength = length;
            B16.MaxLength = length;
        }


        private void ChangeTextBox_TextFromButton()
        {
            // Enter is a Event which handle the selective Textbox and initialize its value with tb_Enter (method)
            B1.Enter += tb_Enter;
            B2.Enter += tb_Enter;
            B3.Enter += tb_Enter;
            B4.Enter += tb_Enter;
            B5.Enter += tb_Enter;
            B6.Enter += tb_Enter;
            B7.Enter += tb_Enter;
            B8.Enter += tb_Enter;
            B9.Enter += tb_Enter;
            B10.Enter += tb_Enter;
            B11.Enter += tb_Enter;
            B12.Enter += tb_Enter;
            B13.Enter += tb_Enter;
            B14.Enter += tb_Enter;
            B15.Enter += tb_Enter;
            B16.Enter += tb_Enter;

        }
        private void tb_Enter(object sender, EventArgs e)
        {
            selbox = (TextBox)sender;    // allowing to select textbox and pass input from button
            arrayseltb = (TextBox)sender;            
        }


        private void AcceptNumberOnly()
        {
            B1.KeyPress += tb_KeyPress;
            B2.KeyPress += tb_KeyPress;
            B3.KeyPress += tb_KeyPress;
            B4.KeyPress += tb_KeyPress;
            B5.KeyPress += tb_KeyPress;
            B6.KeyPress += tb_KeyPress;
            B7.KeyPress += tb_KeyPress;
            B8.KeyPress += tb_KeyPress;
            B9.KeyPress += tb_KeyPress;
            B10.KeyPress += tb_KeyPress;
            B11.KeyPress += tb_KeyPress;
            B12.KeyPress += tb_KeyPress;
            B13.KeyPress += tb_KeyPress;
            B14.KeyPress += tb_KeyPress;
            B15.KeyPress += tb_KeyPress;
            B16.KeyPress += tb_KeyPress;
        }
        private void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!selbox.ReadOnly)
            {
                // clear the value in selective box, so it will not overwrite any value;
                selbox.Clear();
                //SelectedText is a property which located to the box which is selected in a form;
                selbox.SelectedText = "1";
                CheckLogic();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!selbox.ReadOnly)
            {
                selbox.Clear();
                selbox.SelectedText = "2";
                CheckLogic();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (!selbox.ReadOnly)
            {
                selbox.Clear();
                selbox.SelectedText = "3";
                CheckLogic();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (!selbox.ReadOnly)
            {
                selbox.Clear();
                selbox.SelectedText = "4";
                CheckLogic();
            }
        }        
        private void CheckLogic()
        {
            if (IsSudokuLogicCorrect())
            {
                selbox.ForeColor = Color.Green;
            }
            else
            {
                selbox.ForeColor = Color.Red;
            }
        }
        private bool IsSudokuLogicCorrect()
        {
            if (!string.IsNullOrWhiteSpace(selbox.Text))
            {
                int row = -1;
                int column = -1;

                GetRowAndColumnOfSelectedTextBox(ref row, ref column, selbox);

                bool result = Sudoku.IsAnswerValid(row, column, int.Parse(selbox.Text), textboxValue);
                return result;
            }
            return false;
        }
        private void GetRowAndColumnOfSelectedTextBox(ref int row, ref int column, TextBox selectedTextbox)
        {
            for (int i = 0; i < textboxValue.GetLength(0); i++)
            {
                for (int j = 0; j < textboxValue.GetLength(1); j++)
                {
                    if (selectedTextbox == textboxValue[i, j])
                    {
                        row = i;
                        column = j;
                        break;
                    }
                }
                // Find the selectedtb than doesn't waste time check another row.
                if (row != -1 && column != -1)
                    break;
            }
        }


        private void NextLevelbtn_Click(object sender, EventArgs e)
        {
            if (!IsTextboxFilled())
            {
                if (NextLevelbtn.Text == "Quit")
                {
                    Application.Exit();
                }
                else if (Round.Text == "Round 1")
                {
                    DisplaySecondLevel();
                    Round.Text = "Round 2";
                    highscore.Text = "High Score 100";
                }
                else if (Round.Text == "Round 2")
                {
                    DisplayThirdLevel();
                    Round.Text = "Last Round";
                    highscore.Text = "High Scores 200";
                }
                else if (Round.Text == "Last Round")
                {
                    NextLevelbtn.Text = "Quit";
                }
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please complete this level";
            }
        }
        private void DisplayFirstLevel()
        {
            //Readonly prevent user to write or remove data from textbox
            B1.Text = "1";
            B1.ReadOnly = true;

            B4.Text = "2";
            B4.ReadOnly = true;

            B5.Text = "3";
            B5.ReadOnly = true;

            B7.Text = "1";
            B7.ReadOnly = true;

            B8.Text = "4";
            B8.ReadOnly = true;

            B10.Text = "3";
            B10.ReadOnly = true;

            B11.Text = "2";
            B11.ReadOnly = true;

            B16.Text = "3";
            B16.ReadOnly = true;

        }
        private void DisplaySecondLevel()
        {
            B2.Clear();
            B8.Clear();
            B8.ReadOnly = false;
            B12.Clear();
            B13.Clear();
            B15.Clear();
            B16.Clear();
            B16.ReadOnly = false;

            B3.Text = "3";
            B3.ReadOnly = true;
            B4.Clear();
            B4.ReadOnly = false;
            B5.Clear();
            B5.ReadOnly = false;
            B6.Text = "2";
            B6.ReadOnly = true;
            B7.Clear();
            B7.ReadOnly = false;
            B9.Text = "4";
            B9.ReadOnly = true;
            B10.Clear();
            B10.ReadOnly = false;
            B14.Text = "1";
            B14.ReadOnly = true;
        }
        private void DisplayThirdLevel()
        {
            B2.Clear();

            B3.Clear();
            B3.ReadOnly = false;

            B5.Clear();
            B7.Clear();
            B8.Clear();
            B10.Clear();

            B11.Clear();
            B11.ReadOnly = false;


            B13.Clear();


            B14.Clear();
            B14.ReadOnly = false;

            B15.Clear();
            B16.Clear();

            B4.Text = "2";
            B4.ReadOnly = true;

            B12.Text = "1";
            B12.ReadOnly = true;

        }


        private void Checkbtn_Click(object sender, EventArgs e)
        {
            if (IsTextboxFilled())
            {
                CheckCorrectValuesInTextBox();
            }
            else
            {
                lblMsg.Visible = true;
                lblMsg.Text = "Please fill all the box";
            }
        }
        bool IsTextboxFilled()
        {
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox textBox = c as TextBox;
                    if (textBox.Text == string.Empty)
                    {                        
                        return false;
                    }
                }
            }
            return true;
        }

        int[,] correctValue;
        private void CorrectValues()
        {
            correctValue = new int[4, 4];
            correctValue[0, 0] = 1;
            correctValue[0, 1] = 4;
            correctValue[0, 2] = 3;
            correctValue[0, 3] = 2;
            correctValue[1, 0] = 3;
            correctValue[1, 1] = 2;
            correctValue[1, 2] = 1;
            correctValue[1, 3] = 4;
            correctValue[2, 0] = 4;
            correctValue[2, 1] = 3;
            correctValue[2, 2] = 2;
            correctValue[2, 3] = 1;
            correctValue[3, 0] = 2;
            correctValue[3, 1] = 1;
            correctValue[3, 2] = 4;
            correctValue[3, 3] = 3;
        }
        private void CheckCorrectValuesInTextBox()
        {
            CorrectValues();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (IsTextBoxValueCorrect(i, j))
                    {
                        textboxValue[i, j].ForeColor = Color.Green;
                    }
                    else
                    {
                        textboxValue[i, j].ForeColor = Color.Red;
                    }
                }
            }
        }
        private bool IsTextBoxValueCorrect(int row, int column)
        {
            if (correctValue[row, column] == int.Parse(textboxValue[row, column].Text))
                return true;
            return false;
        }


    }
}

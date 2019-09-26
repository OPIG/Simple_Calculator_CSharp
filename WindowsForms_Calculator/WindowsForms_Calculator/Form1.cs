using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsForms_Calculator
{
    public partial class Form1 : Form
    {
        Double resultValue = 0; //Store textBox_input.Text
        string operationPerformed = ""; //Store label_Process_operate.Text
        bool isOperationPerformed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkInputValue()
        {
            string tempIndex0 = Convert.ToString(textBox_input.Text).Substring(0, 1);

            if ((tempIndex0 == "0" && !Convert.ToString(textBox_input.Text).Contains(".")) || isOperationPerformed)
            {
                textBox_input.Clear();
            }
        }
        private void inputData(object sender)
        {
            checkInputValue();
            Button btClicked = (Button)sender;
            isOperationPerformed = false;
            if (btClicked.Text == ".")
            {
                if (!textBox_input.Text.Contains("."))
                {//in case of duplicate character '.'.
                    if (textBox_input.Text.Length != 0)
                    {
                        textBox_input.Text += btClicked.Text;
                    }
                    else
                    {
                        //directly click '.' then the input text should be '0.' as default.
                        textBox_input.Text = "0" + btClicked.Text;
                    }
                }
            }
            else
            {
                textBox_input.Text += btClicked.Text;
            }
        }
        /// <summary>
        /// click number and charater '.' button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNumber_Click(object sender, EventArgs e)
        {
            inputData(sender);
        }

        /// <summary>
        /// click / + - * button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void operation_Click(object sender, EventArgs e)
        {
            Button btnOperation = (Button)sender;
            if (!isOperationPerformed)
            {
                if (resultValue != 0)
                {
                    computeResult();
                    operationPerformed = btnOperation.Text;
                    label_Process_operate.Text = resultValue + operationPerformed;
                    isOperationPerformed = true;
                }
                else
                {
                    operationPerformed = btnOperation.Text;
                    resultValue = double.Parse(textBox_input.Text);
                    label_Process_operate.Text = resultValue + operationPerformed;
                    isOperationPerformed = true;
                }
            }
           
        }

        /// <summary>
        /// click CE button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCe_Click(object sender, EventArgs e)
        {
            textBox_input.Text = "0";
            label_Process_operate.Text = "";
        }

        /// <summary>
        /// click C button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox_input.Text = "0";
            resultValue = 0;
            label_Process_operate.Text = "";
        }

        /// <summary>
        /// click equal button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void equalTo_Click(object sender, EventArgs e)
        {
            computeResult();

        }
        private void computeResult()
        {
            switch (operationPerformed)
            {
                case "+":
                    textBox_input.Text = (resultValue + double.Parse(textBox_input.Text)).ToString();
                    break;
                case "-":
                    textBox_input.Text = (resultValue - double.Parse(textBox_input.Text)).ToString();
                    break;
                case "*":
                    textBox_input.Text = (resultValue * double.Parse(textBox_input.Text)).ToString();
                    break;
                case "/":
                    textBox_input.Text = (resultValue / double.Parse(textBox_input.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = double.Parse(textBox_input.Text);
            label_Process_operate.Text = "";
            operationPerformed = "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShoppingList
{
    public partial class Form1 : Form
    {
        public List<Button> buttons = new List<Button>();
        public List<TextBox> textBoxes = new List<TextBox>();
        public List<CheckBox> checkBoxes = new List<CheckBox>();

        public Form1()
        {
            InitializeComponent();
        }

        private void ButAdd_Click(object sender, EventArgs e)
        {
            if (butAdd.Top + butAdd.Height * 2 + 40 >= this.Height) { }
            else
            {
                butAdd.Top += 25;

                this.Controls.Add(CreateButton());
                this.Controls.Add(CreateTextBox());
                this.Controls.Add(CreateCheckBox());
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            for (int i = 0; i < buttons.Count; i++)
            {
                if(int.Parse(buttons[i].Name.Remove(0,3)) == int.Parse(button.Name.Remove(0, 3)))
                {
                    this.Controls.Remove(buttons[i]);
                    this.Controls.Remove(textBoxes[i]);
                    this.Controls.Remove(checkBoxes[i]);

                    for (int f = i+1; f < buttons.Count; f++)
                    {
                        buttons[f].Top -= 25;
                        textBoxes[f].Top -= 25;
                        checkBoxes[f].Top -= 25;
                    }
                    butAdd.Top -= 25;

                    buttons.Remove(buttons[i]);
                    textBoxes.Remove(textBoxes[i]);
                    checkBoxes.Remove(checkBoxes[i]);
                }
            }
        }

        public Button CreateButton()
        {
            Button button = new Button();

            button.Left = this.Width - 100;
            if (buttons.Count == 0)
                button.Top = 30;
            else
                button.Top = buttons[buttons.Count - 1].Top + 25;

            buttons.Add(button);

            button.Name = "but" + Convert.ToString(buttons.Count - 1);
            button.Text = "Smazat";
            button.Click += Button_Click;

            return button;
        }

        public TextBox CreateTextBox()
        {
            TextBox textBox = new TextBox();

            textBox.Left = 15;
            if (textBoxes.Count == 0)
                textBox.Top = 30;
            else
                textBox.Top = textBoxes[textBoxes.Count - 1].Top + 25;

            textBox.Name = "txt" + Convert.ToString(buttons.Count - 1);
            textBox.Width = 220;

            textBoxes.Add(textBox);
            return textBox;
        }

        public CheckBox CreateCheckBox()
        {
            CheckBox checkBox = new CheckBox();

            checkBox.Left = this.Width - 130;
            if (checkBoxes.Count == 0)
                checkBox.Top = 30;
            else
                checkBox.Top = checkBoxes[checkBoxes.Count - 1].Top + 25;

            checkBox.Name = "chb" + Convert.ToString(buttons.Count - 1);

            checkBoxes.Add(checkBox);
            return checkBox;
        }
    }
}

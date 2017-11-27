using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace UI
{
    public partial class Form1 : Form
    {

        private Person person;
        private int index;
        private bool isSaved, isChange, isClicked;

        public Form1()
        {
            InitializeComponent();
            isSaved = false;
            isClicked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            index = 1;
            FormFill();
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            isSaved = false;
            index--;
            if (index == 0) { index = 1; }
            FormFill();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (IsFilled())
            {
                isSaved = false;
                index++;
                if (index == 100) { index = 99; }
                FormFill();
            }
        }

        private bool IsFilled()
        {
            return nameBox.Text.Length > 0 && phoneBox.Text.Length > 0 && addressBox.Text.Length > 0;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Validator validator = new Validator();
            if (validator.Helper(nameBox.Text, addressBox.Text, phoneBox.Text))
            {
                person.Name = nameBox.Text;
                person.Address = addressBox.Text;
                person.PhoneNumber = phoneBox.Text;
                person.SerialNumber = index;
                person.Serialize();
                isSaved = true;
            } else
            {
                var msg = MessageBox.Show(validator.ToString(), "Something went wrong....");
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            index = 1;
            FormFill();
        }

        private void last_Click(object sender, EventArgs e)
        {
            index = Person.GetLastIndex();
            FormFill();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            isClicked = !isClicked;
            if (isClicked)
            {
                string header = "Solution: \n";
                string address = "\nAddress:\nPostalCode City Street House number\n";
                string phone = "\nPhone:\n1234-1234-123";
                helpLabel.Text = header + address + phone;
            } else
            {
                helpLabel.Text = "Click For Help";
            }
        }

        private void FormFill()
        {
            person = Person.Deserialize(index);
            nameBox.Text = person.Name;
            addressBox.Text = person.Address;
            phoneBox.Text = person.PhoneNumber;
        }
        

    }
}

using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seventh_lesson_csh_ado
{
    public partial class AddOrEdit : Form
    {
        Context _Context = new Context();

        public Author _Author = new Author();
        public Book _Book = new Book();
        public Publisher _Publisher = new Publisher();

        private TextBox _TextBox1 = new TextBox();
        private TextBox _TextBox2 = new TextBox();
        private TextBox _TextBox3 = new TextBox();
        private TextBox _TextBox4 = new TextBox();
        private ComboBox _ComboBox = new ComboBox();

        public AddOrEdit()
        {
            InitializeComponent();
        }

        private void AddOrEdit_Load(object sender, EventArgs e)
        {

            //============================================== Initialize Author ==============================================
            if (Extension.IsAuthor)
            {
                this.ClientSize = new Size(495, 217);

                Label labelName = new Label();
                labelName.AutoSize = true;
                labelName.Location = new Point(36, 43);
                labelName.Name = "labelName";
                labelName.Size = new Size(59, 21);
                labelName.Text = "Name:";
                this.Controls.Add(labelName);

                TextBox textBoxName = new TextBox();
                textBoxName.Location = new Point(117, 40);
                textBoxName.Name = "textBoxName";
                textBoxName.Size = new Size(310, 28);
                textBoxName.TabIndex = 1;
                textBoxName.TextChanged += TextBoxNameAuthor_TextChanged;
                this.Controls.Add(textBoxName);
                _TextBox1 = textBoxName;

                Label labelSurname = new Label();
                labelSurname.AutoSize = true;
                labelSurname.Location = new Point(36, 90);
                labelSurname.Name = "labelSurname";
                labelSurname.Size = new Size(75, 21);
                labelSurname.Text = "Surname:";
                this.Controls.Add(labelSurname);

                TextBox textBoxSurname = new TextBox();
                textBoxSurname.Location = new Point(117, 87);
                textBoxSurname.Name = "textBoxName";
                textBoxSurname.Size = new Size(310, 28);
                textBoxSurname.TabIndex = 2;
                textBoxSurname.TextChanged += TextBoxSurname_TextChanged;
                this.Controls.Add(textBoxSurname);
                _TextBox2 = textBoxSurname;

                Button buttonOK = new Button();
                buttonOK.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonOK.Location = new Point(101, 146);
                buttonOK.Name = "buttonOK";
                buttonOK.Size = new Size(93, 43);
                buttonOK.TabIndex = 3;
                buttonOK.Text = "OK";
                buttonOK.UseVisualStyleBackColor = true;
                buttonOK.Click += ButtonOKAuthor_Click;
                this.Controls.Add(buttonOK);

                Button buttonCancel = new Button();
                buttonCancel.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonCancel.Location = new Point(294, 146);
                buttonCancel.Name = "buttonCancel";
                buttonCancel.Size = new Size(93, 43);
                buttonCancel.TabIndex = 4;
                buttonCancel.Text = "Cancel";
                buttonCancel.UseVisualStyleBackColor = true;
                buttonCancel.Click += ButtonCancel_Click;
                this.Controls.Add(buttonCancel);
                //============================================== Fill fields of Author ==============================================
                if (!Extension.IsAdd)
                {
                    Author author = _Context.Authors.FirstOrDefault(item => item.ID == Extension.SelectedItemID);
                    _Author.ID = author.ID;
                    textBoxName.Text = author.Name;
                    textBoxSurname.Text = author.Surname;
                }
            }
            //============================================== Initialize Book ==============================================
            if (Extension.IsBook)
            {
                this.ClientSize = new Size(495, 284);

                Label labelTitle = new Label();
                labelTitle.AutoSize = true;
                labelTitle.Location = new Point(36, 43);
                labelTitle.Name = "labelTitle";
                labelTitle.Size = new Size(49, 21);
                labelTitle.Text = "Title:";
                this.Controls.Add(labelTitle);

                TextBox textBoxTitle = new TextBox();
                textBoxTitle.Location = new Point(125, 40);
                textBoxTitle.Name = "textBoxName";
                textBoxTitle.Size = new Size(302, 28);
                textBoxTitle.TabIndex = 1;
                textBoxTitle.TextChanged += TextBoxTitleBook_TextChanged;
                this.Controls.Add(textBoxTitle);
                _TextBox1 = textBoxTitle;

                Label labelPages = new Label();
                labelPages.AutoSize = true;
                labelPages.Location = new Point(36, 85);
                labelPages.Name = "labelPages";
                labelPages.Size = new Size(60, 21);
                labelPages.Text = "Pages:";
                this.Controls.Add(labelPages);

                TextBox textBoxPages = new TextBox();
                textBoxPages.Location = new Point(125, 82);
                textBoxPages.Name = "textBoxPages";
                textBoxPages.Size = new Size(302, 28);
                textBoxPages.TabIndex = 2;
                textBoxPages.TextChanged += TextBoxPages_TextChanged;
                this.Controls.Add(textBoxPages);
                _TextBox2 = textBoxPages;

                Label labelPrice = new Label();
                labelPrice.AutoSize = true;
                labelPrice.Location = new Point(36, 128);
                labelPrice.Name = "labelPrice";
                labelPrice.Size = new Size(52, 21);
                labelPrice.Text = "Price:";
                this.Controls.Add(labelPrice);

                TextBox textBoxPrice = new TextBox();
                textBoxPrice.Location = new Point(125, 125);
                textBoxPrice.Name = "textBoxPrice";
                textBoxPrice.Size = new Size(302, 28);
                textBoxPrice.TabIndex = 3;
                textBoxPrice.TextChanged += TextBoxPrice_TextChanged;
                this.Controls.Add(textBoxPrice);
                _TextBox3 = textBoxPrice;

                Label labelPublisher = new Label();
                labelPublisher.AutoSize = true;
                labelPublisher.Location = new Point(36, 168);
                labelPublisher.Name = "labelPublisher";
                labelPublisher.Size = new Size(83, 21);
                labelPublisher.Text = "Publisher:";
                this.Controls.Add(labelPublisher);

                ComboBox comboBoxPublisher = new ComboBox();
                comboBoxPublisher.FormattingEnabled = true;
                comboBoxPublisher.Location = new Point(125, 165);
                comboBoxPublisher.Name = "comboBoxPublisher";
                comboBoxPublisher.Size = new Size(302, 28);
                comboBoxPublisher.TabIndex = 4;
                comboBoxPublisher.SelectedIndexChanged += ComboBoxPublisher_SelectedIndexChanged;
                this.Controls.Add(comboBoxPublisher);
                comboBoxPublisher.Items.AddRange(_Context.Publishers.Select(item => item.Name).ToArray());
                comboBoxPublisher.Items.Add("");
                _ComboBox = comboBoxPublisher;

                Button buttonOK = new Button();
                buttonOK.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonOK.Location = new Point(101, 215);
                buttonOK.Name = "buttonOK";
                buttonOK.Size = new Size(93, 43);
                buttonOK.TabIndex = 5;
                buttonOK.Text = "OK";
                buttonOK.UseVisualStyleBackColor = true;
                buttonOK.Click += ButtonOKBook_Click;
                this.Controls.Add(buttonOK);

                Button buttonCancel = new Button();
                buttonCancel.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonCancel.Location = new Point(294, 215);
                buttonCancel.Name = "buttonCancel";
                buttonCancel.Size = new Size(93, 43);
                buttonCancel.TabIndex = 6;
                buttonCancel.Text = "Cancel";
                buttonCancel.UseVisualStyleBackColor = true;
                buttonCancel.Click += ButtonCancel_Click;
                this.Controls.Add(buttonCancel);
                //============================================== Fill fields of Book ==============================================
                if (!Extension.IsAdd)
                {
                    Book book = _Context.Books.FirstOrDefault(item => item.ID == Extension.SelectedItemID);
                    
                    _Book.ID = book.ID;
                    textBoxTitle.Text = book.Title;
                    textBoxPages.Text = book.Size.ToString();
                    textBoxPrice.Text = book.Price.ToString();

                    if (book.IDPublisher != null)
                    {
                        Publisher publisher = _Context.Publishers.FirstOrDefault(item => item.ID == book.IDPublisher);

                        for (int i = 0; i < comboBoxPublisher.Items.Count; i++)
                            if (comboBoxPublisher.Items[i].ToString() == publisher.Name)
                                comboBoxPublisher.SelectedIndex = i;
                    }
                }
            }
            //============================================== Initialize Publisher ==============================================
            if (Extension.IsPublisher)
            {
                this.ClientSize = new Size(495, 181);

                Label labelName = new Label();
                labelName.AutoSize = true;
                labelName.Location = new Point(36, 43);
                labelName.Name = "labelName";
                labelName.Size = new Size(59, 21);
                labelName.Text = "Name:";
                this.Controls.Add(labelName);

                TextBox textBoxName = new TextBox();
                textBoxName.Location = new Point(117, 40);
                textBoxName.Name = "textBoxName";
                textBoxName.Size = new Size(310, 28);
                textBoxName.TabIndex = 1;
                textBoxName.TextChanged += TextBoxNamePublisher_TextChanged;
                this.Controls.Add(textBoxName);
                _TextBox1 = textBoxName;

                Button buttonOK = new Button();
                buttonOK.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonOK.Location = new Point(101, 103);
                buttonOK.Name = "buttonOK";
                buttonOK.Size = new Size(93, 43);
                buttonOK.TabIndex = 3;
                buttonOK.Text = "OK";
                buttonOK.UseVisualStyleBackColor = true;
                buttonOK.Click += ButtonOKPublisher_Click; ;
                this.Controls.Add(buttonOK);

                Button buttonCancel = new Button();
                buttonCancel.Font = new Font("Tahoma", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                buttonCancel.Location = new Point(294, 103);
                buttonCancel.Name = "buttonCancel";
                buttonCancel.Size = new Size(93, 43);
                buttonCancel.TabIndex = 4;
                buttonCancel.Text = "Cancel";
                buttonCancel.UseVisualStyleBackColor = true;
                buttonCancel.Click += ButtonCancel_Click;
                this.Controls.Add(buttonCancel);
                //============================================== Fill fields of Publisher ==============================================
                if (!Extension.IsAdd)
                {
                    Publisher publisher = _Context.Publishers.FirstOrDefault(item => item.ID == Extension.SelectedItemID);

                    _Publisher.ID = publisher.ID;
                    textBoxName.Text = publisher.Name;
                }
            }
        }

        //============================================== General fields ==============================================
        private void ButtonCancel_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        //============================================== Author fields ==============================================
        private void TextBoxNameAuthor_TextChanged(object? sender, EventArgs e)
        {
            _Author.Name = _TextBox1.Text;
        }
        private void TextBoxSurname_TextChanged(object? sender, EventArgs e)
        {
            _Author.Surname = _TextBox2.Text;
        }
        private void ButtonOKAuthor_Click(object? sender, EventArgs e)
        {
            if (_Author.Name.IsNullOrEmpty() || _Author.Surname.IsNullOrEmpty())
                MessageBox.Show("Not all fields filled correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        //============================================== Book fields ==============================================
        private void TextBoxTitleBook_TextChanged(object? sender, EventArgs e)
        {
            _Book.Title = _TextBox1.Text;
        }
        private void TextBoxPages_TextChanged(object? sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_TextBox2.Text))
            {
                string filter = Regex.Replace(_TextBox2.Text, "[^0-9]", "");

                if (_TextBox2.Text != filter)
                {
                    MessageBox.Show("Wrong input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _TextBox2.Text = filter;
                    _TextBox2.Select(_TextBox2.Text.Length, 0);
                }
                else
                    _Book.Size = Convert.ToInt32(_TextBox2.Text);
            }
            else
                _Book.Size = 0;
        }
        private void TextBoxPrice_TextChanged(object? sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(_TextBox3.Text))
            {
                string filter = Regex.Replace(_TextBox3.Text, "[^0-9,]", "");

                if (_TextBox3.Text != filter)
                {
                    MessageBox.Show("Wrong input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _TextBox3.Text = filter;
                    _TextBox3.Select(_TextBox3.Text.Length, 0);
                }
                else
                {
                    if (!_TextBox3.Text.EndsWith(","))
                    {
                        _Book.Price = Convert.ToDouble(_TextBox3.Text);
                        _TextBox3.Select(_TextBox2.Text.Length, 0);
                    }
                }
            }
            else
                _Book.Price = 0d;
        }
        private void ComboBoxPublisher_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_ComboBox.SelectedItem.ToString() != "")
                _Book.IDPublisher = _Context.Publishers.FirstOrDefault(item => item.Name == _ComboBox.SelectedItem.ToString()).ID;
            else
                _Book.IDPublisher = null;
        }
        private void ButtonOKBook_Click(object? sender, EventArgs e)
        {
            string tmpStr = _Book.Price.ToString();
            if (_Book.Title.IsNullOrEmpty() || _Book.Size <= 0 || _Book.Price <= 0)
                MessageBox.Show("Not all fields filled correctly", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (tmpStr.EndsWith(","))
                {
                    List<char> tmpList = tmpStr.ToList();
                    tmpList.RemoveAt(tmpList.Count);
                    _Book.Price = Convert.ToSingle(tmpList);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        //============================================== Publisher fields ==============================================
        private void TextBoxNamePublisher_TextChanged(object? sender, EventArgs e)
        {
            _Publisher.Name = _TextBox1.Text;
        }
        private void ButtonOKPublisher_Click(object? sender, EventArgs e)
        {
            if (_Publisher.Name.IsNullOrEmpty())
                MessageBox.Show("Fill the field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
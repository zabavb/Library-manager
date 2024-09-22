using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seventh_lesson_csh_ado
{
    public partial class Main : Form
    {
        Context _Context = new Context();

        public Main()
        {
            InitializeComponent();

            comboBoxTables.SelectedIndex = 0;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
        }
        //============================================== General fields ==============================================
        public void SelectedItem()
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            Extension.SelectedItemID = Convert.ToInt32(selectedRow.Cells["Id"].Value);
        }
        public void AuthorOrBookOrPublisher()
        {
            Extension.IsAuthor = comboBoxTables.SelectedIndex == 0;
            Extension.IsBook = comboBoxTables.SelectedIndex == 1;
            Extension.IsPublisher = comboBoxTables.SelectedIndex == 2;
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTables.SelectedIndex == 0)
                InitializeDataGridViewAuthors();
            else if (comboBoxTables.SelectedIndex == 1)
                InitializeDataGridViewBooks();
            else if (comboBoxTables.SelectedIndex == 2)
                InitializeDataGridViewPublishers();
        }

        private void InitializeDataGridViewAuthors()
        {
            if (comboBoxTables.SelectedIndex != 0)
                comboBoxTables.SelectedIndex = 0;

            dataGridView1.DataSource = _Context.Authors.ToList();

            dataGridView1.Columns["Id"].Visible = false;
        }
        private void InitializeDataGridViewBooks()
        {
            if (comboBoxTables.SelectedIndex != 1)
                comboBoxTables.SelectedIndex = 1;

            dataGridView1.DataSource = _Context.Books.ToList();

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["_Publisher"].Visible = false;
        }
        private void InitializeDataGridViewPublishers()
        {
            if (comboBoxTables.SelectedIndex != 2)
                comboBoxTables.SelectedIndex = 2;

            dataGridView1.DataSource = _Context.Publishers.ToList();

            dataGridView1.Columns["Id"].Visible = false;
        }
        //============================================== Add ==============================================
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AuthorOrBookOrPublisher();
            Extension.IsAdd = true;

            AddOrEdit addForm = new AddOrEdit();
            DialogResult dialogResult = addForm.ShowDialog();
            if (dialogResult == DialogResult.OK && Extension.IsAuthor)
            {
                _Context.Authors.Add(addForm._Author);
                _Context.SaveChanges();

                InitializeDataGridViewAuthors();
            }
            if (dialogResult == DialogResult.OK && Extension.IsBook)
            {
                _Context.Books.Add(addForm._Book);
                _Context.SaveChanges();

                InitializeDataGridViewBooks();
            }
            if (dialogResult == DialogResult.OK && Extension.IsPublisher)
            {

                _Context.Publishers.Add(addForm._Publisher);
                _Context.SaveChanges();

                InitializeDataGridViewPublishers();
            }
        }
        //============================================== Edit ==============================================
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                SelectedItem();
                AuthorOrBookOrPublisher();
                Extension.IsAdd = false;

                AddOrEdit editForm = new AddOrEdit();
                DialogResult dialogResult = editForm.ShowDialog();
                if (dialogResult == DialogResult.OK && Extension.IsAuthor)
                {
                    
                    var author = _Context.Authors.FirstOrDefault(item => item.ID == Extension.SelectedItemID);
                    author.Name = editForm._Author.Name;
                    author.Surname = editForm._Author.Surname;

                    _Context.SaveChanges();

                    InitializeDataGridViewAuthors();
                }
                if (dialogResult == DialogResult.OK && Extension.IsBook)
                {
                    var book = _Context.Books.FirstOrDefault(item => item.ID == Extension.SelectedItemID);
                    book.Title = editForm._Book.Title;
                    book.Size = editForm._Book.Size;
                    book.Price = editForm._Book.Price;
                    book.IDPublisher = editForm._Book.IDPublisher;

                    _Context.SaveChanges();

                    InitializeDataGridViewBooks();
                }
                if (dialogResult == DialogResult.OK && Extension.IsPublisher)
                {
                    var publisher = _Context.Publishers.FirstOrDefault(item => item.ID == Extension.SelectedItemID);
                    publisher.Name = editForm._Publisher.Name;

                    _Context.SaveChanges();

                    InitializeDataGridViewPublishers();
                }
            }
            else
                MessageBox.Show("Please choose element (one) to edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //============================================== Delete ==============================================
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                SelectedItem();
                AuthorOrBookOrPublisher();

                if (Extension.IsAuthor)
                {
                    _Context.Authors.Remove(_Context.Authors.FirstOrDefault(item => item.ID == Extension.SelectedItemID));
                    
                    _Context.SaveChanges();

                    InitializeDataGridViewAuthors();

                }
                if (Extension.IsBook)
                {
                    _Context.Books.Remove(_Context.Books.FirstOrDefault(item => item.ID == Extension.SelectedItemID));

                    _Context.SaveChanges();

                    InitializeDataGridViewBooks();
                }
                if (Extension.IsPublisher)
                {
                    _Context.Publishers.Remove(_Context.Publishers.FirstOrDefault(item => item.ID == Extension.SelectedItemID));

                    _Context.SaveChanges();

                    InitializeDataGridViewPublishers();
                }
            }
            else
                MessageBox.Show("Please choose element (one) to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
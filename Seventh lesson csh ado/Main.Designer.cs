using System.Windows.Forms;

namespace Seventh_lesson_csh_ado
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView1 = new DataGridView();
            buttonAdd = new Button();
            buttonEdit = new Button();
            buttonDelete = new Button();
            comboBoxTables = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 37);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(747, 443);
            dataGridView1.TabIndex = 0;
            // 
            // buttonAdd
            // 
            buttonAdd.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonAdd.Location = new Point(0, 0);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(181, 33);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // buttonEdit
            // 
            buttonEdit.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonEdit.Location = new Point(188, 0);
            buttonEdit.Name = "buttonEdit";
            buttonEdit.Size = new Size(181, 33);
            buttonEdit.TabIndex = 2;
            buttonEdit.Text = "Edit";
            buttonEdit.UseVisualStyleBackColor = true;
            buttonEdit.Click += buttonEdit_Click;
            // 
            // buttonDelete
            // 
            buttonDelete.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDelete.Location = new Point(376, 0);
            buttonDelete.Name = "buttonDelete";
            buttonDelete.Size = new Size(181, 33);
            buttonDelete.TabIndex = 3;
            buttonDelete.Text = "Delete";
            buttonDelete.UseVisualStyleBackColor = true;
            buttonDelete.Click += buttonDelete_Click;
            // 
            // comboBoxTables
            // 
            comboBoxTables.Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxTables.Items.AddRange(new object[] { "Authors", "Books", "Publishers" });
            comboBoxTables.Location = new Point(564, 2);
            comboBoxTables.Name = "comboBoxTables";
            comboBoxTables.Size = new Size(181, 29);
            comboBoxTables.TabIndex = 0;
            comboBoxTables.SelectedIndexChanged += comboBoxTables_SelectedIndexChanged;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(747, 478);
            Controls.Add(comboBoxTables);
            Controls.Add(buttonDelete);
            Controls.Add(buttonEdit);
            Controls.Add(buttonAdd);
            Controls.Add(dataGridView1);
            Font = new Font("Tahoma", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "Main";
            Text = "Main";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button buttonAdd;
        private Button buttonEdit;
        private Button buttonDelete;
        private ComboBox comboBoxTables;
    }
}
namespace ToDoList
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTitle = new TextBox();
            btnEkle = new Button();
            label1 = new Label();
            label2 = new Label();
            clbTodo = new CheckedListBox();
            SuspendLayout();
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(96, 41);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(125, 27);
            txtTitle.TabIndex = 1;
            // 
            // btnEkle
            // 
            btnEkle.Location = new Point(239, 40);
            btnEkle.Name = "btnEkle";
            btnEkle.Size = new Size(94, 29);
            btnEkle.TabIndex = 2;
            btnEkle.Text = "EKLE";
            btnEkle.UseVisualStyleBackColor = true;
            btnEkle.Click += btnEkle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 87);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 3;
            label1.Text = "To Do";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 44);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 4;
            label2.Text = "Title";
            // 
            // clbTodo
            // 
            clbTodo.FormattingEnabled = true;
            clbTodo.Location = new Point(40, 121);
            clbTodo.Name = "clbTodo";
            clbTodo.Size = new Size(293, 290);
            clbTodo.TabIndex = 5;
            clbTodo.ItemCheck += clbTodo_ItemCheck;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(394, 450);
            Controls.Add(clbTodo);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnEkle);
            Controls.Add(txtTitle);
            Name = "Form1";
            Text = "To Do List";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTitle;
        private Button btnEkle;
        private Label label1;
        private Label label2;
        private CheckedListBox clbTodo;
    }
}
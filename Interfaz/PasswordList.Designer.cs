﻿
namespace Presentation
{
    partial class PasswordList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlList = new System.Windows.Forms.Panel();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.lblTIitle = new System.Windows.Forms.Label();
            this.tblPassword = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSharedPasswords = new System.Windows.Forms.Button();
            this.pnlList.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.tblPassword);
            this.pnlList.Controls.Add(this.lblTIitle);
            this.pnlList.Location = new System.Drawing.Point(4, 4);
            this.pnlList.Name = "pnlList";
            this.pnlList.Size = new System.Drawing.Size(773, 341);
            this.pnlList.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnSharedPasswords);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnModify);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Location = new System.Drawing.Point(4, 352);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(773, 44);
            this.pnlButtons.TabIndex = 1;
            // 
            // lblTIitle
            // 
            this.lblTIitle.AutoSize = true;
            this.lblTIitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblTIitle.Location = new System.Drawing.Point(3, 14);
            this.lblTIitle.Name = "lblTIitle";
            this.lblTIitle.Size = new System.Drawing.Size(124, 25);
            this.lblTIitle.TabIndex = 0;
            this.lblTIitle.Text = "Contraseñas";
            // 
            // tblPassword
            // 
            this.tblPassword.AllowUserToAddRows = false;
            this.tblPassword.AllowUserToDeleteRows = false;
            this.tblPassword.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblPassword.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblPassword.Location = new System.Drawing.Point(8, 55);
            this.tblPassword.Name = "tblPassword";
            this.tblPassword.ReadOnly = true;
            this.tblPassword.RowHeadersVisible = false;
            this.tblPassword.Size = new System.Drawing.Size(753, 273);
            this.tblPassword.TabIndex = 6;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(686, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 0;
            this.btnDelete.Text = "Eliminar";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(591, 11);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "Modificar";
            this.btnModify.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(501, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Agregar";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnSharedPasswords
            // 
            this.btnSharedPasswords.Location = new System.Drawing.Point(347, 11);
            this.btnSharedPasswords.Name = "btnSharedPasswords";
            this.btnSharedPasswords.Size = new System.Drawing.Size(136, 23);
            this.btnSharedPasswords.TabIndex = 3;
            this.btnSharedPasswords.Text = "Contraseñas compartidas";
            this.btnSharedPasswords.UseVisualStyleBackColor = true;
            // 
            // PasswordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlList);
            this.Name = "PasswordList";
            this.Size = new System.Drawing.Size(780, 399);
            this.pnlList.ResumeLayout(false);
            this.pnlList.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblPassword)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlList;
        private System.Windows.Forms.Label lblTIitle;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.DataGridView tblPassword;
        private System.Windows.Forms.Button btnSharedPasswords;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
    }
}
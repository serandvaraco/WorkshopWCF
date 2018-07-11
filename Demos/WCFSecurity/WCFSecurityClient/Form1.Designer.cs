namespace WCFSecurityClient
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsernameCreate = new System.Windows.Forms.TextBox();
            this.txtPasswordCreate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSendCreate = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmPasswordCreate = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPasswordNewChangePassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSendUpdatePassword = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPasswordChangePassword = new System.Windows.Forms.TextBox();
            this.txtUsernameChangePassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPasswordConfirmChangePassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRoleNameCreateRole = new System.Windows.Forms.TextBox();
            this.txtUsernameCreateRole = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSendRole = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtConfirmPasswordCreate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSendCreate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPasswordCreate);
            this.groupBox1.Controls.Add(this.txtUsernameCreate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(557, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Crear usuario";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSendRole);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtRoleNameCreateRole);
            this.groupBox3.Controls.Add(this.txtUsernameCreateRole);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(13, 352);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(557, 112);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Asignar Roles";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(145, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario";
            // 
            // txtUsernameCreate
            // 
            this.txtUsernameCreate.Location = new System.Drawing.Point(9, 54);
            this.txtUsernameCreate.Name = "txtUsernameCreate";
            this.txtUsernameCreate.Size = new System.Drawing.Size(165, 29);
            this.txtUsernameCreate.TabIndex = 1;
            // 
            // txtPasswordCreate
            // 
            this.txtPasswordCreate.Location = new System.Drawing.Point(200, 54);
            this.txtPasswordCreate.Name = "txtPasswordCreate";
            this.txtPasswordCreate.PasswordChar = '*';
            this.txtPasswordCreate.Size = new System.Drawing.Size(164, 29);
            this.txtPasswordCreate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(199, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // btnSendCreate
            // 
            this.btnSendCreate.Location = new System.Drawing.Point(449, 89);
            this.btnSendCreate.Name = "btnSendCreate";
            this.btnSendCreate.Size = new System.Drawing.Size(102, 35);
            this.btnSendCreate.TabIndex = 4;
            this.btnSendCreate.Text = "Enviar";
            this.btnSendCreate.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Confirmar";
            // 
            // txtConfirmPasswordCreate
            // 
            this.txtConfirmPasswordCreate.Location = new System.Drawing.Point(387, 54);
            this.txtConfirmPasswordCreate.Name = "txtConfirmPasswordCreate";
            this.txtConfirmPasswordCreate.PasswordChar = '*';
            this.txtConfirmPasswordCreate.Size = new System.Drawing.Size(164, 29);
            this.txtConfirmPasswordCreate.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPasswordConfirmChangePassword);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtPasswordNewChangePassword);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnSendUpdatePassword);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPasswordChangePassword);
            this.groupBox2.Controls.Add(this.txtUsernameChangePassword);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(13, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(557, 187);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cambiar Contraseña";
            // 
            // txtPasswordNewChangePassword
            // 
            this.txtPasswordNewChangePassword.Location = new System.Drawing.Point(10, 127);
            this.txtPasswordNewChangePassword.Name = "txtPasswordNewChangePassword";
            this.txtPasswordNewChangePassword.PasswordChar = '*';
            this.txtPasswordNewChangePassword.Size = new System.Drawing.Size(164, 29);
            this.txtPasswordNewChangePassword.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Contraseña Nueva";
            // 
            // btnSendUpdatePassword
            // 
            this.btnSendUpdatePassword.Location = new System.Drawing.Point(449, 146);
            this.btnSendUpdatePassword.Name = "btnSendUpdatePassword";
            this.btnSendUpdatePassword.Size = new System.Drawing.Size(102, 35);
            this.btnSendUpdatePassword.TabIndex = 4;
            this.btnSendUpdatePassword.Text = "Enviar";
            this.btnSendUpdatePassword.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(199, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "Contraseña Actual";
            // 
            // txtPasswordChangePassword
            // 
            this.txtPasswordChangePassword.Location = new System.Drawing.Point(203, 54);
            this.txtPasswordChangePassword.Name = "txtPasswordChangePassword";
            this.txtPasswordChangePassword.PasswordChar = '*';
            this.txtPasswordChangePassword.Size = new System.Drawing.Size(164, 29);
            this.txtPasswordChangePassword.TabIndex = 2;
            // 
            // txtUsernameChangePassword
            // 
            this.txtUsernameChangePassword.Location = new System.Drawing.Point(9, 54);
            this.txtUsernameChangePassword.Name = "txtUsernameChangePassword";
            this.txtUsernameChangePassword.Size = new System.Drawing.Size(165, 29);
            this.txtUsernameChangePassword.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(145, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nombre de usuario";
            // 
            // txtPasswordConfirmChangePassword
            // 
            this.txtPasswordConfirmChangePassword.Location = new System.Drawing.Point(203, 127);
            this.txtPasswordConfirmChangePassword.Name = "txtPasswordConfirmChangePassword";
            this.txtPasswordConfirmChangePassword.PasswordChar = '*';
            this.txtPasswordConfirmChangePassword.Size = new System.Drawing.Size(164, 29);
            this.txtPasswordConfirmChangePassword.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(199, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(213, 21);
            this.label7.TabIndex = 7;
            this.label7.Text = "Confirmar Contraseña Nueva";
            // 
            // label8
            // 
            this.label8.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(199, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "Rol";
            // 
            // txtRoleNameCreateRole
            // 
            this.txtRoleNameCreateRole.Location = new System.Drawing.Point(203, 49);
            this.txtRoleNameCreateRole.Name = "txtRoleNameCreateRole";
            this.txtRoleNameCreateRole.Size = new System.Drawing.Size(164, 29);
            this.txtRoleNameCreateRole.TabIndex = 6;
            // 
            // txtUsernameCreateRole
            // 
            this.txtUsernameCreateRole.Location = new System.Drawing.Point(9, 49);
            this.txtUsernameCreateRole.Name = "txtUsernameCreateRole";
            this.txtUsernameCreateRole.Size = new System.Drawing.Size(165, 29);
            this.txtUsernameCreateRole.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(145, 21);
            this.label9.TabIndex = 4;
            this.label9.Text = "Nombre de usuario";
            // 
            // btnSendRole
            // 
            this.btnSendRole.Location = new System.Drawing.Point(449, 71);
            this.btnSendRole.Name = "btnSendRole";
            this.btnSendRole.Size = new System.Drawing.Size(102, 35);
            this.btnSendRole.TabIndex = 9;
            this.btnSendRole.Text = "Enviar";
            this.btnSendRole.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 476);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Bienvenido ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtConfirmPasswordCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSendCreate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPasswordCreate;
        private System.Windows.Forms.TextBox txtUsernameCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendRole;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRoleNameCreateRole;
        private System.Windows.Forms.TextBox txtUsernameCreateRole;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPasswordConfirmChangePassword;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPasswordNewChangePassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSendUpdatePassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPasswordChangePassword;
        private System.Windows.Forms.TextBox txtUsernameChangePassword;
        private System.Windows.Forms.Label label6;
    }
}


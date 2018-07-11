﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCFSecurityClient
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                BaseSecurityContract baseSecurity = new BaseSecurityContract();
                string token =
                    await baseSecurity.GetTokenUserAsync(txtUsername.Text, txtPassword.Text);

                if (token.LongCount() < 30)
                    throw new Exception(token);

                this.Hide();
                var frm = new Form1();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

using System;
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
    public partial class Form1 : Form
    {
        BaseSecurityContract securityContract;
        UserModel User;
        private string _token = string.Empty;
        public Form1(string token)
        {
            _token = token;
            Inicializar(token);
            InitializeComponent();
        }

        private async void Inicializar(string token)
        {
            try
            {
                securityContract = new BaseSecurityContract();
                User = await securityContract.GetUser(token);
                this.Text = $"Bienvenido {User.DisplayName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private async void btnSendCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsernameCreate.Text) || string.IsNullOrWhiteSpace(txtPasswordCreate.Text))
            {
                MessageBox.Show("debe existir un usuario y/o contraseña valida");
                return;
            }

            if (txtPasswordCreate.Text != txtConfirmPasswordCreate.Text)
            {
                MessageBox.Show("Las contraseñas no son identicas");
                return;
            }

            try
            { 

                var resultModel = await new BaseSecurityContract().CreateUser(_token, txtUsernameCreate.Text, txtConfirmPasswordCreate.Text);

                MessageBox.Show(resultModel.CreateUserResult.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:: {ex.Message}");
            }

        }
    }
}

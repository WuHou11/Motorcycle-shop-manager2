﻿using bx.ALL_UserControl;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bx
{
    public partial class MainBoard : Form
    {

        private Timer moveTimer = new Timer();
        private int targetY;
        public MainBoard()
        {
            InitializeComponent();
            moveTimer.Interval = 1; // 5ms mỗi lần tick
            moveTimer.Tick += moveTimer_Tick;
        }
        private void moveTimer_Tick(object sender, EventArgs e)
        {
            int speed = 5; // Điều chỉnh tốc độ di chuyển

            if (PanelMoving.Top < targetY)
            {
                PanelMoving.Top += speed;
                if (PanelMoving.Top > targetY) PanelMoving.Top = targetY; // Đảm bảo không vượt quá
            }
            else if (PanelMoving.Top > targetY)
            {
                PanelMoving.Top -= speed;
                if (PanelMoving.Top < targetY) PanelMoving.Top = targetY; // Đảm bảo không vượt quá
            }

            if (PanelMoving.Top == targetY)
            {
                moveTimer.Stop(); // Dừng timer khi đã đến vị trí
            }
        }
        private void MovePanel(Guna.UI2.WinForms.Guna2Button btn)
        {
            targetY = btn.Top;
            if (PanelMoving.Top != targetY) // Chỉ chạy nếu chưa ở đúng vị trí
            {
                moveTimer.Start();
            }
        }
        private void MainBoard_Load(object sender, EventArgs e)
        {
            uC_Account1.Visible = false;
            uC_Bill1.Visible = false;
            uC_Customer1.Visible = false;
            uC_Product1.Visible = false;
            uC_Revenue1.Visible = false;
            uC_Supplier1.Visible = false;
            uC_Sale1.Visible = false;
            btnAccount.PerformClick();
            
        }

        private void ActivateButton(Guna2Button activeButton)
        {
            // Đặt màu mặc định cho tất cả các Guna2Button
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Guna2Button btn)
                {
                    btn.FillColor = Color.WhiteSmoke;   // Màu nền mặc định
                    btn.ForeColor = Color.DimGray;   // Màu chữ mặc định
                    btn.ImageSize = new Size(50, 50); // Đặt kích thước icon về bình thường
                }
            }

            // Đổi màu cho nút được chọn
            activeButton.FillColor = Color.DodgerBlue;
            activeButton.ForeColor = Color.White;
            activeButton.ImageSize = new Size(55, 55); // Làm icon to hơn khi nút được chọn
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            ActivateButton(btnAccount);
            MovePanel(btnAccount);
            uC_Account1.Visible = true;
            uC_Account1.BringToFront();


        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(btnProduct);
            MovePanel(btnProduct);
            uC_Product1.Visible = true;
            uC_Product1.BringToFront();
            
        }

        private void btnSuppiler_Click(object sender, EventArgs e)
        {
            ActivateButton(btnSuppiler);
            MovePanel(btnSuppiler);
            uC_Supplier1.Visible = true;
            uC_Supplier1.BringToFront();

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ActivateButton(btnCustomer);
            MovePanel(btnCustomer);
            uC_Customer1.Visible = true;
            uC_Customer1.BringToFront();


        }

        private void btnBill_Click(object sender, EventArgs e)
        {
            ActivateButton(btnBill);
            MovePanel(btnBill);
            uC_Bill1.Visible = true;
            uC_Bill1.BringToFront();

        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            ActivateButton(btnRevenue);
            MovePanel(btnRevenue);
            uC_Revenue1.Visible = true;
            uC_Revenue1.BringToFront();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login Formout = new Login();
            Formout.Show();
            this.Hide();
        }

        private void PanelMoving_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnSale_Click(object sender, EventArgs e)
        {
            uC_Sale1.BackColor = Color.DodgerBlue;
            ActivateButton(btnSale);
            MovePanel(btnSale);
            uC_Sale1.Visible = true;
            uC_Sale1.BringToFront();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();  // Chặn luồng cho tới khi Login được đóng
            this.Show();         // Hiện lại form hiện tại nếu cần sau khi login đóng

        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainBoard_KeyDown(object sender, KeyEventArgs e)
        {
          
        }

        private void lbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}

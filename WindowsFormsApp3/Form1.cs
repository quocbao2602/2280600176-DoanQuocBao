using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Xóa dòng được chọn
                listView1.Items.Remove(listView1.SelectedItems[0]);

                // Cập nhật lại số thứ tự (STT)
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    listView1.Items[i].SubItems[0].Text = (i + 1).ToString();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong danh sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các TextBox có dữ liệu
            if (!string.IsNullOrWhiteSpace(textBox1.Text) &&
                !string.IsNullOrWhiteSpace(textBox2.Text) &&
                !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                // Kiểm tra STT có hợp lệ không
                if (int.TryParse(textBox1.Text, out int stt))
                {
                    // Tạo dòng mới
                    ListViewItem item = new ListViewItem(textBox1.Text); // STT
                    item.SubItems.Add(textBox2.Text); // Họ và Tên đệm
                    item.SubItems.Add(textBox3.Text); // Tên

                    // Thêm vào ListView
                    listView1.Items.Add(item);

                    // Xóa nội dung các TextBox sau khi thêm
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("STT phải là một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 &&
        !string.IsNullOrWhiteSpace(textBox1.Text) &&
        !string.IsNullOrWhiteSpace(textBox2.Text) &&
        !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                // Kiểm tra STT có hợp lệ không
                if (int.TryParse(textBox1.Text, out int stt))
                {
                    // Sửa dòng được chọn
                    ListViewItem selectedItem = listView1.SelectedItems[0];
                    selectedItem.SubItems[0].Text = textBox1.Text; // Sửa STT
                    selectedItem.SubItems[1].Text = textBox2.Text; // Sửa Họ và Tên đệm
                    selectedItem.SubItems[2].Text = textBox3.Text; // Sửa Tên

                    // Xóa nội dung các TextBox sau khi sửa
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                else
                {
                    MessageBox.Show("STT phải là một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng trong danh sách và nhập đầy đủ thông tin để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

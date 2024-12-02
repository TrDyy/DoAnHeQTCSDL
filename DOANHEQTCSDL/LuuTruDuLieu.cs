using KETNOI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DOANHEQTCSDL
{
    public partial class LuuTruDuLieu : Form
    {
        DBConnect db = new DBConnect();
        public LuuTruDuLieu()
        {
            InitializeComponent();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBackUp_Click(object sender, EventArgs e)
        {
            string backupPath = txtBackupPath.Text;
            string dataBaseName = txtDatabaseName.Text;

            if (string.IsNullOrEmpty(backupPath))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn để lưu dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                string query = "EXEC BackupDatabase @DatabaseName, @FilePath";
                var parameters = new Dictionary<string, object>
                {
                    { "@DatabaseName", dataBaseName },
                    {"@FilePath", backupPath }

                };
                db.getExecuteNonQueryWithParams(query, parameters, null);
                MessageBox.Show("Sao lưu dữ liệu thành công!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sao lưu dữ liệu: " + ex.Message);
            }
        }


       

        private void btnRestore_Click(object sender, EventArgs e)
        {
            string restorePath = txtRestorePath.Text;
            string dataBaseName = txtDatabaseName.Text;
            // Kiểm tra đường dẫn nhập vào
            if (string.IsNullOrEmpty(restorePath))
            {
                MessageBox.Show("Please select a restore file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Chuỗi kết nối tới SQL Server
            try
            {
                string query = "EXEC  RestoreDatabase @DatabaseName, @FilePath";
                var parameters = new Dictionary<string, object>
                {
                    { "@DatabaseName", dataBaseName },
                    {"@FilePath", restorePath }

                };
                int result = (int)db.getExecuteNonQueryWithParams(query, parameters, null);
                if (result > 0)
                {
                    // Thông báo thành công
                    MessageBox.Show("Phục hồi dữ liệu thành công, Vui lòng kết nối lại!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {

                    MessageBox.Show("Phục hồi dữ liệu thất bại!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi phục hồi dữ liệu: " + ex.Message);
            }
        }

      

        private void btnBrowseBackup_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            saveFileDialog.Title = "Save Backup File";
            saveFileDialog.FileName = "Backup_QLShopQuanAo.bak";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtBackupPath.Text = saveFileDialog.FileName;
            }

        }

        private void btnBrowseRestore_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
   
            openFileDialog.Filter = "Backup Files (*.bak)|*.bak";
            openFileDialog.Title = "Select Backup File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtRestorePath.Text = openFileDialog.FileName;
            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtDatabaseName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

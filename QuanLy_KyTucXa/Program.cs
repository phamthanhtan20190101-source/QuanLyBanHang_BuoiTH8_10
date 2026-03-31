using QuanLy_KyTucXa.Forms;
using System.Windows.Forms;

namespace QuanLy_KyTucXa
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new frmMain());
            //Application.Run(new frmToaNha());
            //Application.Run(new frmThemSinhVien());
            //Application.Run(new CapNhatDongTien());
        }
    }
}
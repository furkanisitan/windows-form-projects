using HastaneYonetimRandevuSistemi.Business.Abstract;
using System;
using System.Windows.Forms;
using InstanceFactory = HastaneYonetimRandevuSistemi.Business.DependencyResolvers.Ninject.InstanceFactory;

namespace HastaneYonetimRandevuSistemi.WinFormAppUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Database initialize
            var doctors = InstanceFactory.GetInstance<IDoctorService>().GetAll();

            Application.Run(new MainForm());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());
            
            if (Commons.LOGINUSERID == "admin")
            {
                AdministrationForm fr = new AdministrationForm();
                Application.Run(fr);
                fr.ShowInTaskbar = true;
            }
            else
            {
                ProductForm pf = new ProductForm();
                Application.Run(pf);
                pf.ShowInTaskbar = true;
            }
        }
    }
}

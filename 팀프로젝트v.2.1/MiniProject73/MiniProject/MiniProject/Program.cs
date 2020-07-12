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
            //(new LoginForm()).Show();
            //Application.Run();

            Application.Run(new LoginForm());

            //(new AdministrationForm()).Show();a
            
            if (Commons.LOGINUSERID == "admin")
            {
                AdministrationForm fr = new AdministrationForm();
                Application.Run(fr);
                //fr.Show();
                fr.ShowInTaskbar = true;
            }
            else
            {
                ProductForm pf = new ProductForm();
                Application.Run(pf);
                pf.ShowInTaskbar = true;
            }

            
            //QueFrom1 queForm = new QueFrom1();
            //Application.Run(queForm);

            //Form2 form2 = new Form2();
            //Application.Run(form2);

            //All_Products all_Products = new All_Products();
            //Application.Run(all_Products);

        }
    }
}

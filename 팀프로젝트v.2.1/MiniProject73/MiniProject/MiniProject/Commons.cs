using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject
{
    public static class Commons
    {
        //공용 연결문자열
        //HJ 수정 [20200703 12:10] : DB PATH
        //public static string CONNSTRING =
        //    "Data Source=127.0.0.1;Initial Catalog=PhonePlan;User ID=Sa;Password=p@ssw0rd!";
        public static string CONNSTRING =
            "Data Source=127.0.0.1;Initial Catalog = CallingPlanDB;User ID=Sa;Password=p@ssw0rd!";

        public static string LOGINUSERID = "Park";


        public static string SELECTED_PLAN = "";

        public static int USER_STD_1 = 0;
        public static int USER_STD_2 = 0;
        public static int USER_STD_3 = 0;

        //HJ 추가 [20200703 12:13] : 구조체 추가
        public struct Tendency
        {
            public int iStd1;
            public int iStd2;
            public int iStd3;
            public string strUserCall;
        }
    }
    
}

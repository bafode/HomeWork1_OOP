
using System;
using System.Collections.Generic;
using System.Text;

namespace projetBSM
{
    public partial class student
    {
        //Basarı derecesı bulunan fonksionu
        public string getLevelOfSucces()
        {

            if (average >= 90)
            {
                return "Pekiyi";

            }
            else if (average >= 85.00)
            {
                return "iyiPekiyi";
            }
            else if (average>= 80.00)
            {
                return "iyi";
            }
            else if (average >= 75.00)
            {
                return "Orta-iyi";
            }
            else if (average >= 65.00)
            {
                return "Orta";
            }
            else if (average >= 58.00)
            {
                return "Zayif-Orta";
            }
            else if (average >= 50.00)
            {
                return "Zayif";
            }
            else if (average >= 40.00)
            {
                return "başarısız";
            }
            else if (average >= 0)
            {
                return "Başarısız";
            }
            else
            {
                return "devamsizlik";

            }

        }

        //Harf notu bulunan fonksiyonu
        public string getLttermark()
        {
            if (average >= 90)
            {

                return "AA";
            }
            else if (average >= 85.00)
            {
                return "BA";
            }
            else if (average >= 80.00)
            {

                return "BB";

            }
            else if (average >= 75.00)
            {

                return "CB";

            }
            else if (average >= 65.00)
            {

                return "CC";

            }
            else if (average >= 58.00)
            {

                return "DC";

            }
            else if (average >= 50.00)
            {

                return "DD";

            }
            else if (average >= 40.00)
            {

                return "FD";

            }
            else if (average >= 0)
            {

                return "FF";

            }
            else
            {

                return "DZ";

            }

        }


}
}

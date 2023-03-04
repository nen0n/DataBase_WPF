using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Person
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondName { get; set; }
        public string Faculty { get; set; }
        public string KPIdiploma { get; set; } = "-";
        public string IDOfDiploma { get; set; } = "-";
        public string YearOfKPI { get; set; } = "-";
        public string MONdiploma { get; set; } = "-";
        public string YearOfMON { get; set; } = "-";
        public string Prognosis { get; set; } = "-";

        public static string[] KPIdiplomas { get; } =
        {
            "-",
            "Грамота Вченої ради",
            "Почесна грамота Вченої ради",
            "Почесна відзнака Вченої ради",
            "Почесне звання «Заслужений викладач КПІ»",
            "Почесне звання «Заслужений професор КПІ»",
            "Почесне звання «Заслужений науковець КПІ»",
            "Почесне звання «Заслужений працівник КПІ»",
            "Почесна відзнака «Видатний діяч КПІ»",
            "Почесне звання «Почесний доктор КПІ»",
            "Почесна відзнака «За служіння та відданість КПІ»",
            "Почесна відзнака «За заслуги  перед КПІ»",
        };

        public static string[] MONdiplomas { get; } =
        {
            "-",
            "Подяка МОН України",
            "Грамота МОН України",
            "Почесна грамота МОН України",
            "Нагрудний знак «Відмінник освіти»",
            "Почесне звання «Заслужений діяч науки і техніки України»",
            "Подяка КМ України",
            "Грамота КМ України",
        };

        public Person(string _name, string _surname, string _secondname, string _faculty, string _kpidiploma, string _idofdiploma, string _yearofkpi)
        {
            Name = _name;
            Surname = _surname;
            SecondName = _secondname;
            Faculty = _faculty;
            KPIdiploma = KPIdiplomas[Int32.Parse(_kpidiploma)];
            IDOfDiploma = _idofdiploma;
            YearOfKPI = _yearofkpi;
            if (Int32.Parse(YearOfKPI) != 2022 && Int32.Parse(_kpidiploma) != 11)
            {
                Prognosis = "Можливість отримання '" + KPIdiplomas[Int32.Parse(_kpidiploma) + 1] + "' у 2022 році";
            }
            else
            {
                Prognosis = "-";
            }
        }
        public Person(string _name, string _surname, string _secondname, string _faculty, string _mondiploma, string _yearofmon)
        {
            Name = _name;
            Surname = _surname;
            SecondName = _secondname;
            Faculty = _faculty;
            MONdiploma = MONdiplomas[Int32.Parse(_mondiploma)];
            YearOfMON = _yearofmon;
            if (Int32.Parse(YearOfMON) != 2022 && Int32.Parse(_mondiploma) != 7)
            {
                Prognosis = "Можливість отримання '" + MONdiplomas[Int32.Parse(_mondiploma) + 1] + "' у 2022 році";
            }
            else
            {
                Prognosis = "-";
            }
        }
        public Person()
        {

        }
    }   
}

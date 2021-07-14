using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TTProject.src
{
    class Dice
    {
        Random r = new Random();

        public int diceRoll(string s)
        {
            int result = 0;

            string splitPattern = @"(kh)|(dh)|(kl)|(dl)|(d)|(!!)|(!)|";
            string pattern = @"^((d){1-1000} | {1-1000}(d){1-1000}) |
            ^((d){1-1000} | {1-1000}(d){1-1000})((kh)|(kl)|(dh)|(dl)) |
            ^((d){1-1000} | {1-1000}(d){1-1000})((kh)|(kl)|(dh)|(dl)){1-1000}
            ^((d){1-1000} | {1-1000}(d){1-1000})((!!)|(!)) |
            ^((d){1-1000} | {1-1000}(d){1-1000})((!!)|(!))({1-1000}|((>){1-1000})|((<){1-1000})) |
            ^((d){1-1000} | {1-1000}(d){1-1000})((!!)|(!))({1-1000}|((>){1-1000})|((<){1-1000}))((kh)|(kl)|(dh)|(dl)) |
            ^((d){1-1000} | {1-1000}(d){1-1000})((!!)|(!))({1-1000}|((>){1-1000})|((<){1-1000}))((kh)|(kl)|(dh)|(dl)){1-1000}";

            Regex regex = new Regex(splitPattern, RegexOptions.IgnoreCase);
            Regex regex1 = new Regex(pattern, RegexOptions.IgnoreCase);

            var a = regex.Split(s);
            Console.WriteLine(regex1.IsMatch(s));

            foreach (var b in a)
            {
                Console.WriteLine(b);
            }
            if (a[0].Equals(""))
            {
                a[0] = (1).ToString();
            }
            
            for (int i = 0; i < Int16.Parse(a[0]); i++)
            {

            }

            return result;
        }     

    }
}

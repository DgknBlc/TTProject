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

        public int diceRoll(string s, out List<int> values)
        {
            int result = 0;
            values = new List<int>();

            string splitPattern = @"(kh)|(dh)|(kl)|(dl)|(d)|(!!<)|(!!>)|(!!)|(!<)|(!>)|(!)|(<)|(>)|(=)";
            string pattern = @"^[1-9]?[0-9]*d[1-9][0-9]*(((!!<|!!>|!<|!>)[1-9][0-9]*)|((!!|!)[0-9]*))?((kh|kl|dh|dl)[0-9]*)?((<|>|=)[0-9]+$)?";

            string diePattern = @"^[1-9]?[0-9]*d[1-9][0-9]*";
            string explodingPattern = @"((!!<|!!>|!<|!>)[1-9][0-9]*)|((!!|!)[0-9]*)";  //(!!<|!!>|!!|!<|!>|!)[1-9]?[0-9]*
            string valuesPattern = @"(kh|kl|dh|dl)[0-9]*";
            string successPattern = @"(<|>|=)[0-9]+$";
            string intPatern = @"([0-9]+)$";

            Regex splitRegex = new Regex(splitPattern, RegexOptions.IgnoreCase);
            Regex paternRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            Regex dieRegex = new Regex(diePattern, RegexOptions.IgnoreCase);
            Regex explodingRegex = new Regex(explodingPattern, RegexOptions.IgnoreCase);
            Regex valuesRegex = new Regex(valuesPattern, RegexOptions.IgnoreCase);
            Regex successRegex = new Regex(successPattern, RegexOptions.IgnoreCase);
            Regex intRegex = new Regex(intPatern, RegexOptions.IgnoreCase);

            Match match = paternRegex.Match(s);

            if (match.Success)
            {
                short factor;                
                String[] a = splitRegex.Split(dieRegex.Match(match.Value).Value);

                if (!Int16.TryParse(a[0], out factor))
                    factor = 1;                    

                short dieType = Int16.Parse(a[2]);
                for (int i = 0; i < factor; i++)
                {
                    int temp = r.Next(1, dieType + 1);
                    values.Add(temp);
                }

                result = values.Sum();


                if (explodingRegex.Match(match.Value).Success)
                {
                    string bTemp = explodingRegex.Match(match.Value).Value;
                    string[] charList = splitRegex.Split(bTemp);
                    if (!Int16.TryParse(intRegex.Match(bTemp).Value, out factor))
                    {
                        factor = dieType;
                    }
                    int tmp = 0;
                    for (int i = 0; i < values.Count(); i++)
                    {
                        switch (charList[1])
                        {
                            case "!!":
                                if (factor == values[i])
                                {
                                    do
                                    {
                                        tmp = r.Next(1, dieType + 1);
                                        values[i] += tmp;
                                    } while (factor == tmp);
                                }
                                break;
                            case "!!<":
                                if (factor > values[i])
                                {
                                    do
                                    {
                                        tmp = r.Next(1, dieType + 1);
                                        values[i] += tmp;
                                    } while (factor > tmp);                                    
                                }
                                break;
                            case "!!>":
                                if (factor < values[i])
                                {
                                    do
                                    {
                                        tmp = r.Next(1, dieType + 1);
                                        values[i] += tmp;
                                    } while (factor < tmp);                                    
                                }
                                break;
                            case "!":
                                if (factor == values[i])
                                {
                                    tmp = r.Next(1, dieType + 1);
                                    values.Insert(i + 1, tmp);
                                }
                                break;
                            case "!<":
                                if (factor > values[i])
                                {
                                    tmp = r.Next(1, dieType + 1);
                                    values.Insert(i + 1, tmp);
                                }
                                break;
                            case "!>":
                                if (factor < values[i])
                                {
                                    tmp = r.Next(1, dieType + 1);
                                    values.Insert(i + 1, tmp);
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    result = values.Sum();
                }

                if (valuesRegex.Match(match.Value).Success)
                {
                    string cTemp = valuesRegex.Match(match.Value).Value;
                    string[] charList = splitRegex.Split(cTemp);
                    if (!Int16.TryParse(intRegex.Match(cTemp).Value, out factor))
                    {
                        factor = 1;
                    }
                    List<int> newValues = new List<int>();
                    newValues.AddRange(values.GetRange(0, values.Count));
                    newValues.Sort();
                    switch (charList[1])
                    {
                        case "kh":
                            newValues.RemoveRange(0, values.Count - factor);
                            break;
                        case "kl":
                            newValues.RemoveRange(factor, values.Count - factor);
                            break;
                        case "dh":
                            newValues.RemoveRange(values.Count - factor, factor);
                            break;
                        case "dl":
                            newValues.RemoveRange(0, factor);
                            break;
                        default:
                            break;
                    }
                    result = newValues.Sum();
                }

                if (successRegex.Match(match.Value).Success)
                {
                    result = 0;
                    string dTemp = successRegex.Match(match.Value).Value;
                    string[] charList = splitRegex.Split(dTemp);
                    Int16.TryParse(intRegex.Match(dTemp).Value, out factor);
                    for (int i = 0; i < values.Count; i++)
                    {
                        switch (charList[1])
                        {
                            case ">":
                                if (values[i] > factor)
                                    result++;
                                break;
                            case "<":
                                if (values[i] < factor)
                                    result++;
                                break;
                            case "=":
                                if (values[i] == factor)
                                    result++;
                                break;
                            default:
                                Console.WriteLine("Emtpy");
                                break;
                        }
                    }                    

                }
            }
            else
            {
                Console.WriteLine("Error Code : 1 \nUnexpected Dice Roll");
            }
            return result;
        }

    }
}


/*switch (b[1])
                    {
                        case "!":                                           //5d6!  "(1+3+3+5+1)"
                            for (int i = 0; i < values.Count(); i++)
                            {
                                if (dieType == values[i] && !bBool)
                                {
                                    int tmp = r.Next(1, dieType + 1);
                                    values.Insert(tmp, i + 1);
                                }
                                else if ((factor >= values[i] && ((b[2])[0] == '<')) || (factor <= values[i] && ((b[2])[0] == '>')))
                                {
                                    int tmp = r.Next(1, dieType + 1);
                                    values.Insert(tmp, i + 1);
                                }
                            }
                            break;
                        case "!!":
                            for (int i = 0; i < values.Count(); i++)
                            {
                                if (dieType == values[i] && !bBool)
                                {
                                    int tmp = r.Next(1, dieType + 1);
                                    values[i] += tmp;
                                }
                                else if ((factor >= values[i] && ((b[2])[0] == '<')) || (factor <= values[i] && ((b[2])[0] == '>')))
                                {
                                    int tmp = r.Next(1, dieType + 1);
                                    values[i] += tmp;
                                }
                            }
                            break;
                    }*/
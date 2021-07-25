using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TTProject.src
{
    public class Dice
    {
        Random r = new Random();

        #region Patterns
        int[] fateDice = { -1, -1, 0, 0, 1, 1 };
        string fatePattern = @"^[1-9]?[0-9]*dF";

        string diePattern = @"[1-9]?[0-9]*d(f|[1-9][0-9]*)";
        string rerollPattern = @"r((o[<>][1-9][0-9]*|o[0-9]*)|([<>][1-9][0-9]*|[0-9]*))"; //https://tinyurl.com/yg2jsgrg
        string explodingPattern = @"!(!([<>][1-9]|)[0-9]*|([<>][1-9]|)[0-9]*)";
        string valuesPattern = @"[kd][hl][0-9]*";
        string successPattern = @"\.[<>=][1-9][0-9]*";
        string intPatern = @"([0-9]*)$";
        #endregion
        public int diceRoll(string s, out string str)
        {
            int result = 0;
            List<int> values = new List<int>();
            str = "";
            bool isKeepDrop = false;

            string splitPattern = @"(kh)|(dh)|(kl)|(dl)|(d)|(!!<)|(!!>)|(!!)|(!<)|(!>)|(!)|(<)|(>)|(=)|(ro>)|(ro<)|(ro)|(r<)|(r>)|(r)";
            string pattern = diePattern + "((" + explodingPattern + ")(" + rerollPattern + ")?|(" + rerollPattern + ")(" + explodingPattern + ")?)?(" + valuesPattern + ")?(" + successPattern + ")?";
            //diePattern + "(" + explodingPattern + ")?(" + rerollPattern + ")?(" + valuesPattern + ")?(" + successPattern + ")?"; //@"^[1-9]?[0-9]*d[1-9][0-9]*(((!!<|!!>|!<|!>)[1-9][0-9]*)|((!!|!)[0-9]*))?((kh|kl|dh|dl)[0-9]*)?((<|>|=)[0-9]+$)?";

            Regex splitRegex = new Regex(splitPattern, RegexOptions.IgnoreCase);
            Regex paternRegex = new Regex(pattern, RegexOptions.IgnoreCase);

            Regex fateRegex = new Regex(fatePattern, RegexOptions.IgnoreCase);

            Regex dieRegex = new Regex(diePattern, RegexOptions.IgnoreCase);
            Regex rerollRegex = new Regex(rerollPattern, RegexOptions.IgnoreCase);
            Regex explodingRegex = new Regex(explodingPattern, RegexOptions.IgnoreCase);
            Regex valuesRegex = new Regex(valuesPattern, RegexOptions.IgnoreCase);
            Regex successRegex = new Regex(successPattern, RegexOptions.IgnoreCase);
            Regex intRegex = new Regex(intPatern, RegexOptions.IgnoreCase);

            if (paternRegex.IsMatch(s))
            {
                Match match = paternRegex.Match(s);

                short diceFactor, factor;                
                String[] a = splitRegex.Split(dieRegex.Match(match.Value).Value);

                if (!Int16.TryParse(a[0], out diceFactor))
                    diceFactor = 1;

                if (fateRegex.IsMatch(s))
                {
                    for (int i = 0; i < diceFactor; i++)
                    {
                        int temp = fateDice[r.Next(0, 6)];
                        values.Add(temp);
                    }

                    str = listToString(values);
                    return result = values.Sum();
                }


                short dieType = Int16.Parse(a[2]);
                for (int i = 0; i < diceFactor; i++)
                {
                    int temp = r.Next(1, dieType + 1);
                    values.Add(temp);
                }

                result = values.Sum();
                str = listToString(values);

                if (rerollRegex.IsMatch(match.Value)){
                    string bTemp = rerollRegex.Match(match.Value).Value;
                    string[] charList = splitRegex.Split(bTemp);
                    if (!Int16.TryParse(intRegex.Match(bTemp).Value, out factor))
                    {
                        factor = 1;
                    }
                    int tmp = 0;
                    for (int i = 0; i < values.Count; i++)
                    {
                        switch (charList[1])
                        {
                            case "ro>":
                                if (factor < values[i])
                                {
                                    tmp = r.Next(1, dieType + 1);
                                    values[i] = tmp;
                                    i++;
                                }
                                break;
                            case "ro<":
                                if (factor > values[i])
                                {
                                    tmp = r.Next(1, dieType + 1);
                                    values[i] = tmp;
                                    i++;
                                }
                                break;
                            case "ro":
                                if (factor == values[i])
                                {
                                    tmp = r.Next(1, dieType + 1);
                                    values[i] = tmp;
                                    i++;
                                }
                                break;
                            case "r>":
                                if (factor < values[i])
                                {
                                    do
                                    {
                                        tmp = r.Next(1, dieType + 1);
                                        values[i] = tmp;
                                    } while (factor < values[i]);
                                }
                                break;
                            case "r<":
                                if (factor > values[i])
                                {
                                    do
                                    {
                                        tmp = r.Next(1, dieType + 1);
                                        values[i] = tmp;
                                    } while (factor > values[i]);
                                }
                                break;
                            case "r":
                                if (factor == values[i])
                                {
                                    do
                                    {
                                        tmp = r.Next(1, dieType + 1);
                                        values[i] = tmp;
                                    } while (factor == values[i]);
                                }
                                break;
                        }
                    }
                    result = values.Sum();
                    str = listToString(values);
                }

                if (explodingRegex.IsMatch(match.Value))
                {
                    string bTemp = explodingRegex.Match(match.Value).Value;
                    string[] charList = splitRegex.Split(bTemp);
                    if (!Int16.TryParse(intRegex.Match(bTemp).Value, out factor))
                    {
                        factor = dieType;
                    }
                    int tmp = 0;
                    if (factor < 2)
                        factor = 2;
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
                    str = listToString(values);
                }

                List<int> newValues = new List<int>();
                if (valuesRegex.IsMatch(match.Value))
                {
                    isKeepDrop = true;
                    string cTemp = valuesRegex.Match(match.Value).Value;
                    string[] charList = splitRegex.Split(cTemp);
                    if (!Int16.TryParse(intRegex.Match(cTemp).Value, out factor))
                    {
                        factor = 1;
                    }                    
                    newValues.AddRange(values.GetRange(0, values.Count));
                    newValues.Sort();
                    if(factor > diceFactor)
                    {
                        factor = diceFactor;
                    }
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
                    str = "["+ str + "=>"+ listToString(newValues) + "]";
                }

                if (successRegex.IsMatch(match.Value))
                {
                    result = 0;
                    string dTemp = successRegex.Match(match.Value).Value;
                    string[] charList = splitRegex.Split(dTemp);
                    Int16.TryParse(intRegex.Match(dTemp).Value, out factor);

                    List<int> sValues = new List<int>();
                    if (isKeepDrop)
                    {
                        sValues.AddRange(newValues.GetRange(0, newValues.Count));
                    }
                    else
                    {
                        sValues.AddRange(values.GetRange(0, values.Count));
                    }
                    for (int i = 0; i < sValues.Count; i++)
                    {
                        switch (charList[1])
                        {
                            case ">":
                                if (sValues[i] > factor)
                                    result++;
                                break;
                            case "<":
                                if (sValues[i] < factor)
                                    result++;
                                break;
                            case "=":
                                if (sValues[i] == factor)
                                    result++;
                                break;
                            default:
                                Console.WriteLine("Emtpy");
                                break;
                        }
                    }
                    str = "[" + str + charList[1] + factor + " = (" + result + ") Success]";
                }
            }
            return result;
        }

        public int roll(string s, out string str, bool isOpen = false)
        {
            int result = 0;
            str = "";
            string openStr = "";
            string closedStr = "";
            List<int> resultList = new List<int>();
            List<string> resultStringList = new List<string>();

            string pattern = diePattern + "((" + explodingPattern + ")(" + rerollPattern + ")?|(" + rerollPattern + ")(" + explodingPattern + ")?)?(" + valuesPattern + ")?(" + successPattern + ")?";

            DataTable dt = new DataTable();

            Regex diceRegex = new Regex(pattern, RegexOptions.IgnoreCase);
            Regex spaceReplacerRegex = new Regex((@"\s+"), RegexOptions.IgnoreCase);

            s = spaceReplacerRegex.Replace(s, "");
            var a = diceRegex.Matches(s);
            foreach (var item in a)
            {
                string resultStr = "";
                resultList.Add(diceRoll(item.ToString(), out resultStr));
                resultStringList.Add(resultStr);
            }
            s = diceRegex.Replace(s, "#");
            int i = 0;
            foreach (var ch in s)
            {
                if (ch == '#')
                {
                    closedStr += "["+ resultList[i] +"]";
                    openStr += resultStringList[i++];
                }
                else
                {
                    closedStr += ch;
                    openStr += ch;
                }
            }
            try
            {
                var t = dt.Compute(spaceReplacerRegex.Replace(closedStr.Replace('[', ' ').Replace(']',' '),""),"");
                if (!Int32.TryParse(t.ToString(), out result))
                {
                    result = (int)Double.Parse(t.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                str = "Error = -1 : Unkown roll type";
                return -1;
                
            }
            switch (isOpen)
            {
                case true:
                    str = openStr;
                    break;
                default:
                    str = closedStr;
                    break;
            }
            return result;
        }


        string listToString(List<int> vs)
        {
            string txt = "[";
            for (int i = 0; i < vs.Count; i++)
            {
                if (i == vs.Count-1)
                {
                    txt += vs[i] + "]";
                }
                else
                {
                    txt += vs[i] + ",";
                }
            }
            return txt;
        }
    }
}
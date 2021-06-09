using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: Calculator
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Calculator()
        {
            return View();
        }

        [HttpPost]
        public string GetResult(string number)
        {
            try
            {
              
                #region To store entered input operator in the list
                List<char> symbol = new List<char>();

                for (int i = 0; i < number.Length; i++)
                {
                    if (number[i] == '+' || number[i] == '-' || number[i] == '*' || number[i] == '/' || number[i] == '%')
                    {
                        symbol.Add(number[i]);
                    }
                }
                #endregion
                double result;
                #region Get only numerical value from the input string
                string[] NumberString = number.Split(new[] { "-", "+", "/", "*" }, StringSplitOptions.RemoveEmptyEntries);
                #endregion

                #region if starting string char is operator like{-,+,*,/}
                if (number[0] == '+' || number[0] == '-' || number[0] == '*' || number[0] == '/' || number[0] == '%')
                {

                 
                    string firstSymbols = symbol[0].ToString();
                    result = Convert.ToDouble(firstSymbols + NumberString[0]);
              
                    for (int i = 1; i < NumberString.Length; i++)
                    {

                        double num = Convert.ToDouble(NumberString[i]);

                        switch (symbol[i])
                        {
                            case '+':
                                result = Add(result, num);
                                break;
                            case '-':
                                result = Subtract(result, num);
                                break;
                            case '*':
                                result = Multiply(result, num);
                                break;
                            case '/':
                                result = Divide(result, num);
                                break;
                            case '%':
                                result = Modulo(result, num);
                                break;
                            default:
                                result = 0.0;
                                break;
                        }

                    }


                    return result.ToString();
                }
                #endregion
                #region first input char in number
                else
                {
                    result = Convert.ToDouble(NumberString[0]);

                    for (int i = 1; i < NumberString.Length; i++)
                    {
                        double num = Convert.ToDouble(NumberString[i]);
                        int j = i - 1;
                        switch (symbol[j])
                        {
                            case '+':
                                result = Add(result, num);
                                break;
                            case '-':
                                result = Subtract(result, num);
                                break;
                            case '*':
                                result = Multiply(result, num);
                                break;
                            case '/':
                                result = Divide(result, num);
                                break;
                            case '%':
                                result = Modulo(result, num);
                                break;
                            default:
                                result = 0.0;
                                break;
                        }
                    }
                }

                return result.ToString();
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }

        public double Add(double value1, double value2)
        {
            double result = value1 + value2;
            return result;
        }
        public double Subtract(double value1, double value2)
        {
            double result = value1 - value2;
            return result;
        }
        public double Multiply(double value1, double value2)
        {
            double result = value1 * value2;
            return result;
        }
        public double Divide(double value1, double value2)
        {
            double result = value1 / value2;
            return result;
        }
        public double Modulo(double value1, double value2)
        {
            double result = value1 / value2;
            return result;
        }

    }


    #endregion


}



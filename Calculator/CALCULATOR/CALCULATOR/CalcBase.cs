using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CALCULATOR
{
    public class CalcBase
    {
        public double first, second, result,memory = 0;
        public string operation = "";
        public bool ok = false;
        public double one = 0;
        public string oneop = "";
       
        public void operate()
        {
            switch (operation) {
                case "+":
                    result = first + second;
                    ok = true;
                    break;
                case "-":
                    ok = true;
                    result = first - second;
                    break;
                case "*":
                    ok = true;
                    result = first * second;
                    break;
                case "/":
                    result = first / second;
                    ok = true;
                    break;
                case "Mod":
                    result = first % second;
                    ok = true;
                    break;
                case "x^y":
                    double k = 1;
                    for(double i = 1; i <= second ; i++)
                    {
                        k *= first;
                    }
                    result = k;
                    ok = true;
                    break;
                case "x^(1/y)":
                    double d = 1 / second;
                    double l = 1;
                    for(double i = 0; i < d; i++)
                    {
                        l *= first;
                    }
                    ok = true;
                    result = l;
                    break;
            }
        }
        public void calculate()
        {
            switch (oneop)
            {
                case "sqrt":
                    result = Math.Sqrt(one);
                    break;
                case "!":
                    result = 1;
                    for(int i = 1; i <= one; i++)
                    {
                        result *= i;
                    }
                    break;
                case "x^2":
                    result = one * one;
                    break;
                case "1/x":
                    result = 1 / one;
                    ok = true;
                    break;
                case "e^x":
                    result = Math.Exp(one);
                    break;
                case "%":
                    double p = first * (second / 100);
                    switch (operation)
                    {
                        case "+":
                            result = first + p;
                            break;
                        case "-":
                            result = first - p;
                            break;
                        case "*":
                            result = first * p;
                            break;
                        case "/":
                            result = first / p;
                            break;
                    }
                    break;
                case "tan":
                    result = Math.Tan(one);
                        break;
                case "sin":
                    result = Math.Sin(one);
                    break;
                case "cos":
                    result = Math.Cos(one);
                    break;
                case "ln":
                    result = Math.Log10(one);
                    break;
            }
        }
    }
}

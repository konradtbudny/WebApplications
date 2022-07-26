using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Mvc;
namespace Project02CarRentalWebApp.Controllers
{
    public class CalculatorController : Controller
    {
        public static Dictionary<string, ArithmeticOperation> EvaulationDictionary { get; set; } = new Dictionary<string, ArithmeticOperation> {
            { "+", (a, b) => a + b},
            { "-", (a, b) => a - b},
            { "*", (a, b) => a * b},
            { "/", (a, b) => a / b},
            { "%", (a, b) => a % b} };

        public ActionResult Index()
        {
            return RedirectToAction("Evaluate", new { a = 2, b = 5, op = "+" });
        }
        public ActionResult Evaluate(double a, double b, string op)
        {
            return View((object)("" + a + " " + op + " " + b + " = " + EvaulationDictionary[op](a, b)));
        }
        public ActionResult Calculator()
        {
            return View();
        }
        public ActionResult EvaluateExpression(string expression)
        {
            expression = expression.Trim();
            string[] splitExpression = Regex.Split(expression, @"\s+");
            double a = Convert.ToDouble(splitExpression[0]);
            double b = Convert.ToDouble(splitExpression[2]);
            string op = splitExpression[1];
            return RedirectToAction("Evaluate", new { a, b, op });
        }
        [HttpPost]
        public string EvaluateExpressionAJAX(string expression)
        {
            expression = expression.Trim();
            string pattern = @"^-?(\d+)*(?:\.\d+)?(\s+)(\+|\-|\*|/|\%)(\s+)-?(\d+)*(?:\.\d+)?$";
            if (Regex.IsMatch(expression, pattern))
            {
                string[] splitExpression = Regex.Split(expression, @"\s+");
                double a = Convert.ToDouble(splitExpression[0]);
                double b = Convert.ToDouble(splitExpression[2]);
                string op = splitExpression[1];
                return EvaulationDictionary[op](a, b).ToString();
            }
            return "Expression is incorrect";
        }
        [HttpPost]
        public string GetSecuredData(string userName, string password)
        {
            string securedInfo = "";
            if ((userName == "admin") && (password == "admin"))
                securedInfo = "Hello admin, your secured information is .......";
            else
                securedInfo = "Wrong username or password, please retry.";
            return securedInfo;
        }
    }
}
public delegate double ArithmeticOperation(double a, double b);
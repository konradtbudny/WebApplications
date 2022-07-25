//https://localhost:44371/tennisdecision/this?outlook=Sunny&temperature=21&Wind=Weak
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PeopleAPI.Controllers
{
    [Route("[controller]")]
    public class TennisDecisionController : Controller
    {
        private static readonly string[] Outlook = new[] { "Sunny", "Overcast", "Rain" };
        private static readonly string[] Wind = new[] { "No wind", "Weak", "Strong" };
        private static readonly string[] Decisions = new[] { "Undetermined. Check paramters", "Yes", "No" };

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Yes", "No" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("This")]
        public string This([FromQuery] string outlook, [FromQuery] int Temperature, [FromQuery]string wind)
        {
            string decision = Decisions[0].ToString();
            if (Temperature > 15)
            {
                if (outlook == Outlook.GetValue(0).ToString())
                {
                    if (wind == Wind.GetValue(0).ToString() || wind == Wind.GetValue(1).ToString())
                    {
                        decision = Decisions.GetValue(1).ToString();
                    }
                    else
                    {
                        decision = Decisions.GetValue(2).ToString();
                    }
                }
                else if (outlook == Outlook.GetValue(1).ToString())
                {
                    if (wind == Wind.GetValue(0).ToString() || wind == Wind.GetValue(1).ToString())
                    {
                        decision = Decisions.GetValue(1).ToString();
                    }
                    else
                    {
                        decision = Decisions.GetValue(2).ToString();
                    }
                }
                else if (outlook == Outlook.GetValue(2).ToString())
                {
                    decision = Decisions.GetValue(2).ToString();
                }
            }
            else
            {
                decision = Decisions.GetValue(2).ToString();
            }
            return "Decision: " + decision;
        }
    }
}
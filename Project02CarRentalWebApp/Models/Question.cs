using System;
using System.Collections.Generic;

namespace Project02CarRentalWebApp.Models
{
    public class Question
    {
        public Guid Id { get; set; }
        public String Text { get; set; }
        public virtual Survey Survey { get; set; }
        public virtual List<Answer> Answers { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project02CarRentalWebApp.Models
{
    public class Answer
    {
        public Guid Id { get; set; }
        public String Text { get; set; }
        public virtual Question Question { get; set; }
        [NotMapped]
        public bool IsChecked { get; set; }
        public virtual List<Address> Adresses { get; set; }
    }
    public class AnswerComparer : IEqualityComparer<Answer>
    {
        private static readonly Lazy<AnswerComparer> lazy = new Lazy<AnswerComparer>(() => new AnswerComparer());
        public static AnswerComparer Instance { get { return lazy.Value; } }

        private AnswerComparer() { }

        public bool Equals(Answer x, Answer y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(Answer obj)
        {
            return obj.GetHashCode();
        }
    }
}
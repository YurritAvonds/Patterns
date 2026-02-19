using Patterns.Fhir.ValueSet;
using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Fhir.HumanName
{
    internal class HumanName
    {
        public Code? Use { get; set; }
        public string? Text { get; set; }
        public string? Family { get; set; }
        public ICollection<string>? Given { get; set; }
        public ICollection<string>? Prefix { get; set; }
        public ICollection<string>? Suffix { get; set; }
        public DateTime? PeriodStart { get; set; }
        public DateTime? PeriodEnd { get; set; }

        public string FullName
        {
            get
            {
                var fullName = new StringBuilder();
                if (Prefix != null && Prefix.Any())
                {
                    fullName.Append(string.Join(" ", Prefix) + " ");
                }
                if (Given != null && Given.Any())
                {
                    fullName.Append(string.Join(" ", Given) + " ");
                }
                if (!string.IsNullOrEmpty(Family))
                {
                    fullName.Append(Family);
                }
                if (Suffix != null && Suffix.Any())
                {
                    fullName.Append(" " + string.Join(" ", Suffix));
                }
                return fullName.ToString().Trim();
            }
        }
    }
}
using System;
namespace Crosshelper.Models
{
    public class TypeProblem
    {
        public TypeProblem()
        {
        }
        public string ProblemType { get; set; }

        public override string ToString()
        {
            return ProblemType;
        }

    }
}

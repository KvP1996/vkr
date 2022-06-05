using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBaseServer.Determinant
{
    public class ExpressionsList : Expression
    {
        public Expression[] Elements
        {
            set
            {
                elements = value;
            }
            get
            {
                return elements;
            }
        }

        Expression[] elements;

        public ExpressionsList() { }

        public ExpressionsList(Expression[] pairs)
        {
            Elements = pairs;

            calculateLevels();
        }

        void calculateLevels()
        {
            var opers = new List<Expression>[elements.Length][];
            int n = 0;
            for (var i = 0; i < opers.Length; i++)
            {
                if (elements[i] != null)
                {
                    opers[i] = elements[i].GetLevels();
                }
                else
                {
                    opers[i] = new List<Expression>[0];
                }
                if (opers[i].Length > n)
                    n = opers[i].Length;
            }

            levels = new List<Expression>[n];
            for (var i = 0; i < levels.Length; i++)
            {
                levels[i] = new List<Expression>();
                for (var j = 0; j < opers.Length; j++)
                {
                    if (i < opers[j].Length)
                    {
                        foreach (var x in opers[j][i])
                            levels[i].Add(x);
                    }
                }
            }
        }
    }
}
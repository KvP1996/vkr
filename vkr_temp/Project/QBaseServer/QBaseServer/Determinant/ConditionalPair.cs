using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBaseServer.Determinant
{
    public class ConditionalPair : Expression
    {
        public Expression Condition
        {
            set
            {
                condition = value;
            }
            get
            {
                return condition;
            }
        }
        public Expression Value
        {
            set
            {
                this.value = value;
            }
            get
            {
                return value;
            }
        }

        Expression condition;
        Expression value;

        public ConditionalPair() { }

        public ConditionalPair(Expression condition, Expression value)
        {
            Condition = condition;
            Value = value;

            calculateLevels();
        }

        void calculateLevels()
        {
            var oper1 = new List<Expression>[0];
            var oper2 = new List<Expression>[0];
            if (Condition != null)
                oper1 = Condition.GetLevels();
            if (Value != null)
                oper2 = Value.GetLevels();

            int n = 0;
            if (oper1.Length > oper2.Length)
                n = oper1.Length;
            else
                n = oper2.Length;

            levels = new List<Expression>[n];
            for (var i = 0; i < levels.Length; i++)
            {
                levels[i] = new List<Expression>();
                if (i < oper1.Length)
                {
                    foreach (var x in oper1[i])
                        levels[i].Add(x);
                }
                if (i < oper2.Length)
                {
                    foreach (var x in oper2[i])
                        levels[i].Add(x);
                }
            }
        }
    }
}
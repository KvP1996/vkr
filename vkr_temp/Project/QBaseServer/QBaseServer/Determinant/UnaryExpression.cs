using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBaseServer.Determinant
{
    public class UnaryExpression : Expression
    {
        public string Op
        {
            private set
            {
                op = value;
            }
            get
            {
                return op;
            }
        }
        public Expression Operand
        {
            private set
            {
                operand = value;
            }
            get
            {
                return operand;
            }
        }

        string op;
        Expression operand;

        public UnaryExpression() 
        {
            //calcualteLevels();
        }

        public UnaryExpression(string op, Expression operand)
        {
            Op = op;
            Operand = operand;

            calcualteLevels();
        }

        void calcualteLevels()
        {
            List<Expression>[] oper = new List<Expression>[0];
            if (Operand != null)
                oper = Operand.GetLevels();
            levels = new List<Expression>[oper.Length + 1];
            for (var i = 0; i < oper.Length; i++)
            {
                levels[i] = oper[i];
            }
            levels[levels.Length - 1] = new List<Expression>();
            levels[levels.Length - 1].Add(this);
        }
    }
}
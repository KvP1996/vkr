using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBaseServer.Determinant
{
    public class BinaryExpression : Expression
    {
        public string OP
        {
            private set
            {
                oP = value;
            }
            get
            {
                return oP;
            }
        }
        public Expression FO
        {
            private set
            {
                fO = value;
            }
            get
            {
                return fO;
            }
        }
        public Expression SO
        {
            private set
            {
                sO = value;
            }
            get
            {
                return sO;
            }
        }

        string oP;
        Expression fO;
        Expression sO;

        public BinaryExpression() 
        {
            //calcualteLevels();
        }

        public BinaryExpression(string oP, Expression fO, Expression sO)
        {
            OP = oP;
            FO = fO;
            SO = sO;

            calcualteLevels();
        }

        void calcualteLevels()
        {
            var oper1 = new List<Expression>[0];
            var oper2 = new List<Expression>[0];
            if (FO != null)
                oper1 = FO.GetLevels();
            if (SO != null)
                oper2 = SO.GetLevels();

            int n = 0;
            if (oper1.Length > oper2.Length)
                n = oper1.Length;
            else
                n = oper2.Length;
            n++;

            levels = new List<Expression>[n];
            for (var i = 0; i < levels.Length - 1; i++)
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
            levels[levels.Length - 1] = new List<Expression>();
            levels[levels.Length - 1].Add(this);
        }
    }
}
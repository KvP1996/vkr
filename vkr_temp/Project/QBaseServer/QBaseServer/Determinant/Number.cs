using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBaseServer.Determinant
{
    public class Number : Expression
    {
        public double Value
        {
            private set
            {
                this.value = value;
            }
            get
            {
                return value;
            }
        }

        double value;

        public Number()
        {
            //calculateLevels();
        }

        public Number(double value)
        {
            Value = value;

            calculateLevels();
        }

        void calculateLevels()
        {
            levels = new List<Expression>[0];
        }
    }
}
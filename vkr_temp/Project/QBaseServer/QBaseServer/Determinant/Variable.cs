using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QBaseServer.Determinant
{
    public class Variable : Expression
    {
        public string Name
        {
            private set
            {
                name = value;
            }
            get
            {
                return name;
            }
        }

        string name;

        public Variable()
        {
            //calculateLevels();
        }

        public Variable(string name)
        {
            Name = name;

            calculateLevels();
        }

        void calculateLevels()
        {
            levels = new List<Expression>[0];
        }
    }
}
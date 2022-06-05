using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace QBaseServer.Determinant
{
    public abstract class Expression
    {
        protected List<Expression>[] levels;

        public virtual int GetTicks()
        {
            return levels.Length;
        }

        public virtual int GetProcessors()
        {
            int res = 0;
            for (int i = 0; i < levels.Length; i++)
                if (levels[i].Count > res)
                    res = levels[i].Count;
            return res;
        }

        public virtual List<Expression>[] GetLevels()
        {
            return levels;
        }

        public static Expression FromJSON(string json)
        {
            Expression result = null;
            var ser = new JavaScriptSerializer { MaxJsonLength = Int32.MaxValue, RecursionLimit = Int32.MaxValue };
            var deserialized = ser.DeserializeObject(json);
            var obj = deserialized as Dictionary<string, object>;
            if (obj == null)
            {
                var objs = deserialized as object[];
                if (objs != null)
                {
                    var pairs = new Expression[objs.Length];
                    for (var i = 0; i < pairs.Length; i++)
                    {
                        var pair = FromJSON(ser.Serialize(objs[i]));
                        pairs[i] = pair;
                    }
                    result = new ExpressionsList(pairs);
                    return result;
                }
                try
                {
                    double val = double.Parse(deserialized.ToString());
                    result = new Number(val);
                    return result;
                }
                catch
                {
                    string name = deserialized.ToString();
                    result = new Variable(name);
                    return result;
                }
            }
            var lowObj = new Dictionary<string, object>();
            foreach (var x in obj)
            {
                lowObj.Add(x.Key.ToLower(), x.Value);
            }

            if (lowObj.ContainsKey("condition"))
            {
                var condition = FromJSON(ser.Serialize(lowObj["condition"]));
                Expression value = FromJSON(ser.Serialize(lowObj["value"]));
                result = new ConditionalPair(condition, value);
                return result;
            }
            if (lowObj.ContainsKey("fo"))
            {
                string operation = lowObj["op"].ToString();
                Expression operand1 = FromJSON(ser.Serialize(lowObj["fo"]));
                Expression operand2 = FromJSON(ser.Serialize(lowObj["so"]));
                result = new BinaryExpression(operation, operand1, operand2);
                return result;
            }
            if (lowObj.ContainsKey("operand"))
            {
                string operation = lowObj["op"].ToString();
                Expression operand = FromJSON(ser.Serialize(lowObj["operand"]));
                result = new UnaryExpression(operation, operand);
                return result;
            }
            if (lowObj.ContainsKey("name"))
            {
                string name = lowObj["name"].ToString();
                result = new Variable(name);
                return result;
            }
            if (lowObj.ContainsKey("value"))
            {
                double val = double.Parse(lowObj["value"].ToString());
                result = new Number(val);
                return result;
            }

            return result;
        }
    }
}
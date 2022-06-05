using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace QBaseClient.Flowgraph
{
    //interface IExpression
    //{
    //    string outputString();
    //    string outputJSON();

    //}

    //class BinaryExpression : IExpression
    //{
    //    IExpression firstoperand, secondoperand;
    //    ArithmeticOperation operation;

    //    public bool validateOperation()
    //    {
    //        string line;
    //        StreamReader file = new StreamReader("operations");
    //        while ((line = file.ReadLine()) != null)
    //        {
    //            if (line.Equals(operation.op))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }

    //    public string outputString()
    //    {
    //        string str;
    //        str = operation.op + "(" + firstoperand.outputString() + ", " + secondoperand.outputString() + ")";
    //        return str;
    //    }

    //    public string outputJSON()
    //    {
    //        JSONBinary jsbin = new JSONBinary();
    //        jsbin.relationaloperation = operation.op;
    //        jsbin.firstoperand = firstoperand.outputJSON();
    //        jsbin.secondoperand = secondoperand.outputJSON();

    //        return JsonConvert.SerializeObject(jsbin);
    //    }
    //}

    //class JSONBinary
    //{
    //    public string relationaloperation { get; set; }
    //    public string firstoperand { get; set; }
    //    public string secondoperand { get; set; }
    //}

    //class UnaryExpression : IExpression
    //{
    //    public IExpression operand;
    //    public ArithmeticOperation operation;

    //    public string outputString()
    //    {
    //        string str;
    //        str = operation.op + "(" + operand.outputString() + ")";
    //        return str;
    //    }

    //    public bool validateOperation()
    //    {
    //        string line;
    //        StreamReader file = new StreamReader("operations");
    //        while ((line = file.ReadLine()) != null)
    //        {
    //            if (line.Equals(operation.op))
    //            {
    //                return true;
    //            }
    //        }
    //        return false;
    //    }
    //    public string outputJSON()
    //    {
    //        JSONUnary jsun = new JSONUnary();
    //        jsun.relationaloperation = operation.op;
    //        jsun.operand = operand.outputJSON();

    //        return JsonConvert.SerializeObject(jsun);
    //    }
    //}

    //class Number : IExpression
    //{
    //    double num;

    //    public string outputString()
    //    {
    //        return num.ToString();
    //    }

    //    public string outputJSON()
    //    {
    //        return num.ToString();
    //    }
    //}

    //class Variable : IExpression
    //{
    //    string var;

    //    public string outputString()
    //    {
    //        return var;
    //    }

    //    public string outputJSON()
    //    {
    //        return var;
    //    }
    //}

    //class JSONUnary
    //{
    //    public string relationaloperation { get; set; }
    //    public string operand { get; set; }
    //}

    //class Condition
    //{
    //    public bool truecond;
    //    public IExpression firstoperand, secondoperand;
    //    public RelationalOperation operation;

    //    Condition()
    //    {
    //        truecond = true;
    //    }

    //    public string outputString()
    //    {
    //        string str = "";
    //        if (!truecond)
    //        {
    //            str = operation.op + "(" + firstoperand.outputString() + ", " + secondoperand.outputString() + ")";
    //        }
    //        return str;
    //    }

    //    public string outputJSON()
    //    {
    //        JSONCondition jscond = new JSONCondition();
    //        jscond.relationaloperation = operation.op;
    //        jscond.firstoperand = firstoperand.outputJSON();
    //        jscond.secondoperand = secondoperand.outputJSON();

    //        return JsonConvert.SerializeObject(jscond);
    //    }
    //}

    //class JSONCondition
    //{
    //    public string relationaloperation { get; set; }
    //    public string firstoperand { get; set; }
    //    public string secondoperand { get; set; }
    //}

    //class QTerm
    //{
    //    public Condition condition;
    //    public IExpression expression;

    //    public string outputString()
    //    {
    //        string str;
    //        if (condition.truecond)
    //        {
    //            str = expression.outputString();
    //        }
    //        else
    //        {
    //            str = "(" + condition.outputString() + ", " + expression.outputString() + ")";
    //        }
    //        return str;
    //    }

    //    public string outputJSON()
    //    {
    //        JSONQTerm jsqt = new JSONQTerm();

    //        jsqt.condition = condition.outputJSON();
    //        jsqt.value = expression.outputJSON();

    //        return JsonConvert.SerializeObject(jsqt);
    //    }
    //}

    //class JSONQTerm
    //{
    //    public string condition { get; set; }
    //    public string value { get; set; }
    //}

    //class QDeterminant
    //{
    //    public List<QTerm> listofQTerms;

    //    public string outputString()
    //    {
    //        string str = "";
    //        foreach (QTerm qt in listofQTerms)
    //        {
    //            str += qt.outputString() + "\n";
    //        }
    //        return str;
    //    }

    //    public string outputJSON()
    //    {
    //        JSONQDeterminant jsqd = new JSONQDeterminant();
    //        foreach (QTerm qt in listofQTerms)
    //        {
    //            jsqd.qterms.Add(qt);
    //        }

    //        string str = JsonConvert.SerializeObject(jsqd);
    //        return str;
    //    }
    //}

    //class JSONQDeterminant
    //{
    //    public List<QTerm> qterms { get; set; }
    //}

    //class FlowChartHandler
    //{
    //    string flowchartcontent;
    //    public bool validateFlowChart(string path)
    //    {
    //        bool res = true;
    //        using (StreamReader streamReader = new StreamReader(path, Encoding.UTF8))
    //        {
    //            flowchartcontent = streamReader.ReadToEnd();
    //        }

    //        JSONFlowCHart jsfc = JsonConvert.DeserializeObject(flowchartcontent);

    //        foreach (string type in jsfc.vertices)
    //        {
    //            if (!((type == "0") || (type == "1")))
    //            {
    //                res = false;
    //            }
    //        }
    //        int countstart = 0, countend = 0;
    //        foreach (string fromid in jsfc.edges)
    //        {
    //            if (fromid == "0")
    //            {
    //                countstart++;
    //            }
    //            if (fromid == "1")
    //            {
    //                countend++;
    //            }
    //        }
    //        if (!((countstart == 1) && (countend == 1)))
    //        {
    //            res = false;
    //        }

    //        return res;
    //    }

    //    public void DetermineInputData()
    //    {
    //        JSONFlowCHart jsfc = JsonConvert.DeserializeObject(flowchartcontent);

    //        foreach (string type in jsfc.vertices)
    //        {
    //            if (((type == "4")))
    //            {
    //                addInputVariable(jsfc.vertices.content.toString());
    //            }
    //        }
    //    }
    //    public void DetermineOutputData()
    //    {
    //        JSONFlowCHart jsfc = JsonConvert.DeserializeObject(flowchartcontent);

    //        foreach (string type in jsfc.vertices)
    //        {
    //            if (((type == "4")))
    //            {
    //                addOutputVariable(jsfc.vertices.content.toString());
    //            }
    //        }
    //    }
    //}
}

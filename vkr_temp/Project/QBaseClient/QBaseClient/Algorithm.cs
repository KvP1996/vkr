using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace QBaseClient
{
    [Serializable]
    class IDLessAlgorithm
    {
        protected string name;
        protected string description;

        public string Name { get { return name; } }
        public string Description { get { return description; } }

        public IDLessAlgorithm() { }
        public IDLessAlgorithm(string name, string description)
        {
            this.name = name;
            this.description = description;
        }
        public IDLessAlgorithm(string json)
        {
            FromJSON(json);
        }

        public virtual string ToJSON()
        {
            var ser = new JavaScriptSerializer();
            return ser.Serialize(this);
        }
        public virtual void FromJSON(string json)
        {
            var ser = new JavaScriptSerializer();
            var obj = ser.DeserializeObject(json) as Dictionary<string, object>;
            if (obj.ContainsKey("name"))
                name = obj["name"].ToString();
            else
                name = obj["Name"].ToString();
            if (obj.ContainsKey("description"))
                description = obj["description"].ToString();
            else
                description = obj["Description"].ToString();
        }
        public static List<IDLessAlgorithm> ListFromJSON(string json)
        {
            var ser = new JavaScriptSerializer();
            var obj = ser.DeserializeObject(json) as object[];
            var res = new List<IDLessAlgorithm>();
            for (int i = 0; i < obj.Length; i++)
                res.Add(new IDLessAlgorithm(ser.Serialize(obj[i])));
            return res;
        }
    }

    [Serializable]
    class Algorithm : IDLessAlgorithm
    {
        int id;

        public int ID { get { return id; } }

        public Algorithm() : base() { }
        public Algorithm(int id, string name, string description) : base(name, description)
        {
            this.id = id;
        }
        public Algorithm(string json)
        {
            FromJSON(json);
        }

        public override string ToJSON()
        {
            var ser = new JavaScriptSerializer();
            return ser.Serialize(this);
        }

        public override void FromJSON(string json)
        {
            string inp = json.ToLower();
            var ser = new JavaScriptSerializer();
            var obj = ser.DeserializeObject(inp) as Dictionary<string, object>;
            if (obj.ContainsKey("id"))
                id = int.Parse(obj["id"].ToString());
            else
                id = int.Parse(obj["ID"].ToString());
            base.FromJSON(json);
        }

        new public static List<Algorithm> ListFromJSON(string json)
        {
            var ser = new JavaScriptSerializer();
            var obj = ser.DeserializeObject(json) as object[];
            var res = new List<Algorithm>();
            for (int i = 0; i < obj.Length; i++)
                res.Add(new Algorithm(ser.Serialize(obj[i])));
            return res;
        }
    }

    class QDeterminant
    {
        public object Determinant { private set; get; }
        public object Dimensions { private set; get; }

        public QDeterminant() { }

        public QDeterminant(object determinant, object dimensions)
        {
            Determinant = determinant;
            Dimensions = dimensions;
        }
    }
}

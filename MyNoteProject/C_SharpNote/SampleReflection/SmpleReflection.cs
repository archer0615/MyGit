using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.SampleReflection
{
    public class SmpleReflection
    {
        public class GetInputAttribute : Attribute
        {
            public string Content { get; set; }
        }
        public enum Status
        {
            [GetInput(Content = "AAA")]
            A = 0,
            [GetInput(Content = "BBB")]
            B = -1,
            [GetInput(Content = "CCC")]
            C = 2
        }
        public static string Print2(Status status)
        {
            var field = typeof(Status).GetField(status.ToString());
            var attr = Attribute.GetCustomAttribute(field, typeof(GetInputAttribute)) as GetInputAttribute;
            string str = attr.Content;

            return str;
        }
    }
}

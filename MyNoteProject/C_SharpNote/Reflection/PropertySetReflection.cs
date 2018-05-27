using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace C_SharpNote.Reflection
{
    public class PropertySetReflection
    {
        public void PropertySetReflectionMethod()
        {
            var model = new Model();
            var value = string.Empty;

            var propertyName = "指定屬性";
            Type type = model.GetType();
            PropertyInfo propertyInfo = type.GetProperty(propertyName);
            propertyInfo.SetValue(model, value);

            model.GetType().GetProperty(propertyName).SetValue(model, value);
        }
    }
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

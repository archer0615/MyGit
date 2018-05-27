using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace C_SharpNote.Helper
{
    public class XmlHelper
    {
        /// <summary>
        /// String To XML(反序列化)
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="xmlString"></param>
        /// <returns></returns>
        public static TSource TryPareseXml<TSource>(string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TSource));
            TSource result;

            //反序列化
            using (TextReader reader = new StringReader(xmlString))
            {
                try
                {
                    result = (TSource)serializer.Deserialize(reader);
                }
                catch (Exception)
                {
                    return default(TSource); ;
                }
                return result;
            }
        }
    }
}

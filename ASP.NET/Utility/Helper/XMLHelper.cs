using System.IO;
using System.Xml.Serialization;

namespace Utility.Helper
{
    public static class XMLHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="File"></param>
        /// <returns></returns>
        public static T ReadXmlFile<T>(string File) where T : class
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (StreamReader reader = new StreamReader(File))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// 儲存XML 檔案
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">資料</param>
        /// <param name="Path">路徑</param>
        public static void Serialize<T>(T value, string Path)
        {
           
            var xmlserializer = new XmlSerializer(typeof(T));
            using (var writer = new FileStream(Path, FileMode.Create))
            {
                xmlserializer.Serialize(writer, value);
            }
        }
    }
}

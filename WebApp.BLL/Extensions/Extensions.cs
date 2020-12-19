using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace WebApp.BLL.Extensions
{
    public static class Extensions
    {
        #region XML Serializer

        public static string Serialize(this object value, Type type)
        {
            var serializer = new XmlSerializer(type);
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = false };

            using (var ms = new MemoryStream())
            using (var writer = XmlWriter.Create(ms, settings))
            {
                serializer.Serialize(writer, value, emptyNamepsaces);
                return Encoding.UTF8.GetString(ms.ToArray()).BOMCleanUTF8();
            }
        }

        public static T Deserialize<T>(this string xml)
        {
            if (xml == null)
                return default(T);
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                var type = typeof(T);
                var serializer = new XmlSerializer(type);
                return (T)serializer.Deserialize(ms);
            }
        }

        public static string Serialize<T>(this T item)
        {
            string ret = string.Empty;
            using (var ms = new MemoryStream())
            {

                if (item == null)
                    return "";
                if (item != null && (item as string) != null)
                    return item as string;

                XmlSerializer serializer = new XmlSerializer(item.GetType());
                var ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                serializer.Serialize(ms, item, ns);
                ms.Position = 0;
                using (var streamReader = new StreamReader(ms))
                {
                    ret = streamReader.ReadToEnd().BOMCleanUTF8();
                    streamReader.Close();
                }
                ms.Close();
                return ret;
            }
        }

        public static object Deserialize(this string xml, Type type)
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                var serializer = new XmlSerializer(type);
                return serializer.Deserialize(ms);
            }
        }

        public static string RemoveXmlDeclaration(this string xml)
        {
            if (string.IsNullOrEmpty(xml)) return xml;

            var matchRegex = "<\\?xml.*?\\?>";
            return Regex.Replace(xml, matchRegex, "", RegexOptions.IgnoreCase);
        }

        #endregion

        private static readonly string ByteOrderMarkUTF8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
        public static string BOMCleanUTF8(this string data)
        {
            if (data.StartsWith(ByteOrderMarkUTF8, StringComparison.Ordinal))
            {
                data = data.Remove(0, ByteOrderMarkUTF8.Length);
            }

            return data;
        }

        public static byte[] GZipCompress(this byte[] data)
        {
            using (var compressedStream = new MemoryStream())
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                zipStream.Write(data, 0, data.Length);
                zipStream.Close();
                return compressedStream.ToArray();
            }
        }

        public static byte[] GZipDecompress(this byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                zipStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }
    }
}

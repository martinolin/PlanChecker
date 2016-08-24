using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.IO;

namespace PlanChecker
{
    /// <summary>
    /// Class that handles serialization and deserialization of objects
    /// </summary>
    public static class Serialization
    {
        /// <summary>
        /// Deserializes an object from a file
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="filePath">Path to file</param>
        /// <returns>The deserialized object</returns>
        public static T BinaryFileDeserialize<T>(string filePath)
        {
            FileStream fileStream = null;
            Object deserializedObject;

            try
            {
                if (File.Exists(filePath) == false)
                    throw new FileNotFoundException("The file was not found:\n" + filePath, filePath);

                fileStream = new FileStream(filePath, FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                deserializedObject = binaryFormatter.Deserialize(fileStream);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }

            return (T)deserializedObject;
        }

        /// <summary>
        /// Serialize an object to a file
        /// </summary>
        /// <param name="filePath">Path to file</param>
        /// <param name="objectToSerialize">The object to serialize</param>
        public static void BinaryFileSerialize(string filePath, Object objectToSerialize)
        {
            FileStream fileStream = null;

            try
            {
                fileStream = new FileStream(filePath, FileMode.Create);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(fileStream, objectToSerialize);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
            }
        }

        /// <summary>
        /// Deserialize an object from a XML file
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="filePath">Path to file</param>
        /// <returns>The deserialized object</returns>
        public static T XMLFileDeserialize<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextReader textReader = new StreamReader(filePath);

            try
            {
                return (T)serializer.Deserialize(textReader);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (textReader != null)
                    textReader.Close();
            }
        }

        /// <summary>
        /// Serialize an object to a XML file
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="filePath">Path to file</param>
        /// <param name="objectToSerialize">The object to serialize</param>
        public static void XMLFileSerialize<T>(string filePath, T objectToSerialize)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            TextWriter textWriter = new StreamWriter(filePath);

            try
            {
                serializer.Serialize(textWriter, objectToSerialize);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (textWriter != null)
                    textWriter.Close();
            }
        }
    }
}

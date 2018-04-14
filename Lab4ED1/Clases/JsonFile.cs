using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using Newtonsoft.Json;
namespace Lab4ED1.Clases
{
    public class JsonFile
    {
        public Dictionary<string,StickerLists> ListRead(Stream path)
        {
            var collection = new Dictionary<string, StickerLists>();
            try
            {

                using (var reader1 = new StreamReader(path))
                {
                    var lecture = reader1.ReadToEnd();



                    collection = JsonConvert.DeserializeObject<Dictionary<string, StickerLists>>(lecture);
                    reader1.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;

            }
            return collection;

        }
        public Dictionary<string,bool> ListState(Stream path)
        {
            var collection = new Dictionary<string, bool>();
            try
            {

                using (var reader1 = new StreamReader(path))
                {
                    var lecture = reader1.ReadToEnd();



                    collection = JsonConvert.DeserializeObject<Dictionary<string, bool>>(lecture);
                    reader1.Close();
                }
            }

            catch (Exception ex)
            {
                throw ex;

            }
            return collection;
        }
    }
}
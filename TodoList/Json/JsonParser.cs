using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList
{
    public class JsonParser
    {
        #region Private Properties

        private String filePath = "List.json";

        private String txt;

        private static JsonParser instance;

        #endregion

        #region Public Properties

        private JArray jsonListArray;
        public JArray JsonListArray
        {
            get
            {
                if(jsonListArray == null)
                {
                    jsonListArray = new JArray();
                }
                return jsonListArray;
            }
            set
            {
                jsonListArray = value;
            }
        }

        #endregion


        #region Constructor
        public JsonParser()
        {
            instance = null;
            LoadFile();
        }
        #endregion

        #region Public Method
        public static JsonParser GetInstance()
        {
            if(instance == null)
            {
                instance = new JsonParser();
            }
            return instance;
        }

        /// <summary>
        /// Json 파일을 불러와준다
        /// </summary>
        public bool LoadFile()
        {
            StreamReader sr = new StreamReader(filePath);
            if (sr == null)
                return false;
            else
            {
                txt = sr.ReadToEnd();
                JsonListArray = JArray.Parse(txt);
            }
            sr.Close();
            return true;
        }

        /// <summary>
        /// Json 파일로 저장한다.
        /// </summary>
        /// <returns></returns>
        public bool WriteFile()
        {
            StreamWriter sw = new StreamWriter(filePath, false);
            if (sw == null)
                return false;
            else
            {
                txt = JsonListArray.ToString();
                sw.Write(txt);
            }
            sw.Close();
            return true;
        }
        

        /// <summary>
        /// 불러와진 Json 파일을 이용하여 List 갱신
        /// </summary>
        public void RefreshArray()
        {
            foreach (JObject fElem in JsonListArray)
            {
                var fDate = fElem["Date"] ?? "<NoDate>";
                var fDesc = fElem["Desc"] ?? "<NoDesc>";

            }
        }

        /// <summary>
        /// Json Array에 일정 Date 추가
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="desc"></param>
        public void AddJson(DateTime dt, String desc)
        {
            var jobject = new JObject();
            String date;
            date = String.Format("{0:yyyy-MM-dd}", dt);
            jobject.Add("Date", date);
            jobject.Add("Desc", desc);
            JsonListArray.Add(jobject);
        }

        #endregion

    }
}

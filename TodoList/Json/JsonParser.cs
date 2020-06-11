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


        #endregion

        #region Public Properties


        public JArray jsonListArray;

        #endregion


        #region Constructor
        public JsonParser()
        {
            jsonListArray = new JArray();
            InitParse();
        }
        #endregion

        #region Public Method

        /// <summary>
        /// Json 파일을 불러와준다
        /// </summary>
        public void InitParse()
        {
            StreamReader sr = new StreamReader(filePath);
            txt = sr.ReadToEnd();
            jsonListArray = JArray.Parse(txt);
        }

        /// <summary>
        /// 불러와진 Json 파일을 이용하여 List 갱신
        /// </summary>
        public void RefreshArray()
        {
            foreach (JArray fElem in jsonListArray)
            {
                var fDate = fElem["Date"] ?? "<NoDate>";
                var fDesc = fElem["Desc"] ?? "<NoDesc>";

            }
        }

        #endregion

    }
}

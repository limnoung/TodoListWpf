using System;
using System.Collections;
using System.Collections.Generic;
using TodoList.Mvvm;

namespace TodoList
{
    public class TodoListDataModel : BindableBase
    {
        #region Private Properties

        /// <summary>
        /// 일정에 해당하는 날짜
        /// </summary>
        private DateTime date { get; set; }

        /// <summary>
        /// 일정 내용
        /// </summary>
        private ArrayList doText;


        #endregion



        #region Constructor

        TodoListDataModel()
        {
            doText = new ArrayList();
        }

        #endregion


        #region Public Method
        /// <summary>
        /// 일정 목록에 일정을 추가 합니다
        /// </summary>
        /// <param name="s"></param>
        public void AddList(String s)
        {
            doText.Add(s);
        }

        /// <summary>
        /// 일정 목록에서 index 번호에 있는 항목의 내용을 불러옴
        /// </summary>
        /// <param name="index">List 항목(0번 부터 시작)</param>
        /// <returns></returns>
        public String GetListDesc(int index)
        {
            return doText[index].ToString();
        }

        public void MoveList(int index)
        {
            
        }
        #endregion
    }
}

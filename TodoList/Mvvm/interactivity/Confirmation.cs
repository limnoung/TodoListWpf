using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoList.Mvvm
{
    public class Confirmation : Notification, IConfirmation
    {
        /// <summary>
        /// Gets or sets a value indicating that the confirmation is confirmed.
        /// </summary>
        public bool Confirmed { get; set; }
    }
}

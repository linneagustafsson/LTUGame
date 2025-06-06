using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LtuGame.LimitedList
{
    public class MessageLog<T> : LimitedList<T>

    {
        public MessageLog(int capacity) : base(capacity)//
        {
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    internal class Week
    {
        static readonly string[] NAMES = { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс"};
        byte days;
        public Week(byte days)
        {
            this.days = days;
        }
        public override string ToString()
        {
            string days = "";
            for (int i = 0; i < 7; i++)
            {
                byte day = (byte)(1 << i);
                if ((this.days & day) != 0) days += $"{NAMES[i]},";
            }
            return base.ToString();
            /*
            -----------------------------------------------------
            ~ NOT - побитовое отрицание  (Инверсия - это операция, при которой едницы заменяется)
            | OR - побитовое сложение
            -----------------------------------------------------
             */
        }
    }
}

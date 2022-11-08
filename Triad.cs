using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace project5
{
    internal class Triad
    {
        public uint Number1 { get; set; }
        public uint Number2 { get; set; }
        public uint Number3 { get; set; }

        public Triad(uint number1, uint number2, uint number3)
        {
            Number1 = number1;
            Number2 = number2;
            Number3 = number3;
        }

        public uint Amount()
        {
            return Number1 + Number2 + Number3;
        }

        public void SetParams(uint numberA, uint numberB, uint numberC)
        {
            Number1 = numberA;
            Number2 = numberB;
            Number3 = numberC;
        }

        public void SetParams(uint number1)
        {
            Number1 = number1;
        }

        public void SetParams(uint number1, uint number2)
        {
            Number1 = number1;
            Number2 = number2;
        }

        public void SetParams(int number1, int number2, int number3)
        {
            if (!(number1 > 0 && number2 > 0 && number3 > 0))
            {
                throw new ArgumentOutOfRangeException(null, "Данные должны быть больше 0");
            }
            Number1 = (uint)number1;
            Number2 = (uint)number2;
            Number3 = (uint)number3;
        }

        public void ClearTriad()
        {
            Number1 = 0;
            Number2 = 0;
            Number3 = 0;
        }
    }
}

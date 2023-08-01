using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class NumberCallback
    {


        public NumberCallback(int increment, int maxValue, EOperator _eOperator, DelegateOperatorCallback delegateOperatorCallback)
        {
            Increment = increment;
            MaxValue = maxValue;
            eOperator = _eOperator;
            DelegateOperatorCallback = delegateOperatorCallback;
        }

        public int Increment { get; set; }
        public int MaxValue { get; set; }
        public EOperator eOperator { get; set; }
        private DelegateOperatorCallback DelegateOperatorCallback { get; set; }

        public void ThreadProc()
        {
            Console.WriteLine(eOperator);
            if (DelegateOperatorCallback != null)
            {
                DelegateOperatorCallback(eOperator, Increment, MaxValue);
            }
        }

    }
}

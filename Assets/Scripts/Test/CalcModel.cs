using System;
using Abstract.Model;
using UnityEngine;

namespace Test
{
    public class CalcModel
    {
        public double? Calc(double val1, double val2, char sign)
        {
            switch (sign)
            {
                case '+': return val1 + val2;
                case '-': return val1 - val2;
            }

            return null;
        }
    }
}
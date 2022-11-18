using FuncProgramming.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuncProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            var derHelper = new DerivativeHelper();
            derHelper.BuildDerivative();

            var sendHelper = new SendFunctionHelper();
            sendHelper.SendFunction();

            var linqHelper = new LinqRealizationHelper();
            var whereRes = linqHelper.TestWhereSelectToList();
            var firstOrDef = linqHelper.TestFirstOrDefault();
            var takeRes = linqHelper.TestTake();
            var selManyRes = linqHelper.TestSelectMany();

            var usingLinqHelper = new UsingLinqHelper();
            var test1 = usingLinqHelper.TestLookup();

            var textHelper = new TextHelper();
            var index = textHelper.GetIndex();
        }
    }
}

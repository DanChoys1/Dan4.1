using System;
using System.Collections.Generic;
using System.Text;

namespace Dan4._1
{
    class Tester
    {
        private readonly int _intervalValues = 100;
        private readonly int _sizeArray = 100;

        public string Start(int countTest)
        {
            Dictionary<int, double> arr = new Dictionary<int, double>();
            Dictionary<int, double> evenArr = new Dictionary<int, double>();
            Dictionary<int, double> oddArr = new Dictionary<int, double>();

            Random random = new Random();

            while(countTest-- > 0)
            {
                for (int i = 0; i < _sizeArray; i++)
                {
                    arr.Add(i, random.Next(-_intervalValues, _intervalValues));

                    if (i % 2 == 0)
                    {
                        evenArr.Add(i, arr[i]);
                    }
                    else
                    {
                        oddArr.Add(i, arr[i]);
                    }
                }

                ParitySplitArray paritySplitArray = new ParitySplitArray(arr);

                Dictionary<int, double> evenSplitArray = paritySplitArray.GetEvenArray();
                Dictionary<int, double> oddSplitArray = paritySplitArray.GetOddArray();

                foreach (int i in evenArr.Keys)
                {
                    if (evenArr[i] != evenSplitArray[i])
                    {
                        return "Тестирование провалено:\n" +
                            "Массив разбивается не правильно.";
                    }
                }

                foreach (int i in oddArr.Keys)
                {
                    if (oddArr[i] != oddSplitArray[i])
                    {
                        return "Тестирование провалено:\n" +
                            "Массив разбивается не правильно.";
                    }
                }

                arr.Clear();
                evenArr.Clear();
                oddArr.Clear();
            }

            return "Тестирование прошло успешно.";
        }
    }
}

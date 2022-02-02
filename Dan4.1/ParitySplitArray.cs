using System;
using System.Collections.Generic;
using System.Text;

namespace Dan4._1
{
    class ParitySplitArray
    {
        private Dictionary<int, double> _mainArray;

        private Dictionary<int, double> _evenArray;
        private double _evenSum = 0;

        private Dictionary<int, double> _oddArray;
        private double _oddSum = 0;

        public ParitySplitArray(Dictionary<int, double> arr)
        {
            _mainArray = new Dictionary<int, double>(arr);
            _evenArray = new Dictionary<int, double>();
            _oddArray = new Dictionary<int, double>();

            foreach (int index in _mainArray.Keys)
            {
                if (index % 2 == 0)
                {
                    _evenArray.Add(index, _mainArray[index]);
                    _evenSum += _mainArray[index];
                }

                if (index % 2 != 0)
                {
                    _oddArray.Add(index, _mainArray[index]);
                    _oddSum += _mainArray[index];
                }
            }
        }

        public Dictionary<int, double> GetEvenArray()
        {
            return new Dictionary<int, double>(_evenArray);
        }

        public Dictionary<int, double> GetOddArray()
        {
            return new Dictionary<int, double>(_oddArray);
        }

        public double GetSumEvenArray()
        {
            return _evenSum;
        }

        public double GetSumOddArray()
        {
            return _oddSum;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Dan4._1 {
    class ParitySplitArray {

        Dictionary<int, double> mainArray;

        Dictionary<int, double> evenArray;
        double evenSum = 0;

        Dictionary<int, double> oddArray;
        double oddSum = 0;

        public ParitySplitArray(Dictionary<int, double> arr) {
            mainArray = new Dictionary<int, double>(arr);
            evenArray = new Dictionary<int, double>();
            oddArray = new Dictionary<int, double>();

            foreach (int index in mainArray.Keys) {
                if(index % 2 == 0) {
                    evenArray.Add(index, mainArray[index]);
                    evenSum += mainArray[index];
                }

                if (index % 2 != 0) {
                    oddArray.Add(index, mainArray[index]);
                    oddSum += mainArray[index];
                }
            }
        }

        public Dictionary<int, double> GetEvenArray() {
            return new Dictionary<int, double>(evenArray);
        }

        public Dictionary<int, double> GetOddArray() {
            return new Dictionary<int, double>(oddArray);
        }

        public double GetSumEvenArray() {
            return evenSum;
        }

        public double GetSumOddArray() {
            return oddSum;
        }
    }
}

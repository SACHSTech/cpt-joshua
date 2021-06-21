using System.Collections.Generic;

namespace CPT
{
    class Sort
    {
        private int partitionDoubles(List<GPU> data, int f, int datasetSize, string valueName)
        {
            double pivot = data[datasetSize].getValue(valueName);

            int P_index = f;
            int i;
            var t = data[0];

            for (i = f; i < datasetSize; i++)
            {
                if (data[i].getValue(valueName) <= pivot)
                {
                    t = data[i];
                    data[i] = data[P_index];
                    data[P_index] = t;
                    P_index++;
                }
            }

            t = data[datasetSize];
            data[datasetSize] = data[P_index];
            data[P_index] = t;

            return P_index;
        }

        /**
         * 
         * @param data is the array
         * @param f is the lowest of the array
         * @param datasetSize is the size of the array
         * @param valueName is the name of the 
         */
        public void SortDoubles(List<GPU> data, int f, int datasetSize, string valueName)
        {
            if (f < datasetSize)
            {
                int P_index = partitionDoubles(data, f, datasetSize, valueName);
                SortDoubles(data, f, P_index - 1, valueName);
                SortDoubles(data, P_index + 1, datasetSize, valueName);
            }
        }

        private int partitionStrings(List<GPU> data, int f, int datasetSize)
        {
            string pivot = data[datasetSize].getName();

            int P_index = f;
            int i;
            var t = data[0];

            for (i = f; i < datasetSize; i++)
            {
                if (data[i].getName() == pivot || string.Compare(data[i].getName(), pivot) == -1)
                {
                    t = data[i];
                    data[i] = data[P_index];
                    data[P_index] = t;
                    P_index++;
                }
            }

            t = data[datasetSize];
            data[datasetSize] = data[P_index];
            data[P_index] = t;

            return P_index;
        }
        public void SortStrings(List<GPU> data, int f, int datasetSize)
        {
            if (f < datasetSize)
            {
                int P_index = partitionStrings(data, f, datasetSize);
                SortStrings(data, f, P_index - 1);
                SortStrings(data, P_index + 1, datasetSize);
            }
        }
    }
}

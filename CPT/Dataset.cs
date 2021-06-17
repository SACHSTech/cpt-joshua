using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT
{
    public class Dataset
    {
        private List<GPU> gpus;
        public Dataset()
        {
            gpus = new List<GPU>();
            string[] lines = File.ReadAllLines(@"..\..\csv\gpu.csv");
            for(int i=1;i<lines.Length;i++)
            {
                var split = ((lines[i].Replace("%", "")).Replace("-,", "0,")).Split(',');
                gpus.Add(new GPU(Int32.Parse(split[0]), split[1], Convert.ToDouble(split[2]), Convert.ToDouble(split[3]), Convert.ToDouble(split[4]), Convert.ToDouble(split[5]), Convert.ToDouble(split[6]), split[7]));
            }
        }
        public void addGPU(GPU gpu)
        {
            gpus.Add(gpu);
        }
        public void removeGPU(GPU gpu)
        {
            gpus.Remove(gpu);
        }
        public List<GPU> getList()
        {
            return gpus;
        }
        public GPU getGPU(int index)
        {
            return gpus[index];
        }
        public int getGPUSize()
        {
            return gpus.Count;
        }
        // add sorter
        public void sortGPU()
        {
            Quicksort(gpus, 0, getGPUSize()-1);
        }
        private int partition(List<GPU> data, int f, int datasetSize)
        {
            double pivot = data[datasetSize].getMarPercent();

            int P_index = f;
            int i;
            GPU t;

            for (i = f; i < datasetSize; i++)
            {
                if (data[i].getMarPercent() <= pivot)
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
        private void Quicksort(List<GPU> data, int f, int datasetSize)
        {
            if (f < datasetSize)
            {
                int P_index = partition(data, f, datasetSize);
                Quicksort(data, f, P_index - 1);
                Quicksort(data, P_index + 1, datasetSize);
            }
        }
    }
}

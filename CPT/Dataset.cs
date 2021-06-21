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
        public List<GPU> gpus;
        public Dataset()
        {
            gpus = new List<GPU>();
        }
        public void loadGPU()
        {
            gpus.Clear();
            string[] lines = File.ReadAllLines(@"..\..\csv\gpu.csv");
            for (int i = 1; i < lines.Length; i++)
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
    }
}

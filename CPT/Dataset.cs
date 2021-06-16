using System;
using System.Collections.Generic;
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
            gpus.Add(new GPU(1, "oof", 3, 4, 5, 6, 7, "ahhh"));
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
        //public GPU getGPU(int index)
        //{
        //    return gpus.get(index);
        //}
        public int getGPUSize()
        {
            return gpus.Count;
        }
        // add sorter
    }
}

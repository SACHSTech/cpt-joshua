using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPT
{
    /**
    * A class to hold information associated with cpu
    * unlike the gpu class which I did in the java style since this was secondary to the main main cpt I did thing one with c# conventions
    * @author Joshua Shuttleworth
    */
    public class Dataset
    {
        private List<GPU> gpus;
        private List<CPU> cpus;
        public Dataset()
        {
            gpus = new List<GPU>();
            cpus = new List<CPU>();
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
        
        public void loadCPU()
        {
            cpus.Clear();
            string[] lines = File.ReadAllLines(@"..\..\csv\cpu_cores.csv");
            for (int i = 1; i < lines.Length; i++)
            {
                var split = ((((lines[i].Replace("%", "")).Replace("-,", "0,")).Replace(" cpus", "")).Replace(" cpu", "")).Split(',');
                cpus.Add(new CPU(Convert.ToInt32(split[0]), Convert.ToDouble(split[1]), split[2], Convert.ToDouble(split[3]), Convert.ToDouble(split[4]), Convert.ToDouble(split[5]), Convert.ToDouble(split[6]), Convert.ToDouble(split[7]), split[8]));
            }
        }

        public List<GPU> getGPUList()
        { 
            return gpus;
        }
        public List<CPU> getCPUList()
        {
            return cpus;
        }

        public void removeGPU(GPU gpu)
        {
            gpus.Remove(gpu);
        }
        public void removeCPU(CPU cpu)
        {
            cpus.Remove(cpu);
        }

        public GPU getGPU(int index)
        {
            return gpus[index];
        }
        public CPU getCPU(int index)
        {
            return cpus[index];
        }

        public int getGPUSize()
        {
            return gpus.Count;
        }
        public int getCPUSize()
        {
            return cpus.Count;
        }
    }
}

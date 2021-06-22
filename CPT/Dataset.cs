using System;
using System.Collections.Generic;
using System.IO;

namespace CPT
{
    /**
    * A class to manage the datasets in the csv folder
    * @author Joshua Shuttleworth
    */
    public class Dataset
    {
        // var decloration
        private List<GPU> gpus;
        private List<CPU> cpus;

        /**
         * Initialize the GPU and CPU lists
         */
        public Dataset()
        {
            gpus = new List<GPU>();
            cpus = new List<CPU>();
        }

        /**
         * Reads the csv file to populate the list of GPUs
         */
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

        /**
         * Reads the csv file to populate the list of CPUs
         */
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

        /**
         * A getter method for gpus
         * @return gpus
         */
        public List<GPU> getGPUList()
        { 
            return gpus;
        }

        /**
         * A getter method for cpus
         * @return cpus
         */
        public List<CPU> getCPUList()
        {
            return cpus;
        }

        /**
         * Remove a GPU from the list
         * @param gpu
         */
        public void removeGPU(GPU gpu)
        {
            gpus.Remove(gpu);
        }

        /**
         * Remove a CPU from the list
         * @param cpu
         */
        public void removeCPU(CPU cpu)
        {
            cpus.Remove(cpu);
        }

        /**
         * A getter method for gpus
         * @param index
         * @return GPU from gpus at index
         */
        public GPU getGPU(int index)
        {
            return gpus[index];
        }

        /**
         * A getter method for cpus
         * @param index
         * @return CPU from cpus at index
         */
        public CPU getCPU(int index)
        {
            return cpus[index];
        }

        /**
         * A getter method for gpus
         * @return size of gpus list
         */
        public int getGPUSize()
        {
            return gpus.Count;
        }

        /**
         * A getter method for cpus
         * @return size of cpus list
         */
        public int getCPUSize()
        {
            return cpus.Count;
        }
    }
}

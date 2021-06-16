package classes;

import java.io.BufferedReader;
import java.io.FileReader;
import java.util.ArrayList;


public class Dataset {
    private ArrayList<GPU> gpus;

    public Dataset() {
        gpus = new ArrayList<GPU>();
        try{
            BufferedReader br = new BufferedReader(new FileReader("csv/gpu.csv"));
            br.readLine();
            String data;
            while((data=br.readLine())!=null){
                //var split = data.split(",");
                var split = ((data.replaceAll("%", "")).replaceAll("-,", "0,")).split(",");
                gpus.add(new GPU(Integer.parseInt(split[0]), split[1], Double.parseDouble(split[2]), Double.parseDouble(split[3]), Double.parseDouble(split[4]), Double.parseDouble(split[5]), Double.parseDouble(split[6]), split[7]));
            }
            br.close();
        } catch (Exception e) {

        }
    }
    public void addGPU(GPU gpu) {
        gpus.add(gpu);
    }
    public ArrayList<GPU> getList() {
        return gpus;
    }
    public GPU getGPU(int index) {
        return gpus.get(index);
    }
    public int getGPUSize() {
        return gpus.size();
    }
    // add sorter
}

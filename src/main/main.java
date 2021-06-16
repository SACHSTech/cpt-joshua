package main;

import java.io.*;

import classes.Dataset;
import classes.GPU2;

public class main {
    public static void main(String[] args) throws IOException {
        BufferedReader br = new BufferedReader(new FileReader("csv/gpu.csv"));
        Dataset ds = new Dataset();
        System.out.println(br.readLine());

        String data;
        while((data=br.readLine())!=null){
            var split = ((data.replaceAll("%", "")).replaceAll("-,", "0,")).split(",");
            ds.addGPU(new GPU2(Integer.parseInt(split[0]), split[1], Double.parseDouble(split[2]), Double.parseDouble(split[3]), Double.parseDouble(split[4]), Double.parseDouble(split[5]), Double.parseDouble(split[6]), split[7]));
        }
        br.close();
        
        for(int i=0;i<ds.getGPUSize();i++)
            System.out.println(ds.getGPU(i));
    }
}

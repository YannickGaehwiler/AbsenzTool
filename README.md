package com.company;

import java.io.*;

public class Main {

    public static void main(String[] args) throws Exception{
        try {
            File masterFile = new File("master.txt");
            File clientFile = new File("client.txt");

            //PrintWriter missedLinesWriter = new PrintWriter("missing.txt", "UTF-8");

            BufferedReader masterReader;
            BufferedReader clientReader = new BufferedReader(new FileReader(clientFile));

            String currentMasterReaderLine;
            String currentClientReaderLine;

            try {
                while ((currentClientReaderLine = clientReader.readLine()) != null) {
                    masterReader = new BufferedReader(new FileReader(masterFile));
                    while ((currentMasterReaderLine = masterReader.readLine()) != null) {
                        if (currentClientReaderLine.equals(currentMasterReaderLine)) {
                            System.out.println("Exist:\t{" + currentClientReaderLine + "}");
                            break;
                        }
                    }
                }
            } catch (IOException e) {
                System.out.println("File is empty");
            }
        } catch(FileNotFoundException e) {
            System.out.println("File not Found.");
        }
    }
}

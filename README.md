package com.company;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class Main {

    public static void main(String[] args) throws Exception {
        //arraylists inwelche die Daten der files gespeichert werden
        List<String> clientFileData = new ArrayList<>();
        List<String> masterFileData = new ArrayList<>();

        try {
            //master und client file initialisieren
            File clientFile = new File("client.txt");
            File masterFile = new File("master.txt");

            //filewriter um die unmatched strings in missing.txt zu schreiben
            PrintWriter missingLinesWriter = new PrintWriter("missing.txt", "UTF-8");

            //filereader um den inhalt der files auszulesen
            BufferedReader clientFileReader = new BufferedReader(new FileReader(clientFile));
            BufferedReader masterFileReader = new BufferedReader(new FileReader(masterFile));

            //variabeln für aktuelle zeile im file
            String currentClientFileLine;
            String currentMasterFileLine;

            try {

                //reader vom client file (liest alle daten aus client.txt und speichert sie in die arraylist clientFileData)
                while ((currentClientFileLine = clientFileReader.readLine()) != null) {
                    clientFileData.add(currentClientFileLine);
                }

                //reader vom master file (liest alle daten aus master.txt und speichert sie in die arraylist masterFileData)
                while ((currentMasterFileLine = masterFileReader.readLine()) != null) {
                    masterFileData.add(currentMasterFileLine);
                }

                //foreach welche durch die clientfile daten iterriert
                for (String currentClientLine : clientFileData) {

                    //falls masterfile aktuelle clientfile line enthält
                    if (masterFileData.contains(currentClientLine)) {
                        System.out.println("Matched:\t{" + currentClientLine + "}");
                    }

                    //sonst
                    else
                    {
                        System.out.println("Missing:\t{" + currentClientLine + "}");
                        missingLinesWriter.println(currentClientLine);
                    }
                }

                //filewriter schliessen (falls später neuer writer geöffnet wird kommt es dadurch zu keiner exception)
                missingLinesWriter.close();

            } catch (Exception e) {
                e.printStackTrace();
            }
        } catch (FileNotFoundException ex) {
            System.out.println(ex);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
    public TextAsset textAssetData;

    [System.Serializable]
    public class Player
    {
        public float missionElapsedTime; // (mins)
        public int rx; // (km)[J2000-EARTH]
        public int ry; // (km)[J2000-EARTH]
        public int rz; // (km)[J2000-EARTH]
        public float vx; // (km/s)[J2000-EARTH]
        public float vy; // (km/s)[J2000-EARTH]
        public float vz; // (km/s)[J2000-EARTH]
        public float mass; // (kg)
        public int wpsa;
        public float wpsaRange;
        public int ds54;
        public float ds54Range;
        public int ds24;
        public float ds24Range;
        public int ds34;
        public float ds34Range;
    }

    [System.Serializable]
    public class PlayerList
    {
        public Player[] players;
    }

    public PlayerList myPlayerList = new PlayerList();

    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();
    

    }

    void ReadCSV()
    {
        string[] lines = textAssetData.text.Split(new[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        int tableSize = lines.Length - 1; // Assuming first line is headers
        myPlayerList.players = new Player[tableSize];

        for (int i = 1; i < tableSize; i++)
        {
            myPlayerList.players[i] = new Player();
            string[] values = lines[i + 1].Split(',');

            // Make sure you have enough values before parsing
            if (values.Length >= 16)
            {

                myPlayerList.players[i].missionElapsedTime = float.Parse(values[0]);
                myPlayerList.players[i].rx = (int)float.Parse(values[1]);
                myPlayerList.players[i].ry = (int)float.Parse(values[2]);

                myPlayerList.players[i].rz = (int)float.Parse(values[3]);
                myPlayerList.players[i].vx = float.Parse(values[4]);
                myPlayerList.players[i].vy = float.Parse(values[5]);
                myPlayerList.players[i].vz = float.Parse(values[6]);
                myPlayerList.players[i].mass = float.Parse(values[7]);
                myPlayerList.players[i].wpsa = int.Parse(values[8]);

                if (myPlayerList.players[i].wpsa > 0)
                {
                    myPlayerList.players[i].wpsaRange = float.Parse(values[9]);
                }
                else
                {
                    myPlayerList.players[i].wpsaRange = 0;
                }

                    
                myPlayerList.players[i].ds54 = int.Parse(values[10]);
                if(myPlayerList.players[i].ds54 > 0)
                {
                    myPlayerList.players[i].ds54Range = float.Parse(values[11]);
                }
                else
                {
                    myPlayerList.players[i].ds54Range = 0;
                }
                
                myPlayerList.players[i].ds24 = int.Parse(values[12]);

                if (myPlayerList.players[i].ds24 > 0)
                {
                    myPlayerList.players[i].ds24Range = float.Parse(values[13]);
                }
                else
                {
                    myPlayerList.players[i].ds24Range = 0;
                }
                
                myPlayerList.players[i].ds34 = int.Parse(values[14]);

                if(myPlayerList.players[i].ds34 > 0 )
                {
                    myPlayerList.players[i].ds34Range = float.Parse(values[15]);
                }
                else
                {
                    myPlayerList.players[i].ds34Range = 0;
                }
                    
            }
            else
            {
                Debug.LogError("Insufficient data in row " + (i + 1));
            }
        }
    }
   
}

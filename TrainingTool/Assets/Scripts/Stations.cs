using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stations : MonoBehaviour
{
    public int StationID { get; set; }
    public int Security { get; set; }
    public int Machine { get; set; }
    public int Electrode { get; set; }

    public Stations(int stationID, int security, int machine, int electrode)
    {
        StationID = stationID;
        Security = security;
        Machine = machine;
        Electrode = electrode;
        
        
    }
    public int MatchElectrode(int electrode)
    {
        if (Electrode == electrode)
            return StationID;
        return 0;
    }
    
}

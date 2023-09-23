using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{
    public static StationManager Instance;
    private string station;
    private int stationID;

    private void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetStation(string _station, int id)
    {
        station = _station;
        stationID = id;
    }

    public string GetStationName()
    {
        return station;
    }

    //STATIONS
    List<Stations> stations = new List<Stations>
    {
        new Stations(1,701,901,501),
        new Stations(2,701,901,502),
        new Stations(3,701,3202,503)
    };

    // Method to compare user input with predefined values
    public bool CheckStation(int id)
    {
       
       foreach(var station in stations)
        {
            var userStation = station.MatchElectrode(id);
            if (userStation == stationID)
            {
                return true;
            }
        }
       return false;
       
    }

}

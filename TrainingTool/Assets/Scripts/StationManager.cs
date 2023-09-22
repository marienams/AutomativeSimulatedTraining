using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationManager : MonoBehaviour
{
    public static StationManager Instance;
    private string station;

    private void Awake()
    {
        if (Instance != null)
            return;
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetStation(string _station)
    {
        station = _station;
    }

    public string GetStation()
    {
        return station;
    }
}

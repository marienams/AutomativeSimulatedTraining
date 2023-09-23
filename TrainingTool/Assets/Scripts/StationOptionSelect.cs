using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StationOptionSelect : MonoBehaviour
{
    //PART OF FIRST MENU 
    private Button btn;
    [SerializeField] private TextMeshProUGUI stationName;
    [SerializeField] private int stationID;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        
        btn.onClick.AddListener(SetStation);
    }

    
    
    void SetStation()
    {
        StationManager.Instance.SetStation(stationName.text, stationID);
    }
    
}

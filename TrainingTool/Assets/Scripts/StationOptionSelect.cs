using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StationOptionSelect : MonoBehaviour
{
    private Button btn;
    [SerializeField] private TextMeshProUGUI stationName;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        
        btn.onClick.AddListener(SetStation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetStation()
    {
        StationManager.Instance.SetStation(stationName.text);
    }
}

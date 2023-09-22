using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    //[SerializeField] private Text debugText;
    [SerializeField] private ParameterMenu parameter_menu;
    [SerializeField]private GameObject stationContainer;
    [SerializeField] private StationButtonManager _stationButtonPrefab;
    [SerializeField] private TextMeshProUGUI stationName;
    
    private List<Equipment> equipments;

    StationButtonManager _stationButtonManager;

    private static Parameters instance;
    public static Parameters Instance
    {
        get
        {
            if (instance == null)
            { instance = FindObjectOfType<Parameters>(); }
            return instance;
        }
        
    }
    private void Start()
    {
        stationName.text = StationManager.Instance.GetStation();
    }

    void Update()
    {
        
         
    }

    public void CreateParameter(Equipment i)
    {
        
        StationButtonManager a = Instantiate(_stationButtonPrefab, stationContainer.transform);
        a.Equipment_ID = i.equipmentID;
        a.Equipment_Name = i.Name;

    }

    public void ParameterList(Equipment equipment)
    {
        if (equipments != null)
        {
            equipments.Add(equipment);
            CreateParameter(equipment);
            return;
        }
        if(equipments == null)
        {
            equipments = new List<Equipment>();
            equipments.Add(equipment as Equipment);
            CreateParameter(equipment);
            return;
        }
        
        /*
        foreach (Equipment i in equipments)
            debugText.text = i.EquipmentSettingState;*/
    }

    public void SetParameters(string name)
    {
        foreach(var equipment in equipments)
        {
            if(equipment.Name == name)
            {
                Instantiate(parameter_menu);
            }
        }
    }
}

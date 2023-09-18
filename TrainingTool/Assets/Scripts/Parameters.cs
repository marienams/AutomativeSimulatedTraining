using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    [SerializeField]private GameObject paramter_input;
    
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

     void Update()
    {
        
         
    }

    public void CreateParameter(Equipment i)
    {
        
        StationButtonManager a = Instantiate(i.Setting, paramter_input.transform);
        a.SetParameter(i.Parameters);

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

    public void SetParameters()
    {

    }
}

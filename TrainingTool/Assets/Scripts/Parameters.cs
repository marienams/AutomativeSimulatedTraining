using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    [SerializeField]private GameObject paramter_input;
    [SerializeField] private Text debugText;
    private List<Equipment> equipments;
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

    private void Update()
    {
        if (equipments != null)
            CreateParameter();
    }

    public void CreateParameter()
    {
        foreach(Equipment i in equipments)
        {
            Instantiate(i.Setting, paramter_input.transform);
        }
    }

    public void ParameterList(Equipment equipment)
    {
        debugText.text = equipment.EquipmentSettingState;
        equipments.Add(equipment);
    }
}

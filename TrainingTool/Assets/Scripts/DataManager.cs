using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{

    // ----- EQUIPMENT LIST --------- //
    private GameObject equipment;
    
    public Equipment equipmentObj;
    //public Button equipmentOptionsBtn;

    [SerializeField] private EquipmentButtonManager _equipmentButtonManagerPrefab;
    [SerializeField] private GameObject _equimentButtonContainer;

    [SerializeField] private List<Equipment> equipments;
    
    [SerializeField] private Text debugText;
    
    private int current_id = 0;

    public GameObject settingCanvas;
    [SerializeField]private GameObject setting_Btn;
    [SerializeField] private GameObject StationEquipmentContainer;


    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<DataManager>();
            }
            return instance;
        }
    }

    private void Start()
    {
        LoadEquipments();
        CreateButtons();
    }

    void LoadEquipments()
    {
        var equipment_obj = Resources.LoadAll("equipment", typeof(Equipment));
        foreach(var equipment in equipment_obj)
        {
            equipments.Add(equipment as Equipment);
        }
    }

    void CreateButtons()
    {
        foreach(Equipment i in equipments)
        {
            EquipmentButtonManager b = Instantiate(_equipmentButtonManagerPrefab, _equimentButtonContainer.transform);
            b.Equipment_ID = current_id;
            b.Equipment_Icon = i.equipment_icon;
            current_id++;
        }
    }

   public void SetEquipment(int id)
    {
        equipment = equipments[id].equipmentPrefab;
        setting_Btn = equipments[id].Setting;
        equipmentObj = equipments[id];
    }
    
    


    public GameObject GetEquipment()
    {
        return equipment;
    }

    public GameObject SettingsParameters()
    {
        return settingCanvas;
    }
    /*public void CreateParameters()
    {
        Parameters.Instance.Input = setting_Btn;
        Parameters.Instance.CreateParameter(setting_Btn);
    }*/
}

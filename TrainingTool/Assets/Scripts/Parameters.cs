using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Parameters : MonoBehaviour
{
    //[SerializeField] private Text debugText;
    [SerializeField] private Button CheckStationSetup;
    [SerializeField] private ParameterMenu parameter_menu;
    [SerializeField]private GameObject stationContainer;
    [SerializeField] private StationButtonManager _stationButtonPrefab;
    [SerializeField] private TextMeshProUGUI stationName;
    [SerializeField] private TextMeshProUGUI result;
    
    [SerializeField]private List<Equipment> equipments;

    

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
        CheckStationSetup = GameObject.Find("CheckBtn").GetComponent<Button>();

        stationName.text = StationManager.Instance.GetStationName();
        CheckStationSetup.onClick.AddListener(StationSetupCheck);
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
        
        
    }

    public void SetParameters(string name)
    {
        foreach(var equipment in equipments)
        {
            if(equipment.Name == name)
            {
                Instantiate(parameter_menu);
                parameter_menu.EquipPrefab = equipment.equipmentPrefab;
                parameter_menu.EquipName = equipment.name;
            }
        }
    }

    void StationSetupCheck()
    {
        foreach(var equip in equipments)
        {
            if(StationManager.Instance.CheckStation(equip.equipmentID))
            {
                result.text = "Correct Setup";
            }
            else
            {
                result.text = "Try Again";
            }
        }
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        result.text = message;
        result.enabled = true;
        yield return new WaitForSeconds(delay);
        result.enabled = false;
    }

    public void DeleteEquipment(string name)
    {
        foreach(var i in equipments)
        {
            if (i.name == name)
                equipments.Remove(i);
        }
    }

    public void CloseParameterMenu()
    {
        Destroy(parameter_menu);
    }
}

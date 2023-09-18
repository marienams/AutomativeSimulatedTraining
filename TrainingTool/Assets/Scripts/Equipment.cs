using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Equipment", menuName = "AddEquipment/Equipment")]
public class Equipment : ScriptableObject
{
    // Tags: Stationary, Security, Electric
    //[SerializeField] public Button optionsBtn;
    public GameObject equipmentPrefab;
    public StationButtonManager Setting;
    public Sprite equipment_icon;
    public string EquipmentSettingState;
    public GameObject Parameters;
}

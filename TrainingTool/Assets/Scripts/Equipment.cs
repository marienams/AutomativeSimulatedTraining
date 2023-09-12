using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Equipment", menuName = "AddEquipment/Equipment")]
public class Equipment : ScriptableObject
{
    
    //[SerializeField] public Button optionsBtn;
    public GameObject equipmentPrefab;
    public Button Setting;
    public Sprite equipment_icon;
}
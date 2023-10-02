using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParameterMenu : MonoBehaviour
{
    private Button delete;
    private Button finish;
    private TextMeshProUGUI equipNameDisplay;

    private GameObject equipPrefab;
    public GameObject EquipPrefab
    {
        set
        {
            equipPrefab = value;
        }
    }
    private string equipName;
    public string EquipName
    {
        set
        {
            equipName = value;
        }
    }

    private void Start()
    {
        equipNameDisplay = GameObject.Find("EquipmentName").GetComponent<TextMeshProUGUI>();
        equipNameDisplay.text = equipName;
        delete = GameObject.Find("Delete").GetComponent<Button>();
        delete.onClick.AddListener(DeleteEquipment);
        finish = GameObject.Find("Finish").GetComponent<Button>();
        finish.onClick.AddListener(CloseParameterMenu);
    }

    void DeleteEquipment()
    {
        Destroy(equipPrefab);
        Parameters.Instance.DeleteEquipment(equipName);
    }

    void CloseParameterMenu()
    {
        Parameters.Instance.CloseParameterMenu();
        Destroy(this);

    }

}

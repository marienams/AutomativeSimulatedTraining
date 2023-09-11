using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentButtonManager : MonoBehaviour
{
    public GameObject equipmentModel;
    private Button equipmentBtn;

    // Start is called before the first frame update
    void Start()
    {
        equipmentBtn = GetComponent<Button>();
        equipmentBtn.onClick.AddListener(SetEquipment);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetEquipment()
    {
        DataManager.Instance.equipment = equipmentModel;
    }
}

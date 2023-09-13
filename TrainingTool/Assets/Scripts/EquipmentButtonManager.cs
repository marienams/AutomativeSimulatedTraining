using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentButtonManager : MonoBehaviour
{
    //Setting the scriptable object fields to display in equipment container scroll bar

    
    [SerializeField] private RawImage buttonImage;

    private Button equipmentBtn;

    

    private int equipment_id;
    private Sprite equipment_icon;

    public int Equipment_ID
    {
        set
        {
            equipment_id = value;
            
        }
    }
    

    public Sprite Equipment_Icon
    {
        set
        {
            equipment_icon = value;
            buttonImage.texture = equipment_icon.texture;
        }

        }

    // Start is called before the first frame update
    void Start()
    {
        equipmentBtn = GetComponent<Button>();
        equipmentBtn.onClick.AddListener(SelectEquipment);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SelectEquipment()
    {
        DataManager.Instance.SetEquipment(equipment_id);
        
        //DataManager.Instance.equipment = equipmentModel;
        //DataManager.Instance.equipment_Btn = equipment_Btn;
    }
}

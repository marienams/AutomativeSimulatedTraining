using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationButtonManager : MonoBehaviour
{
    
    
    [SerializeField] private Text buttonText;
    private Button equipmentBtn;
    

    // Start is called before the first frame update

    private int equipment_id;
    public int Equipment_ID
    {
        set
        {
            equipment_id = value;

        }
    }

    private string equipment_name;
    public string Equipment_Name
    {
        set
        {
            equipment_name = value;
            buttonText.text = equipment_name;
        }
    }

    void Start()
    {
        
        equipmentBtn = GetComponent<Button>();

        equipmentBtn.onClick.AddListener(DisplayParameter);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void DisplayParameter()
    {
        Parameters.Instance.SetParameters(equipment_name);
        
    }
}

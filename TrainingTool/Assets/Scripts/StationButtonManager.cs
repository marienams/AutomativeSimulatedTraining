using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StationButtonManager : MonoBehaviour
{
    private Button equipmentBtn;
    [SerializeField] private Text debugText;

    private GameObject parameterMenu;
    // Start is called before the first frame update
    void Start()
    {
        debugText.text = "Button added";
        equipmentBtn = GetComponent<Button>();

        equipmentBtn.onClick.AddListener(DisplayParameter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetParameter(GameObject equip)
    {
        parameterMenu = equip;
        
    }
    void DisplayParameter()
    {
        parameterMenu.SetActive(true);
    }
}

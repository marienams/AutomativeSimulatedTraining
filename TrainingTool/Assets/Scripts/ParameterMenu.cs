using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParameterMenu : MonoBehaviour
{
    [SerializeField]private Button finishButton; 
    // Start is called before the first frame update
    void Start()
    {
        finishButton = GetComponent<Button>();
        finishButton.onClick.AddListener(Finish);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Finish()
    {
        
    }
}

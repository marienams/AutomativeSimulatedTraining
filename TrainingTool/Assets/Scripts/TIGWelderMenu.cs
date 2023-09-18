using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TIGWelderMenu : MonoBehaviour
{
    private Button _btn;
    // Start is called before the first frame update
    void Start()
    {
        _btn = GetComponentInChildren<Button>();
        _btn.onClick.AddListener(Visibility);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Visibility()
    {
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseEquipment : MonoBehaviour
{
    private Vector2 touchPosition;
    [SerializeField] private Camera arCamera;
    
    [SerializeField] private Text debugText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touchPosition);
                RaycastHit hitObject;
                if(Physics.Raycast(ray, out hitObject))
                {
                    Equipment equipment = hitObject.transform.GetComponent<Equipment>();
                    if(equipment != null)
                    {
                        debugText.text = "Equipment";
                    }
                }
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceEquipment : MonoBehaviour
{
    [SerializeField] private GameObject equipment;
    bool isAddingEquipment;
    [SerializeField] private Text debugText;
    [SerializeField]private ARRaycastManager arRaycastManager;
    [SerializeField] private ARPlaneManager arPlaneManager;
    [SerializeField] private Button addEquipmentBtn;

    public GameObject Equipment
    {
        get {return equipment; }
        set {equipment = value; }
    }
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
        isAddingEquipment = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        PlaceObject();
        if(addEquipmentBtn!= null)
        {
            
            addEquipmentBtn.onClick.AddListener(AddEquipment);
            
        }
        
        
    }

    public bool GetUserTap(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;
            return true;
        }
        
        touchPosition = default;
        return false;
    }

    public void PlaceObject()
    {
        if (!GetUserTap(out Vector2 touchPosition))
            return;
        if(arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            debugText.text = "tapped";
            var hitPose = hits[0].pose;
            Instantiate(equipment, hitPose.position, hitPose.rotation);
            isAddingEquipment = false;

            foreach (ARPlane plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

        }
        
        
    }

    public void AddEquipment()
    {
        isAddingEquipment = true;
        
            
        foreach(ARPlane plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(true);
            }
        
    }

    public static List<ARRaycastHit> hits = new List<ARRaycastHit>();
}

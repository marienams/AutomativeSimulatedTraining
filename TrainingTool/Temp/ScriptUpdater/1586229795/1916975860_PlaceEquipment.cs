using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceEquipment : ARBaseGestureInteractable
{
    private Touch touch;
    bool isAddingEquipment;
    private Vector2 touchPosition;
    [SerializeField] private Camera arCamera;
    //[SerializeField] private Canvas mainCanvas;
    [SerializeField] private Text debugText;
     private ARRaycastManager arRaycastManager;
     private ARPlaneManager arPlaneManager;
    [SerializeField] private Button addEquipmentBtn;

    

    public static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
        
        arPlaneManager.enabled = false;
        isAddingEquipment = false;
        debugText.text = isAddingEquipment.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        touch = Input.GetTouch(0);
        
        

        if (addEquipmentBtn != null)
        {
            addEquipmentBtn.onClick.AddListener(AddDetection);
        }

    }

    
    protected override void OnEndManipulation(TapGesture gesture)
    {
        if (gesture.isCanceled)
            return;
        if (gesture.targetObject != null || TouchIsOverUI(gesture))
            return;
        if (isAddingEquipment)
            PlaceObject();
    }

    bool GetUserTap(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
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
        if (GestureTransformationUtility.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon) && isAddingEquipment)
        {
            isAddingEquipment = false;
            var hitPose = hits[0].pose;
            GameObject placeObj= Instantiate(DataManager.Instance.GetEquipment(), hitPose.position, hitPose.rotation);

            var anchorObj = new GameObject("PlacementAnchor");
            anchorObj.transform.position = hitPose.position;
            anchorObj.transform.rotation = hitPose.rotation;
            placeObj.transform.parent = anchorObj.transform;

            debugText.text = isAddingEquipment.ToString();
            Parameters.Instance.ParameterList(DataManager.Instance.equipmentObj);
            //DisplayEquipmentSetting();
        }


    }

    public void AddDetection()
    {
        
        isAddingEquipment = true;
        arPlaneManager.enabled = true;
        foreach (ARPlane plane in arPlaneManager.trackables)
        {
            plane.gameObject.SetActive(true);
        }
        debugText.text = isAddingEquipment.ToString();
        
    }


    

    bool TouchIsOverUI(TapGesture touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.startPosition.x, touch.startPosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    /*void useEquipment()
    {
        if (Input.touchCount > 0 && !isAddingEquipment)
        {
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touchPosition);
                RaycastHit hitObject;
                if (Physics.Raycast(ray, out hitObject))
                {
                    Equipment equipment = hitObject.transform.GetComponent<Equipment>();
                    if (equipment != null)
                    {
                        debugText.text = "Equipment";
                    }
                }
            }
        }
    }*/
}

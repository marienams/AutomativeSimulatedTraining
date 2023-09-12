using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceEquipment : MonoBehaviour
{
    private Touch touch;
    bool isAddingEquipment;
    private Vector2 touchPosition;
    [SerializeField] private Camera arCamera;
    [SerializeField] private Canvas mainCanvas;
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

        if (!isAddingEquipment)
            useEquipment();

        if (touch.tapCount < 0 || touch.phase != TouchPhase.Began)
            return;

        if (TouchIsOverUI(touch))
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
        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon) && isAddingEquipment)
        {
            isAddingEquipment = false;
            var hitPose = hits[0].pose;
            Instantiate(DataManager.Instance.GetEquipment(), hitPose.position, hitPose.rotation);
            EquipmentSetting();
            arPlaneManager.enabled = false;
            foreach (ARPlane plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            debugText.text = isAddingEquipment.ToString();
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


    void EquipmentSetting()
    {
        Button child = Instantiate(DataManager.Instance.setting_Btn);
        child.transform.parent = mainCanvas.transform;
    }


    bool TouchIsOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }

    void useEquipment()
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
    }
}

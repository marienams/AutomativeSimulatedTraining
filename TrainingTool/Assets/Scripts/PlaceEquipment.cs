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
    
    [SerializeField] private Text debugText;
    [SerializeField]private ARRaycastManager arRaycastManager;
    [SerializeField] private ARPlaneManager arPlaneManager;
    [SerializeField] private Button addEquipmentBtn;

    
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
        
        arPlaneManager.enabled = false;
    }
    

    // Update is called once per frame
    void Update()
    {
        touch = Input.GetTouch(0);
        if (touch.tapCount < 0 || touch.phase != TouchPhase.Began)
            return;

        if (TouchIsOverUI(touch))
            return;

        PlaceObject();

        if(addEquipmentBtn!= null)
        {
            addEquipmentBtn.onClick.AddListener(AddDetection);
        }

        
        
        
    }

    bool GetUserTap(out Vector2 touchPosition)
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
            Instantiate(DataManager.Instance.equipment, hitPose.position, hitPose.rotation);

            arPlaneManager.enabled = false;
            foreach (ARPlane plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }

        }
        
        
    }

    public void AddDetection()
    {
        
        arPlaneManager.enabled = true;
        foreach(ARPlane plane in arPlaneManager.trackables)
        {
                plane.gameObject.SetActive(true);
        }

    }

    

    public static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    bool TouchIsOverUI(Touch touch)
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        return results.Count > 0;
    }
}

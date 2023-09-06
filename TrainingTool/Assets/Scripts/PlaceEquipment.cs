using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class PlaceEquipment : MonoBehaviour
{
    [SerializeField] private GameObject equipment;


    private ARRaycastManager arRaycastManager;

    public GameObject Equipment
    {
        get {return equipment; }
        set {equipment = value; }
    }
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static bool GetUserTap(out Vector2 touchPosition)
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
            var hitPose = hits[0].pose;
            Instantiate(equipment, hitPose.position, hitPose.rotation);
        }
    }

    List<ARRaycastHit> hits = new List<ARRaycastHit>();
}

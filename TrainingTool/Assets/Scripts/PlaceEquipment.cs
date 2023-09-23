using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.AR;
using UnityEngine.XR.ARSubsystems;

public class PlaceEquipment : ARBaseGestureInteractable
{

    [SerializeField]private Camera arCamera;
    [SerializeField]private ARRaycastManager arraycastManager;
    [SerializeField]private ARPlaneManager aRPlaneManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Touch touch;
    private Pose pose;

    bool isAddingEquipment;
    [SerializeField] private Button addEquipmentBtn;
    [SerializeField] private Text debugText;

    private void Start()
    {
        addEquipmentBtn = GetComponent<Button>();
        isAddingEquipment = true;
    }

    private void Update()
    {
        //addEquipmentBtn.onClick.AddListener(AddDetection);
        debugText.text = isAddingEquipment.ToString();
        

    }
    
    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        if (gesture.targetObject == null)
        {
            return true;
        }
        return false;
    }

    protected override void OnEndManipulation(TapGesture gesture)
    {
        if (gesture.isCanceled)
        {
            return;
        }
        if (gesture.targetObject != null || IsPointerOverUI(gesture))
        {
            return;
        }
        if (GestureTransformationUtility.Raycast(gesture.startPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            GameObject placeObj = Instantiate(DataManager.Instance.GetEquipment(), hitPose.position, hitPose.rotation);
            isAddingEquipment = false;
            debugText.text = isAddingEquipment.ToString();
            var anchorObj = new GameObject("PlacementAnchor");
            anchorObj.transform.position = pose.position;
            anchorObj.transform.rotation = pose.rotation;
            placeObj.transform.parent = anchorObj.transform;
            Parameters.Instance.ParameterList(DataManager.Instance.equipmentObj);

        }
    }

    bool IsPointerOverUI(TapGesture touch) // specify the gesture, if it is a tap or a swipe
    {
        
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        
        eventData.position = new Vector2(touch.startPosition.x, touch.startPosition.y);
        
        List<RaycastResult> raycastResult = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResult);
        return raycastResult.Count > 0;

    }

    

    public void AddDetection()
    {

        isAddingEquipment = true;

    }
}

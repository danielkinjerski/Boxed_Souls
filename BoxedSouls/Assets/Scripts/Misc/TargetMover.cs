using UnityEngine;
using System.Collections;

public class TargetMover : MonoBehaviour {
	
	/** Mask for the raycast placement */
	public LayerMask mask;
	
	public Transform target;
    static public Vector3 targetPosition;
	
	/** Determines if the target position should be updated every frame or only on double-click */
	public bool onlyOnDoubleClick;
	
	Camera cam;
	
	public void Start () {
		//Cache the Main Camera
		cam = Camera.main;
	}
	
	public void OnGUI () {

        if (onlyOnDoubleClick && cam != null && Event.current.type == EventType.MouseDown || Event.current.type == EventType.MouseDrag)
        {
			UpdateTargetPosition ();
        }
	}
	
	public void UpdateTargetPosition () {
		//Fire a ray through the scene at the mouse position and place the target where it hits
		RaycastHit hit;
		if (Physics.Raycast	(cam.ScreenPointToRay (Input.mousePosition), out hit, Mathf.Infinity, mask)) {
			target.position = hit.point;
            targetPosition = target.position;
		}
	}
	
}

using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public GameObject target;
	public Transform player;
    Vector3 lookPoint;
    public float lookDistance = 14;
    public float lookHeight = 1;
    public float height = 2;
	
	public float rotationDamping = 3;
	public float distance = 0;
	float wantedRotationAngle; 
	float currentRotationAngle;
	Quaternion  currentRotation;
	

	// Use this for initialization
	void Start () 
	{
		lookPoint = target.transform.position + 
					transform.forward * lookDistance -
					new Vector3(0, lookHeight, 0);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (!target)
            return;
		
		wantedRotationAngle = player.eulerAngles.y;
		currentRotationAngle = transform.eulerAngles.y;
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, 
		                                        wantedRotationAngle, 
		                                       rotationDamping * Time.deltaTime);
		currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
		transform.position -= currentRotation * Vector3.up * distance;
		
		lookPoint = Vector3.Lerp(lookPoint, target.transform.position + transform.forward * lookDistance - new Vector3(0, lookHeight, 0), .05f);
        lookPoint = new Vector3(lookPoint.x, height, lookPoint.z);
		transform.position = Vector3.Lerp(transform.position, target.transform.position + 
		                                  new Vector3(0, height, lookDistance) + 
		                                  target.transform.forward * -1.5f, .1f);
		
		
		
	}
}

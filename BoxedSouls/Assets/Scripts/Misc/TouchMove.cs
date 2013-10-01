using UnityEngine;
using System.Collections;

public class TouchMove : MonoBehaviour {

    static public Vector3 targetPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 8))
            {
                print("Hit!" + hit.point);
                targetPosition = hit.point;
                print(targetPosition);
            }
        }
	}
}

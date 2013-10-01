using UnityEngine;
using System.Collections;
[RequireComponent(typeof(CharacterController))]
public class AIStatus : MonoBehaviour {
    public AIState behaviorState;
    public Relationship relationship;
    public int health;

    void Awake()
    {
        this.tag = "ai";
    }
	// Update is called once per frame
	void Update () {
	
	}
}

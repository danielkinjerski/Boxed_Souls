using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum AIState { Pause, InActive, Idle, Aware, Charge, Null };
public class AIManager : MonoBehaviour {

    public struct AIStruct
    {
        public Transform obj;
        public AIStatus script;
    }
    bool EnemyAIStateRun;
    bool FriendAIStateRun;
    //public List<AIStruct> ai = new List<AIStruct>();
    public List<AIStruct> enemyAI = new List<AIStruct>();
    public List<AIStruct> friendAI = new List<AIStruct>();
    public Transform target;
    public int maxHP;

	void Start () {
        StartCoroutine(FetchAI());
	}
    IEnumerator FetchAI()
    {
        var temp = GameObject.FindGameObjectsWithTag("ai") as GameObject[];
        foreach (GameObject ele in temp)
        {
            AIStruct tmp = new AIStruct();
            tmp.obj = ele.transform;
            tmp.script = ele.GetComponent<AIStatus>();
            switch (GameManager.difficulty)
            {
                case Difficulty.Easy:
                    tmp.script.health = maxHP / 2;
                    break;
                case Difficulty.Normal:
                    tmp.script.health = maxHP;
                    break;
                case Difficulty.Hard:
                    tmp.script.health = maxHP * 2;
                    break;
            }
            if (tmp.script.relationship == Relationship.Foe)
            {
                ele.tag = "enemy";
                enemyAI.Add(tmp);
            }
            else if (tmp.script.relationship == Relationship.Friend)
            {
                ele.tag = "friend";
                friendAI.Add(tmp);
            }
        }
        yield return null;
    }
	void Update () {
        if (!EnemyAIStateRun)
            StartCoroutine(EnemyAI());
        if (!FriendAIStateRun)
            StartCoroutine(FriendAI());
	}
    IEnumerator FriendAI() 
    {
        FriendAIStateRun = true;
        foreach (AIStruct ele in friendAI)
        {
            switch(ele.script.behaviorState)
            {
                case AIState.Aware:
                    break;
                case AIState.Charge:
                    break;
                case AIState.Idle:
                    break;
                case AIState.InActive:
                    break;
                case AIState.Pause:
                    break;
                case AIState.Null:
                    break;
            }

        }
        FriendAIStateRun = false;
        yield return null;
    }
    IEnumerator EnemyAI() 
    {
        EnemyAIStateRun = true;
        foreach (AIStruct ele in enemyAI)
        {
            switch (ele.script.behaviorState)
            {
                case AIState.Aware:
                    break;
                case AIState.Charge:
                    break;
                case AIState.Idle:
                    break;
                case AIState.InActive:
                    break;
                case AIState.Pause:
                    break;
                case AIState.Null:
                    break;
            }

        }
        EnemyAIStateRun = false;
        yield return null;
    }



}

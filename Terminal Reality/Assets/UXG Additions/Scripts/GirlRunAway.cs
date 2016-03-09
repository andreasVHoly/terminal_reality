﻿using UnityEngine;
using System.Collections;

public class GirlRunAway : MonoBehaviour {


    public Transform position;
    private NavMeshAgent agent;
    private Animator anim;

	// Use this for initialization
	void Start () {
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        anim = this.gameObject.GetComponent<Animator>();
        if (agent == null || position == null) {
            Debug.LogError("not assigned");
        }
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (checkArrival(position.position)) {
            Destroy(this.gameObject);
        }
	}

    public void moveToNewPos() {
        anim.SetBool("Sprint", true);
        agent.SetDestination(position.position);
    }

    bool checkArrival(Vector3 pos1) {
        //Debug.Log(Vector3.Distance(pos1, this.transform.position));
        if (Vector3.Distance(pos1, this.transform.position) <= 2) {
            return true;
        }
        return false;
    }

}

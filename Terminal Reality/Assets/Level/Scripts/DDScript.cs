﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DDScript : MonoBehaviour {

    private GameObject soundController;
    private Animator anim;
	private bool open;
	private Text pushE;

	// Use this for initialization
	void Start () 
	{
        soundController = GameObject.FindGameObjectWithTag(Tags.SOUNDCONTROLLER);
        anim = gameObject.GetComponent<Animator>();
		open = false;
		pushE = GameObject.FindGameObjectWithTag(Tags.PUSHE).GetComponent<Text>();
	}


	//WHEN THE PLAYER INTERACTS WITH THE DOOR//
	public void interaction()
	{
		//IF THE DOOR IS CLOSED//
		if(!open)
		{
            //play sound of this component
            soundController.GetComponent<soundControllerScript>().playDoorCreek(this.GetComponent<AudioSource>());
            anim.SetTrigger("OpenFWD");
			open = true;
		}
	}

	//WHEN SOMETHING ENTERS THE DOORS TRIGGER//
	void OnTriggerEnter (Collider other)
	{
		//IF A PLAYER ENTERS THE DOOR'S TRIGGER//
		if (other.tag == Tags.PLAYER1 || other.tag == Tags.PLAYER2)
		{
			if (!open) //Only show hint if the door is closed
			{
				pushE.enabled = true;
			}
		}

	}
	
	//WHEN SOMETHING LEAVES THE DOOR'S TRIGGER//
	void OnTriggerExit (Collider other)
	{
		//IF A PLAYER LEAVES THE DOOR'S TRIGGER//
		if (other.tag == Tags.PLAYER1 || other.tag == Tags.PLAYER2)
		{
			pushE.enabled = false;
		}

	}





}

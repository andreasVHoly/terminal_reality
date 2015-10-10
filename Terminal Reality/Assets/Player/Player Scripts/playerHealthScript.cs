﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerHealthScript : MonoBehaviour {
	
	public playerDataScript playerData;
	public UIBarScript uiBarScript;	
	private bool heartBeatPlaying = false;
	private GameObject soundController;
	
	//the animator
	private Animator animator;
    private PhotonView pView;
    private playerAnimatorSync animSync;
	
	// Use this for initialization
	void Start () {
        uiBarScript = GameObject.FindGameObjectWithTag(Tags.UIBAROBJ).GetComponent<UIBarScript>();
        playerData = this.GetComponent<playerDataScript>();		
		soundController = GameObject.FindGameObjectWithTag("Sound Controller");
		animator = this.gameObject.GetComponent<Animator>();
		updateHealthHUD();
        animSync = this.gameObject.GetComponent<playerAnimatorSync>();
        pView = this.gameObject.GetComponent<PhotonView>();


    }
	
	// Update is called once per frame
	void Update () 
	{
		//////////////
		//TEMP CODE//
		/////////////
		if (Input.GetKeyDown(KeyCode.KeypadMinus)) // decrease health //
		{
			if (playerData.health >= 5)
			{
				playerData.health -= 5;			
				updateHealthHUD();
			}
		}
		if (Input.GetKeyDown(KeyCode.KeypadPlus)) // increase health //
		{
			if (playerData.health <= 95)
			{
				playerData.health += 5;
				updateHealthHUD();
			}
		}
		/////////////////////////////////////////////////////////////////
		////////////////////////////////////////////////////////////////
		
		if (!heartBeatPlaying && playerData.health < 50)
		{
			soundController.GetComponent<soundControllerScript>().playLowHealthHeartBeat(transform.position); //play heart beat
			heartBeatPlaying = true;
		}
		if (heartBeatPlaying && playerData.health >= 50)
		{
			this.GetComponent<AudioSource>().Stop(); //stop the heart beat
			heartBeatPlaying = false;
		}
		
	}
	
	//REDUCE PLAYER'S HEALTH BY DAMAGE//
	public void reducePlayerHealth(int damage)
	{
		//If the damage received does NOT kill the player
		//i.e. damage does not make player health <= 0
		if ((playerData.health - damage) > 0)
		{
			print ("Health: " + playerData.health);
			playerData.health -= damage;			
			this.GetComponent<AudioSource>().Stop(); //stop the heart beat
			heartBeatPlaying = false;
			updateHealthHUD();
		}
		//if the damage kills the player//
		else if ((playerData.health - damage) <= 0)
		{
			playerData.health = 0;
			playerData.playerAlive = false; //boolean to send over network
			//animator.SetTrigger(playerAnimationHash.dieTrigger);
            if (PhotonNetwork.offlineMode) {
                animSync.setTriggerP(playerAnimationHash.dieTrigger);
            }
            else {
                pView.RPC("setTriggerP", PhotonTargets.AllViaServer, playerAnimationHash.dieTrigger);
            }
			updateHealthHUD();
            Application.LoadLevel("Credits");
            pView.RPC("endGame", PhotonTargets.OthersBuffered);
			print ("PLAYER IS DEAD!!!"); //temp print out
		}
		
	}
	


    [PunRPC]
    public void endGame() {
        Application.LoadLevel("Credits");
    }

	//INCREASE PLAYER'S HEALTH//
	public void increasePlayerHealth(int healthPoints)
	{
		
		//TODO: IF WE DECIDE ON DOING INCREMENTAL HEALING AND NOT ONLY FULL HEALS//
		
	}
	
	//FULL UP (MAX) PLAYER'S HEALTH//
	public void fullPlayerHealth()
	{
		playerData.health = 100;
		updateHealthHUD();
	}
	
	//UPDATE THE HEALTH DISPLAYED ON THE HUD//
	private void updateHealthHUD()
	{
        uiBarScript.UpdateValue(playerData.health, 100);
	}
}
﻿using UnityEngine;
using System.Collections;

public class soundControllerScript : MonoBehaviour {

	AudioSource safeAudio;
	AudioSource tensionAudio;
	
	//PUBLIC PLAYER SOUND VARIABLES//
	public AudioClip pistolShotSound;
	public AudioClip machineGunShotSound;
	public AudioClip reloadSound;
	public AudioClip outOfAmmoSound;
	public AudioClip ammoAndWeaponPickupSound;
	public AudioClip torchButtonSound;

	public AudioClip lowHealthHeartBeat;
	
	
	//PUBLIC ZOMBIE SOUND VARIABLES//
	public AudioClip maleScreamingSound;
	public AudioClip femaleScreamingSound;

    public AudioClip bossZombieScream;
    public AudioClip bossZombieDeath;
    public AudioClip pukingSound;

	//PUBLIC BACKGROUND SOUNDS CLIPS//
	public AudioClip safeBackgroundSound;




    private Vector3 pos;

	// Use this for initialization
	void Start () {
		safeAudio = GameObject.FindGameObjectWithTag("Sound Controller").GetComponent<AudioSource>();
		tensionAudio = GameObject.FindGameObjectWithTag(Tags.PLAYER1).GetComponent<AudioSource>();
		playSafeBackgroundSound();
	}

	public void playSafeBackgroundSound()
	{
		safeAudio.Play();
	}

	public void playTensionAudio()
	{
		if (safeAudio.isPlaying)
		{
			safeAudio.Stop();
		}
		if (!tensionAudio.isPlaying)
		{
			tensionAudio.Play();
		}
	}

	//PLAY LOW HEALTH HEART BEAT//
	public void playLowHealthHeartBeat(Vector3 position)
	{
        //play sound
        //soundSource.PlayOneShot(lowHealthHeartBeat);
        AudioSource.PlayClipAtPoint(lowHealthHeartBeat, position);
    }
	
	//PLAY EMPTY CLIP SOUND//
	public void playEmptyClip(Vector3 position)
	{
        //play sound
        //soundSource.PlayOneShot(outOfAmmoSound);
        AudioSource.PlayClipAtPoint(outOfAmmoSound, position);
    }

    //PLAY PISTOL SHOOTING SOUND//
    public void playPistolShot(Vector3 position)
	{
        //play sound
        //soundSource.PlayOneShot(pistolShotSound);
        AudioSource.PlayClipAtPoint(pistolShotSound, position);
    }

    //PLAY RELOAD SOUND//
    public void playReload(Vector3 position)
	{
        //play sound
        //soundSource.PlayOneShot(reloadSound);
        AudioSource.PlayClipAtPoint(reloadSound, position);
    }

    //PLAY AMMO AND WEAPON PICKUP SOUND//
    public void playPickupSound(Vector3 position)
	{
        //play sound
        //soundSource.PlayOneShot(ammoAndWeaponPickupSound);
        AudioSource.PlayClipAtPoint(ammoAndWeaponPickupSound, position);
    }

    //PLAY TORCH ON/OFF SOUND//
    public void playTorchSound(Vector3 position)
	{
        //play sound
        //soundSource.PlayOneShot(torchButtonSound);
        AudioSource.PlayClipAtPoint(torchButtonSound, position);
    }

    //PLAY SCREAM FOR MALE ZOMBIE//
    public void playMaleScream(Vector3 position){
        //soundSource.PlayOneShot(maleScreamingSound);
        AudioSource.PlayClipAtPoint(maleScreamingSound, position);
    }

    //PLAY SCREAM FOR FEMALE ZOMBIE//
    public void playFemaleScream(Vector3 position){
        //soundSource.PlayOneShot(femaleScreamingSound);
        AudioSource.PlayClipAtPoint(femaleScreamingSound, position);
    }

    
    //PLAY SCREAM FOR BOSS ZOMBIE//
    public void playBossScreamSound(Vector3 position) {
        
        AudioSource.PlayClipAtPoint(bossZombieScream, position);
    }

    //PLAY DEATH CLIP FOR BOSS ZOMBIE//
    public void playBossDeathSound(Vector3 position) {
        //soundSource.PlayOneShot(bossZombieDeath);
        AudioSource.PlayClipAtPoint(bossZombieDeath, position);
    }
    
    
    
    //PLAY DEATH CLIP FOR BOSS ZOMBIE//
    public void playPukingSound(Vector3 position) {
        //soundSource.PlayOneShot(bossZombieDeath);
        //2.1
        pos = position;
        playPuke();
        Invoke("playPuke", pukingSound.length);
        
    }


    void playPuke() {
        AudioSource.PlayClipAtPoint(pukingSound, pos);
    }
}


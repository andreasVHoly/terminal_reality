﻿using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour {


	public enum SpawnTypes {
		player,
		enemy,
		other
	};

	public Transform[] playerSpawns;



	public Transform getSpawnLocation(SpawnTypes type){
		switch(type){
		case SpawnTypes.player:
			int selection = Random.Range(0,playerSpawns.Length);
			return playerSpawns[selection];
			break;
		case SpawnTypes.enemy:
			return playerSpawns[0];
			break;
		case SpawnTypes.other:
			return playerSpawns[0];
			break;
		default:
			return playerSpawns[0];
		
		}
	}

}

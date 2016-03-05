﻿using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {


    public bool player1Dead, player2Dead;



    void Update() {

        if (gameObject.GetComponent<GameManager>().singleplayer && player1Dead) {

			writeToFile();

            Application.LoadLevel("Thriller");
        }
        else if (!gameObject.GetComponent<GameManager>().singleplayer && player1Dead && player2Dead) {
            Application.LoadLevel("Thriller");
        }

    }

	public void writeToFile()
	{
		string path = PlayerPrefs.GetString("filePath");
		string text = PlayerPrefs.GetString("StartTime");

		//Wrtie to file whether the player died or made it to the end of the level.
		if (player1Dead)
		{
			text = text + "\r\nPlayer died.";
		}
		else
		{
			text = text + "\r\nPlayer finished the level.";
		}

		//Add the end time to the file.
		text = text + "\r\nEnd time: " + System.DateTime.Now.ToString();
		
		System.IO.File.WriteAllText(path, text);
	}

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	
	public void PlayGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

	public void Quit(){
		Application.Quit();
	}

	public void Next(){
		//print(PlayerPrefs.GetString("lastLoadedScene"));
		SceneManager.LoadScene(int.Parse(PlayerPrefs.GetString("lastLoadedScene"))+1);
	}

	public void Restart(){
		
		GM.GMReset();
		SceneManager.LoadScene(int.Parse(PlayerPrefs.GetString("lastLoadedScene")));
	}
}

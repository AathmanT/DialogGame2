using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {

    
    public static int score;
    public static int coinTotal;
    
    public static float timeTotal;
    public static int zVelocityAdjustment=1;
    public static int forwardVelocity=4;
    public static string lvlCompleteStatus = "";
    public static float verticalVelocity=0;
    public float waitToLoad;

    public static int letterCount;
    public static string lettersCollected;
    public static int wordProgress;
    public static string currentWord;

    public static string[] wordList;
     
	// Use this for initialization
	void Start () {
		
        wordList=new string[] { "APPLE", "MANGO", "ORANGE","GRAPES", "PEARS", "LIME" };
        
        
       
	}
	
	// Update is called once per frame
	void Update () {
        timeTotal += Time.deltaTime;
         currentWord=wordList[wordProgress];

        if (GM.lvlCompleteStatus == "Fail")
        {
            waitToLoad += Time.deltaTime;
        
        }
        if (waitToLoad>2)
        {
            SceneManager.LoadScene("LevelComplete");
            GMReset();
        }

	}

    public static void check(){
        if(GM.letterCount<GM.currentWord.Length){
                if(GM.lettersCollected!=GM.currentWord.Substring(0,GM.letterCount)){
                    GM.lvlCompleteStatus = "Fail";
                    GM.wordProgress+=1;
                    wordCheckReset();
                }
                
            }else if(GM.letterCount==GM.currentWord.Length){
                 if(GM.lettersCollected==GM.currentWord){

                    GM.score+=1;
                    GM.wordProgress+=1;
                    wordCheckReset();


                   // GM.lvlCompleteStatus = "You Won";
                   // PlayerPrefs.SetString ("lastLoadedScene", (SceneManager.GetActiveScene ().buildIndex).ToString());
                   // SceneManager.LoadScene("LevelComplete");
                }
            }
    }


    public static bool wordCheck(){
        if(GM.letterCount==GM.currentWord.Length && GM.lettersCollected!=GM.currentWord){
                    lvlCompleteStatus = "Fail";
                    wordProgress+=1;
                    wordCheckReset();
                    return false;
        }else{
            return true;
        }
    }
    public static void GMReset(){
        zVelocityAdjustment=1;
        forwardVelocity=4;
        verticalVelocity=0;
        letterCount=0;
        lettersCollected="";
        currentWord="";
        wordProgress=0;
    }

    public static void wordCheckReset(){
        letterCount=0;
        lettersCollected="";
    }
}

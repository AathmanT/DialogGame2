using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stats : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(gameObject.name=="coinsTxt"){
            GetComponent<TextMesh>().text = "Coins : " + GM.coinTotal;
        }

        if(gameObject.name=="timeTxt"){
            GetComponent<TextMesh>().text = "Time : " + GM.timeTotal;
        }

        if (gameObject.name=="status")
        {
            GetComponent<TextMesh>().text =GM.lvlCompleteStatus;
            
        }

        if(gameObject.name=="lettersCollected"){
                GetComponent<TextMesh>().text = GM.lettersCollected;
        }

        if(gameObject.name=="letters"){
                GetComponent<TextMesh>().text = GM.currentWord;
        }
        /////////////////////////////////word comparision display /////////////////////////////
        
        /* if(gameObject.name=="Score"){
                GetComponent<TextMesh>().text = GM.currentWord.Substring(0,GM.letterCount);
         } */

         if(gameObject.name=="Score"){
                GetComponent<TextMesh>().text = "Score:" + GM.score+"/10";
         }
        
	}
}

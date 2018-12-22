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

        
	}
}

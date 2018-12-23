using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




 
 
    /* void Update()
    {
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list
 
                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x) && laneNumber<3 && controlLocked==false)  //If the movement was to the right)
                        {   //Right swipe
							horizontalVelocity = 2;
							StartCoroutine(stopSlide());
							laneNumber += 1;
							controlLocked = true;
                            Debug.Log("Right Swipe");
                        }
                        else
                        {   //Left swipe
							if( laneNumber>1 && controlLocked==false){
									horizontalVelocity = -2;
									StartCoroutine(stopSlide());
									laneNumber -= 1;
									controlLocked = true;
							}
                            Debug.Log("Left Swipe");
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }
    }

*/








public class moveOrb : MonoBehaviour
{

	private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
	public KeyCode moveLeft;
	public KeyCode moveRight;

	public float horizontalVelocity;
	public int laneNumber = 2;
	public bool controlLocked;

    public Transform boomObject;

	// Use this for initialization
	void Start () {
		//dragDistance = Screen.height * 15 / 100; //dragDistance is 15% height of the screen
        dragDistance = 0.02f; //dragDistance is 15% height of the screen
        GM.lvlCompleteStatus="";
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody>().velocity = new Vector3(horizontalVelocity, GM.verticalVelocity, GM.forwardVelocity);

        

 if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list
 
                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x) && laneNumber<3 && controlLocked==false)  //If the movement was to the right)
                        {   //Right swipe
							horizontalVelocity = 2;
							StartCoroutine(stopSlide());
							laneNumber += 1;
							controlLocked = true;
                            Debug.Log("Right Swipe");
                        }
                        else
                        {   //Left swipe
							if( laneNumber>1 && controlLocked==false){
									horizontalVelocity = -2;
									StartCoroutine(stopSlide());
									laneNumber -= 1;
									controlLocked = true;
							}
                            Debug.Log("Left Swipe");
                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }






		if (Input.GetKeyDown(moveLeft) && laneNumber>1 && controlLocked==false )
		{
			horizontalVelocity = -4;
			StartCoroutine(stopSlide());
			laneNumber -= 1;
			controlLocked = true;
		}

		if (Input.GetKeyDown(moveRight) && laneNumber<3 && controlLocked==false)
		{
			horizontalVelocity = 4;
			StartCoroutine(stopSlide());
			laneNumber += 1;
			controlLocked = true;
		}
		

	}

	void OnTriggerEnter(Collider other) {

        
        

		if (other.gameObject.name=="rampBottomTrig") {
			GM.verticalVelocity = 2;
		}
		if (other.gameObject.name == "rampTopTrig")
		{
			GM.verticalVelocity = 0;
		}

         if(other.gameObject.name=="wordCheckTrigger"){

            if( GM.wordCheck()!=true){
                Destroy(gameObject);
                Instantiate(boomObject,transform.position,boomObject.rotation);
            }
            
           
        }

        if (other.gameObject.name=="Quad") {

            GM.lvlCompleteStatus = "You Won";
            PlayerPrefs.SetString ("lastLoadedScene", (SceneManager.GetActiveScene ().buildIndex).ToString());
            SceneManager.LoadScene("LevelComplete");
        }
	}

	void OnCollisionEnter(Collision other) {

		if (other.gameObject.tag == "lethal")
		{
			Destroy(gameObject);
            GM.zVelocityAdjustment = 0;
            GM.lvlCompleteStatus = "Fail";
            Instantiate(boomObject,transform.position,boomObject.rotation);
		}

		if (other.gameObject.name=="Capsule") {

			Destroy(other.gameObject);
		}
        

        if(other.gameObject.tag=="coin"){

            Destroy(other.gameObject);
            GM.coinTotal += 1;
        }

       

       if(other.gameObject.tag=="A"){

            GM.letterCount+=1;
            GM.lettersCollected += "A";
            Destroy(other.gameObject);

            GM.check();
            
        }

         if(other.gameObject.tag=="B"){

            GM.letterCount+=1;
            GM.lettersCollected += "B";
            Destroy(other.gameObject);

            GM.check();
        }


        if(other.gameObject.tag=="C"){
            
            GM.letterCount+=1;
            GM.lettersCollected += "C";
            Destroy(other.gameObject);

            GM.check();
        }

        if(other.gameObject.tag=="D"){

            GM.letterCount+=1;
            GM.lettersCollected += "D";
            Destroy(other.gameObject);

            GM.check();
        }

        if(other.gameObject.tag=="E"){

            GM.letterCount+=1;
            GM.lettersCollected += "E";
            Destroy(other.gameObject);

            GM.check();
        }

        if(other.gameObject.tag=="G"){

            GM.letterCount+=1;
            GM.lettersCollected += "G";
            Destroy(other.gameObject);

            GM.check();
        }

        if(other.gameObject.tag=="L"){

            GM.letterCount+=1;
            GM.lettersCollected += "L";
            Destroy(other.gameObject);

            GM.check();
        }

        if(other.gameObject.tag=="M"){

            GM.letterCount+=1;
            GM.lettersCollected += "M";
            Destroy(other.gameObject);

            GM.check();
        }

        if(other.gameObject.tag=="N"){

            GM.letterCount+=1;
            GM.lettersCollected += "N";
            Destroy(other.gameObject);

            GM.check();
        }

        if(other.gameObject.tag=="O"){

            GM.letterCount+=1;
            GM.lettersCollected += "O";
            Destroy(other.gameObject);

            GM.check();
        }

        if(other.gameObject.tag=="P"){

            GM.letterCount+=1;
            GM.lettersCollected += "P";
            Destroy(other.gameObject);

            GM.check();
        }

	}

	IEnumerator stopSlide()
	{
		yield return new WaitForSeconds(0.4f);
		horizontalVelocity = 0;
		controlLocked = false;
	}
}

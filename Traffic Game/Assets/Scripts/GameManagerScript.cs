using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {


    float timer = 0f;
    float timerLag = 0f;

    public GameObject[] intersectionArray;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //time
        timerLag = timer;
        timer += Time.deltaTime;
        if (timerLag < 1f && timer >= 1f)
        {
            timer--;
            timerLag--;
            tick();
        }

        checkForStopLightToggle();
    }

    void checkForStopLightToggle()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("Toggle");
            if (intersectionArray[1].GetComponent<IntersectionScript>().leftLightOn)
                intersectionArray[1].GetComponent<IntersectionScript>().leftLightOn = false;
            else
                intersectionArray[1].GetComponent<IntersectionScript>().leftLightOn = true;

            if (intersectionArray[1].GetComponent<IntersectionScript>().rightLightOn)
                intersectionArray[1].GetComponent<IntersectionScript>().rightLightOn = false;
            else
                intersectionArray[1].GetComponent<IntersectionScript>().rightLightOn = true;
        }
    }

    void tick()
    {
        Debug.Log(timer);
        
        for (int i = 0; i < intersectionArray.Length; i++)
        {
            intersectionArray[i].GetComponent<IntersectionScript>().tick();
        }

        intersectionArray[1].GetComponent<IntersectionScript>().spawnCar("l", 2);
    }
}

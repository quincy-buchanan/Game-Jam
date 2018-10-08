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

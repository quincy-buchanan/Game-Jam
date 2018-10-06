using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {


    float timer = 0f;
    float timerLag = 0f;

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
    }
}

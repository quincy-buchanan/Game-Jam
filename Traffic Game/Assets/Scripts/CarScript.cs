using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {

    //the intersection that the car is trying to reach
    public int destination;

    //the car's current intersection
    public GameObject intersection;
    //which direction (t/b/l/r) the queue the car is in is pointing
    public string queueDirection;
    //the car's current queue within the 
    public CarQueue currentQueue;


	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void reachedDestination()
    {
        Destroy(gameObject);
    }



    public void tick()
    {
        if (queueDirection.Equals("t"))
            gameObject.transform.position = intersection.transform.position + new Vector3(0, currentQueue.GetPositionInQueue(gameObject) + 1); //may need to be different
        if (queueDirection.Equals("b"))
            gameObject.transform.position = intersection.transform.position + new Vector3(0, (currentQueue.GetPositionInQueue(gameObject) * -1) - 1);
        if (queueDirection.Equals("l"))
            gameObject.transform.position = intersection.transform.position + new Vector3((currentQueue.GetPositionInQueue(gameObject) * -1) - 1, 0);
        if (queueDirection.Equals("r"))
            gameObject.transform.position = intersection.transform.position + new Vector3(currentQueue.GetPositionInQueue(gameObject) + 1, 0);

        //remember to do direction of car
    }
}

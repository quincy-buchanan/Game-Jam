using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {

    public int destination;

    public GameObject intersection;
    public string queueDirection;
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
            gameObject.transform.position = intersection.transform.position + new Vector3(0, currentQueue.GetPositionInQueue(gameObject) * 2 + 2); //may need to be different
        if (queueDirection.Equals("b"))
            gameObject.transform.position = intersection.transform.position + new Vector3(0, currentQueue.GetPositionInQueue(gameObject) * -2 - 2);
        if (queueDirection.Equals("l"))
            gameObject.transform.position = intersection.transform.position + new Vector3(currentQueue.GetPositionInQueue(gameObject) * -2 - 2, 0);
        if (queueDirection.Equals("r"))
            gameObject.transform.position = intersection.transform.position + new Vector3(currentQueue.GetPositionInQueue(gameObject) * 2 + 2, 0);

        //remember to do direction of car
    }
}

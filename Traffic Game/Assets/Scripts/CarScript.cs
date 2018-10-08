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
    //the car's current queue within the intersection
    public CarQueue currentQueue;

    Vector3 desiredLocation;
    Vector3 desiredVelocity = Vector3.zero;
    float velCounter = 0f;


	// Use this for initialization
	void Start () {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value);

    }

    public void initPosition()
    {
        if (queueDirection.Equals("t"))
        {
            gameObject.transform.position = intersection.transform.position + new Vector3(-0.4f, currentQueue.GetPositionInQueue(gameObject) + 1); //may need to be different
        }
        if (queueDirection.Equals("b"))
        {
            gameObject.transform.position = intersection.transform.position + new Vector3(0.4f, (currentQueue.GetPositionInQueue(gameObject) * -1) - 1);
        }
        if (queueDirection.Equals("l"))
        {
            gameObject.transform.position = intersection.transform.position + new Vector3((currentQueue.GetPositionInQueue(gameObject) * -1) - 1, 0.4f);
        }
        if (queueDirection.Equals("r"))
        {
            gameObject.transform.position = intersection.transform.position + new Vector3(currentQueue.GetPositionInQueue(gameObject) + 1, -0.4f);
        }

        desiredLocation = gameObject.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        moveTowardsDesiredLocation();
	}

    public void reachedDestination()
    {
        Destroy(gameObject);
    }

    void moveTowardsDesiredLocation()
    {
        if (velCounter < 1f)
        {
            Debug.Log("got there");
            gameObject.transform.position += desiredVelocity * Time.deltaTime;
            velCounter += Time.deltaTime;
        }
        else
        {
            gameObject.transform.position = desiredLocation;
        }
    }


    public void tick()
    {
        //gameObject.transform.position = desiredLocation;

        if (queueDirection.Equals("t"))
        {
            desiredLocation = intersection.transform.position + new Vector3(-0.4f, currentQueue.GetPositionInQueue(gameObject) + 1); //may need to be different
        }
        if (queueDirection.Equals("b"))
        {
            desiredLocation = intersection.transform.position + new Vector3(0.4f, (currentQueue.GetPositionInQueue(gameObject) * -1) - 1);
        }
        if (queueDirection.Equals("l"))
        {
            desiredLocation = intersection.transform.position + new Vector3((currentQueue.GetPositionInQueue(gameObject) * -1) - 1, 0.4f);
        }
        if (queueDirection.Equals("r"))
        {
            desiredLocation = intersection.transform.position + new Vector3(currentQueue.GetPositionInQueue(gameObject) + 1, -0.4f);
        }

        desiredVelocity = desiredLocation - gameObject.transform.position;
        velCounter = 0f;

        //remember to do direction of car
    }
}

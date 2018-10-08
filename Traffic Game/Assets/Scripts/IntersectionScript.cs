using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionScript : MonoBehaviour {

    CarQueue topQueue, bottomQueue, leftQueue, rightQueue;
    public int topQueueSize = 0, bottomQueueSize = 0, leftQueueSize = 0, rightQueueSize = 0;

    public bool topLightOn = false;
    public bool leftLightOn = false;
    public bool rightLightOn = false;
    public bool bottomLightOn = false;

    public GameObject topIntersection, bottomIntersection, leftIntersection, rightIntersection;

	public int intersectionInt;

    public int[] distanceArray = { 99, 99, 99 };

    public GameObject carPrefab;

    // Use this for initialization
    void Start () {
        if (topQueueSize == 0)
        {
            topQueue = null;
        }
        else
        {
            topQueue = new CarQueue(topQueueSize);
        }

        if (bottomQueueSize == 0)
        {
            bottomQueue = null;
        }
        else
        {
            bottomQueue = new CarQueue(bottomQueueSize);
        }

        if (leftQueueSize == 0)
        {
            leftQueue = null;
        }
        else
        {
            leftQueue = new CarQueue(leftQueueSize);
        }

        if (rightQueueSize == 0)
        {
            rightQueue = null;
        }
        else
        {
            rightQueue = new CarQueue(rightQueueSize);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void spawnCar(string dir, int destination)
    {
        if (
            (dir.Equals("l") && leftQueue != null && leftQueue.isFull()) ||
            (dir.Equals("r") && rightQueue != null && rightQueue.isFull()) ||
            (dir.Equals("t") && topQueue != null && topQueue.isFull()) ||
            (dir.Equals("b") && bottomQueue != null && bottomQueue.isFull()))
        {
            Debug.Log("Abort");
            return;
        }

        GameObject newCar = Instantiate(carPrefab);
        //TODO this needs to know which roads it can spawn cars on
        
        if (dir.Equals("t"))
            topQueue.PushCarEnd(newCar);
        if (dir.Equals("r"))
            rightQueue.PushCarEnd(newCar);
        if (dir.Equals("l"))
            leftQueue.PushCarEnd(newCar);
        if (dir.Equals("b"))
            bottomQueue.PushCarEnd(newCar);

        newCar.GetComponent<CarScript>().intersection = gameObject;
        newCar.GetComponent<CarScript>().queueDirection = dir;
        newCar.GetComponent<CarScript>().destination = destination;


        if (dir.Equals("t"))
            newCar.GetComponent<CarScript>().currentQueue = topQueue;
        if (dir.Equals("b"))
            newCar.GetComponent<CarScript>().currentQueue = bottomQueue;
        if (dir.Equals("l"))
            newCar.GetComponent<CarScript>().currentQueue = leftQueue;
        if (dir.Equals("r"))
            newCar.GetComponent<CarScript>().currentQueue = rightQueue;

        newCar.GetComponent<CarScript>().tick();
    }

    public void tick()
    {
        //remember to account for gridlock (each road is full)
        //and collisions

        GameObject carToMove;

		if (topLightOn && topQueue != null)
		{
            carToMove = topQueue.PopCar();
            if (carToMove != null)
            {
                routeCar(carToMove);
                carToMove = null;
            }
		}
        else if (!topLightOn && topQueue != null)
        {
            topQueue.MoveCars();
        }

        if (bottomLightOn && bottomQueue != null)
        {
            carToMove = bottomQueue.PopCar();
            if (carToMove != null)
            {
                routeCar(carToMove);
                carToMove = null;
            }
        }
        else if (!bottomLightOn && bottomQueue != null)
        {
            bottomQueue.MoveCars();
        }

        if (leftLightOn && leftQueue != null)
        {
            carToMove = leftQueue.PopCar();
            if (carToMove != null)
            {
                routeCar(carToMove);
                carToMove = null;
            }
        }
        else if (!leftLightOn && leftQueue != null)
        {
            leftQueue.MoveCars();
        }

        if (rightLightOn && rightQueue != null)
        {
            carToMove = rightQueue.PopCar();
            if (carToMove != null)
            {
                routeCar(carToMove);
                carToMove = null;
            }
        }
        else if (!rightLightOn && rightQueue != null)
        {
            rightQueue.MoveCars();
        }
    }

    void routeCar(GameObject carToMove)
    {
        if (carToMove.GetComponent<CarScript>().destination == intersectionInt)
        {
            carToMove.GetComponent<CarScript>().reachedDestination();
        }
        else
        {
            string shortestRoute = "";
            int shortestRouteValue = 99;

            if (leftIntersection != null)
            {
                int leftDistance = leftIntersection.GetComponent<IntersectionScript>().distanceTo(carToMove.GetComponent<CarScript>().destination);
                if (leftDistance <= shortestRouteValue)
                {
                    shortestRoute = "l";
                    shortestRouteValue = leftDistance;
                }
            }

            if (rightIntersection != null)
            {
                int rightDistance = rightIntersection.GetComponent<IntersectionScript>().distanceTo(carToMove.GetComponent<CarScript>().destination);
                if (rightDistance <= shortestRouteValue)
                {
                    shortestRoute = "r";
                    shortestRouteValue = rightDistance;
                }
            }

            if (topIntersection != null)
            {
                int topDistance = topIntersection.GetComponent<IntersectionScript>().distanceTo(carToMove.GetComponent<CarScript>().destination);
                if (topDistance <= shortestRouteValue)
                {
                    shortestRoute = "t";
                    shortestRouteValue = topDistance;
                }
            }

            if (bottomIntersection != null)
            {
                int bottomDistance = bottomIntersection.GetComponent<IntersectionScript>().distanceTo(carToMove.GetComponent<CarScript>().destination);
                if (bottomDistance <= shortestRouteValue)
                {
                    shortestRoute = "b";
                    shortestRouteValue = bottomDistance;
                }
            }

            if (Equals(shortestRoute, "t"))
            {
                carToMove.GetComponent<CarScript>().intersection = topIntersection;
                carToMove.GetComponent<CarScript>().currentQueue = topIntersection.GetComponent<IntersectionScript>().bottomQueue;
                carToMove.GetComponent<CarScript>().queueDirection = "t";
                topIntersection.GetComponent<IntersectionScript>().bottomQueue.PushCarEnd(carToMove);
                carToMove.GetComponent<CarScript>().tick();
            }
            else if (Equals(shortestRoute, "b"))
            {
                carToMove.GetComponent<CarScript>().intersection = bottomIntersection;
                carToMove.GetComponent<CarScript>().currentQueue = bottomIntersection.GetComponent<IntersectionScript>().topQueue;
                carToMove.GetComponent<CarScript>().queueDirection = "b";
                bottomIntersection.GetComponent<IntersectionScript>().topQueue.PushCarEnd(carToMove);
                carToMove.GetComponent<CarScript>().tick();
            }
            else if (Equals(shortestRoute, "r"))
            {
                carToMove.GetComponent<CarScript>().intersection = rightIntersection;
                carToMove.GetComponent<CarScript>().currentQueue = rightIntersection.GetComponent<IntersectionScript>().leftQueue;
                carToMove.GetComponent<CarScript>().queueDirection = "r";
                rightIntersection.GetComponent<IntersectionScript>().leftQueue.PushCarEnd(carToMove);
                carToMove.GetComponent<CarScript>().tick();
            }
            else if (Equals(shortestRoute, "l"))
            {
                carToMove.GetComponent<CarScript>().intersection = leftIntersection;
                carToMove.GetComponent<CarScript>().currentQueue = leftIntersection.GetComponent<IntersectionScript>().rightQueue;
                carToMove.GetComponent<CarScript>().queueDirection = "l";
                leftIntersection.GetComponent<IntersectionScript>().rightQueue.PushCarEnd(carToMove);
                carToMove.GetComponent<CarScript>().tick();
            }
            else
            {
                Debug.Log("NO SHORTEST PATH!?");
            }
        }

    }

    public int distanceTo(int destination)
    {
        return distanceArray[destination];
    }

    
}

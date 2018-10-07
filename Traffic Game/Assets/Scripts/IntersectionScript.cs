using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntersectionScript : MonoBehaviour {

    CarQueue topQueue, bottomQueue, leftQueue, rightQueue;

    bool topLightOn = false;
    bool leftLightOn = false;
    bool rightLightOn = false;
    bool bottomLightOn = false;

    public IntersectionScript topIntersection, bottomIntersection, leftIntersection, rightIntersection;

	public string intersectionString = "";

    // Use this for initialization
    void Start () {
		leftQueue = new CarQueue (5);
		rightQueue = new CarQueue (5);
		topQueue = null;
		bottomQueue = null;

	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void tick()
    {
		//remember to account for gridlock (each road is full)
		if (topLightOn)
		{
			
		}
    }

	public int distanceTo(string iString)
	{
		if (intersectionString == iString)
		{
			return 0;
		}
		else
		{
			int topIntersectionDistanceTo, bottomIntersectionDistanceTo, leftIntersectionDistanceTo, rightIntersectionDistanceTo;
			int leastDistanceTo = 99;

			if (topIntersection != null)
			{
				topIntersectionDistanceTo = topIntersection.distanceTo (iString);
				if (topIntersectionDistanceTo < leastDistanceTo)
				{
					leastDistanceTo = topIntersectionDistanceTo;
				}
			}

			if (bottomIntersection != null)
			{
				bottomIntersectionDistanceTo = bottomIntersection.distanceTo (iString);
				if (bottomIntersectionDistanceTo < leastDistanceTo)
				{
					leastDistanceTo = bottomIntersectionDistanceTo;
				}
			}

			if (leftIntersection != null)
			{
				leftIntersectionDistanceTo = leftIntersection.distanceTo (iString);
				if (leftIntersectionDistanceTo < leastDistanceTo)
				{
					leastDistanceTo = leftIntersectionDistanceTo;
				}
			}

			if (rightIntersection != null)
			{
				rightIntersectionDistanceTo = rightIntersection.distanceTo (iString);
				if (rightIntersectionDistanceTo < leastDistanceTo)
				{
					leastDistanceTo = rightIntersectionDistanceTo;
				}
			}

			return leastDistanceTo;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarQueue {

    GameObject[] queue;
    int size;
    int numCars;

    public CarQueue(int size)
    {
        this.size = size;
        queue = new GameObject[size];
        for (int i = 0; i < size; i++)
        {
            queue[i] = null;
        }

        numCars = 0;
    }

    public GameObject[] GetQueue()
    {
        return queue;
    }

    public int GetSize()
    {
        return size;
    }

    public int GetNumCars()
    {
        return numCars;
    }

    public int GetPositionInQueue(GameObject c)
    {
        for (int i = 0; i < size; i++)
        {
            if (Object.ReferenceEquals(c, queue[i]))
            {
                return i;
            }

        }
        return -1;
    }
    
    public void PushCar(GameObject c)
    {
        if (numCars < size)
        {
            queue[numCars] = c;
            numCars++;
        }
    }

	public void PushCarEnd(GameObject c)
	{
		if (queue[size - 1] == null)
		{
			queue [size - 1] = c;
			numCars++;
		}
        else
        {
            //Debug.Log("Full");
            //Debug.Log(isFull());
        }
	}

	public void MoveCars()
	{
		for (int i = 0; i < size - 1; i++)
		{
			if (queue[i] == null)
			{
				queue [i] = queue [i + 1];
				queue [i + 1] = null;
                if (queue[i] != null)
                    queue[i].GetComponent<CarScript>().tick(); //this is bad practice
            }
		}
	}

    public GameObject PopCar()
    {
        if (numCars > 0)
        {
            GameObject tempCar = queue[0];
            for (int i = 0; i < size - 1; i++)
            {
                queue[i] = queue[i + 1];
                if (queue[i] != null)
                    queue[i].GetComponent<CarScript>().tick(); //this is bad practice
            }
            queue[size - 1] = null;
            numCars--;
            return tempCar;
        }
        else
        {
            return null;
        }
    }

    public bool isFull()
    {
        return numCars >= size;
    }
}

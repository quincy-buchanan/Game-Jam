using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarQueue {

    Car[] queue;
    int size;
    int numCars;

    public CarQueue(int size)
    {
        this.size = size;
        queue = new Car[size];
        for (int i = 0; i < size; i++)
        {
            queue[i] = null;
        }

        numCars = 0;
    }

    public Car[] GetQueue()
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

    public int GetPositionInQueue(Car c)
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
    
    public void PushCar(Car c)
    {
        if (numCars < size)
        {
            queue[numCars] = c;
            numCars++;
        }
    }

	public void PushCarEnd(Car c)
	{
		if (queue[size] == null)
		{
			queue [size] = c;
			numCars++;
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
			}
		}
	}

    public Car PopCar()
    {
        if (numCars > 0)
        {
            Car tempCar = queue[0];
            for (int i = 0; i < size - 1; i++)
            {
                queue[i] = queue[i + 1];
            }
            queue[size] = null;
            numCars--;
            return tempCar;
        }
        else
        {
            return null;
        }
    }
}

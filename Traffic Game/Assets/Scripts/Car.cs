using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//defunct
public class Car{
    public Car(int origin, int destination, string type, GameObject thisCarScript)
    {
        this.origin = origin;
        this.destination = destination;
        this.type = type;
        this.thisCarScript = thisCarScript;
    }
    public int origin;
    public int destination;
    public string type;

	GameObject thisCarScript;

    public void reachedDestination()
    {
        //TODO
    }
}

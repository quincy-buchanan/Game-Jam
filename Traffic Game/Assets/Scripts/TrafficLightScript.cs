using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrafficLightScript : MonoBehaviour {

    public IntersectionScript intersection;

    public bool leftLightOn;
    public bool rightLightOn;
    public bool topLightOn;
    public bool bottomLightOn;

    public string roadSide;

    private void Start()
    {
        leftLightOn = intersection.leftLightOn;
        rightLightOn = intersection.rightLightOn;
        topLightOn = intersection.topLightOn;
        bottomLightOn = intersection.bottomLightOn;

        if (roadSide == "l")
        {
            ChangeColor(leftLightOn);
        }
        else if (roadSide == "r")
        {
            ChangeColor(rightLightOn);
        }
        else if (roadSide == "t")
        {
            ChangeColor(topLightOn);
        }
        else if (roadSide == "b")
        {
            ChangeColor(bottomLightOn);
        }
    }

    public void ChangeLight()
    {
        if (roadSide == "l")
        {
            leftLightOn = !leftLightOn;
            intersection.leftLightOn = leftLightOn;
            ChangeColor(leftLightOn);
        }
        else if (roadSide == "r")
        {
            rightLightOn = !rightLightOn;
            intersection.rightLightOn = rightLightOn;
            ChangeColor(rightLightOn);
        }
        else if (roadSide == "t")
        {
            topLightOn = !topLightOn;
            intersection.topLightOn = topLightOn;
            ChangeColor(topLightOn);
        }
        else if(roadSide == "b")
        {
            bottomLightOn = !bottomLightOn;
            intersection.bottomLightOn = bottomLightOn;
            ChangeColor(bottomLightOn);
        }
    }

    void ChangeColor(bool lightOn)
    {
        ColorBlock cb = GetComponent<Button>().colors;

        if (lightOn)
        {
            cb.normalColor = Color.green;
            cb.highlightedColor = new Color(0, .5f, 0, 1);
            GetComponent<Button>().colors = cb;
        }
        else
        {
            cb.normalColor = Color.red;
            cb.highlightedColor = new Color(.5f, 0, 0, 1);
            GetComponent<Button>().colors = cb;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BandSelect : MonoBehaviour {

	public int tag;
	public string genre;
	public GameObject info;

	public void ShowInfo()
	{
		info.SetActive(true);
		//more to come...

		GameObject.Find ("HireBandButton").GetComponent<Button> ().interactable = true;
		GameObject.Find ("HireBandButton").GetComponent<HireBand> ().genre = genre;
		GetComponent<Button> ().interactable = false;
	}
}

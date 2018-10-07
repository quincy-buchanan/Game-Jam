using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireBand : MonoBehaviour {

	public int tag;
	public string genre;
	public GameObject venueMenu;

	public void OpenVenueMenu()
	{
		venueMenu.SetActive (true);
	}

	public void SetVenueGenre()
	{
		if (GameObject.Find ("Venue1").GetComponent<HireBand> ().tag == tag) {
			GameObject.Find ("VenueText1").GetComponent<Text> ().text = genre;
		}

		venueMenu.SetActive (false);
	}
}

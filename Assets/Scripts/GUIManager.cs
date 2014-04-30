using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    public GUIText boostsText, scoreText; //creates guitext variables to store boostText and scoreText

    private static GUIManager instance; 

	// Use this for initialization
	void Awake () { //loads all gui text when the application starts
        instance = this;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void SetBoosts(int boosts) 
    {
        instance.boostsText.text = "Ammo: " + boosts.ToString();
	}
}

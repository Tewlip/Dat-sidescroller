using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    public GUIText boostsText, scoreText;

    private static GUIManager instance; 

	// Use this for initialization
	void Start () {
        instance = this;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void SetBoosts(int boosts)
    {
        instance.boostsText.text = "Attacks: " + boosts.ToString();
    }

    public static void SetScore(float score)
    {
        instance.scoreText.text = "Score: " + score.ToString("f0");
    }
}

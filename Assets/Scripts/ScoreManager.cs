using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public Player player;
    public Text points;
    
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Player>();

    //    score.text = "Score: " + PlayerPrefs.GetFloat("Score").ToString();
    }
	
	// Update is called once per frame
	void Update () {
        player.score += Time.deltaTime;
        float points1 = player.score;
        points.text = points1.ToString ();
		
	}
}

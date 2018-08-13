using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CopyOldText : MonoBehaviour {
    public Text score;
	// Use this for initialization
	void Start () {
        Text new_text = GameObject.Find("Text").GetComponent<Text>();
        score = new_text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

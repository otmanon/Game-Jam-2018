using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final_Score : MonoBehaviour {
    public Text final_score;
    public Text final_score_death;
	// Use this for initialization
	void Start () {
        Player player = GameObject.Find("Player").GetComponent<Player>();

        final_score.text = player.score.ToString("00");
        final_score_death.text = final_score.text;
	}
    private void Awake()
    {
        DontDestroyOnLoad(final_score);
    }

}

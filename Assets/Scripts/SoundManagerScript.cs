using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {
    public static AudioClip Bye_Bye_Baby, Eerie_Background_Shit, LambChops, Spannenlanger_Hansel, SpookyTwinkle;
    public static AudioSource audioSrc;

	// Use this for initialization
	void Start () {
        Bye_Bye_Baby = Resources.Load<AudioClip>("Bye_Bye_Baby");
        Eerie_Background_Shit = Resources.Load<AudioClip>("Eerie_Background_Shit");
        LambChops = Resources.Load<AudioClip>("LambChops");
        Spannenlanger_Hansel = Resources.Load<AudioClip>("Spannelanger_Hansel (1)");
        SpookyTwinkle = Resources.Load<AudioClip>("Spooky Twinkle (1)");

        audioSrc = GetComponent<AudioSource>();

        audioSrc.PlayOneShot(Bye_Bye_Baby);
       // audioSrc.PlayOneShot(Eerie_Background_Shit);
        audioSrc.PlayOneShot(LambChops);
        audioSrc.PlayOneShot(Spannenlanger_Hansel);
        audioSrc.PlayOneShot(SpookyTwinkle);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void PlaySound ()
    {
        while (true)
        {
            audioSrc.PlayOneShot (Bye_Bye_Baby);
            audioSrc.PlayOneShot(Eerie_Background_Shit);
            audioSrc.PlayOneShot(LambChops);
            audioSrc.PlayOneShot(Spannenlanger_Hansel);
            audioSrc.PlayOneShot(SpookyTwinkle);
        }
    }
}

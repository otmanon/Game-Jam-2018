using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour {
    public static AudioClip Bye_Bye_Baby, Eerie_Background_Shit, LambChops, Spannenlanger_Hansel, SpookyTwinkle;
    public static AudioSource audioSrc;
    public static AudioClip cake, bear, Billy, Flower, coach, football, Woodrow;
    public static AudioClip teleportSound, throwSound;

	// Use this for initialization
	void Start () {
        Bye_Bye_Baby = Resources.Load<AudioClip>("Bye_Bye_Baby");
        Eerie_Background_Shit = Resources.Load<AudioClip>("Eerie_Background_Shit");
        LambChops = Resources.Load<AudioClip>("LambChops");
        Spannenlanger_Hansel = Resources.Load<AudioClip>("Spannelanger_Hansel (1)");
        SpookyTwinkle = Resources.Load<AudioClip>("Spooky Twinkle (1)");

        cake = Resources.Load<AudioClip>("Cake");
        bear = Resources.Load<AudioClip>("Bear");
        Billy = Resources.Load<AudioClip>("Billy");
        coach = Resources.Load<AudioClip>("CoachCreul");
        football= Resources.Load<AudioClip>("Football");
        Flower = Resources.Load<AudioClip>("Flowers");
        Woodrow = Resources.Load<AudioClip>("Woodrow");

        throwSound = Resources.Load<AudioClip>("Throw");
        teleportSound = Resources.Load<AudioClip>("teleportSound");

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

    public static void PlaySound (string clip)
    {
        if (clip == "cake")
        {
            audioSrc.PlayOneShot (cake);
        }
        if (clip == "bear")
        {
            audioSrc.PlayOneShot(cake);
        }
        if (clip == "billy")
        {
            audioSrc.PlayOneShot(Billy);
        }
        if (clip == "coach")
        {
            audioSrc.PlayOneShot(coach);
        }
        if (clip == "football")
        {
            audioSrc.PlayOneShot(football);
        }
        if (clip == "flower")
        {
            audioSrc.PlayOneShot(Flower);
        }
        if (clip == "woodrow")
        {
            audioSrc.PlayOneShot(Woodrow);
        }
        if (clip == "teleport")
        {
            audioSrc.PlayOneShot(teleportSound);
        }
        if (clip == "throw")
        {
            audioSrc.PlayOneShot(throwSound);
        }
    }
}

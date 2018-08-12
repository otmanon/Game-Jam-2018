using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject cake;
    public GameObject bear;
    public GameObject Billy;
    public GameObject Flower;
    public GameObject coach;
    public GameObject football;
    public GameObject Woodrow;

    // Use this for initialization
    void Start () {
       // SoundManagerScript.PlaySound();
        InvokeRepeating("Spawn_1", 5, 40);
        InvokeRepeating("Spawn_2", 10, 40);
        InvokeRepeating("Spawn_3", 15, 40);
        InvokeRepeating("Spawn_4", 20, 40);
        InvokeRepeating("Spawn_5", 25, 40);
        InvokeRepeating("Spawn_6", 30, 40);
        InvokeRepeating("Spawn_7", 35, 40);
  

    }
	
	// Update is called once per frame
	void Update () {
      //  Instantiate(enemy);
	}
    void Spawn_1 ()
    {
       
        GameObject clone = (GameObject)Instantiate(cake);
        SoundManagerScript.PlaySound("cake");
    }
    void Spawn_2()
    {
        GameObject clone = (GameObject)Instantiate(bear);
        SoundManagerScript.PlaySound("bear");
    }
    void Spawn_3()
    {
        GameObject clone = (GameObject)Instantiate(Billy);
        SoundManagerScript.PlaySound("billy");
    }
    void Spawn_4()
    {
        GameObject clone = (GameObject)Instantiate(Flower);
        SoundManagerScript.PlaySound("flower");
    }
    void Spawn_5()
    {
        GameObject clone = (GameObject)Instantiate(coach);
        SoundManagerScript.PlaySound("coach");
    }
    void Spawn_6()
    {
        GameObject clone = (GameObject)Instantiate(football);
        SoundManagerScript.PlaySound("football");
    }
    void Spawn_7()
    {
        GameObject clone = (GameObject)Instantiate(Woodrow);
        SoundManagerScript.PlaySound("woodrow");
    }
}

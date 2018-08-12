using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemy_1;
    public GameObject enemy_2;
    public GameObject enemy_3;
    public GameObject enemy_4;
    public GameObject enemy_5;
    public GameObject enemy_6;
    public GameObject enemy_7;

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
        GameObject clone = (GameObject)Instantiate(enemy_1);
    }
    void Spawn_2()
    {
        GameObject clone = (GameObject)Instantiate(enemy_2);
    }
    void Spawn_3()
    {
        GameObject clone = (GameObject)Instantiate(enemy_3);
    }
    void Spawn_4()
    {
        GameObject clone = (GameObject)Instantiate(enemy_4);
    }
    void Spawn_5()
    {
        GameObject clone = (GameObject)Instantiate(enemy_5);
    }
    void Spawn_6()
    {
        GameObject clone = (GameObject)Instantiate(enemy_6);
    }
    void Spawn_7()
    {
        GameObject clone = (GameObject)Instantiate(enemy_7);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Player : MonoBehaviour
{
    public Text scoreText;
    public bool endGame = false;
    public float bestScore;
    private Rigidbody2D rb;
    public float score;
   
  


    // Use this for initialization
    void Start()
    {
        
        bestScore = PlayerPrefs.GetFloat("bestScore");
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        if(endGame == true)
        {
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && endGame == false)
        {
            StartCoroutine(GameOver());
           
        }
    }

    IEnumerator GameOver()
    {
        iTween.FadeTo(gameObject, 0f, 2f);
        endGame = true;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
       
        
        PlayerPrefs.SetFloat("Score", score);
        
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}


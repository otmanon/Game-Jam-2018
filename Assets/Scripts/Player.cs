using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    public bool endGame = false;
    private Rigidbody2D rb;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
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
    }
}


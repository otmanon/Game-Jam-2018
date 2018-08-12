using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public GameObject rightEdge;
    public GameObject leftEdge;
    public GameObject doll;
    public GameObject FootballEnemy;
    public float height1 = Screen.height;
    private float width1 = Screen.width;
    private float speed = 0.05f;
    public Rigidbody2D rb;
    bool movingRight;
    Vector3 topRightVector;
    
    // Use this for initialization
    void Start () {
        Vector3 topRightEdges = Camera.main.ScreenToWorldPoint(new Vector3(width1, height1, 0.0f));
        topRightVector = topRightEdges;
        if (Random.Range(-1, 1) < 0) //starts at right condition
        {
            FootballEnemy.transform.position = new Vector3(topRightVector.x - 4f, -topRightEdges.y, 0.0f);
            movingRight = false;
        }
        else //starts at left position
        {
            FootballEnemy.transform.position = new Vector3(-topRightVector.x + 4f, -topRightEdges.y, 0.0f);
            movingRight = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (movingRight == true)
        {
            FootballEnemy.transform.position = new Vector3(FootballEnemy.transform.position.x + speed, FootballEnemy.transform.position.y, 0);

            if (FootballEnemy.transform.position.x >= topRightVector.x  - 2f)
            {
                movingRight = false;
            }
        }
        if (movingRight == false)
        {
            FootballEnemy.transform.position = new Vector3(FootballEnemy.transform.position.x - speed, FootballEnemy.transform.position.y, 0);
            if (FootballEnemy.transform.position.x <= -topRightVector.x + 2f)
            {
                movingRight = true;
            }
        }
    
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Doll") && GameObject.Find("Doll").GetComponent<Throw>().throwing == true)
        {
            Destroy(gameObject);

        }
    }










}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour {
    public GameObject doll;
    private float force = 230f;
    private Vector2 speed = new Vector2(1.5f, 0f);
    private Rigidbody2D rb;
    private
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D> ();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))        {
            // rb.AddForce(transform.right * force);
            Vector2 current_position = doll.transform.position;
            Vector2 mouse_position = Input.mousePosition;
            Vector3 direction = current_position - mouse_position;
            float angle = Mathf.Atan2(direction.x, direction.y);
            float y_force = force * Mathf.Sin(angle);
            float x_force = force * Mathf.Cos(angle);

            throw_Doll(direction, y_force,x_force);
        }
		
	}

    private void throw_Doll (Vector3 direction, float y_force, float x_force){
        if (direction.y < 0)
        {
            rb.AddForce(-(transform.up * y_force));
        }
        else { rb.AddForce(transform.up * y_force); }
        if (direction.x < 0)
        {
            rb.AddForce(-(transform.right * x_force));
        }
        else { rb.AddForce(transform.right * x_force); }
    }
}

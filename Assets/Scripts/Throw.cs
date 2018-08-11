using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour {
    public GameObject doll;
    Camera cam;
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
            Vector3 current_position = (transform.position);
            Vector3 new_position = Camera.main.WorldToScreenPoint(current_position);
            Vector3 mouse_position = Input.mousePosition;
            Vector3 direction = mouse_position - new_position;
            float angle = Mathf.Atan2(direction.y, direction.x);
            float y_force = force * Mathf.Sin(angle);
            float x_force = force * Mathf.Cos(angle);

            throw_Doll(direction, y_force,x_force);
            doll.transform.position = doll.transform.position;
        }
		
	}
	

    private void throw_Doll (Vector3 direction, float y_force, float x_force){
        if (direction.y < 0)
        {
            rb.AddForce((transform.up * y_force));
        }
        else { rb.AddForce(transform.up * y_force); }
        if (direction.x < 0)
        {
            rb.AddForce((transform.right * x_force));
        }
        else { rb.AddForce(transform.right * x_force); }
    }
}

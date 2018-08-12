using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Throw : MonoBehaviour {
    public GameObject doll;
    public GameObject player;
    public bool throwing = false;
    Camera cam;
    private float timer = 0;
    private float force = 230f;
    private Vector2 speed = new Vector2(1.5f, 0f);
    private Rigidbody2D rb;
    private
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D> ();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0;
        rb.gravityScale = 0.0f;
        timer = 0;

    }
	
	// Update is called once per frame
	void Update () {
        
        doll.transform.rotation = Quaternion.Euler(0, 0, doll.transform.rotation.z) ;
        player.transform.rotation = Quaternion.Euler(0, 0, player.transform.rotation.z);

        if (Input.GetMouseButtonDown(0) && throwing == false)
        {
            // rb.AddForce(transform.right * force);
            throwing = true;
            Vector3 current_position = (transform.position);
            Vector3 new_position = Camera.main.WorldToScreenPoint(current_position);
            Vector3 mouse_position = Input.mousePosition;
            Vector3 direction = mouse_position - new_position;
            float angle = Mathf.Atan2(direction.y, direction.x);
            float y_force = force * Mathf.Sin(angle)*Mathf.Abs(direction.y)/100;
            float x_force = force * Mathf.Cos(angle)*Mathf.Abs(direction.x)/100;
            throw_Doll(direction, y_force,x_force);
            doll.transform.position = doll.transform.position;
         }
        if (Input.GetMouseButton(1) && throwing == true)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            rb.gravityScale = 0.3f;
            SoundManagerScript.PlaySound("teleport");
            player.transform.position = new Vector2(doll.transform.position.x - 0.5f, doll.transform.position.y);
            throwing = false;
        }
        if (throwing == false) {
            doll.transform.position = new Vector2(player.transform.position.x + 0.5f, player.transform.position.y);
        }
		
	}
	

    private void throw_Doll (Vector3 direction, float y_force, float x_force){
        SoundManagerScript.PlaySound("throw");
        rb.gravityScale = 0.3f;
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
        StartCoroutine(waitThreeSeconds());
    }
    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSecondsRealtime(2);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
        rb.gravityScale = 0.3f;
        SoundManagerScript.PlaySound("teleport");
        player.transform.position = new Vector2(doll.transform.position.x - 0.5f , doll.transform.position.y );
        throwing = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

    public float speed;
    public GameObject projectile;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {
        adjustCamera();
        move();
        shoot();

       
		
	}

    // chec if the character is shooting
    void shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject proj = Instantiate(projectile);
            proj.transform.position = transform.position + 0.1f * transform.forward;
            proj.GetComponent<RangeAttackController>().speed = 10;
            proj.GetComponent<RangeAttackController>().direction = transform.forward;
        }

    }

    // check if the character is moving
    void move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.forward * -1 * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * -1 * speed * Time.deltaTime);
        }
    }

    // change Camera position to always focus on the character
    void adjustCamera()
    {
        Camera.main.transform.position = transform.position + Vector3.forward * -1 * 5 + Vector3.up * 1;
    }
}

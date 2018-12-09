using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnemyController : MonoBehaviour {

    private int direction;
    private float speed;

	// Use this for initialization
	void Start () {
        float random = Random.Range(0, 10);
        if (random < 5) direction = 1; else direction = -1;
        speed = 5.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > 10 || transform.position.x < -10)
            direction = direction * -1;
        if (direction == 1)
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        else
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        transform.Translate(direction * speed * Time.deltaTime * transform.right);
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        direction = direction * -1;
    }
}

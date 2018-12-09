using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float speed;
    private GokuController goku;

	// Use this for initialization
	void Start () {
        goku = GameObject.FindGameObjectWithTag("Player").GetComponent<GokuController>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.up * -1 *  speed * Time.deltaTime);		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EasyEnemy"))
        {
            goku.collect(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("MediumEnemy"))
        {
            goku.collect(collision.gameObject);
            Destroy(gameObject);

        }

        if (collision.gameObject.CompareTag("HardEnemy"))
        {
            goku.collect(collision.gameObject);
            Destroy(gameObject);

        }
    }
}

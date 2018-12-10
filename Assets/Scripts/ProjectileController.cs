using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {

    public float speed;
    private GokuController goku;
	private SpriteRenderer sprite;

	private int sideProjectile;
	// Use this for initialization
	void Start () {
        goku = GameObject.FindGameObjectWithTag("Player").GetComponent<GokuController>();
		sideProjectile = goku.facing;

		if (sideProjectile == 2 || sideProjectile == 3)
		{
			transform.Rotate(0,0,90);
			if (sideProjectile == 2)
				GetComponent<SpriteRenderer>().flipX = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (sideProjectile == 1)
		{
			transform.Translate(transform.up * -1 *  speed * Time.deltaTime);
		}
	    else if(sideProjectile == -1)
	        transform.Translate(transform.up * speed * Time.deltaTime);
	    else if(sideProjectile == 2)
	        transform.Translate(transform.right* speed * Time.deltaTime);
		else if (sideProjectile == 3)
			transform.Translate(transform.right * -1 * speed * Time.deltaTime);
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EasyEnemy"))
        {
            goku.collect(collision.gameObject);
            
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

		if(collision.gameObject.CompareTag("Boss"))
		{
			collision.gameObject.SendMessage("shootBoss");
			Destroy(gameObject);
		}
	    
	    if(collision.gameObject.CompareTag("Wall"))
	    {
		    Destroy(gameObject);
	    }
    }
}

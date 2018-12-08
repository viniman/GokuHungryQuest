using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GokuController : MonoBehaviour {

    public float speed;
    private int coinCounter;

    private GameObject projectilePreFab;

	// Use this for initialization
	void Start () {
        coinCounter = 0;

        projectilePreFab = Resources.Load("Projectile") as GameObject;
		
	}
	
	// Update is called once per frame
	void Update () {

        handleInput();
	}

    // Handles input from keyboard
    void handleInput()
    {
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(transform.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(transform.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(transform.up * -1 * speed * Time.deltaTime);
            
        if (Input.GetKeyDown(KeyCode.Space))
            shoot();
    }

    void shoot()
    {
        GameObject proj = Instantiate(projectilePreFab);
        proj.transform.position = transform.position;
    }

    void attack()
    {

    }

    void die()
    {

    }

    public void collect(GameObject go)
    {
        Destroy(go);
        coinCounter += 1;
    }

    void OnCollisionEnter2D(Collision2D collider){

        if (collider.gameObject.CompareTag("EasyEnemy"))
            Debug.Log("Colliding with easy enemy");
        if (collider.gameObject.CompareTag("MediumEnemy"))
            die();
        if (collider.gameObject.CompareTag("Coin"))
            collect(collider.gameObject);
                
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GokuController : MonoBehaviour {

    public float speed;
    private int coinCounter;

    private int direction; // 1 while going right, -1 while going left, 0 while going up or down
    private int facing; // 1 while going up, -1 while going down, 0 while going right or left
    private bool walking;

    private GameObject projectilePreFab;
    private Animator animator;

	// Use this for initialization
	void Start () {
        coinCounter = 0;
        walking = false;
        direction = 0;
        facing = 1;

        projectilePreFab = Resources.Load("Projectile") as GameObject;
        animator = GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {

        handleInput();

        // changes angle according to current direction
        if (direction == 1) transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f); 
        if (direction == -1) transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        // changes animation according to current move
        walking = (direction != 0 || facing != 0);
        animator.SetBool("walking", walking);
        animator.SetInteger("facing", facing);


	}

    // Handles input from keyboard
    void handleInput()
    {
        direction = 0;
        facing = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
            direction = -1;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
            facing = 1;
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            /// Menor altura no campo de visão da câmera
            float lowerBound = Camera.main.transform.position.y - Camera.main.orthographicSize;

            /// Só move o Goku pra baixo dentro da visão da câmera
            if(transform.position.y > lowerBound + 1){
                transform.Translate(transform.up * -1 * speed * Time.deltaTime);
                facing = -1;
            }
        }
            
        if (Input.GetKeyDown(KeyCode.Space))
            shoot();
    }

    void shoot()
    {
        GameObject proj = Instantiate(projectilePreFab);
        Physics2D.IgnoreCollision(proj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        proj.transform.position = transform.position;
    }

    void attack()
    {

    }

    void die()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(2);

    }

    public void collect(GameObject go)
    {
        Destroy(go);
        coinCounter += 1;
    }

    void OnCollisionEnter2D(Collision2D collider){

        if (collider.gameObject.CompareTag("EasyEnemy"))
            Debug.Log("Colliding with easy enemy");
        if (collider.gameObject.CompareTag("MediumEnemy") || collider.gameObject.CompareTag("HardEnemy"))
            die();
        if (collider.gameObject.CompareTag("Coin"))
            collect(collider.gameObject);
                
    }
    
}

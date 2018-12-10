using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GokuController : MonoBehaviour {

    public float speed;
    
    public int direction; // 1 while going right, -1 while going left, 0 while going up or down
    public int facing; // 1 while going up, -1 while going down, 0 while going right or left
    //2 right 3 left
    
    private bool walking;
    private int coinCounter;

    private GameObject projectilePreFab;
    private Animator animator;

    void Awake()
    {
        coinCounter = CrossSceneInfo.coinsCollected;
        transform.position = CrossSceneInfo.pointToSpawn;
        /// TODO: Adicionar o estado do Goku
    }

	// Use this for initialization
	void Start () {
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
        //walking = (direction != 0 || facing != 0);
        animator.SetBool("walking", walking);
        animator.SetInteger("facing", facing);


	}

    // Handles input from keyboard
    void handleInput()
    {
        direction = 0;
        //facing = 0;
        walking = false;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
            direction = 1;
            facing = 2;
            walking = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
            direction = -1;
            facing = 3;
            walking = true;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.up * speed * Time.deltaTime);
            facing = 1;
            walking = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            /// Menor altura no campo de visão da câmera
            float lowerBound = Camera.main.transform.position.y - Camera.main.orthographicSize;

            /// Só move o Goku pra baixo dentro da visão da câmera
            if(transform.position.y > lowerBound + 0.5){
                transform.Translate(transform.up * -1 * speed * Time.deltaTime);
                facing = -1;
                
            }
            walking = true;
        }
            
        if (Input.GetKeyDown(KeyCode.Space))
            shoot();


        if(Input.GetKeyDown(KeyCode.S)) // TODO: Mudar pra salvar quando pega um item
        {
            SaveLoadController.SaveGame(SceneManager.GetActiveScene().buildIndex, transform.position,
                                        coinCounter, 1); // TODO: Passar o estado atual do Goku

            Debug.Log("Jogo salvo!");
        }
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
        Debug.Log("Coins: " + coinCounter);
    }

    void OnCollisionEnter2D(Collision2D collider){

        if (collider.gameObject.CompareTag("EasyEnemy"))
            Debug.Log("Colliding with easy enemy");

        if (collider.gameObject.CompareTag("MediumEnemy") ||
            collider.gameObject.CompareTag("HardEnemy") || collider.gameObject.CompareTag("Boss"))
            die();
            
        if (collider.gameObject.CompareTag("Coin"))
            collect(collider.gameObject);
                
        if(collider.gameObject.CompareTag("BossProjectile"))
        {
            Destroy(collider.gameObject);
            die();
        }
    }
    
}

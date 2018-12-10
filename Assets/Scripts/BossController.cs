using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
	public GameObject projectile;
	public float speed;

	/// Tempo em segundos do intervalo entre os tiros
	public float minShotInterval;
	public float maxShotInterval;

	private float health;
	private float lastShotTime;

	private Vector3 direction;

	public GameObject siriCascudo;

	// Use this for initialization
	void Start ()
	{
		if(Random.value < 0.5)
			direction = Vector3.right;
		else
			direction = Vector3.left;

		health = 100;
		lastShotTime = Time.time;

		siriCascudo.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!this)
			return;
		
		if(Random.value < 0.01) // Troca de direção
			direction = -direction;

		transform.Translate(direction * speed * Time.deltaTime);

		if(Time.time - lastShotTime >= Random.Range(minShotInterval, maxShotInterval))
		{
			shootProjectile();
			lastShotTime = Time.time;
		}
	}

	void shootProjectile()
	{	
		GameObject instance = Instantiate(projectile);
		if(this) instance.transform.position = transform.position;
		if(this) instance.transform.up = GameObject.Find("Goku").transform.position - transform.position;
		instance.transform.Rotate(new Vector3(0, 0, Random.Range(-30, 30)));
	}

	void killBoss()
	{
		Destroy(gameObject);
		siriCascudo.SetActive(true);
	}

	void shootBoss()
	{
		health -= 5;
		health *= 0.95f;

		if(health > 0)
			Debug.Log("Boss health: " + health);
		else
			killBoss();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Wall"))
			direction = -direction;
	}
}

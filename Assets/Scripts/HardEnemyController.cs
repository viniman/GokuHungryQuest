using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardEnemyController : MonoBehaviour
{
	public float speed;

	/// Distância que o inimigo deve estar do jogador para começar a segui-lo
	public float distanceToPlayer;

	private GameObject goku;

	// Use this for initialization
	void Start ()
	{
		goku = GameObject.Find("Goku");
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(goku && Vector3.Distance(transform.position, goku.transform.position) < distanceToPlayer)
		{
			transform.Translate( Vector3.Normalize(goku.transform.position - transform.position) *
								speed * Time.deltaTime );
		}
	}
}

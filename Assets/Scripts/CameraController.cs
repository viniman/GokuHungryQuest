using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;
	private float previousPlayerY;
	private float playerOffsetY;

	// Use this for initialization
	void Start ()
	{
		previousPlayerY = player.position.y;
		playerOffsetY = -previousPlayerY;
		transform.position = new Vector3(0, previousPlayerY + playerOffsetY, -10);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(player.position.y > previousPlayerY) // Câmera só anda pra frente
		{
			transform.position = new Vector3(0, player.position.y + playerOffsetY, -10);
			previousPlayerY = player.position.y;
		}
	}
}

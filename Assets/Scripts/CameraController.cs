using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;
	public float playerOffsetY;

	private float previousPlayerY;

	// Use this for initialization
	void Start ()
	{
		previousPlayerY = player.position.y;
		float cameraY = previousPlayerY + playerOffsetY;
		Debug.Log("PlayerY: " + previousPlayerY);
		Debug.Log("CameraY: " + cameraY);

		/// Ponto mais alto visível pela câmera
		float cameraUpperBound = Camera.main.orthographicSize + cameraY;

		/// Ponto mais alto da fase
		float levelUpperBound = GameObject.Find("Floor").GetComponent<Renderer>().bounds.max.y;

		/// Verifica se a câmera não vai spawnar fora da fase
		if(cameraUpperBound < levelUpperBound - 1)
			transform.position = new Vector3(0, cameraY, -10);
		else
			transform.position = new Vector3(0, levelUpperBound - Camera.main.orthographicSize - 1, -10);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(player && player.position.y > previousPlayerY) // Câmera só anda pra frente
		{
			/// Ponto mais alto visível pela câmera
			float cameraUpperBound = Camera.main.orthographicSize + transform.position.y;

			/// Ponto mais alto da fase
			float levelUpperBound = GameObject.Find("Floor").GetComponent<Renderer>().bounds.max.y;

			/// Só move a câmera se ela estiver dentro dos limites da fase
			if(cameraUpperBound < levelUpperBound - 1)
			{
				transform.position = new Vector3(0, player.position.y + playerOffsetY, -10);
				previousPlayerY = player.position.y;
			}
		}
	}
}

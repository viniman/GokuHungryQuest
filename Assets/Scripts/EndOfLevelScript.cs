using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfLevelScript : MonoBehaviour
{
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "Goku")
		{
			/// TODO fim da fase
			Debug.Log("Fase concluida!");
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	public GameObject easyEnemy;
	public GameObject mediumEnemy;
	public GameObject hardEnemy;

	public GameObject coin;

	/// Indica quantos inimigos (mais ou menos) serão renderizados em cada bloco de dimensão 10x10
	public float enemiesPer10x10;

	/// Indica quantas moedas (mais ou menos) serão renderizadas em cada bloco de dimensão 10x10
	public float coinsPer10x10;

	// Use this for initialization
	void Start ()
	{
		renderEnemies();
		renderCoins();
	}

	void renderEnemies()
	{
		Renderer renderer = GetComponent<Renderer>();
		float levelArea = renderer.bounds.size.x * renderer.bounds.size.y;

		/// Número total de inimigos a serem criados na fase, levelArea / 100 representa quantos
		/// blocos de 10x10 cabem na fase
		int enemiesToRender = Mathf.FloorToInt( (levelArea / 100) * enemiesPer10x10 );

		float maxX = renderer.bounds.max.x - 2;
		float maxY = renderer.bounds.max.y - 2;
		float minX = renderer.bounds.min.x + 2;
		float minY = renderer.bounds.min.y + 2;

		for(int i=0; i < enemiesToRender; i++)
		{
			GameObject enemy;

			if( Random.value < 0.75 )
				enemy = Instantiate(easyEnemy);
			else if( Random.value < 0.75 )
				enemy = Instantiate(mediumEnemy);
			else
				enemy = Instantiate(hardEnemy);

			Vector3 enemyPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);

			enemy.transform.position = enemyPosition;
		}
	}

	void renderCoins()
	{
		Renderer renderer = GetComponent<Renderer>();
		float levelArea = renderer.bounds.size.x * renderer.bounds.size.y;

		/// Número total de moedas a serem criadas na fase, levelArea / 100 representa quantos
		/// blocos de 10x10 cabem na fase
		int coinsToRender = Mathf.FloorToInt( (levelArea / 100) * coinsPer10x10 );

		float maxX = renderer.bounds.max.x - 2;
		float maxY = renderer.bounds.max.y - 2;
		float minX = renderer.bounds.min.x + 2;
		float minY = renderer.bounds.min.y + 2;

		for(int i=0; i < coinsToRender; i++)
		{
			GameObject coinInstance = Instantiate(coin);

			Vector3 coinPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY),
												coin.transform.position.z);

			coinInstance.transform.position = coinPosition;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

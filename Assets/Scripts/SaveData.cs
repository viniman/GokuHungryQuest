using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData
{
	public int level;

	public float positionOnLevelX;
	public float positionOnLevelY;
	public float positionOnLevelZ;

	public Vector3 positionOnLevel()
	{
		return new Vector3(positionOnLevelX, positionOnLevelY, positionOnLevelZ);
	}

	public int coinsCollected;
	public int gokuState;


	public SaveData(int level, Vector3 positionOnLevel, int coinsCollected, int gokuState)
	{
		this.level = level;

		this.positionOnLevelX = positionOnLevel.x;
		this.positionOnLevelY = positionOnLevel.y;
		this.positionOnLevelZ = positionOnLevel.z;

		this.coinsCollected = coinsCollected;
		this.gokuState = gokuState;
	}
}

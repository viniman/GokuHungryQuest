using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveLoadController
{
	public static void SaveGame(int level, Vector3 positionOnLevel, int coinsCollected, int gokuState)
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.OpenWrite(Application.persistentDataPath + "/save.dat");

		SaveData saveData = new SaveData(level, positionOnLevel, coinsCollected, gokuState);

		bf.Serialize(file, saveData);
		file.Close();

		Debug.Log(Application.persistentDataPath);
	}


	// Retorna um objeto contendo as informações salvas se existirem e null se não existe um jogo salvo
	public static SaveData LoadGame()
	{
		try
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.OpenRead(Application.persistentDataPath + "/save.dat");
			SaveData saveData = bf.Deserialize(file) as SaveData;
			file.Close();

			return saveData;
		}
		catch
		{
			return null;
		}
	}
}

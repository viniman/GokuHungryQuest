using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    public GameObject loadButton;

    void Start()
    {
        SaveData saveData = SaveLoadController.LoadGame();

        if(saveData != null)
            loadButton.SetActive(true);
    }

    public void PlayGame()
    {
        CrossSceneInfo.level = 1; // 1 no ProjectSettings setada como a primeira cena do Jogo
        CrossSceneInfo.pointToSpawn = new Vector3(0, -3, 0);
        CrossSceneInfo.coinsCollected = 0;
        CrossSceneInfo.gokuState = 1; // Estado normal do Goku

        SceneManager.LoadScene(CrossSceneInfo.level);
    }

    public void LoadGame()
    {
        SaveData saveData = SaveLoadController.LoadGame();

        CrossSceneInfo.level = saveData.level;
        CrossSceneInfo.pointToSpawn = saveData.positionOnLevel();
        CrossSceneInfo.coinsCollected = saveData.coinsCollected;
        CrossSceneInfo.gokuState = saveData.gokuState;

        SceneManager.LoadScene(CrossSceneInfo.level);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ShowCredits()
    {
        SceneManager.LoadScene(3);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }
}

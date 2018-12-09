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
        {
            CrossSceneInfo.level = saveData.level;
            CrossSceneInfo.pointToSpawn = saveData.positionOnLevel();
            CrossSceneInfo.coinsCollected = saveData.coinsCollected;
            CrossSceneInfo.gokuState = saveData.gokuState;

            loadButton.SetActive(true);
        }
        else
        {
            CrossSceneInfo.level = 1; // 1 no ProjectSettings setada como a primeira cena do Jogo
            CrossSceneInfo.pointToSpawn = new Vector3(0, -3, 0);
            CrossSceneInfo.coinsCollected = 0;
            CrossSceneInfo.gokuState = 1; // Estado normal do Goku
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
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

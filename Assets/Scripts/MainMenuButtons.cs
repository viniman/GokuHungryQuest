using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour {

    public GameObject loadButton;

    void Start()
    {
        //Verificar aqui se existe algum jogo salvo
        //if(){
        loadButton.SetActive(true);
        //}
    }

    public void PlayGame()
    {
        //1 no ProjectSettings setada como a primeira cena do Jogo
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

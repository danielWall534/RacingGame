using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Sprite selectedCar;

    void Start()
    {
        //make this object presistent
        //this object will be created once and transferred into every scene
        DontDestroyOnLoad(this);
    }

    //will be called by the btnQuit on the main menu
    public void QuitGame()
    {
        Application.Quit();
    }

    //will be called by the btnPlay and btnMulti on the main menu
    public void LoadScene(string sceneName)
    {
        //Load the scene with the name passed in(SceneName)
        SceneManager.LoadScene(sceneName);
    }
}

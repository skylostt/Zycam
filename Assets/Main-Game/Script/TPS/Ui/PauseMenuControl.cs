using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuControl : MonoBehaviour
{

    private GameManager manager;
    private void Start()
    {
        manager = GameManager.instance;
    }





    public void switchscene(string _sceneName)
    {
        manager.switchscene(_sceneName);
        Time.timeScale = 1f;

    }


    public void Quit()
    {
        manager.Quit();
    }

}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//씬 전환을 위해 필요한 SceneManagement

public class connectScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void loadSceneLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void loadSceneInGame()
    {
        SceneManager.LoadScene("Lv1");
    }
    public void loadSceneSettingWindow()
    {
        SceneManager.LoadScene("SettingWindow");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
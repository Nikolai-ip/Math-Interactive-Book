using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private List<string> _sceneNames;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

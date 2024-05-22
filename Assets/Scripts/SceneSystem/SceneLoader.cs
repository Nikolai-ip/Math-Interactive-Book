using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private List<string> _sceneNames;

    private void OnValidate()
    {
        #if UNITY_EDITOR
        _sceneNames = EditorBuildSettings.scenes
            .Where(scene => scene.enabled)
            .Select(scene => System.IO.Path.GetFileNameWithoutExtension(scene.path))
            .ToList();
            #endif
    }

    public void LoadScene(int sceneIndex)
    {
        if (sceneIndex >= 0 && sceneIndex < _sceneNames.Count)
        {
            SceneManager.LoadScene(_sceneNames[sceneIndex]);
        }
        else
        {
            Debug.LogError("Scene index out of range");
        }
    }
}

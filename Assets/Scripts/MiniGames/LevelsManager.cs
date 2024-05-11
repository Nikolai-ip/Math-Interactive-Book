using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsManager : MonoBehaviour
{
    [SerializeField] private List<string> _levelNames;
    [SerializeField] private bool _debug;
    public void LoadNextScene()
    {
        int index = _levelNames.IndexOf(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(_levelNames[index+1]);
    }
    private void OnGUI()
    {
        if (_debug)
            if (GUI.Button(new Rect(0, 0, 100, 50), "LoadNextScene"))
            {
                LoadNextScene();
            }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelloadButtons : MonoBehaviour
{
    [SerializeField] Button button;
    public string scenename;
private void Start() {
    button.onClick.AddListener(playscene);
}

    private void playscene()
    {
        SceneManager.LoadScene(scenename);
    }

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameover : MonoBehaviour
{
    [SerializeField] Button play,quit;
    

    private void Start() {
        play.onClick.AddListener(playcurrentscene);
        quit.onClick.AddListener(playmenuscene);
    }

    private void playcurrentscene()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void playmenuscene()
    {
       SceneManager.LoadScene(0);
    }
}

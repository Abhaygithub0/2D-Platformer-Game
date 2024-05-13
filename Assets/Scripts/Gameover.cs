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
        SoundManager.Instance.play(soundplaces.buttonclick);
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void playmenuscene()
    {
         SoundManager.Instance.play(soundplaces.buttonclick);
       SceneManager.LoadScene(0);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCompleteButtons : MonoBehaviour
{
    [SerializeField] Button play,restart,menu;
    
    

    private void Start() {
        play.onClick.AddListener(playnextscene);
        restart.onClick.AddListener(playcurrentscene);
        menu.onClick.AddListener(playmenuscene);
    }

    private void playnextscene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int lastscenecount=SceneManager.sceneCountInBuildSettings;
        if (currentSceneIndex<lastscenecount-1){
             int nextSceneIndex = currentSceneIndex + 1;
             SoundManager.Instance.play(soundplaces.buttonclick);
            SceneManager.LoadScene(nextSceneIndex);
        }
        else{
            Debug.Log("No next scene");
        }
        // Calculate the index for the next scene
        
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

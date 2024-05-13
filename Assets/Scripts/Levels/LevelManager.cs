
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance{ get{ return instance; } }

    private string Level1 = "Level1";

    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if(GetLevelStatus(Level1) == Levelstatus.Locked)
        {
            SetLevelStatus(Level1, Levelstatus.Unlocked);
        }
    }

    public Levelstatus GetLevelStatus(string levelName)
    {
        Levelstatus levelStatus = (Levelstatus) PlayerPrefs.GetInt(levelName);
        return levelStatus;
    }

    public void SetLevelStatus(string levelName, Levelstatus levelStatus)
    {
        PlayerPrefs.SetInt(levelName, (int) levelStatus);
    }

    public void SetCurrentLevelComplete()
    {
        SetLevelStatus(SceneManager.GetActiveScene().name, Levelstatus.Completed);

        string nextSceneName = NameFromIndex(SceneManager.GetActiveScene().buildIndex + 1);
        SetLevelStatus(nextSceneName, Levelstatus.Unlocked);
    }

    private string NameFromIndex(int BuildIndex)
{
    string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
    int slash = path.LastIndexOf('/');
    if (slash == -1) return "";  // Slash not found, return empty string or handle error

    string name = path.Substring(slash + 1);
    int dot = name.LastIndexOf('.');
    if (dot == -1) return name;  // Dot not found, return the whole name

    // Check to avoid negative length for substring
    if (dot > 0) 
    {
        return name.Substring(0, dot);
    }
    else
    {
        return "";  // Dot is at the start, return empty string or handle error
    }
}

}



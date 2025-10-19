using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //public void LoadGameScene()
    //{
    //    SceneManager.LoadScene("MenuScene");  // nazwa sceny (zapisana w Build Settings)
    //}

    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
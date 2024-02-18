using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

public class AsyncLoader : MonoBehaviour
{
    [Header("Menu Screens")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject mainMenu;

    [Header("Slider")]
    [SerializeField] private Slider loadingSlider;
    
    
   public void retryButton()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        string activeSceneName = SceneManager.GetSceneByBuildIndex(activeSceneIndex).name;

        PlayButton(activeSceneName);
    }

    public void MenuPlayButton()
    {
        int levelCount = 0;
        int highestLevelNumber = 0;
        while (PlayerPrefs.HasKey("Level" + (++levelCount)))
        {
            highestLevelNumber = levelCount;
        }
        string levelToLoad = "Level" + highestLevelNumber;

        if (highestLevelNumber == 0)
        {

            PlayButton("Level1");
        }
        else
        {
            PlayButton(levelToLoad);
        }
    }

    public void NextLevelButton()
    {
            string currentSceneName = SceneManager.GetActiveScene().name;
            int currentSceneNumber = ExtractSceneNumber(currentSceneName);
            int nextSceneNumber = currentSceneNumber + 1;
            string nextSceneName = "Level" + nextSceneNumber.ToString();
            PlayButton(nextSceneName);  
    }
    private int ExtractSceneNumber(string sceneName)
    {
        Match match = Regex.Match(sceneName, @"\d+");
        return match.Success ? int.Parse(match.Value) : 0;
    }


    public void PlayButton(string level)
    {
       

        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);


        StartCoroutine(LoadLevelAsync(level));
    }

    
    
    IEnumerator LoadLevelAsync(string level)
    {
        Time.timeScale = 1f;
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(level);
        Time.timeScale = 1f;
        while (!loadOperation.isDone)
        {
            float progressValue = Mathf.Clamp01(loadOperation.progress / 0.9f);
            loadingSlider.value = progressValue;
            yield return null;
        }
    }

   


}

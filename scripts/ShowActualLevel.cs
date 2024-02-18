using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowActualLevel : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int activeSceneIndex = SceneManager.GetActiveScene().buildIndex;

        string activeSceneName = SceneManager.GetSceneByBuildIndex(activeSceneIndex).name;
        displayText.text = activeSceneName;
    }
}

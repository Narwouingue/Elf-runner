using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destroyLevelMenu : MonoBehaviour
{


    [SerializeField] GameObject levelMenu;
    // Start is called before the first frame update

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        DontDestroyOnLoad(gameObject);
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        

        if (sceneName != "menu")
        {
            Destroy(levelMenu);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dontDestroyBackground : MonoBehaviour
{
    public static dontDestroyBackground instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if you are in a level scene
        string sceneName = SceneManager.GetActiveScene().name;
        Regex regex = new Regex(@"^Level\d+$");
        if (regex.IsMatch(sceneName))
        {
            // Destroy the object
            Destroy(gameObject);
        }

        
    }
}

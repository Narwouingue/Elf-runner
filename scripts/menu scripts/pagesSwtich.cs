using System;


using System.Text.RegularExpressions;

using UnityEngine;

using UnityEngine.SceneManagement;


public class pagesSwtich : MonoBehaviour
{
    public static pagesSwtich instance;
    public int sharedVariable;
    [SerializeField] GameObject[] pages;






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


        sharedVariable = PlayerPrefs.GetInt("sharedVariable", 0);
        Debug.Log(sharedVariable);
        pages[sharedVariable].SetActive(true);






    }
    



    private void Update()
    {

        

        PlayerPrefs.SetInt("sharedVariable", sharedVariable);
    }    
}

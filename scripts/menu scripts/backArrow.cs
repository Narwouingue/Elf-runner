using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backArrow : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject LevelMenu;
    [SerializeField] GameObject SettingsMenu;




    void Start()
    {

    }
    public void OnButtonClick()
    { 
        SettingsMenu.SetActive(false);
        LevelMenu.SetActive(false);
        mainMenu.SetActive(true);
        
        
    }
}

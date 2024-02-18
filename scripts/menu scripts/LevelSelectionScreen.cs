using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class LevelSelectionScreen : MonoBehaviour
{

    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject LevelMenu;




    void Start()
    {
        
    }
    public void Click()
    {
        mainMenu.SetActive(false);
        LevelMenu.SetActive(true);
    }





}



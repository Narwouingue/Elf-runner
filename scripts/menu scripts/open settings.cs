using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opensettings : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject SettingsMenu;




    void Start()
    {

    }
    public void Click()
    {
        mainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }
}

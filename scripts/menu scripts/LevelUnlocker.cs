using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{

    public string level;
    public Button button;
    public void Start()
    {

        PlayerPrefs.SetInt("Level1", 1);
        customStart(level);
    }


    public void customStart(string level)
    {
        button = GetComponent<Button>();


        if (PlayerPrefs.GetInt(level) == 1)
        {

            button.interactable = true;
        }

        else
        {
            Debug.Log("niveau non débloqué");
        }
    }
}

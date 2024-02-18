using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnMainMenu : MonoBehaviour
{
    public void goToLevel()
    {
        Time.timeScale = 1f;
        
        SceneManager.LoadScene("menu");
    }

}

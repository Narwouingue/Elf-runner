using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMenuMusic : MonoBehaviour
{
    public static PlayMenuMusic instance;
    
    void Start()
    {
        AudioListener.pause = false;
        AudioManager.instance.PlayMusic("MenuMusic");
        AudioManager.instance.stopSFX();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

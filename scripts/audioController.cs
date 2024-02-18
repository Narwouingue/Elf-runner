using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;



public class audioController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;

    private void Update()
    {
        PlayerPrefs.SetFloat("sfxVolume", _sfxSlider.value);
        PlayerPrefs.SetFloat("musicVolume", _musicSlider.value);
        PlayerPrefs.Save();

    }

    private void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 1);
        _sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 1);
    }
    public void musicVolume()
    {
        
        
        
        AudioManager.instance.mVolume(_musicSlider.value);
    }

    public void sfxVolume()
    {
       
        
        
        AudioManager.instance.sVolume(_sfxSlider.value);
    }




}


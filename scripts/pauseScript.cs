using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject resumeButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("123")]
    [SerializeField] private GameObject number1;
    [SerializeField] private GameObject number2;
    [SerializeField] private GameObject number3;


    private float timeScaleBeforePause;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
    }

    public void menuOn() //Click() pour le mettre
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        pauseButton.SetActive(false);
        resumeButton.SetActive(true);
        pauseMenu.SetActive(true);

    }

    public void menuOff() //Pour l'enlever
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        resumeButton.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class counter : MonoBehaviour
{

    [SerializeField] GameObject[] pages;
    public TextMeshProUGUI displayText; // Reference to the TextMeshProUGUI component
    private pagesSwtich gameManager;
    private void Start()
    {
        gameManager = pagesSwtich.instance;
    }

    private void Update()
    {
        // Change the text dynamically
        displayText.text = gameManager.sharedVariable+1 + " / " + pages.Length;
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextPageMenu : MonoBehaviour
{

    private pagesSwtich gameManager;

    private void Start()
    {
        gameManager = pagesSwtich.instance;
    }

   

    [SerializeField] GameObject[] pages;
    



    public void OnButtonClick()
    {
        // Hide the current page
        pages[gameManager.sharedVariable].SetActive(false);

        // Increment the page index or wrap around to the first page
        gameManager.sharedVariable = (gameManager.sharedVariable + 1) % pages.Length;

        // Show the next page
        pages[gameManager.sharedVariable].SetActive(true);

        
    }
}

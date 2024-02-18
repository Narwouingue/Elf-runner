using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuBackground : MonoBehaviour
{

    [SerializeField] GameObject background1;
    [SerializeField] GameObject background2;
    [SerializeField] GameObject background3;
    [SerializeField] GameObject background4;
    [SerializeField] GameObject background5;


    // Start is called before the first frame update
    void Awake()
    {
        int levelCount = 0;
        int highestLevelNumber = 0;
        while (PlayerPrefs.HasKey("Level" + (++levelCount)))
        {
            highestLevelNumber = levelCount;
        }


        if (highestLevelNumber <= 10)
        {
            background1.SetActive(true);
        }
        else if (highestLevelNumber <= 20)
        {
            background2.SetActive(true);
        }

        else if (highestLevelNumber <= 30)
        {
            background3.SetActive(true);
        }

        else if (highestLevelNumber <= 40)
        {
            background4.SetActive(true);
        }

        else if (highestLevelNumber <= 40)
        {
            background5.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System;
using System.Collections;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    public float lateralSpeed = 1.0f; // Adjust this value to change the movement speed
    public float forwardSpeed = 2.0f;
    private bool shouldMove = true;
    private bool CanMoveLateral = true;
    
    public Animator animator;
    private Vector3 lateralDirection;
    private bool isTheEnd = false;
    
    public bool HasStartSoundPlayed = false;
    private bool hasBeenLowered = false;
    private bool isDead = false;
    private bool hasdeadsongplayed = false;

    private bool hasCorStarted = false;
    private bool timerDone = false;
    






    [Header("canvas")]
    [SerializeField] private GameObject number1;
    [SerializeField] private GameObject number2;
    [SerializeField] private GameObject number3;
    
    [SerializeField] public GameObject pauseMenu;
    [SerializeField] public GameObject endMenu;
    [SerializeField] public GameObject pauseButton;
    [SerializeField] public GameObject deadMenu;
    

    public AudioClip starterSound;
    public Rigidbody rb;
    


    private void Start()
    {
        animator = GetComponent<Animator>();
        AudioListener.pause = false;
        StartCoroutine(timer());
        

    }


    private IEnumerator timer()
    {

        if (!HasStartSoundPlayed)
        {
            HasStartSoundPlayed = true;
            AudioManager.instance.PlaySFX("StartAGame");
            AudioManager.instance.PlayMusic("GameMusic");
        }
        number1.SetActive(true);
        yield return new WaitForSeconds(1);

        number2.SetActive(true);
        number1.SetActive(false);
        yield return new WaitForSeconds(1);
        number3.SetActive(true);
        number2.SetActive(false);
        yield return new WaitForSeconds(1);

        timerDone = true;


        

    }
    private void Update()
    {

        if (pauseMenu.activeSelf) { GetComponent<Animator>().Play("Idle animations");  }
        

         if (timerDone && !pauseMenu.activeSelf)
        {

            number3 .SetActive(false);

            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f))
            {

                if (hit.collider.attachedRigidbody != null && !hit.collider.CompareTag("Canon")) 
                {

                    shouldMove = false;
                }

               
            }

            else if (!isDead && !isTheEnd)
            {
                shouldMove = true;
            }



            if (shouldMove)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * forwardSpeed);
               // rb.velocity = transform.forward * forwardSpeed;

                GetComponent<Animator>().Play("running animation");
            }

            else if (!shouldMove && !isDead && !isTheEnd)
            {
                GetComponent<Animator>().Play("Idle animations");
            }






            // Assuming you detect touch input (e.g., screen touch)
            if (Input.touchCount == 1 && !isDead && CanMoveLateral)
            {
                Touch screenTouch = Input.GetTouch(0);
                Vector2 screenTouchDelta = screenTouch.deltaPosition;

                // Calculate the lateral movement direction using the right vector of the character
                lateralDirection = transform.right * (screenTouchDelta.x / 2f) * lateralSpeed;
            }
            else
            {
                lateralDirection = Vector3.zero;
            }

            // Apply lateral velocity to the Rigidbody
            rb.velocity = new Vector3(lateralDirection.x, rb.velocity.y, lateralDirection.z);



            if (isTheEnd == true)
                {
                

                GetComponent<Animator>().Play("Idle animations");
                endMenu.SetActive(true);
                pauseButton.SetActive(false);
                

                if (hasBeenLowered == false)
                {
                    float lowerVolume = PlayerPrefs.GetFloat("musicVolume", 1);
                    lowerVolume = lowerVolume - 0.2f;
                    AudioManager.instance.mVolume(lowerVolume);
                    hasBeenLowered = true;
                }

                string currentLevelName = SceneManager.GetActiveScene().name;
                string numberString = currentLevelName.Substring(5); // Assuming the scene name format is "levelX"
                int currentLevelNumber = int.Parse(numberString);
                int nextLevelNumber = currentLevelNumber + 1;
                string nextLevelName = "Level" + nextLevelNumber.ToString();

                PlayerPrefs.SetInt(nextLevelName, 1);
            }

            if(isDead == true)
            {
                GetComponent<Animator>().Play("dying animation");
                pauseButton.SetActive (false);

                if (hasCorStarted == false)
                {
                    StartCoroutine(deadCoroutine());

                }

                

            }
        }
    }

    
    private IEnumerator deadCoroutine()
    {
        hasCorStarted = true;

       
        
        deadMenu.SetActive(true);
        pauseButton.SetActive(false);
        yield return new WaitForSeconds (4);



        
        launchDeathMusic();
    }

    private void launchDeathMusic()
    {

        AudioManager.instance.PlayMusic("death music");
        Debug.Log("death music launched");
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal"))
        {
            CanMoveLateral = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        
            CanMoveLateral = true;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Portal"))
        {
            CanMoveLateral = false;
        }

        

        if (collision.gameObject.CompareTag("endFlag"))
        {
            isTheEnd = true;
            shouldMove = false;
            CanMoveLateral = false;
            
        }

        if (collision.gameObject.CompareTag("deadlyObject"))
        {
            isDead = true;
            shouldMove = false;
            CanMoveLateral = false;
            

            if (hasdeadsongplayed == false)
            {
                AudioManager.instance.PlaySFX("dead");
                
                AudioManager.instance.stopMusic();
                hasdeadsongplayed = true;
                
            }
            


        }

       


    }

    
    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.CompareTag("Portal"))
        {
            CanMoveLateral = true;
        }
    }


}













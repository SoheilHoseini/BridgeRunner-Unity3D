using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//to make menu scene


public class PauseMenu : MonoBehaviour
{
    public Text scoreText;
    public Image backgroundImage;//to show sth before it goes to the menu simultaneously


    private bool isShowned = false;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//when we start the game, pause menu is hidden
    }

    // Update is called once per frame
    void Update()
    {
        //if the pause menu is not shown, we dont need the update( I guess :| )
        if (!isShowned)
            return;
    }

    public void TogglePauseMenu()
    {
        gameObject.SetActive(true);//when the player hits space, the pause menu is shown on the screen
        isShowned = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        isShowned = false;
        gameObject.SetActive(false);
    }

    //when we hit the "Menu" button
    public void ToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}

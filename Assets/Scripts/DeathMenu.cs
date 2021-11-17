using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//to make menu scene

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;
    public Image backgroundImage;//to show sth before it goes to the menu simultaneously

    private bool isShowned = false;
    private float transition = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);//when we start the game, death menu is hidden
    }

    // Update is called once per frame
    void Update()
    {
        //if the menu is not shown, we dont need the update( I guess :| )
        if (!isShowned)
            return;

        //before showing the menu, it slowly changes the background color to black
        transition += Time.deltaTime;
        backgroundImage.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black, transition);
    }

    public void ToggleEndMenu(float score)
    {
        gameObject.SetActive(true);//when the player hits sth, the menu is shown on the screen
        scoreText.text = ((int)score).ToString();
        isShowned = true;
    }

    //when we hit the "Play" button
    public void Restart()
    {
        //this will boot the wanted scene again
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //when we hit the "Menu" button
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

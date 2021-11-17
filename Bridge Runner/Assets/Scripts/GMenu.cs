using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //getting a reference to the "Highscore" text

public class GMenu : MonoBehaviour
{
    public Text highscoreText;

    // Start is called before the first frame update
    void Start()
    {                                        //gets the saved value from the file
        highscoreText.text = "High Score : " + ((int)PlayerPrefs.GetFloat("Highscore")).ToString();//
    }

    //when we hit the "Start" button
    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score = 0.0f;
    private int difficulytLevel = 1;
    private int maxDifficultyLevel = 10;
    private int scoreToNextLevel = 10;

    public Text scoreText;
    public DeathMenu deathMenu;//to use the ToggleEndMenu() from DeathMenu script in here!


    private bool isDead = false;//used when player dies


    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (score >= scoreToNextLevel)
            LevelUp();

        score += Time.deltaTime * difficulytLevel;//the score will increase faster in higher levels and so player will run faster an faster
        scoreText.text = ((int)score).ToString();
    }

    void LevelUp()
    {
        if (difficulytLevel == maxDifficultyLevel)
            return; //the game will be hard enough so we don't need to do anything else
        scoreToNextLevel *= 2;//first at 10 and then at 20 and so on will be needed to go to the next level

        difficulytLevel++;
        GetComponent<Sportma>().SetSpeed(difficulytLevel);

        //shows the levels moning up
        Debug.Log(difficulytLevel);
    }

    //when the player dies, the score must stop
    public void OnDeath()
    {
        isDead = true;
        if (PlayerPrefs.GetFloat("Highscore") < score)
            PlayerPrefs.SetFloat("Highscore", score);//to keep the highest score of our playing history
        deathMenu.ToggleEndMenu(score);
    }

}

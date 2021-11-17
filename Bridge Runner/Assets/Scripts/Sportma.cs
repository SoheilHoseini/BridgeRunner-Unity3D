using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//to make menu scene

public class Sportma : MonoBehaviour
{
    public Animator animator;
    private CharacterController controller;
    private float speed = 5.0f;
    private Vector3 moveVector;
    private float verticalVelocity = 0.0f;
    private float gravity = 12.0f;

    private float animationDuration = 2.0f;
    private float startTime;//used to not allowing the player moving left & right while the starting animation of the camera is going on

    private bool isDead = false;

    public PauseMenu pauseMenu;//to use the TogglePauseMenu() from PauseMenu script in here!


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        //if palyer is dead, it shoudn't be updated
        if (isDead)
            return;


        //this is being called every time our player hits space button
        if (Input.GetKey(KeyCode.Space))
        {
            Pause();
        }


        animator.SetBool("Run", true);//to run in its place
        //while the camera hasn't come down, the player only moves forward not  left & right
        if (Time.time - startTime < animationDuration)
        {
            controller.Move(Vector3.forward * speed * Time.deltaTime);
            return;

        }

        moveVector = Vector3.zero; //reset in every frame

        if (controller.isGrounded)//when the player goes out the plane
        {
            verticalVelocity = -0.5f;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }

        //X value : Left & Right
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;

        //Y value : Up & Down
        moveVector.y = verticalVelocity;

        //Z value : Forward & Backward
        moveVector.z = speed;//only moving forward

        controller.Move(moveVector * Time.deltaTime);
    }

    //to provide access to speed for the score script for mangaing difficulty level
    public void SetSpeed(float modifier)
    {
        speed = 5.0f + modifier;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.TogglePauseMenu();
    }

    ////this is being called every time our player's capsule hit sth in front (not left/right sides)
    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{                  //this is the player front border
    //    if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == ("Enemy"))
    //    {                                     //this is the raduis of the capsule around him
    //        Death();
    //    }
    //}

    //private void Death()
    //{
    //    isDead = true;
    //    GetComponent<Score>().OnDeath();
    //}
}

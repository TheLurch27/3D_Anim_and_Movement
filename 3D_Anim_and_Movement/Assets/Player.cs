using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnim;                                                                                 // Character Animator
    public Rigidbody playerRigid;                                                                               // Character Rigidbody
    public float walking_speed, walking_backwards_speed, old_walking_speed, run_speed, rotate_speed;            // Amimation Speed
    public bool walking;                                                                                        // Bool to know whether the Character is Walking/Run or not.
    public Transform playerTrans;                                                                               // Character Transformation

    // Includes Code for the Movement. (Old Version)
    void FixedUpdate()
    {
        // If "W" is pressed, the Character Rigidbody will move forward at the speed of walking_speed.
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * walking_speed * Time.deltaTime;
        }
        // If "S" is pressed, the Character Rigidbody will move backwards at the speed of walking_backwards_speed.
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = transform.forward * walking_backwards_speed * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If "W" is pressed, the Walk/Run Animation trigger will be set, and the Idle trigger wil be reset just in case.
        if(Input.GetKeyDown(KeyCode.W))
        {
            playerAnim.SetTrigger("WALK");
            playerAnim.ResetTrigger("IDLE");
            walking = true;
        }
        // If the "W" key is let go of, the Idle Animation trigger will be set and the Walk/Run trigger will be reset in case.
        if(Input.GetKeyUp(KeyCode.W))
        {
            playerAnim.ResetTrigger("WALK");
            playerAnim.SetTrigger("IDLE");
            walking = false;
        }
        // If "S" is pressed, the Backwards-Walk Animation trigger will be set, and the Idle trigger wil be reset just in case.
        if(Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("WALK_BACKWARDS");
            playerAnim.ResetTrigger("IDLE");

        }
        // If the "S" key is let go of, the Idle Animation trigger will be set and the Backwards-Walk trigger will be reset in case.
        if(Input.GetKeyUp(KeyCode.S))
        {
            playerAnim.ResetTrigger("WALK_BACKWARDS");
            playerAnim.SetTrigger("IDLE");
        }
        // If "A" is pressed, the Character will rotate left on the Y Axis at the speed of rotate_speed.
        if(Input.GetKey(KeyCode.A))
        {
            playerTrans.Rotate(0, -rotate_speed * Time.deltaTime, 0);
        }
        // If "D" is pressed, the Character will rotate right on the Y Axis at the speed of rotate_speed.
        if (Input.GetKey(KeyCode.D))
        {
            playerTrans.Rotate(0, rotate_speed * Time.deltaTime, 0);
        }
        // Code for Run
        if(walking == true)
        {
            // If the Character is Walking and they press "Left Shift", walk_speed will =! the rotate_speed and the Run Animation trigger will be set, whilst the Walking Animation is reset in case.
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                walking_speed = walking_speed + run_speed;
                playerAnim.SetTrigger("FAST_RUN");
                playerAnim.ResetTrigger("WALK");
            }
            // If "Left Shift" is let go of, the walking_speed will =! the old_walking_speed and the Walking trigger will be set whilst the Run trigger is reset in case.
            if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                walking_speed = old_walking_speed;
                playerAnim.ResetTrigger("FAST_RUN");
                playerAnim.SetTrigger("WALK");
            }
        }
    }
}

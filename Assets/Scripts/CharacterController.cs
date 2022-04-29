using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float gravity; // flight mode gravity
    [SerializeField] private float acceleration; // flight mode acceleration
    [SerializeField] private float maxSpeed; // flight mode speed upward
    [SerializeField] private float floorHeight; // floor height
    [SerializeField] private CinemachineVirtualCamera flightVCam;
    [SerializeField] private CinemachineVirtualCamera driveVCam;
    private bool flightMode = true;
    private float velocityY = 0;
    private int lane = 0; // -1, 0, 1
    private float laneWidth = 2; // how much the character moves left/right

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            flightMode = !flightMode;
            if (flightMode) flightVCam.Priority = 11;
            else flightVCam.Priority = 9;
        }

        // flight controls
        if (flightMode)
        {
            // read input and calculate up-/downwards velocity
            if (Input.GetAxis("Vertical") > 0)
            {
                // lower limit of clamp kills downward velocity instantly so controls feel more responsive
                // upper limit caps upward speed so you don't fly out of the screen / level
                velocityY = Mathf.Clamp(velocityY + acceleration * Time.deltaTime, 0, maxSpeed);
            }
        }

        // driving controls
        else
        {
            if (Input.GetButtonDown("Horizontal"))
            {
                if (Input.GetAxis("Horizontal") < 0 && lane > -1) lane--;
                if (Input.GetAxis("Horizontal") > 0 && lane < 1) lane++;
                //transform.position.Set(transform.position.x, transform.position.y, lane * 2);
            }
        }

        // gravity
        velocityY -= gravity * Time.deltaTime;
        // check if character has hit the ground
        if (transform.position.y <= floorHeight)
        {
            // prevent character from falling through ground
            velocityY = Mathf.Max(0, velocityY);
        }

        // smoothly translate character between lanes
        float zTime = 0.08f;                                        // amount of time (seconds) it takes to change lanes;
        float zError = lane * -laneWidth - transform.position.z;    // how far the character is form where it should be. laneWidth is inverted so that controls are correct.
        float zMax = laneWidth / zTime * Time.deltaTime;            // maximum translation amont in this frame
        float zTranslateAmout = Mathf.Clamp(zError, -zMax, zMax);   // how much the character is translated in this frame. (Mathf.Clamp sets correct +/- sign to zMax and prevents overshooting)

        // move character
        transform.Translate(0, velocityY * Time.deltaTime, zTranslateAmout);
    }
}

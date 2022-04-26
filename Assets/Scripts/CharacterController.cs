using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float gravity; // flight mode gravity
    [SerializeField] private float acceleration; // flight mode acceleration
    [SerializeField] private float maxSpeed; // flight mode speed upward
    [SerializeField] private float floorHeight; // floor height. game over if player falls under this.
    private bool flightMode = true;
    private float velocityY = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (flightMode)
        {
            // read input and calculate up-/downwards velocity
            if (Input.GetAxis("Vertical") > 0)
            {
                // lower limit of clamp kills downward velocity instantly so controls feel more responsive
                // upper limit caps upward speed so you don't fly out of the screen / level
                velocityY = Mathf.Clamp(velocityY + acceleration * Time.deltaTime, 0, maxSpeed);
            }
            else
            {
                velocityY -= gravity * Time.deltaTime;
            }

            //velocityY += Time.deltaTime * (Input.GetAxis("Vertical") * acceleration - gravity);
            //velocityY = Mathf.Min(velocityY, maxSpeed); // caps upwards flight speed

            // check if player has hit the ground
            if (transform.position.y <= floorHeight)
            {
                // TODO: game over
                velocityY = Mathf.Max(0, velocityY); // prevent player from falling forever
            }

            // move player
            transform.Translate(0, velocityY * Time.deltaTime, 0);
        }
        else
        {
            // driving mode code
        }
    }
}

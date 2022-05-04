using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    Vector3 destination;
    public GameObject tile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        destination = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);
        tile.transform.position = Vector3.Lerp(tile.transform.position, destination, Time.deltaTime);
    }
}

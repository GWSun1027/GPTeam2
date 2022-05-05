using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMeter : MonoBehaviour
{
    public float gameSpeed;
    [SerializeField] private float startingSpeed;
    [SerializeField] private float gameSpeedMultiplier; // how quickly the speed builds up
    private int score;
    private Text textComponent;


    // Start is called before the first frame update
    void Start()
    {
        textComponent = gameObject.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gameSpeed = startingSpeed + Time.timeSinceLevelLoad * gameSpeedMultiplier;
        score = (int)Mathf.Pow(Time.timeSinceLevelLoad, 2);
        textComponent.text = ("SCORE: " + score.ToString());
        Debug.Log(Time.realtimeSinceStartup);
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreLogic : MonoBehaviour
{
    [SerializeField] private TMP_Text score;
    [SerializeField] public float currentScore;
    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + currentScore;
    }
}

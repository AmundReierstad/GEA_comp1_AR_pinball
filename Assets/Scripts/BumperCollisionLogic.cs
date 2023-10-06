using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BumperCollisionLogic : MonoBehaviour
{
    private GameObject _planeRef;
    private Vector3 _planeUpVector;
    private ScoreLogic _currentScoreRef;
    [SerializeField] private float bumperStrength=1;
    [SerializeField] private float scoreValue=100;
    private void Awake()
    {
        //default values
       
        //init references
        _planeRef=GameObject.Find("Plane");
        _currentScoreRef = GameObject.Find("ScoreHandler").GetComponent<ScoreLogic>();
        _planeUpVector = _planeRef.transform.up;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //collision logic
        float pinballSpeed = collision.rigidbody.velocity.magnitude;
        Vector3 ballToBumperVector = transform.position - collision.transform.position;
        Vector3 bumpDirection = Vector3.Cross(ballToBumperVector, _planeUpVector);
        bumpDirection.Normalize();
        bumpDirection *= bumperStrength * pinballSpeed; //apply force proportional to velocity of ball
        collision.rigidbody.AddForce(bumpDirection, ForceMode.Impulse);
        //update score
        _currentScoreRef.currentScore += scoreValue;

        Debug.Log("Bump detected, direction: " + bumpDirection);
    }
}

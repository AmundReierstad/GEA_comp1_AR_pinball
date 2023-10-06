using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperLogic : MonoBehaviour
{
    [SerializeField] private AnimationCurve animationCurve;
    [SerializeField] private bool isLeft;
    public bool isActive;
    [SerializeField] private float _timer;
    private Rigidbody _rigidbody;

    private Quaternion _initialRotation;
    private void Awake()
    {
        _initialRotation = transform.rotation; 
        //init references
        _rigidbody = GetComponent<Rigidbody>();
        isActive = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isLeft)
        {
            // input handling
            if (Input.GetKeyDown(KeyCode.A)) 
            {
                _timer = 0;
            }

            _timer += Time.deltaTime;
        }
        else //is right
        {
            // input handling
            if (Input.GetKeyDown(KeyCode.D)) 
            {
                _timer = 0;
            }
            _timer += Time.deltaTime;
        }

        if (_timer <0.5f)
        {
            isActive = true;
        }
        else isActive = false;
    }

    private void FixedUpdate()
    {
        //rotation done in fixed update so physics are applied per frame
        _rigidbody.MoveRotation(_initialRotation*Quaternion.Euler(0,animationCurve.Evaluate(_timer)*90f,0));
    }
    
}

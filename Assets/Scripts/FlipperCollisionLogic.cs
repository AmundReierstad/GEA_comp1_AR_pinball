using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballCollisionPinballPaddleLogic : MonoBehaviour
{
    [SerializeField] private float flipperStrength=1;
    [SerializeField] private bool isLeft;
    private float _timer;
    private GameObject _planeRef;
    private Vector3 _planeUpVector;
    private void Awake()
    {
        //default values
       
        //init references
        _planeRef=GameObject.Find("Plane");
        _planeUpVector = _planeRef.transform.up;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (!GetComponentInParent<FlipperLogic>().isActive) return;
        Vector3 ballToPivotVector =  transform.parent.position-collision.transform.position;
        Vector3 strikeDirection = Vector3.Cross(ballToPivotVector, _planeUpVector);
        strikeDirection.Normalize();
        strikeDirection *= flipperStrength;
        
        if (isLeft) strikeDirection *= -1;
        collision.rigidbody.AddForce(strikeDirection, ForceMode.Impulse);
        Debug.Log("Coll Detected "+strikeDirection);
    }
}

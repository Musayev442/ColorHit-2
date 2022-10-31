using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RotateController : MonoBehaviour
{
    [SerializeField] private Transform circleTransform;

    [SerializeField] private float turnSpeed;


    private float currentDegree;


    private void Start()
    {
        currentDegree = transform.rotation.z;
    }

    private void OnEnable()
    {
        EventManager.RotateChanged += RotateCircle;
    }

    private void OnDisable()
    {
        EventManager.RotateChanged -= RotateCircle;
    }
    
    private void RotateCircle(float degree)
    {        
        circleTransform.Rotate(new Vector3(0,0, degree));
    }

 

}

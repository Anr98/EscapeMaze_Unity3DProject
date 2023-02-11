using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float  movementFactor;
    [SerializeField] float period = 2f;

    void Start()
    {
        startingPosition = transform.position;
        
    }

    // Update is called once per frame 


    void Update()
    {
        if (period <= Mathf.Epsilon) return;
        float cycles = Time.time / period;                                                                       // continually growing over time 
        const float tau = Mathf.PI * 2 ;                                                                           // constant value 6.283  
        float rawSinWave = Mathf.Sin(cycles / tau);                                                                 // going from -1 to 1
        movementFactor = (rawSinWave + 1f)/2f;                                                                        //recalculate 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = offset + startingPosition  ;

    }
}

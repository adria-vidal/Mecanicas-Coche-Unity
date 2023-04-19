using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Colliders
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    //Meshes
    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;


    public float acceleration = 500f;
    public float breakingForce = 300f;
    private float currentAceleration = 0f;
    private float currentBreakingForce = 0f;

    //Giro de Ruedas
    private float currentTurnAngle = 0f;
    private float maxTurnAngle = 15f;


    //Quaternior para hacer el movimento realista
    //función para que la rueda rote visualmente
    void UpdateWheel(WheelCollider col, Transform trans){
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;

    }
    private void FixedUpdate()
    {
        currentAceleration = acceleration * Input.GetAxis("Vertical");
        Debug.Log(currentAceleration);
        if (Input.GetKey(KeyCode.Space))
        {
            currentBreakingForce = breakingForce;
        }
        else
        {
            currentBreakingForce = 0f;
        }

        //Apply acceleration wheels
        frontRight.motorTorque = currentAceleration;
        frontLeft.motorTorque = currentAceleration;

        frontRight.brakeTorque = currentBreakingForce;
        frontLeft.brakeTorque = currentBreakingForce;
        backRight.brakeTorque = currentBreakingForce;
        backRight.brakeTorque = currentBreakingForce;

        //steerAngle =  Angulo de dirección de grados alrededor del eje
        //giro de ruedas
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

    }
}

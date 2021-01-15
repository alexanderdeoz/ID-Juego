using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public GameObject ball;
    public Transform cam;
    public float ballDistance = 2f;

    // lanzar la bola 
    public float ballForce = 250f;
    bool holdingBall = true;
    Rigidbody ballRB;


    //
    bool isPickableBall = false;
    public CanvasController canvasScript;
    public LayerMask pickableLayer;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        ballRB = ball.GetComponent<Rigidbody>();
        ballRB.useGravity = false;
        canvasScript.OcuktarCursor(true);

    }

    // Update is called once per frame
    void Update()
    {
        if (holdingBall == true)
        {

            if (Input.GetMouseButtonDown(0)) // aplastar el boton de la izquierda del mause
            {
                holdingBall = false;
                ballRB.useGravity = true;
                ballRB.AddForce(cam.forward * ballForce);
                canvasScript.OcuktarCursor(false);
            }
        }
        else 
        {
            if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, pickableLayer))
            {
                if (isPickableBall == false)
                {
                    isPickableBall = true;
                    canvasScript.ChangePickableBallColor(true);
                }
                if (isPickableBall && Input.GetKeyDown(KeyCode.E))
                {
                    holdingBall = true;
                    ballRB.useGravity = false;
                    ballRB.velocity = Vector3.zero;
                    ballRB.angularVelocity = Vector3.zero;
                    ball.transform.localRotation = Quaternion.identity;
                    ball.transform.localRotation = Quaternion.identity;

                    canvasScript.ChangePickableBallColor(true);
                    canvasScript.OcuktarCursor(true);
                }
            }
            else if (isPickableBall == true)
            {
                isPickableBall = false;
                canvasScript.ChangePickableBallColor(false);
            }
            
        }
       
    }
    private void LateUpdate()
    {
        if (holdingBall == true)
        {
            ball.transform.position = cam.position + cam.forward * ballDistance;
        }
    }
}

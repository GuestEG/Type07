using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float controlForce = 1.00f;
    //[SerializeField] private float jumpControlForce = 1.00f;
    private Rigidbody controlSubject; //must be set
    [SerializeField] private float maxRotationVelocity = 10f;


    // Use this for initialization
    void Start () {
        controlSubject = GetComponent<Rigidbody>();
        if (controlSubject == null) { Debug.LogError("Cannot find RigidBody component!", this); }
        else {
            controlSubject.maxAngularVelocity = maxRotationVelocity;
        }

	}

    //Use FixedUpdate to actually drive ball
    void FixedUpdate()
    {
        float rollForce = Input.GetAxis("Horizontal") * controlForce;
        float pitchForce = Input.GetAxis("Vertical") * controlForce;
        //float jumpForce = Input.GetAxis("Jump") * jumpControlForce;

        //torque ain't working
        //controlSubject.AddTorque(pitchForce, 0, -rollForce);
        //using world-space force seems better...
        controlSubject.AddForce(rollForce, 0, pitchForce);
        //controlSubject.AddForce(0, jumpForce, 0);
    }

    // Update is called once per frame
    void Update () {
		
	}
}

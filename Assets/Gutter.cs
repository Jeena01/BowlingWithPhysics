using UnityEngine;

public class Gutter : MonoBehaviour
{
    private void OnTriggerEnter(Collider triggeredBody){
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        ballRigidBody.linearVelocity=Vector3.zero;
        ballRigidBody.angularVelocity=Vector3.zero;
        Debug.Log("Applying force to ball!");
        Debug.Log(transform.forward*velocityMagnitude);
        ballRigidBody.AddForce(3*transform.forward*velocityMagnitude,ForceMode.VelocityChange);
    }
}

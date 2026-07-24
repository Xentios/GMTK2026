using UnityEngine;

public class ClockController : MonoBehaviour
{
    public Rigidbody2D myBody;
    public float rotateSpeed = 2f;

    private void FixedUpdate()
    {
        myBody.AddTorque(rotateSpeed * Time.fixedDeltaTime);
    }

}

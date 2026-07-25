using UnityEngine;

public class ClockController : MonoBehaviour
{
    public Rigidbody2D myBody;
    public float rotateSpeed = 2f;

    public RectTransform hourHand;
    public RectTransform minuteHand;

    private void FixedUpdate()
    {
        myBody.AddTorque(rotateSpeed * Time.fixedDeltaTime);
        //transform.Rotate(0f, 0f, rotateSpeed*Time.fixedDeltaTime);
        //hourHand.localRotation = Quaternion.Euler(0, 0f, rotateSpeed);
    }

}

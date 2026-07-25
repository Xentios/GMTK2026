using UnityEngine;

public class ClockController : MonoBehaviour
{

    public float rotateSpeed = 2f;

    public RectTransform hourHand;
    public RectTransform minuteHand;

    private float test;
    private void FixedUpdate()
    {
        test++;
        // myBody.AddTorque(rotateSpeed * Time.fixedDeltaTime);
        //transform.Rotate(0f, 0f, rotateSpeed*Time.fixedDeltaTime);
        hourHand.localRotation = Quaternion.Euler(0, 0f, test * rotateSpeed);
        minuteHand.localRotation = Quaternion.Euler(0, 0f, test * rotateSpeed * 2);
    }

}

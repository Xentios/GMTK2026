using UnityEngine;

public class ItemController : MonoBehaviour, IDrag
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void onEndDrag()
    {
        //rb.useGravity = false;
    }

    public void onStartDrag()
    {
        //rb.useGravity = true;
        rb.linearVelocity = Vector3.zero;
    }
}

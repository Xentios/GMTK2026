using UnityEngine;

public class TeamMemberFallDown : MonoBehaviour
{

    public ShowTotalSeconds ShowTotalSeconds;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("TeamMembers"))
        {
            ShowTotalSeconds.ActivateTimeDown();
            GeneralTimer.instance?.RemoveTime(new System.TimeSpan(hours: 1, 0, 0));
            var rb = other.GetComponent<Rigidbody2D>();
            rb.gravityScale = 1.0f;
            rb.AddForceX(Random.Range(-10, 250));
        }
    }
}

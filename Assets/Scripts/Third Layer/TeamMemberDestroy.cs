using UnityEngine;

public class TeamMemberDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("TeamMembers"))
        {
            Destroy(other.gameObject);
        }
    }
}

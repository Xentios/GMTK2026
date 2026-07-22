using UnityEngine;

public class SpikeTest : MonoBehaviour
{
    [SerializeField]
    private GameEvent gameWonEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Spikes"))
        {
            Destroy(transform.gameObject);
        }

        if (collision.CompareTag("Exit"))
        {
            gameWonEvent.TriggerEvent();
        }
    }
}

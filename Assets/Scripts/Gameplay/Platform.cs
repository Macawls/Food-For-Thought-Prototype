using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IPlayer player))
        {
            player.Transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IPlayer player))
        {
            var fall = player.Transform.gameObject.AddComponent<PlayerFall>();
            fall.landEvent.AddListener(() => player.AnimFeedbacks.TriggerLand());
            fall.rb = player.Rigidbody;
            player.Transform.SetParent(null);
        }
    }
}

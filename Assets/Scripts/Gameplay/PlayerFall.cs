using System;
using UnityEngine;
using UnityEngine.Events;

// added to the player when the player leaves the platform trigger
public class PlayerFall : MonoBehaviour
{
    public Rigidbody rb;
    // add landing sound effect here
    public UnityEvent landEvent = new();

    private void FixedUpdate()
    {
        if (!rb)
        {
            return;
        }
        
        var velocity = rb.velocity;
        velocity.y += Physics.gravity.y * Time.fixedDeltaTime;
        rb.velocity = velocity;

        // TODO: quick fix, need better way to detect landing
        if (rb.transform.position.y < 0.05f)
        {
            landEvent?.Invoke();
            Destroy(this);
        }
    }
}


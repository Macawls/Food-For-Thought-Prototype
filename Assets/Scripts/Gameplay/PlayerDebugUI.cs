using System;
using System.Text;
using UnityEngine;
using OceanFSM;
using TMPro;

public class PlayerDebugUI : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private TextMeshProUGUI playerStateText;
    [SerializeField] private TextMeshProUGUI statsText;
    public void OnPlayerStateChanged(State<IPlayer> state)
    {
        playerStateText.text = $"State: {state.GetType()}";
    }

    private void Update()
    {
        statsText.text = $"Velocity:  {rb.velocity.ToString()} \n" +
                         $"Rotation: {rb.rotation.eulerAngles.ToString()}";
    }
}


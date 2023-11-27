using UnityEngine;

public class FaceCameraUI : MonoBehaviour
{
    private Camera _mCamera;

    private void Awake()
    {
        _mCamera = Camera.main;
    }
    void Update()
    {
        var rot = _mCamera.transform.rotation;
        transform.LookAt(transform.position + rot * Vector3.forward, rot * Vector3.up);
    }
}

using Cinemachine;

using System.Runtime.CompilerServices;

using UnityEngine;
[ExecuteAlways]
public class MinimapController : MonoBehaviour
{
    [SerializeField] private float height;
    [SerializeField] private Camera minimapCam;
    

    private void Awake()
    {
        minimapCam.transform.position = transform.position + Vector3.up * height;
    }

    private void LateUpdate()
    {
        minimapCam.transform.position = transform.position + Vector3.up * height;
        Vector3 currentRotation = transform.rotation.eulerAngles;
        minimapCam.transform.rotation = Quaternion.Euler(90,currentRotation.y,0);

    }
}

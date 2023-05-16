using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardBehaviour : MonoBehaviour
{
    private Camera mainCamera;
    private void Awake()
    {
        mainCamera = Camera.main;
    }
    private void Update()
    {
        transform.position = mainCamera.transform.position + mainCamera.transform.forward * 5;
        transform.rotation = Quaternion.LookRotation(mainCamera.transform.forward);
    }
}

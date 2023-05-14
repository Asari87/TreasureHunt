using Cinemachine;

using System.Runtime.CompilerServices;

using UnityEngine;
public class MinimapController : MonoBehaviour
{
    [SerializeField] private float height;
    private GameObject player;
    
    private CinemachineVirtualCamera minimapCam;

    private void Awake()
    {
        minimapCam = GetComponent<CinemachineVirtualCamera>();
    }
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if (player == null || minimapCam == null)
            throw new System.Exception("Error initializing minimap camera!");

        CinemachineTransposer transposer = minimapCam.GetCinemachineComponent<CinemachineTransposer>();
        transposer.m_FollowOffset = new Vector3(0, height, 0);
        minimapCam.Follow = player.transform;
        minimapCam.LookAt = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

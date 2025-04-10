using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float MIN_CAMERA_ZOOM = 2f;
    private const float MAX_CAMERA_ZOOM = 12f;
    [SerializeField] private CinemachineVirtualCamera cinemachineCam;

    private CinemachineTransposer cinemachineTransposer;
    private Vector3 targetZoom;

    void Start()
    {
        // for camera zoom
        cinemachineTransposer = cinemachineCam.GetCinemachineComponent<CinemachineTransposer>();
        targetZoom = cinemachineTransposer.m_FollowOffset;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleZoom();
    }

    private void HandleMovement()
    {
        Vector3 inputMoveDir = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W))
        {
            inputMoveDir.z = +1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDir.x = -1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDir.z = -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDir.x = +1f;
        }

        float moveSpeed = 10f;
        // use transform.forward and transform.right so wasd keys move towards where the camera is facing to
        Vector3 moveVector = transform.forward * inputMoveDir.z + transform.right * inputMoveDir.x;
        transform.position += moveVector * moveSpeed * Time.deltaTime;
    }

    private void HandleRotation()
    {        
        Vector3 rotationVector = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.Q))
        {
            rotationVector.y = -1f;
        }
        if (Input.GetKey(KeyCode.E))
        {
            rotationVector.y = +1f;
        }
        float rotationSpeed = 100f;
        transform.eulerAngles += rotationVector * rotationSpeed * Time.deltaTime;
    }

    private void HandleZoom()
    {
        float zoomSpeed = 5f;
        float zoomAmount = 1f;
        if (Input.mouseScrollDelta.y > 0)
        {
            targetZoom.y -= zoomAmount;
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            targetZoom.y += zoomAmount;
        }
        targetZoom.y = Mathf.Clamp(targetZoom.y, MIN_CAMERA_ZOOM, MAX_CAMERA_ZOOM);
        cinemachineTransposer.m_FollowOffset = Vector3.Lerp(cinemachineTransposer.m_FollowOffset, targetZoom, zoomSpeed * Time.deltaTime);

    }
}

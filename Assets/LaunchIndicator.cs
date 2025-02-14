using UnityEngine;
using Unity.Cinemachine;
public class LaunchIndicator : MonoBehaviour
{
    [SerializeField] private CinemachineCamera freeLookCamera;
  

    void Update()
    {
        transform.forward = freeLookCamera.transform.forward;
        transform.rotation = Quaternion.Euler(0, freeLookCamera.transform.rotation.eulerAngles.y, 0);
    }
}

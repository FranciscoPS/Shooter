using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

public class CineMachineMovementCamera : MonoBehaviour
{
    public static CineMachineMovementCamera Instance;
    private CinemachineCamera cineMachineCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Destroy(this);
        }
    }

    public void Start()
    {
        cineMachineCamera = GetComponent<CinemachineCamera>();
        noise = cineMachineCamera.GetComponentInChildren<CinemachineBasicMultiChannelPerlin>();

        if (cineMachineCamera == null)
        {
            Debug.LogError("No se encontró CinemachineCamera en el GameObject.");
            return;
        }


        if (noise == null)
        {
            Debug.LogError("No se encontró CinemachineBasicMultiChannelPerlin. Asegúrate de que el 'Noise' esté habilitado en la cámara.");
        }
    }

    public void ShakeCamera(float intensity, float frequency, float duration)
    {
        if (noise == null)
        {
            Debug.LogError("No se puede aplicar shake: CinemachineBasicMultiChannelPerlin es null.");
            return;
        }

        noise.AmplitudeGain = intensity;
        noise.FrequencyGain = frequency;

        StartCoroutine(StopShakeAfterTime(duration));
    }

    private IEnumerator StopShakeAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Resetear el shake
        if (noise != null)
        {
            noise.AmplitudeGain = 0f;
            noise.FrequencyGain = 0f;
        }
    }
}

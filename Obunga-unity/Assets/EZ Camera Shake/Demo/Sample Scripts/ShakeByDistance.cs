using UnityEngine;
using EZCameraShake;

/*
 * Shake the camera based on the player object's distance to the object this script is attached to.
 */
public class ShakeByDistance : MonoBehaviour
{
    public GameObject Player;
    public float MaxDistance = 10f;
    private CameraShakeInstance _shakeInstance;

    void Start()
    {
        _shakeInstance = CameraShaker.Instance.StartShake(2, 14, 0);
    }

	void Update ()
    {
        float distanceFromPlayerToObject = Vector3.Distance(Player.transform.position, this.transform.position);

        // Scale the magnitude of the saved shake, so that the scale is higher the closer we get to the object.
        _shakeInstance.ScaleMagnitude = 1 - Mathf.Clamp01(currentDistance / Distance);
	}
}

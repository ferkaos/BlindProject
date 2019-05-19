using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {

    // The target we are following
    public Transform target;
    // How much we 
    public float smoothness;

    // Place the script in the Camera-Control group in the component menu
    [AddComponentMenu("Camera-Control/Smooth Follow")]

    void LateUpdate() {
        // Early out if we don't have a target
        if (!target) return;

        transform.position = Vector3.Lerp(transform.position, target.transform.position, smoothness * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, smoothness * Time.deltaTime);
    }
}
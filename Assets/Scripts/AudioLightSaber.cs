using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLightSaber : MonoBehaviour
{
    private AudioSource audioSource;
    private Vector3 lastPosition;
    private Vector3 velocity;
    private AudioDistortionFilter audioDistortionFilter;
    [Range(0,1)]
    public float maxDistortion;
    public float maxVelocity = 20;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 lastPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        CalculateVelocity();
        ApplyDistortion();
    }

    private void CalculateVelocity() {
        velocity = (transform.position - lastPosition) / Time.fixedDeltaTime;
        lastPosition = transform.position;
        if(velocity.magnitude > maxVelocity) {
            maxVelocity = velocity.magnitude;
        }
    }

    private void ApplyDistortion() {
        audioSource.volume = Mathf.Clamp(velocity.magnitude / maxVelocity,0,maxDistortion);
    }
}

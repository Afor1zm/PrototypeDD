using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxForTeleport : MonoBehaviour
{
    [SerializeField] private float parallaxEffectMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;        
    }

    private void LateUpdate()
    {
        float deltaMovement = cameraTransform.position.x - lastCameraPosition.x;
        transform.position = new Vector3(transform.position.x + (deltaMovement * parallaxEffectMultiplier), transform.position.y, transform.position.z);
        lastCameraPosition = cameraTransform.position;
    }

}

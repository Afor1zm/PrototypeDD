using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private float parallaxEffectMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSize;    
    private void Start()
    {        
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSize = texture.width / sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        float deltaMovement = cameraTransform.position.x - lastCameraPosition.x;
        transform.position = new Vector3(transform.position.x + (deltaMovement * parallaxEffectMultiplier), transform.position.y, transform.position.z);
        lastCameraPosition = cameraTransform.position;

        if (Mathf.Abs (cameraTransform.position.x - transform.position.x) >= textureUnitSize)
        {
            float offsetPosition = (cameraTransform.position.x - transform.position.x) % textureUnitSize;
            transform.position = new Vector3(cameraTransform.position.x + offsetPosition, transform.position.y);
        }
    }

}

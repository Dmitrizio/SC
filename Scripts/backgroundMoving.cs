using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMoving : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] private float viewZone = 5f;
    [SerializeField] private float backGroundSize = 24f;
    [SerializeField] private float parallaxSpeed = 0.5f;
    private Transform[] layers;
    private int leftIndex;
    private int rightIndex;
    private float lastCameraX;
    
    // Start is called before the first frame update
    void Start()
    {
        lastCameraX = cameraTransform.position.x;
        layers = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
            leftIndex = 0;
            rightIndex = layers.Length - 1;
        }




    }

    private void ScrollRight()
    {
        float lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backGroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if(leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
    private void ScrollLeft()
    {
        float lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x + backGroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, cameraTransform.position.y);
        layers[leftIndex].transform.position = new Vector2(layers[leftIndex].transform.position.x, cameraTransform.position.y);
        layers[rightIndex].transform.position = new Vector2(layers[rightIndex].transform.position.x, cameraTransform.position.y);

        float deltaX = cameraTransform.position.x - lastCameraX;
        lastCameraX = cameraTransform.position.x;
        transform.position += Vector3.right * (deltaX * parallaxSpeed);

        if(cameraTransform.position.x < layers[leftIndex].transform.position.x + viewZone)
        {
            ScrollLeft();
        }
        if(cameraTransform.position.x > layers[rightIndex].transform.position.x - viewZone)
        {
            ScrollRight();
        }
    }
}

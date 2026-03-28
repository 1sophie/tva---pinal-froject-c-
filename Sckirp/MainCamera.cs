using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCamera : MonoBehaviour
{

    Vector3 PlayerPos;
    public GameObject Player;
    Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        float targetAspect = 16f / 9f;
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;
        Camera camera = Camera.main;

        if (scaleHeight <1.0f)
        {
            camera.orthographicSize = camera.orthographicSize / scaleHeight;
            
        }
        else
        {
            camera.orthographicSize = camera.orthographicSize;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Player != null)
        {
        PlayerPos = Player.transform.position;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            Player.transform.position,
            ref velocity, smoothTime
        );   
        }

    }
}

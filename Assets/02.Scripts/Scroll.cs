using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float scrollSpeedX = 2f;
    private Renderer quadRenderer;

    public bool isCloud;   // true면 구름 false면 Ground
    public float cloudScrollSpeedX = 0.5f;  // 구름이 움직이는 속도

    void Start()
    {
        quadRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isCloud)
        {
            transform.position = new Vector3(transform.position.x - cloudScrollSpeedX * Time.deltaTime,
                                             transform.position.y,
                                             transform.position.z);

            if(transform.position.x <= -11f)
            {
                transform.position = new Vector3(11f, Random.Range(0f, 4f), 0f);
            }
        }
        else
        {
            float offsetX = Time.time * scrollSpeedX;
            quadRenderer.material.mainTextureOffset = new Vector2 (offsetX, 0f);
        }
    }
}

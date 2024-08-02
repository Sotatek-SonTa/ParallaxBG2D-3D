using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float starPos,length;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        starPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        Debug.Log(length);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        float movement = cam.transform.position.x * (1 - parallaxEffect);
        transform.position = new Vector3(starPos + distance, transform.position.y, transform.position.z);
        if (movement > starPos + length)
        {
            starPos += length;
        } else if (movement < starPos - length){
            starPos -= length;
        }
    }
}

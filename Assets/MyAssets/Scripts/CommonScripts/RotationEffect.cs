using UnityEngine;

public class RotationEffect : MonoBehaviour
{

    public float angle = 10f;
    public float speed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tilt = Mathf.Sin(Time.time * speed) * angle;
        transform.localRotation = Quaternion.Euler(0,0,tilt);
    }
}

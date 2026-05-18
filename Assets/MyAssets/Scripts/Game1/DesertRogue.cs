using UnityEngine;

public class DesertRogue : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Launch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Launch(){

        Vector2 dir = new Vector2(Random.Range(-0.7f, 0.7f), 1f);
        
        rb.linearVelocity = dir * speed;

    }
}

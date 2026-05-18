using UnityEngine;

public class Walls : MonoBehaviour
{
    public BoxCollider2D left;
    public BoxCollider2D right;
    public BoxCollider2D floor;
    public BoxCollider2D roof;

    public float thickness = 1f;

    void Start()
    {
        UpdateWalls();
    }

    void Update()
    {
        UpdateWalls();
    }

    void UpdateWalls()
    {
        Camera cam = Camera.main;

        float height = cam.orthographicSize * 2f;
        float width = height * cam.aspect;

        Vector2 center = cam.transform.position;

        left.transform.position = new Vector2(center.x - width / 2f - thickness / 2f, center.y);
        left.size = new Vector2(thickness, height + thickness * 2f);

        right.transform.position = new Vector2(center.x + width / 2f + thickness / 2f, center.y);
        right.size = new Vector2(thickness, height + thickness * 2f);

        floor.transform.position = new Vector2(center.x, center.y - height / 2f - thickness / 2f);
        floor.size = new Vector2(width + thickness * 2f, thickness);

        roof.transform.position = new Vector2(center.x, center.y + height / 2f + thickness / 2f);
        roof.size = new Vector2(width + thickness * 2f, thickness);
    }
}

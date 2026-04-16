using UnityEngine;

public class ScrollGames : MonoBehaviour
{
    public GameObject[] levels;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public FadeController fade;
    void Start()
    {
        fade.fadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

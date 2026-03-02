using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public FadeController fade;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fade.fadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

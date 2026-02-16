using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeController : MonoBehaviour
{
    public float fadeDuration = 2f;
    public Image panelImage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private Color originalColor;

    void Awake()
    {
        originalColor = panelImage.color;
    }
    
    
    void Start()
    {
        fadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fadeOut(){
        StartCoroutine(FadeRoutine(0f));
    }

    public void fadeIn(){
        StartCoroutine(FadeRoutine(originalColor.a));
    }




    private IEnumerator FadeRoutine(float targetAlpha){

        float time = 0;

        float startAlpha = panelImage.color.a;

        while (time < fadeDuration){

            //Lisätään kulunut aika edellisestä framesta
            time += Time.deltaTime;

            //Normalisoidaan aika välille 0-1. Tätä käytetään myöhemmin kertoimena
            float t = time / fadeDuration;

            //Luetaan nyktinen väri
            Color c = panelImage.color;

            //Lerppaaminen tarkoittaa, että vaihdetaan väriä pikkuhiljaa
            //(targetAlfa - startAlpha) * t
            c.a = Mathf.Lerp(startAlpha, targetAlpha, t);

            panelImage.color = c;

            yield return null;
        }

    }
}

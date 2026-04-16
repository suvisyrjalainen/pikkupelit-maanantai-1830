using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class Selector : MonoBehaviour
{
    public TMP_Text[] items;

    public Color normalColor;
    public Color highlightColor;
    public FadeController fade;
    private int index = 0; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateColors();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            if(index < items.Length - 1){
                index += 1;
                Debug.Log(index);
            }
            UpdateColors();
        }

        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(index > 0){
                index -= 1;
                Debug.Log(index);
            }
            UpdateColors();
        }

        if(Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)){
            ActivateItem(index);
        }
        
    }

    void UpdateColors(){
        for(int i=0; i<items.Length; i++){
            if(i==index){
                items[i].color = highlightColor;
            }
            else{
                items[i].color = normalColor;
            }
        }
    }

    public void ActivateItem(int i){
        if(items[i].text == "Pikkupelit"){
            Debug.Log("Siirry pikkupeleihin");
         
            StartCoroutine(ChangeToMyScene("Pikkupelit"));
        }
        else if(items[i].text == "Asetukset"){
            Debug.Log("Siirry asetuksiin");
            StartCoroutine(ChangeToMyScene("Asetukset"));
        }
        else if(items[i].text == "Lopeta peli"){
            Debug.Log("Lopetetaan peli");
            StartCoroutine(QuitGame());
        }

    }

    public void SetIndex(int i){
        index = i;
        UpdateColors();
    }

    private IEnumerator ChangeToMyScene(string sceneName)
    {
        fade.fadeIn();
        yield return new WaitForSeconds(fade.fadeDuration);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator QuitGame()
    {
        fade.fadeIn();
        yield return new WaitForSeconds(fade.fadeDuration);

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

}

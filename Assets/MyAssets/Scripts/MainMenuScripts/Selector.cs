using UnityEngine;
using TMPro;

public class Selector : MonoBehaviour
{
    public TMP_Text[] items;

    public Color normalColor;
    public Color highlightColor;

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


}

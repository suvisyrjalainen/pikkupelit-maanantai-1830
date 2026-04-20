using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScrollGames : MonoBehaviour
{
    public GameObject[] levels;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public FadeController fade;

    private Vector3 centerPos;
    private Vector3 rightPos;
    private Vector3 leftPos;

    public float levelWidth = 20f;

    private int currentIndex = 0;

    void Start()
    {
        fade.fadeOut();

        centerPos = new Vector3(0,0,0);
        rightPos = new Vector3(levelWidth,0,0);
        leftPos = new Vector3(-levelWidth,0,0);

        for(int i = 0; i < levels.Length; i++)
        {
            if(i == 0)
            {
                levels[i].transform.position = centerPos;
                levels[i].SetActive(true);             
            }
            else
            {
                //Siirretään muut tasot vasemmalle
                levels[i].transform.position = leftPos;
                levels[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(ChangeScene("Game1"));
        }

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Vaihdetaan seuraavaan peliin
            currentIndex++;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentIndex--;
        }

    }

    private IEnumerator ChangeScene(string levelName)
    {
        fade.fadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(levelName);
    }
}

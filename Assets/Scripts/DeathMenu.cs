using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DeathMenu : MonoBehaviour
{
    private bool EstaMostrando = false;
    private float transicao = 0.0f;

    
    public Text TextoMorte;
    public Image BGimg;



    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!EstaMostrando)
        {
            return;
        }
        transicao += Time.deltaTime;
        BGimg.color = Color.Lerp(new Color(0, 0, 0, 0), Color.black,transicao);
    }

    public void AcabaMenu(float score)
    {
        gameObject.SetActive(true);
        TextoMorte.text = ((int)score).ToString();
        EstaMostrando = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToManu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}



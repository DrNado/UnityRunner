using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private bool MortoT = false;
    private float Placar = 0.0f;
    private int dificuldadeMin = 1;
    private int dificuldadeMax = 20;
    private int PlacarPraPassar = 10;
    
    public Text scoreT;
    public DeathMenu MenuMorte;

    // Update is called once per frame
    void Update()
    {
        if (MortoT == true)
        {
            return;
        }
        if (Placar >= PlacarPraPassar)
        {
            SubirNIvel();
        }

        Placar += Time.deltaTime * dificuldadeMin;
        scoreT.text = ((int)Placar).ToString();
    }

    void SubirNIvel()
    {
        if (dificuldadeMin == dificuldadeMax)
        {
            return;
        }
        PlacarPraPassar *= 2;
        dificuldadeMin+=2;  // modificar caso a vel vique mto alta

        GetComponent<PlayerControl>().SetSpeed(dificuldadeMin);
        //Debug.Log(dificuldadeMin);
    }

    public void QndMorrer()
    {
        MortoT = true;
        MenuMorte.AcabaMenu(Placar);
        
    }

   
}

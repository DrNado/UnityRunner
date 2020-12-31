using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update

    public void ParaAScena()
    {
        SceneManager.LoadScene("Fase1");
    }
    public void ParaOJogo()
    {
        SceneManager.LoadScene("PlayScene");
    }
}

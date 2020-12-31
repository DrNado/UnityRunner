using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private CharacterController controller;
    public AudioSource AudioMusic;

    //private float TempoInicial = 0.0f;
    public float speed = 5.0f;
    public int CoinCounter = 0;
    private Vector3 MoveVector;
    private float VerticalVelocidad  = 0.0f;
    private float Gravity = 12.0f;
    private bool MortoP = false;
    private float VolumeMusica = 1f;
    bool MusicaFundo = true;

    void MovimentacaoPersonagem()
    {

        if (MortoP == true)
        {
            return;
        }
        MoveVector = Vector3.zero;
        if (controller.isGrounded)
        {
            VerticalVelocidad = -0.5f;
        }
        else
        {
            VerticalVelocidad -= Gravity * Time.deltaTime;
        }

        //x esquerda e direita
        MoveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //y cima e baixo
        MoveVector.y = VerticalVelocidad;
        //z frente e traz
        MoveVector.z = speed;


        controller.Move(MoveVector * Time.deltaTime);

        ControleMoedas();
        ControleVol();
    }
    public void ControleVol()
    {
        AudioMusic.volume = VolumeMusica;
    }
    public void SetVolume(float vol)
    {
        VolumeMusica = vol;
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
       
        //TempoInicial = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        MovimentacaoPersonagem();
       // AudioMusic.GetComponent<AudioSource>();
    }

    public void SetSpeed(float Modificador)
    {
        speed = 5.0f + Modificador;
    }

    // eh chamado sempre que o colisor do Player bater em algo

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "Danger" && hit.point.z > transform.position.z + controller.radius)
        {
            Morte();
        }
        if (hit.gameObject.CompareTag("Coletavel"))
        {
            CoinCounter++;
        }
       
    }
    private void ControleMoedas()
    {
        if (CoinCounter == 10)
        {
            speed ++;
            CoinCounter = 0;
        }
        //Debug.Log(speed);
        Debug.Log(CoinCounter);
    }

    private void Morte()
    {
        //Debug.Log("Morto");
        
        MortoP = true;
        GetComponent<Score>().QndMorrer();
        if (AudioMusic.isPlaying && MusicaFundo == true)
        {
            AudioMusic.Stop();
        }

    }
}

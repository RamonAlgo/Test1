using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    public float _velNau;
    public float maxX;  // Límite máximo en el eje X
    public float minX; // Límite mínimo en el eje X

    // Start is called before the first frame update
    void Start()
    {
        _velNau =15f;
        minX = -35f;
        maxX = 35f;
    }

    // Update is called once per frame
    void Update()
    {
        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        //Debug.Log(direccioHoritzontal);
        Vector2 direccioIndicada= new Vector2 (direccioHoritzontal,0f);

        Vector2 novaPos = transform.position; //Ens retorna la posicio actual de la nau


        novaPos += direccioIndicada * _velNau * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minX, maxX);

        transform.position = novaPos;
        print(novaPos);
    }
}
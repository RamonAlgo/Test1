using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    public float velocidadHorizontal;
    public float velocidadVertical;
    public float maxX;  // L�mite m�ximo en el eje X
    public float minX; // L�mite m�nimo en el eje X
    public float maxY;
    public float minY;

    // Start is called before the first frame update
    void Start()
    {
        velocidadHorizontal = 15f;
        velocidadVertical = 10f;
        minX = (float)-20.39f;
        maxX = 20.39f;
        minY = (float)-2.48f;  // Establece tus propios l�mites en el eje Y
        maxY = 2.48f;   // Establece tus propios l�mites en el eje Y
    }

    // Update is called once per frame
    void Update()
    {
        float direccionHorizontal = Input.GetAxisRaw("Horizontal");
        float direccionVertical = Input.GetAxisRaw("Vertical");  // Obt�n la entrada vertical

        Vector2 direccionIndicada = new Vector2(direccionHorizontal, direccionVertical); // Utiliza ambas direcciones

        Vector2 nuevaPosicion = transform.position;

        nuevaPosicion += direccionIndicada * new Vector2(velocidadHorizontal, velocidadVertical) * Time.deltaTime;

        // Aplica las restricciones en ambos ejes (X e Y)
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, minX, maxX);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, minY, maxY);

        transform.position = nuevaPosicion;
        print(nuevaPosicion);
    }
}
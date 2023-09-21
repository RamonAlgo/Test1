using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    public float velocidadHorizontal;
    public float velocidadVertical;
    private float maxX;  // Límite máximo en el eje X
    private float minX; // Límite mínimo en el eje X
    private float maxY;
    private float minY;
    private float tiempoUltimoDisparo;
    private float intervaloEntreDisparos = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        velocidadHorizontal = 6f;
        velocidadVertical = 6f;

        // Calcula los límites basados en el tamaño de la pantalla
        float screenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = screenAspect * cameraHeight;

        // Calcula el tamaño del jugador
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float jugadorWidth = spriteRenderer.bounds.size.x / 2f;
        float jugadorHeight = spriteRenderer.bounds.size.y / 2f;

        minX = -cameraWidth + jugadorWidth;
        maxX = cameraWidth - jugadorWidth;
        minY = -cameraHeight + jugadorHeight;
        maxY = cameraHeight - jugadorHeight;
    }

    // Update is called once per frame
    void Update()
    {
        float direccionHorizontal = Input.GetAxisRaw("Horizontal");
        float direccionVertical = Input.GetAxisRaw("Vertical");  // Obtén la entrada vertical

        Vector2 direccionIndicada = new Vector2(direccionHorizontal, direccionVertical).normalized; // Utiliza ambas direcciones

        Vector2 nuevaPosicion = transform.position;

        nuevaPosicion += direccionIndicada * new Vector2(velocidadHorizontal, velocidadVertical) * Time.deltaTime;

        // Aplica las restricciones en ambos ejes (X e Y)
        nuevaPosicion.x = Mathf.Clamp(nuevaPosicion.x, minX, maxX);
        nuevaPosicion.y = Mathf.Clamp(nuevaPosicion.y, minY, maxY);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot1();
            shoot2(); 
        }

        transform.position = nuevaPosicion;

        
    }
 
    private void shoot1()
    {
        GameObject bala = Instantiate(Resources.Load("Prefabs/Bala_1") as GameObject);
        bala.transform.position = this.transform.position + new Vector3(-0.06f, 0.0f, 0.0f);
    }
    
    private void shoot2()
    {
        GameObject bala = Instantiate(Resources.Load("Prefabs/Bala_1") as GameObject);
        bala.transform.position = this.transform.position + new Vector3(0.06f, 0.0f, 0.0f);
    }
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        /*
         * Quan la nau toqui un objecte, atuomaticament es cridara aquest metode
         * El valor de objecteTocat, sera l'objecte que hem tocat (per exemple, un numero)
         */
        if (objecteTocat.tag=="Numero")
        {
            Destroy(gameObject);
        }
    }

}
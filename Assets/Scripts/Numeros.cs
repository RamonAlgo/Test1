using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numeros : MonoBehaviour
{
    public GameObject num;
    private float _vel;

    private int _valorNumero;

    public Sprite[] _spritesNumeros = new Sprite[10];
    // Start is called before the first frame update
    void Start()
    {
        _vel = 50f;
    
        System.Random aleatori = new System.Random();
        _valorNumero = aleatori.Next(0,10);//Aleatori ebtre 0 i 9
        // Accedim al component Sptite Render i dins d'aquest, a l'atribut Sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = _spritesNumeros[_valorNumero];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos.y = novaPos.y - _vel * Time.deltaTime;
        transform.position = novaPos;

        DestrueixSiSurtFora();
    }

    private void DestrueixSiSurtFora()
    {
        
        if (transform.position.y <= -3)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Balas"||collision.tag=="Player")
        {
            Destroy(gameObject);
        }
    }
}

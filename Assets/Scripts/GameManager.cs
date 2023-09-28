using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject nauJugador;
    public GameObject GameOver;
    public GameObject Titol;
    public GameObject butoInici;
    public GameObject generador;
    public enum EstatsGameManager
    {
        Inici,
        Jugant,
        GameOver
    }

    private EstatsGameManager _estatGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _estatGameManager = EstatsGameManager.Inici;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ActualitzaEstatGameManager()
    {
        switch (_estatGameManager)
        {
            case EstatsGameManager.Inici:
                nauJugador.SetActive(false);
                Titol.SetActive(true);
                GameOver.SetActive(false);
                butoInici.SetActive(true);
                generador.SetActive(false);
                break;
            case EstatsGameManager.Jugant:
                nauJugador.SetActive(true);
                Titol.SetActive(false);
                GameOver.SetActive(false);
                butoInici.SetActive(false);
                generador.SetActive(true);
                break;
            case EstatsGameManager.GameOver:
                nauJugador.SetActive(false);
                Titol.SetActive(false);
                GameOver.SetActive(true);
                butoInici.SetActive(false);
                generador.SetActive(true);
                break;
        }
    }
    public void SetEstatGameManager(EstatsGameManager estat)
    {
        _estatGameManager = estat;
        ActualitzaEstatGameManager();
    }

    public void PassarAEstatsJugant()
    {
        _estatGameManager = EstatsGameManager.Jugant;
        ActualitzaEstatGameManager();
    }
}

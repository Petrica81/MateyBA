using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] pills;
    public Sprite fullPile;
    public Sprite halfPile;
    public Sprite emptyPile;
    public int pileContainers;
    public int currentPlayerHealth;

    void Start()
    {
        InitHealth();
    }

    //Set active a specific number of pile objects
    public void InitHealth()
    {
        for(int i = 0; i < pileContainers; i++)
        {
            pills[i].gameObject.SetActive(true);
            pills[i].sprite = fullPile;
        }
    }

    void Update()
    {
        UpdateHealth();
    }

    //Update displayed sprite for piles by a specific number which should represent player's current health
    public void UpdateHealth()
    {
        int auxHealth = currentPlayerHealth;
        for(int i = 0; i < pileContainers*2; i++)
        {
            if( i < auxHealth)
            {
                pills[i/2].sprite = fullPile;
            }
            else if(i > auxHealth)
            {
                pills[i/2].sprite = emptyPile;
            }
            else
            {
                pills[i/2].sprite = halfPile;
            }
        }
    }
}

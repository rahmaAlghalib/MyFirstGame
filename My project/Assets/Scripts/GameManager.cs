using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI coinText;
    public TextMeshProUGUI HealthText;
    public Slider healthBar;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void Restart(){

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void UpdateCoinText(int collectedCoins){

        coinText.text = "Coins: " + collectedCoins;

    }

    public void UpdateHealthText(int currentHealth, int maxHealth){

        HealthText.text = currentHealth + "/" + maxHealth;
        float newCurrentHealth = (float) currentHealth / maxHealth;
        healthBar.value = newCurrentHealth;
    }
}

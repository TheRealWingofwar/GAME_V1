using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public GameObject VictimPrefab;

    public Text MoneyText;

    private float MONEY = 0;

    public float getMoney() { return MONEY; }

    public void setMoney(float _m)
    {
        MONEY = _m;
        MoneyText.text = "Money: "+MONEY.ToString();
    }

    public void gameOver()
    {
        Application.Quit();
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int randomNumber = UnityEngine.Random.Range(1, 10);
        yield return new WaitForSeconds(randomNumber);
        GameObject Victim = Instantiate(VictimPrefab, new Vector3(36, -3.83f, 0), Quaternion.identity) as GameObject;
        }
        
    }
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
}
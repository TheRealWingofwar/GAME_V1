using UnityEngine;
using System.Collections;

public class Victim : MonoBehaviour {

    
    private Vector3 RightScreenEdge;
    private Vector3 LeftScreenEdge;

    private float Money;
    private float SpriteSize;

    void Start()
    {
       Money = Random.Range(1, 50);
        RightScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0));
        LeftScreenEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        SpriteSize = GetComponent<SpriteRenderer>().bounds.size.x;
    }
    void Update()
    {
        transform.Translate(Vector3.left * 5 * Time.deltaTime);

        if(transform.position.x < LeftScreenEdge.x - SpriteSize)
        {
            Destroy(gameObject);
        }
    }
    public void Robbed()
    {
        Money = 0;
    }
    public float GetMoney()
    {
        return Money;
    }
    
}


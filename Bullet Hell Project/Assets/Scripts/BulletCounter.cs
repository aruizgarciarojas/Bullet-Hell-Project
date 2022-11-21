using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
    public TextMeshProUGUI bulletCounter;
    public int bulletCount = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Count the number of bullets on screen and add them to a counter to then display on UI
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        bulletCount = bullets.Length;
        Debug.Log(bulletCount);
        bulletCounter.text = $"Bullets: {bulletCount}";

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    public int AngleCounter = 0;
    public TextMeshProUGUI bulletCounter;
    public int BulletCount = 0;
    // Start is called before the first frame update
   public void OnEnable()
{
    TimeManager.OnMinuteChanged += TimeCheck;
    bulletCounter.text = BulletCount.ToString();
}

public void OnDisable()
{
    TimeManager.OnMinuteChanged -= TimeCheck;
}
//if time is 10:10 firing mode is Fire2

    void TimeCheck()
    {
        if (TimeManager.Minute == 10 && TimeManager.Hour == 10)
        {
            BulletCount++;
            StartCoroutine(Fire2());
            
        }
        if (TimeManager.Minute == 30 && TimeManager.Hour == 10)
        {
            StartCoroutine(CircularFire());
        }
        if (TimeManager.Minute == 50 && TimeManager.Hour == 10)
        {
            StartCoroutine(SpiralFire());
        }

        
    }

    void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

//Fire 2 bullets on each side of the enemy
    private IEnumerator Fire2()
    {
        float timeElapsed = 0;
        float timeToMove = 10f;
        
        while (timeElapsed < timeToMove)
        {
        GameObject Bullet =Instantiate(bullet, transform.position, transform.rotation);
        Bullet.transform.Rotate(0, 90,0); 
        //if Bullets are destroyed subtract one from counter
        BulletCount++;
        if (Bullet == null)
        {
            BulletCount--;
        }
        GameObject Bullet2 = Instantiate(bullet, transform.position, transform.rotation);
        Bullet2.GetComponent<BulletPath>().RotatingMovementNegative();
        Bullet2.transform.Rotate(0, 270, 0);
        BulletCount++;
        if (Bullet2 == null)
        {
            BulletCount--;
        }
        GameObject Bullet3 = Instantiate(bullet, transform.position, transform.rotation);
        Bullet3.GetComponent<BulletPath>().RotatingMovement();
        Bullet3.transform.Rotate(0, 180, 0);
        BulletCount++;
        if (Bullet3 == null)
        {
            BulletCount--;
        }
        GameObject Bullet4 = Instantiate(bullet, transform.position, transform.rotation);
        Bullet4.GetComponent<BulletPath>().RotatingMovementNegative();
        Bullet4.transform.Rotate(0, 0, 0);
        BulletCount++;
        if (Bullet4 == null)
        {
            BulletCount--;
        }
        GameObject Bullet5 = Instantiate(bullet, transform.position, transform.rotation);
        Bullet5.GetComponent<BulletPath>().RotatingMovement();
        Bullet5.transform.Rotate(180, 90, 0);
        BulletCount++;
        if (Bullet5 == null)
        {
            BulletCount--;
        }
        GameObject Bullet6 = Instantiate(bullet, transform.position, transform.rotation);
        Bullet6.GetComponent<BulletPath>().RotatingMovementNegative();
        Bullet6.transform.Rotate(180, 270, 0);
        BulletCount++;
        if (Bullet6 == null)
        {
            BulletCount--;
        }
        GameObject Bullet7 = Instantiate(bullet, transform.position, transform.rotation);
        Bullet7.GetComponent<BulletPath>().RotatingMovement();
        Bullet7.transform.Rotate(180, 180, 0);
        BulletCount++;
        if (Bullet7 == null)
        {
            BulletCount--;
        }
        GameObject Bullet8 = Instantiate(bullet, transform.position, transform.rotation);
        Bullet8.GetComponent<BulletPath>().RotatingMovementNegative();
        Bullet8.transform.Rotate(180, 0, 0);
        BulletCount++;
        if (Bullet8 == null)
        {
            BulletCount--;
        }

        //if bullet is destroyed, remove from bullet count
        

        timeElapsed += Time.deltaTime;
        yield return null;
        }
        
    }

  //Function to fire bullets in a cross pattern,spawning 4 bullets on each side of the enemy
    void CrossFire()
    {
        for (int i = 0; i < 4; i++)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0, 90 * i, 0));
        }
    }
    //Function to fire bullets in a circular pattern,spawning 8 bullets in a circle around the enemy
    private IEnumerator CircularFire()
    {
        float timeElapsed = 0;
        float timeToMove = 10f;
        while (timeElapsed < timeToMove)
        {
        for (int i = 0; i < 360; i += 45)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.transform.Rotate(0, i, 0);
        }
        timeElapsed += Time.deltaTime;
        yield return null;
        }
    }

    //Function that spawns a rotaring Stream of bullets around the enemy
    private IEnumerator SpiralFire()
    {
        float timeElapsed = 0;
        float timeToMove = 10f;
        while (timeElapsed < timeToMove)
        {
          
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.Rotate(0, AngleCounter, 0);
        AngleCounter += 5;
        timeElapsed += Time.deltaTime;
        yield return null;
        
    }
    }
    
    //Function that spawns multiple streams of bullets around the forming a flower around the enemy
    void RotatingCrossFire()
    {
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
       newBullet.transform.Rotate(0, AngleCounter, 0);
        newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.Rotate(0, AngleCounter + 90, 0);
        newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.Rotate(0, AngleCounter + 180, 0);
        newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.transform.Rotate(0, AngleCounter + 270, 0);
        AngleCounter += 15;
    }

}

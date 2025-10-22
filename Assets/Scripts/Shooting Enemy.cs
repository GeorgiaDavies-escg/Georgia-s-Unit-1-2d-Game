using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeBtwShots = startTimeBtwShots;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBtwShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}

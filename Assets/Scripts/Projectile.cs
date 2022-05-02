using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject target;
    public Tower tower;
    public ParticleSystem smokeTrail;
    public ParticleSystem impact;
    public int speed = 1;
    public float radius = 1;
    private float radiusSqrt;
    private bool hit = false;
    void Start()
    {
        radiusSqrt = radius * radius;
    }

    // Update is called once per frame
    void Update()
    {
        if(!target)
        {
            Destroy(gameObject);
            return;
        }

        if(!smokeTrail.isPlaying)
            smokeTrail.Play();
        Vector3 direction = target.transform.position - transform.position;
        transform.position += direction.normalized * speed * Time.deltaTime;

        if(direction.sqrMagnitude < radiusSqrt && !hit)
        {
            target.GetComponent<Enemy>().TakeDamage(tower.GetTowerDamage(), tower);
            if(impact != null)
            impact.Play();
            hit = true;
            Destroy(gameObject,2f);
        }
        
    }

    public static Projectile Spawn(GameObject prefab, Vector3 position, Quaternion rotation, GameObject target, Tower tower)
    {
        GameObject go = Instantiate(prefab, position, rotation);
        Projectile projectile = go.GetComponent<Projectile>();
        projectile.tower = tower;
        projectile.target = target;
        return projectile;
    }
}

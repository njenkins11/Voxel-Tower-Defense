using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tower))]
public class TowerShoot : MonoBehaviour
{
    [SerializeField] private LineRenderer laser;
    [SerializeField] private Transform fireLocation;
    [SerializeField] private GameObject misslePrefab;
    [SerializeField] private GameObject magicPrefab;
    [SerializeField] private AudioSource shootSound;
    private Tower tower;
    private GameObject target;
    private float nextShootTime;
    // Start is called before the first frame update
    void Start()
    {
        tower = GetComponent<Tower>();
        InvokeRepeating("SelectTarget", 0, 0.5f);
        nextShootTime = tower.GetShootRate();
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            if(laser != null)
                laser.enabled = false;
            return;
        }
        if(laser != null)
        {
            laser.SetPosition(0,fireLocation.position);
            laser.SetPosition(1,target.transform.position);
            if(!shootSound.isPlaying)
            shootSound.Play();
        }
        LockOnTarget();
        ShootTarget();
        nextShootTime += Time.deltaTime;
    }

    private void LockOnTarget()
    {
        tower.towerHead.transform.rotation = Quaternion.LookRotation(target.transform.position - fireLocation.position);
    }
    private void SelectTarget()
    {
          GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
          float minDist = Mathf.Infinity;
          int selectedEnemy = -1;
          for(int i = 0; i < allEnemies.Length; i++)
          {
              float distance = Vector3.Distance(transform.position, allEnemies[i].transform.position);
              if(distance < minDist)
              {
                  minDist = distance;
                  selectedEnemy = i;
              }
          }
          if(selectedEnemy != - 1 && minDist <= tower.GetTowerRange())
          {
              target = allEnemies[selectedEnemy];
          }
          else
            target = null;
    }

    private void ShootTarget()
    {
        if(tower.GetShootRate() <= nextShootTime)
        {
            switch(tower.GetTOWER_TYPE())
            {
                case TOWER_TYPE.LASER:
                    ShootLaser();
                    break;
                case TOWER_TYPE.MAGIC:
                    ShootMagic();
                    break;
                case TOWER_TYPE.MISSLE:
                    ShootMissle();
                    break;
            }
            nextShootTime = 0;
        }
       
    }

    private void ShootLaser()
    {
        laser.enabled = true;
        laser.SetPosition(0,fireLocation.position);
        laser.SetPosition(1,target.transform.position);
        target.GetComponent<Enemy>().TakeDamage(tower.GetTowerDamage(), tower);
    }

    private void ShootMagic()
    {
        Projectile.Spawn(magicPrefab, fireLocation.transform.position, Quaternion.identity, target, tower);
        shootSound.Play();
    }

    private void ShootMissle()
    {
        Projectile.Spawn(misslePrefab, fireLocation.transform.position, Quaternion.identity, target, tower);
        shootSound.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;

    public GameObject deathParticle, heartParticle, collectParticle,milkParticle;

    public Transform player;

    private void Awake()
    {
        Instance = this;
    }


    public void SpawnParticle(GameObject particle)
    {
        Instantiate(particle,player.position,Quaternion.identity);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSystem : MonoBehaviour
{
    public int vehicleAmount;

    public  GameObject[] vehicles;
    public Transform[] spawnPoses;
    public bool[] isLeftToRight;


    private void Start()
    {
        CreateVehicle();
    }

    void CreateVehicle()
    {
       for(int i = 0; i < spawnPoses.Length; i++)
        {
            GameObject instantiated = Instantiate(vehicles[i],spawnPoses[i]);
            instantiated.GetComponent<Vehicle>().leftToRight = isLeftToRight[i];
        }
    }
}

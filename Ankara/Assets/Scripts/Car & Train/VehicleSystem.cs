using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSystem : MonoBehaviour
{
    public int vehicleAmount;

    public  GameObject vehicleLeft,vehicleRight;
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
            Vector2 middleVector = (new Vector2(1, 1) - new Vector2(0, 0));
            if(spawnPoses[i].transform.position.y > middleVector.y && spawnPoses[i].transform.position.x < middleVector.x)
            {
                GameObject instantiated = Instantiate(vehicleLeft, spawnPoses[i]);
                instantiated.GetComponent<Vehicle>().leftToRight = true;
            }
            else if (spawnPoses[i].transform.position.y < middleVector.y && spawnPoses[i].transform.position.x > middleVector.x)
            {
                GameObject instantiated = Instantiate(vehicleRight, spawnPoses[i]);
                instantiated.GetComponent<Vehicle>().leftToRight = false;
            }

            

        }
    }
}

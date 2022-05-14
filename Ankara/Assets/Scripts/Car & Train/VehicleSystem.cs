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
            Debug.Log("1");
            Vector2 middleVector = (new Vector2(0.66f, 0.33f)- new Vector2(0, 0));

            Debug.Log(Vector2.SignedAngle(middleVector, new Vector2(spawnPoses[i].position.x, spawnPoses[i].position.y) - new Vector2(0, 0)));
            if (Vector2.SignedAngle(middleVector, new Vector2(spawnPoses[i].position.x, spawnPoses[i].position.y) - new Vector2(0, 0)) > 0)
            {
                Debug.Log("qweqwe");
                GameObject instantiated = Instantiate(vehicleLeft, spawnPoses[i]);
                instantiated.GetComponent<Vehicle>().leftToRight = true;
            }
            else if (Vector2.SignedAngle(middleVector, new Vector2(spawnPoses[i].position.x, spawnPoses[i].position.y) - new Vector2(0, 0)) <= 0)
            {
                Debug.Log("asdasdssa");

                GameObject instantiated = Instantiate(vehicleRight, spawnPoses[i]);
                instantiated.GetComponent<Vehicle>().leftToRight = false;
            }

            /*
            if (spawnPoses[i].transform.position.y > middleVector.y && spawnPoses[i].transform.position.x < middleVector.x)
            {
                Debug.Log("2");

                GameObject instantiated = Instantiate(vehicleLeft, spawnPoses[i]);
                instantiated.GetComponent<Vehicle>().leftToRight = true;
            }
            else if (spawnPoses[i].transform.position.y < middleVector.y && spawnPoses[i].transform.position.x > middleVector.x)
            {
                Debug.Log("3");

                GameObject instantiated = Instantiate(vehicleRight, spawnPoses[i]);
                instantiated.GetComponent<Vehicle>().leftToRight = false;
            }
            */
            


        }
    }
}

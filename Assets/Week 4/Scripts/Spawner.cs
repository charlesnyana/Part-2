using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject plane;
    Transform spawner;
    public float interval;
    float currentTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        float randomInterval = Random.Range(1, 5);
        interval = randomInterval * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime * 1;
        float randomVal = Random.Range(-5, 5);
        float randomRotate = Random.Range(0, 359);
        
        

        if (currentTime - 1 >= interval)
        {
            transform.position = new Vector3(randomVal, randomVal, 0);
            transform.rotation = Quaternion.Euler(0, 0, randomRotate);

            Instantiate(plane, transform.position, transform.rotation);
            currentTime = 0f;

            float randomInterval = Random.Range(1, 5);
            interval = randomInterval * Time.deltaTime;
        }
    }
}

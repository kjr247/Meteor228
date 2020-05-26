using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteors : MonoBehaviour
{
    public GameObject meteor;
    public float timer = 3.0f;
    public int maxMeteorsCount = 3;
    public int meteorsCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position; // TODO: randomize
        Instantiate(meteor, position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // timer -= Time.deltaTime;

        // if (timer < 0 && meteorsCount < maxMeteorsCount ) {
        //     Vector3 position = transform.position; // TODO: randomize
        //     Instantiate(meteor, position, Quaternion.identity);
        //     timer = 0.0f;
        // }
    }
}

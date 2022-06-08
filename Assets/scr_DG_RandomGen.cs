using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_DG_RandomGen : MonoBehaviour
{
    public GameObject[] possibleRooms;
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, possibleRooms.Length);
        GameObject baby = Instantiate(possibleRooms[rand], transform.position, Quaternion.identity);
        baby.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        


    }
}

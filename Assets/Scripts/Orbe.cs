using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().PegouOrbe();
            gameObject.SetActive(false);

            ScoreManager.instance.AddPoint();
        }
    }
}

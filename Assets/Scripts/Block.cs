using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject blockPrefab;
    bool p;
    void Start()
    {
        p = false;
        Invoke("S", 0.1f);
    }

    void S()
    {
        p = true;
    }
    public void Remove()
    {
        if (p)
        {
            if(blockPrefab != null)
            {
                GameObject newBlock = Instantiate(blockPrefab);
                newBlock.transform.SetParent(transform.parent);
                newBlock.transform.position = transform.position;
            }
            Destroy(this.gameObject);
        }
    }
}

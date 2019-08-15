using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Это силя нашин солдятин, сила в жизни, которую он отдаст за Нерзула
    float Health = 0.15f;
    bool AmIalIve = true;
    public Color dieColor;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (AmIalIve)
        {
            other.gameObject.GetComponent<CharapterScript>().TakeDamage(this.Health);
            // Renderer rend = GetComponent<Renderer>();

            // //Set the main Color of the Material to green
            // rend.material.shader = Shader.Find("lambert4");
            // rend.material.SetColor("lambert4", Color.green);
            GetComponent<Renderer>().material.color = dieColor;
            // Not, my friend you must live! Товариши, он был хорошим солдатен!
            this.AmIalIve = false;
            Destroy(gameObject, 1);
        }
    }
}

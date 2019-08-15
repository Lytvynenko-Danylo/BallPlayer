using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragon : MonoBehaviour
{
    public GameObject WinImage;
    // Start is called before the first frame update
    void Start()
    {
        WinImage.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        WinImage.SetActive(true);
        Destroy(other.gameObject);
        // Renderer rend = GetComponent<Renderer>();

        // //Set the main Color of the Material to green
        // rend.material.shader = Shader.Find("lambert4");
        // rend.material.SetColor("lambert4", Color.green);
    }
}

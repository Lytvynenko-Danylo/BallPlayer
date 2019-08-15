using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharapterScript : MonoBehaviour
{
    public float Health = 1.58f;
    public GameObject FailImage;
    private GameObject shot;
    private bool Move = false;
    private Size shotSize = new Size(0.4f, 0.4f, 0.4f);
    void Start()
    {
        FailImage.SetActive(false);
    }

    void Update()
    {
        if (Move)
        {
            transform.position += transform.forward * Time.deltaTime;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit) && hit.collider.name == "Ball player")
                {
                    Vector3 whereSpawn = new Vector3(-0.86f, 0.365f, -9f);
                    this.shot = Instantiate(gameObject, whereSpawn, Quaternion.identity);
                    this.shot.transform.localScale = new Vector3(shotSize.x, shotSize.y, shotSize.z);
                }
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;
                // if you touch the ball
                if (Physics.Raycast(raycast, out hit) && hit.collider.name == "Ball player")
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            if (!this.shot)
                            {
                                Vector3 whereSpawn = new Vector3(-0.86f, 0.865f, -9f);
                                this.shot = Instantiate(gameObject, whereSpawn, Quaternion.identity);
                                this.shot.transform.localScale = new Vector3(shotSize.x, shotSize.y, shotSize.z);
                                this.shot.GetComponent<CharapterScript>().Health = 0;
                            }
                            break;
                        case TouchPhase.Stationary:
                            if (this.shot)
                            {
                                this.shot.transform.localScale =
                                new Vector3(this.shot.transform.localScale.x + 0.01f, this.shot.transform.localScale.y + 0.01f, this.shot.transform.localScale.z + 0.01f);
                                Vector3 temp = new Vector3(0, 0.003f, 0);
                                this.shot.transform.position += temp;
                                gameObject.transform.localScale =
                                new Vector3(gameObject.transform.localScale.x - 0.01f, gameObject.transform.localScale.y - 0.01f, gameObject.transform.localScale.z - 0.01f);
                                this.Health -= 0.01f;
                                //this.shot.GetComponent<CharapterScript>().Health += 0.01f;
                                if (this.Health < 0)
                                {
                                    FailImage.SetActive(true);
                                    Destroy(gameObject);
                                }
                            }
                            break;

                        // you release your finger
                        case TouchPhase.Ended:
                            if (this.shot)
                            {
                                this.shot.transform.Rotate(-0.874f, 14.379f, 2.371f);
                                this.shot.GetComponent<CharapterScript>().Health = this.shot.transform.localScale.x;
                                this.shot.GetComponent<CharapterScript>().Move = true;
                            }
                            break;
                    }
                }
            }
        }
    }
    public void TakeDamage(float amount)
    {
        this.Health -= amount;
        gameObject.transform.localScale =
        new Vector3(gameObject.transform.localScale.x - amount, gameObject.transform.localScale.y - amount, gameObject.transform.localScale.z - amount);
        if (this.Health < 0)
        {
            FailImage.SetActive(true);
            Destroy(gameObject);
        }
    }
}
public struct Size
{
    public float x;
    public float y;
    public float z;
    public Size(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject[] dots;

    [SerializeField]
    private GameObject dotPrefab;

    private Vector3 projectilePosition, shotDirection, force;
    private Camera cam;
    private Transform m_transform;
    private Rigidbody projectileRigid;

    // Use this for initialization
    void Start()
    {
        m_transform = transform;
        projectileRigid = m_transform.GetComponent<Rigidbody>();

        cam = Camera.main;

        dots = new GameObject[10];

        for (int i = 0; i < dots.Length; i++)
        {
            dots[i] = Instantiate(dotPrefab);

            dots[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            projectilePosition = cam.WorldToScreenPoint(m_transform.position);
            projectilePosition.z = 0;

            shotDirection = (projectilePosition - Input.mousePosition).normalized;

            Aim();
        }

        if(Input.GetMouseButtonUp(0))
        {
            projectileRigid.AddForce(shotDirection.magnitude * force, ForceMode.Impulse);

            for(int i = 0; i < dots.Length; i++)
            {
                dots[i].SetActive(false);
            }
        }
    }

    private void Aim()
    {
        float sX = shotDirection.x * (projectilePosition.x - Input.mousePosition.x);
        float sY = shotDirection.y * (projectilePosition.y - Input.mousePosition.y);

        for(int i = 0; i < dots.Length; i++)
        {
            float t = i * 0.1f;

            float dX = sX * t;
            float dY = sY * t - (0.5f * -Physics.gravity.y * t * t);

            force = new Vector3(dX, dY, 0);

            dots[i].transform.position = new Vector3(m_transform.position.x + dX, m_transform.position.y + dY, m_transform.position.z);
            dots[i].SetActive(true);
        }
    }
}

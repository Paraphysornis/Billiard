using UnityEngine;
using System.Collections.Generic;

public class BallController : MonoBehaviour
{
    [SerializeField] GameObject mainBall = null;
    [SerializeField] float power = 0.1f;
    [SerializeField] Transform arrow = null;
    [SerializeField] List<ColorBall> ballList = new List<ColorBall>();
    Vector3 mousePosition = new Vector3();
    Vector3 mainBallDefaultPosition = new Vector3();
    Rigidbody mainRigid = null;

    void Start()
    {
        mainRigid = mainBall.GetComponent<Rigidbody>();
        mainBallDefaultPosition = mainBall.transform.localPosition;
        arrow.gameObject.SetActive(false);
    }

    void Update()
    {
        if (mainBall.activeSelf)
        {
            if (Input.GetMouseButtonDown(0))
            {
                mousePosition = Input.mousePosition;
                arrow.gameObject.SetActive(true);
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 position = Input.mousePosition;
                Vector3 def = mousePosition - position;
                float rad = Mathf.Atan2(def.x, def.y);
                float angle = rad * Mathf.Rad2Deg;
                Vector3 rot = new Vector3(0, angle, 0);
                Quaternion qua = Quaternion.Euler(rot);
                arrow.localRotation = qua;
                arrow.transform.position = mainBall.transform.position;
            }

            if (Input.GetMouseButtonUp(0))
            {
                Vector3 upPosition = Input.mousePosition;
                Vector3 def = mousePosition - upPosition;
                Vector3 add = new Vector3(def.x, def.y);
                mainRigid.AddForce(add * power);
                arrow.gameObject.SetActive(false);
            }
        }
    }

    public void OnResetButtonClicked()
    {
        mainBall.SetActive(true);
        mainRigid.velocity = Vector3.zero;
        mainRigid.angularVelocity = Vector3.zero;
        mainBall.transform.localPosition = mainBallDefaultPosition;

        foreach (ColorBall ball in ballList)
        {
            ball.Reset();
        }
    }
}

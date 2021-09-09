
using UnityEngine;

public class Cam : MonoBehaviour
{

    public GameObject player;
    public Camera MainCamera;
    void Start()
    {
        MainCamera.orthographicSize = 13f;
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x + 3.5f, player.transform.position.y + 2f, -15f);
        if (Player.TrapIsActive == true && Player.BossIsDead == false && MainCamera.orthographicSize <= 16f)
        {
            MainCamera.orthographicSize += 0.8f * Time.deltaTime;
        }
        if (Player.BossIsDead == true && MainCamera.orthographicSize > 13f)
        {
            MainCamera.orthographicSize -= 0.5f * Time.deltaTime;
        }
    }

}

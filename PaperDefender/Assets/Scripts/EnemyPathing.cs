using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    List<Transform> Waypoints;
  
    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        Waypoints = waveConfig.GetWaveWaypoints();
        transform.position = Waypoints[waypointIndex].transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        NewMethod();

    }

    public void setWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }


    private void NewMethod()
    {
        if (waypointIndex <= Waypoints.Count - 1)
        {
            var targetPosition = Waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    } 
}

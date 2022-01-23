using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsingBackground : MonoBehaviour
{
    public float timePassed = 0;
    public float beatInterval = 0;
    public float pulseMultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Conductor.instance.gameStarted && !Conductor.instance.settingsCanvas.activeSelf) {
            timePassed += Time.deltaTime;
            beatInterval = 60 / Conductor.instance.songBpm * pulseMultiplier;
            if (timePassed >= beatInterval) {
                StartCoroutine("Pulse");
                timePassed -= beatInterval;
            }
        }
        else {
            timePassed = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            //StartCoroutine("Pulse");
        }
    }

    public IEnumerator Pulse() {
        var growthTarget = 1.05f;
        var startingScale = 1f;
        while (transform.localScale.x < growthTarget) {
            startingScale += 0.001f; 
            transform.localScale = new Vector2(startingScale, startingScale);
            yield return new WaitForEndOfFrame();
        }
        //yield return new WaitForSeconds(0.15f);

        while (transform.localScale.x > 1) {
            startingScale -= 0.001f;
            transform.localScale = new Vector2(startingScale, startingScale);
            yield return new WaitForEndOfFrame();

        }
        //yield return new WaitForSeconds(0.15f);
        //transform.localScale = new Vector2(1f, 1f);
    }
}

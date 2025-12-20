using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public Transform player; 
    public List<Transform> parts = new List<Transform>();

    [Header("Orbiting")]
    public float orbitSpeedDegrees = 120f; 
    public float orbitDistance = 3f; 
    public int minOrbitsBeforeDecision = 2;
    public int maxOrbitsBeforeDecision = 4;

    [Header("Attack")]
    public float gatherTimeMin = 1.0f;
    public float gatherTimeMax = 2.0f;
    public float chargeSpeed = 10f;
    public float maxChargeDuration = 3.5f; 

    [Header("Behavior tuning")]
    [Range(0f,1f)]
    public float extraChanceAfterEachOrbit = 0.0f;
    public bool useChildOffsetsForParts = true; //

    enum State { Orbiting, Gathering, Charging, Cooldown }
    State state = State.Orbiting;

    int targetOrbits;
    int completedOrbits;
    float angleAccum; 
    Vector3 chargeTarget;
    Coroutine behaviorCoroutine;

    void Awake()
    {
        if (player == null)
        {
            var found = GameObject.FindGameObjectWithTag("Player");
            if (found) player = found.transform;
        }

        if (parts == null) parts = new List<Transform>();
        if (parts.Count == 0)
        {
            foreach (Transform t in transform)
                if (t.GetComponent<SpriteRenderer>() != null)
                    parts.Add(t);
        }

        PickNewTargetOrbits();
    }

    void OnEnable()
    {
        behaviorCoroutine = StartCoroutine(MainBehaviorLoop());
    }

    void OnDisable()
    {
        if (behaviorCoroutine != null) StopCoroutine(behaviorCoroutine);
    }

    IEnumerator MainBehaviorLoop()
    {
        if (player != null)
            transform.position = player.position + Vector3.right * orbitDistance;

        angleAccum = 0f;
        completedOrbits = 0;

        while (true)
        {
            if (state == State.Orbiting)
            {
                
                if (player != null)
                {
                    float deltaAngle = orbitSpeedDegrees * Time.deltaTime;
                    transform.RotateAround(player.position, Vector3.forward, deltaAngle);
                    angleAccum += Mathf.Abs(deltaAngle);
                    
                    if (angleAccum >= 360f)
                    {
                        angleAccum -= 360f;
                        completedOrbits++;
                        
                        if (completedOrbits >= targetOrbits)
                        {
                            
                            state = State.Gathering;
                        }
                        else
                        {
                           
                            float chance = extraChanceAfterEachOrbit;
                            if (Random.value < chance)
                            {
                                state = State.Gathering;
                            }
                        }
                    }
                }
            }
            else if (state == State.Gathering)
            {
                
                float gatherDuration = Random.Range(gatherTimeMin, gatherTimeMax);

                foreach (var p in parts)
                {
                    var pulse = p.GetComponent<PartPulse>();
                    if (pulse) pulse.StartPulsing(gatherDuration);
                }
                yield return StartCoroutine(GatherRoutine(gatherDuration));
                
                if (player != null) chargeTarget = player.position;
                else chargeTarget = transform.position;
                state = State.Charging;
            }
            else if (state == State.Charging)
            {
                yield return StartCoroutine(ChargeRoutine(chargeTarget));
                
                state = State.Cooldown;
                yield return new WaitForSeconds(0.25f);
                PickNewTargetOrbits();
                state = State.Orbiting;
            }

            yield return null;
        }
    }

    IEnumerator GatherRoutine(float duration)
    {
        float t = 0f;
        while (t < duration)
        {
            
            t += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator ChargeRoutine(Vector3 target)
    {
        float t = 0f;
        Vector3 start = transform.position;
        
        while (t < maxChargeDuration)
        {
            Vector2 dir = (target - transform.position);
            float dist = dir.magnitude;
            if (dist <= 0.05f) break;
            dir.Normalize();
            
            transform.position = Vector2.MoveTowards(transform.position, target, chargeSpeed * Time.deltaTime);

            t += Time.deltaTime;
            yield return null;
        }
        
        yield return null;
    }

    void PickNewTargetOrbits()
    {
        targetOrbits = Random.Range(minOrbitsBeforeDecision, maxOrbitsBeforeDecision + 1);
        completedOrbits = 0;
        angleAccum = 0f;
    }
    
    public void ForceAttackNow()
    {
        if (state != State.Charging)
            state = State.Gathering;
    }
}

    

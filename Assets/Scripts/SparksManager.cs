﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparksManager : MonoBehaviour
{
    ParticleSystem particleSystem;
    private void Awake()
    {
        particleSystem= GetComponent<ParticleSystem>();
    }
    private void OnEnable()
    {
        SimpleGameEvents.OnPickAxeImpact += play;
    }
    private void OnDisable()
    {
        SimpleGameEvents.OnPickAxeImpact -= play;

    }
    // Update is called once per frame
    private void play(TileManager a)
    {
        particleSystem.Play();
    }
}
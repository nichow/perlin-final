﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionClass : MonoBehaviour {
    private int x = 1;
    private void OnParticleCollision(GameObject other)
    {
        // other.GetComponent<ParticleSystem>.particleSystem[] particles;     
        float particle = 1.0f;
        if (x%10==0)
        {
            OSCHandler.Instance.SendMessageToClient("SuperCollider", "/particle", particle);
            x = 0;
        }
        x++;     
      
    }
}

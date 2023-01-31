using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // The renderer that will be made invisible
    public Renderer renderer;

    // The material that will be used to make the renderer invisible
    public Material invisibleMaterial;

    // The original material of the renderer
    private Material originalMaterial;

    private void Start()
    {
        // Store the original material of the renderer
        originalMaterial = renderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Make the renderer invisible when the player enters the trigger
        renderer.material = invisibleMaterial;
    }

    private void OnTriggerExit(Collider other)
    {
        // Restore the original material of the renderer when the player exits the trigger
        renderer.material = originalMaterial;
    }
}


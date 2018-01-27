using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesSystem : MonoBehaviour
{
    public bool enableBones = true;
    public GameObject bonesObject;
    public SkinnedMeshRenderer armSkinnedLeft;
    public SpriteRenderer armSpriteRendererLeft;
    public SkinnedMeshRenderer armSkinnedRight;
    public SpriteRenderer armSpriteRendererRight;
    bool currentBonesMode = true;


    void Update()
    {
        if (enableBones != currentBonesMode)
        {
            ChangeBonesMode(enableBones);
            currentBonesMode = enableBones;
        }
    }

    void ChangeBonesMode(bool bonesEnabled)
    {
        bonesObject.SetActive(bonesEnabled);
        armSkinnedLeft.enabled = bonesEnabled;
        armSpriteRendererLeft.enabled = !bonesEnabled;
        armSkinnedRight.enabled = bonesEnabled;
        armSpriteRendererRight.enabled = !bonesEnabled;

        Debug.Log(bonesEnabled);
    }
}

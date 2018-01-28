using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2PiecesScript : TriggerEffect
{
    public float speed = 1;
    public float maxAperture = 1;
    Vector3 startPosUP;
    Vector3 startPosDOWN;
    GameObject pieceUP;
    GameObject pieceDOWN;

    public AudioSource doorSound;
    bool lastSoundState;

    void Start()
    {    
        pieceUP = transform.GetChild(0).gameObject;
        pieceDOWN = transform.GetChild(1).gameObject;
        startPosUP = pieceUP.transform.position;
        startPosDOWN = pieceDOWN.transform.position;
        lastSoundState = isActive;
    }

    void Update()
    {


        Vector3 posPieceUP = pieceUP.transform.position;
        Vector3 posPieceDOWN = pieceDOWN.transform.position;

        if (isActive)
        {
            if (posPieceUP.y < (startPosUP.y + maxAperture))
            {
                posPieceUP.y += speed * Time.deltaTime;
            }

            if (posPieceDOWN.y > (startPosDOWN.y - maxAperture))
            {
                posPieceDOWN.y -= speed * Time.deltaTime;
            }
        }
        else
        {
            if (posPieceUP.y > startPosUP.y)
            {
                posPieceUP.y -= speed * Time.deltaTime;
            }

            if (posPieceDOWN.y < startPosDOWN.y)
            {
                posPieceDOWN.y += speed * Time.deltaTime;
            }
        }

        pieceUP.transform.position = posPieceUP;
        pieceDOWN.transform.position = posPieceDOWN;

        if (lastSoundState != isActive)
        {
            doorSound.Play();
            lastSoundState = isActive;
        }
    }
}

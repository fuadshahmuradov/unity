using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RG.OrbitalElements;
using UnityEngine.UI;
using System.IO;

public class OrbitMotion : MonoBehaviour
{
    public Transform orbitingObject;
    public Text PositionText;
    public Text DateText;
    public bool orbitActive = true;

    public const int div = 10000;
    public Vector3Double nextPosition;

    public List<TeslaPositions> teslaPositions = new List<TeslaPositions>();
    int i = 1;


    private void Awake()
    {
        TextAsset elements = Resources.Load<TextAsset>("elements");

        string[] data = elements.text.Split(new char[] { '\n' });

        for (int i = 1; i < 607; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });

            TeslaPositions tp = new TeslaPositions();

            tp.date = row[1];
            tp.semimajorAxis = double.Parse(row[2]);
            tp.eccentricity = double.Parse(row[3]);
            tp.inclination = double.Parse(row[4]);
            tp.longitudeOfAscendingNode = double.Parse(row[5]);
            tp.periapsisArgument = double.Parse(row[6]);
            tp.trueAnomaly = double.Parse(row[8]);

            teslaPositions.Add(tp);
        }
    }



    void Start()
    {
        if (orbitingObject == null)
        {
            orbitActive = false;
            return;
        }
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        if (orbitActive)
            for (i = 0; i < 606; i++)
            {
                nextPosition = Calculations.CalculateOrbitalPosition
                    (teslaPositions[i].semimajorAxis,
                    teslaPositions[i].eccentricity,
                    teslaPositions[i].inclination,
                    teslaPositions[i].longitudeOfAscendingNode,
                    teslaPositions[i].periapsisArgument,
                    teslaPositions[i].trueAnomaly);
                nextPosition.x /= div;
                nextPosition.y /= div;
                nextPosition.z /= div;

                PositionText.text = ("Position: " + nextPosition);
                DateText.text = ("Date: " + teslaPositions[i].date);
                orbitingObject.localPosition = new Vector3((float)nextPosition.x, (float)nextPosition.y, (float)nextPosition.z);
                yield return new WaitForSeconds(0.01f);
            }
        StartCoroutine(Move());
    }
}

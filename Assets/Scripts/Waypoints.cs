using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;//don't need a reference to the script, access form anywhere

    void Awake()
    {
        //find all objects that are children of waypoints object
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

}

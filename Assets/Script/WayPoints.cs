using UnityEngine;

public class WayPoints : MonoBehaviour {

    public static Transform[] points;   //this array of transform will be contains the "ruby" points

    private void Awake()
    {
        points = new Transform[transform.childCount];   //childCount allows to get a number of child 
        for (int i = 0; i < points.Length; i++)
            points[i] = transform.GetChild(i);  //initialization of points array
    }

}

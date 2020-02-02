using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{

    //objects that will interact with the rope
    public Transform whatTheRopeIsConnectedTo;
    public Transform whatIsHangingFromTheRope;

    //line render to display the rope
    private LineRenderer lineRenderer;

    //A list with all rope sections
    public List<Vector3> allRopeSections = new List<Vector3>();

    //Rope data
    public float ropeLength;
    public float minRopeLength;
    public float maxRopeLength;
    //How fast we add more/less rope
    public float winchSpeed;
    public float scalar;

    //joint used to approximate the rope
    SpringJoint2D springJoint2D;

    // Start is called before the first frame update
    void Start()
    {
        springJoint2D = whatTheRopeIsConnectedTo.GetComponent<SpringJoint2D>();

        //Init the line renderer we use to display the rope
        lineRenderer = GetComponent<LineRenderer>();

        //Init the spring we use to approximate the rope from point a to b
        UpdateSpring();
    }

    // Update is called once per frame
    void Update()
    {
        //Add more/less rope
        UpdateWinch();

        //Display the rope with a line renderer
        DisplayRope();
    }

    //Update the spring constant and the length of the spring
    private void UpdateSpring()
    {
        springJoint2D.distance = ropeLength;
} 

    //Display the rope with a line render
    private void DisplayRope()
    {
        //this is not actual width, but width use so we can see the ropw
        float ropeWidth = 0.2f;
        lineRenderer.startWidth = ropeWidth;
        lineRenderer.endWidth = ropeWidth;

        //update the list with rope secctions by approximating the rope with bezier curve
        //a bezier curve needs 4 control points
        Vector3 A = whatTheRopeIsConnectedTo.position;
        Vector3 D = whatIsHangingFromTheRope.position;

        //upper control point
        //to get a little curve at the top than at the bottom
        Vector3 B = A + whatTheRopeIsConnectedTo.up * (-(A - D).magnitude * 0.1f);
        //B=A

        //Lower control point
        Vector3 C = D + whatIsHangingFromTheRope.up * ((A - D).magnitude * 0.5f);

        //get the positions 
        BezierCurve.GetBezierCurve(A, B, C, D, allRopeSections);

        //an array wit all rope section positions
        Vector3[] positions = new Vector3[allRopeSections.Count];

        for (int i = 0; i < allRopeSections.Count; i++)
        {
            positions[i] = allRopeSections[i];
        }

        //just add a line between the start ad end position for testing purposes
        //Vector3[] positions = new Vector3[2];

        //position[0] = whatTheRopeIsConnectedTo.position;
        //postions[1] = whatIsHangingFromTheRope.position;

        //add the positions to the line renderer
        lineRenderer.positionCount = positions.Length;

        lineRenderer.SetPositions(positions);
    }

    //add more/less rope
    private void UpdateWinch()
    {
        bool hasChangedRope = false;

        //more rope
        if (Input.GetKey(KeyCode.JoystickButton2) && ropeLength < maxRopeLength)
        {
            ropeLength += winchSpeed * Time.deltaTime;

            hasChangedRope = true;
        }

        else if (Input.GetKey(KeyCode.JoystickButton1) && ropeLength > minRopeLength)
        {
            ropeLength -= scalar * winchSpeed * Time.deltaTime;

            hasChangedRope = true;
        }

        if (hasChangedRope)
        {
            ropeLength = Mathf.Clamp(ropeLength, minRopeLength, maxRopeLength);

            //need to recalculate the k-value because it depends on the length of the rope
            UpdateSpring();
        }
    }

    public static class BezierCurve
    {
        public static void GetBezierCurve(Vector3 A, Vector3 B, Vector3 C, Vector3 D, List<Vector3> allRopeSections)
        {
            //resolution of the line
            //make sure resolution is adding up to 1, so 0.3 will give a gap at the end, but 0.2 will work
            float resolution = 0.1f;

            //clear the list
            allRopeSections.Clear();


            float t = 0;
            while(t<= 1f)
            {
                //find the coordinates between the control points with a bezier curve
                Vector3 newPos = DeCasteljausAlgorithm(A, B, C, D, t);

                allRopeSections.Add(newPos);

                //which t position are we at?
                t += resolution;
            }

            allRopeSections.Add(D);
        }
       
        //the de casteljau's algorithm
        static Vector3 DeCasteljausAlgorithm(Vector3 A, Vector3 B, Vector3 C, Vector3 D, float t)
        {
            //linear interpolation = lerp = (1 - t) * A + t * B
            //could use Vector3.Lep(A, B, t)

            //to make it faster
            float oneMinusT = 1f - t;

            //layer 1
            Vector3 Q = oneMinusT * A + t * B;
            Vector3 R = oneMinusT * B + t * C;
            Vector3 S = oneMinusT * C + t * D;

            //layer 2
            Vector3 P = oneMinusT * Q + t * R;
            Vector3 T = oneMinusT * R + t * S;

            //final interpolated position
            Vector3 U = oneMinusT * P + t * T;

            return U;
        }
        
    }
}
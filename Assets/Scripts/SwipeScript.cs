using UnityEngine;
using System.Collections;

public class SwipeScript : MonoBehaviour
{


    private static float fingerStartTime = 0.0f;
    private static Vector2 fingerStartPos = Vector2.zero;

    private static bool isSwipe = false;
    private static float minSwipeDist = 50.0f;
    private static float maxSwipeTime = 0.5f;


    // Update is called once per frame
    public static int GetTouch()
    {

        if (Input.touchCount > 0)
        {

            foreach (Touch touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        /* this is a new touch */
                        SwipeScript.isSwipe = true;
                        SwipeScript.fingerStartTime = Time.time;
                        SwipeScript.fingerStartPos = touch.position;
                        break;

                    case TouchPhase.Canceled:
                        /* The touch is being canceled */
                        SwipeScript.isSwipe = false;
                        break;

                    case TouchPhase.Ended:

                        float gestureTime = Time.time - fingerStartTime;
                        float gestureDist = (touch.position - fingerStartPos).magnitude;

                        if (SwipeScript.isSwipe && gestureTime < SwipeScript.maxSwipeTime && gestureDist > SwipeScript.minSwipeDist)
                        {
                            Vector2 direction = touch.position - fingerStartPos;
                            Vector2 swipeType = Vector2.zero;

                            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                            {
                                // the swipe is horizontal:
                                swipeType = Vector2.right * Mathf.Sign(direction.x);
                            }
                            else
                            {
                                // the swipe is vertical:
                                swipeType = Vector2.up * Mathf.Sign(direction.y);
                            }

                            if (swipeType.x != 0.0f)
                            {
                                if (swipeType.x > 0.0f)
                                {
                                    // MOVE RIGHT
                                }
                                else
                                {
                                    // MOVE LEFT
                                }
                            }

                            if (swipeType.y != 0.0f)
                            {
                                if (swipeType.y > 0.0f)
                                {
                                    //Move up
                                    return 0;
                                }
                                else
                                {
                                    //Move down
                                    return 1;
                                }
                            }

                        }

                        break;
                }
            }
        }
        return -1;

    }
}

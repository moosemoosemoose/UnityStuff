using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controlOverlay : MonoBehaviour
{
    public Image _A,_B,_C,_D,_E,_F,_G,_H,_I,_J,_K,_L,_M,_N,_O,_P,_Q,_R,_S,_T,_U,_V,_W,_X,_Y,_Z;
    public Image _escape, _zero, _one, _two, _three, _four, _five, _six, _seven, _eight, _nine, _dash, _equals, _backspace;
    public Image _tab, _caps, _leftShift, _leftControl, _leftAlt, _space, _leftBracket, _rightBracket, _backSlash,
        _enter, _semiColon, _apostrophe, _comma, _period, _forwardSlash, _rightShift, _rightControl, _rightAlt, _up, _left, _right, _down;
    public Image square, ex, triangle, circle, leftStick, rightStick, r1, r2, l1, l2, dpadU, dpadD, dpadL, dpadR, options, share, big, ps;
    public float lerpTime;

    void Update()
    {
        keyListener();
    }

    public void keyListener()
    {
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))) 
        {
			if (Input.GetKeyDown(vKey)) 
            {
                switch (vKey)
                {
                    //ROW ONE
                    case KeyCode.Escape:
                        fadeIn(_escape);
                        break;
                    case KeyCode.Alpha0:
                        fadeIn(_zero);
                        break;
                    case KeyCode.Alpha1:
                        fadeIn(_one);
                        break;
                    case KeyCode.Alpha2:
                        fadeIn(_two);
                        break;
                    case KeyCode.Alpha3:
                        fadeIn(_three);
                        break;
                    case KeyCode.Alpha4:
                        fadeIn(_four);
                        break;
                    case KeyCode.Alpha5:
                        fadeIn(_five);
                        break;
                    case KeyCode.Alpha6:
                        fadeIn(_six);
                        break;
                    case KeyCode.Alpha7:
                        fadeIn(_seven);
                        break;
                    case KeyCode.Alpha8:
                        fadeIn(_eight);
                        break;
                    case KeyCode.Alpha9:
                        fadeIn(_nine);
                        break;
                    case KeyCode.Minus:
                        fadeIn(_dash);
                        break;
                    case KeyCode.Equals:
                        fadeIn(_equals);
                        break;
                    case KeyCode.Backspace:
                        fadeIn(_backspace);
                        break;
                    //ROW TWO
                    case KeyCode.Tab:
                        fadeIn(_tab);
                        break;
                    case KeyCode.Q:
                        fadeIn(_Q);
                        break;
                    case KeyCode.W:
                        fadeIn(_W);
                        break;
                    case KeyCode.E:
                        fadeIn(_E);
                        break;
                    case KeyCode.R:
                        fadeIn(_R);
                        break;
                    case KeyCode.T:
                        fadeIn(_T);
                        break;
                    case KeyCode.Y:
                        fadeIn(_Y);
                        break;
                    case KeyCode.U:
                        fadeIn(_U);
                        break;
                    case KeyCode.I:
                        fadeIn(_I);
                        break;
                    case KeyCode.O:
                        fadeIn(_O);
                        break;
                    case KeyCode.P:
                        fadeIn(_P);
                        break;
                    case KeyCode.LeftBracket:
                        fadeIn(_leftBracket);
                        break;
                    case KeyCode.RightBracket:
                        fadeIn(_rightBracket);
                        break;
                    case KeyCode.Backslash:
                        fadeIn(_backSlash);
                        break;
                    //ROW THREE
                    case KeyCode.CapsLock:
                        fadeIn(_caps);
                        break;
                    case KeyCode.A:
                        fadeIn(_A);
                        break;
                    case KeyCode.S:
                        fadeIn(_S);
                        break;
                    case KeyCode.D:
                        fadeIn(_D);
                        break;
                    case KeyCode.F:
                        fadeIn(_F);
                        break;
                    case KeyCode.G:
                        fadeIn(_G);
                        break;
                    case KeyCode.H:
                        fadeIn(_H);
                        break;
                    case KeyCode.J:
                        fadeIn(_J);
                        break;
                    case KeyCode.K:
                        fadeIn(_K);
                        break;
                    case KeyCode.L:
                        fadeIn(_L);
                        break;
                    case KeyCode.Semicolon:
                        fadeIn(_semiColon);
                        break;
                    case KeyCode.Quote:
                        fadeIn(_apostrophe);
                        break;
                    case KeyCode.Return:
                        fadeIn(_enter);
                        break;
                    //ROW FOUR
                    case KeyCode.LeftShift:
                        fadeIn(_leftShift);
                        break;
                    case KeyCode.Z:
                        fadeIn(_Z);
                        break;
                    case KeyCode.X:
                        fadeIn(_X);
                        break;
                    case KeyCode.C:
                        fadeIn(_C);
                        break;
                    case KeyCode.V:
                        fadeIn(_V);
                        break;
                    case KeyCode.B:
                        fadeIn(_B);
                        break;
                    case KeyCode.N:
                        fadeIn(_N);
                        break;
                    case KeyCode.M:
                        fadeIn(_M);
                        break;
                    case KeyCode.Comma:
                        fadeIn(_comma);
                        break;
                    case KeyCode.Period:
                        fadeIn(_period);
                        break;
                    case KeyCode.Slash:
                        fadeIn(_forwardSlash);
                        break;
                    case KeyCode.RightShift:
                        fadeIn(_rightShift);
                        break;
                    //ROW FIVE
                    case KeyCode.LeftControl:
                        fadeIn(_leftControl);
                        break;
                    case KeyCode.LeftAlt:
                        fadeIn(_leftAlt);
                        break;
                    case KeyCode.Space:
                        fadeIn(_space);
                        break;
                    case KeyCode.RightAlt:
                        fadeIn(_rightAlt);
                        break;
                    case KeyCode.RightControl:
                        fadeIn(_rightControl);
                        break;
                    case KeyCode.LeftArrow:
                        fadeIn(_left);
                        break;
                    case KeyCode.DownArrow:
                        fadeIn(_down);
                        break;
                    case KeyCode.RightArrow:
                        fadeIn(_right);
                        break;
                    case KeyCode.UpArrow:
                        fadeIn(_up);
                        break;
                    //CONTROLLER
                    case KeyCode.JoystickButton0:
                        fadeIn(square);
                        break;
                    case KeyCode.JoystickButton1:
                        fadeIn(ex);
                        break;
                    case KeyCode.JoystickButton2:
                        fadeIn(circle);
                        break;
                    case KeyCode.JoystickButton3:
                        fadeIn(triangle);
                        break;
                    case KeyCode.JoystickButton4:
                        fadeIn(l1);
                        break;
                    case KeyCode.JoystickButton5:
                        fadeIn(r1);
                        break;
                    case KeyCode.JoystickButton6:
                        fadeIn(l2);
                        break;
                    case KeyCode.JoystickButton7:
                        fadeIn(r2);
                        break;
                    case KeyCode.JoystickButton8:
                        fadeIn(share);
                        break;
                    case KeyCode.JoystickButton9:
                        fadeIn(options);
                        break;
                    case KeyCode.JoystickButton10:
                        fadeIn(leftStick);
                        break;
                    case KeyCode.JoystickButton11:
                        fadeIn(rightStick);
                        break;
                    case KeyCode.JoystickButton12:
                        fadeIn(ps);
                        break;
                    case KeyCode.JoystickButton13:
                        fadeIn(big);
                        break; 
                    default:
                        break;
                }
            }

            if (Input.GetKeyUp(vKey)) 
            {
                switch (vKey)
                {
                    //ROW ONE
                    case KeyCode.Escape:
                        fadeOut(_escape);
                        break;
                    case KeyCode.Alpha0:
                        fadeOut(_zero);
                        break;
                    case KeyCode.Alpha1:
                        fadeOut(_one);
                        break;
                    case KeyCode.Alpha2:
                        fadeOut(_two);
                        break;
                    case KeyCode.Alpha3:
                        fadeOut(_three);
                        break;
                    case KeyCode.Alpha4:
                        fadeOut(_four);
                        break;
                    case KeyCode.Alpha5:
                        fadeOut(_five);
                        break;
                    case KeyCode.Alpha6:
                        fadeOut(_six);
                        break;
                    case KeyCode.Alpha7:
                        fadeOut(_seven);
                        break;
                    case KeyCode.Alpha8:
                        fadeOut(_eight);
                        break;
                    case KeyCode.Alpha9:
                        fadeOut(_nine);
                        break;
                    case KeyCode.Minus:
                        fadeOut(_dash);
                        break;
                    case KeyCode.Equals:
                        fadeOut(_equals);
                        break;
                    case KeyCode.Backspace:
                        fadeOut(_backspace);
                        break;
                    //ROW TWO
                    case KeyCode.Tab:
                        fadeOut(_tab);
                        break;
                    case KeyCode.Q:
                        fadeOut(_Q);
                        break;
                    case KeyCode.W:
                        fadeOut(_W);
                        break;
                    case KeyCode.E:
                        fadeOut(_E);
                        break;
                    case KeyCode.R:
                        fadeOut(_R);
                        break;
                    case KeyCode.T:
                        fadeOut(_T);
                        break;
                    case KeyCode.Y:
                        fadeOut(_Y);
                        break;
                    case KeyCode.U:
                        fadeOut(_U);
                        break;
                    case KeyCode.I:
                        fadeOut(_I);
                        break;
                    case KeyCode.O:
                        fadeOut(_O);
                        break;
                    case KeyCode.P:
                        fadeOut(_P);
                        break;
                    case KeyCode.LeftBracket:
                        fadeOut(_leftBracket);
                        break;
                    case KeyCode.RightBracket:
                        fadeOut(_rightBracket);
                        break;
                    case KeyCode.Backslash:
                        fadeOut(_backSlash);
                        break;
                    //ROW THREE
                    case KeyCode.CapsLock:
                        fadeOut(_caps);
                        break;
                    case KeyCode.A:
                        fadeOut(_A);
                        break;
                    case KeyCode.S:
                        fadeOut(_S);
                        break;
                    case KeyCode.D:
                        fadeOut(_D);
                        break;
                    case KeyCode.F:
                        fadeOut(_F);
                        break;
                    case KeyCode.G:
                        fadeOut(_G);
                        break;
                    case KeyCode.H:
                        fadeOut(_H);
                        break;
                    case KeyCode.J:
                        fadeOut(_J);
                        break;
                    case KeyCode.K:
                        fadeOut(_K);
                        break;
                    case KeyCode.L:
                        fadeOut(_L);
                        break;
                    case KeyCode.Semicolon:
                        fadeOut(_semiColon);
                        break;
                    case KeyCode.Quote:
                        fadeOut(_apostrophe);
                        break;
                    case KeyCode.Return:
                        fadeOut(_enter);
                        break;
                    //ROW FOUR
                    case KeyCode.LeftShift:
                        fadeOut(_leftShift);
                        break;
                    case KeyCode.Z:
                        fadeOut(_Z);
                        break;
                    case KeyCode.X:
                        fadeOut(_X);
                        break;
                    case KeyCode.C:
                        fadeOut(_C);
                        break;
                    case KeyCode.V:
                        fadeOut(_V);
                        break;
                    case KeyCode.B:
                        fadeOut(_B);
                        break;
                    case KeyCode.N:
                        fadeOut(_N);
                        break;
                    case KeyCode.M:
                        fadeOut(_M);
                        break;
                    case KeyCode.Comma:
                        fadeOut(_comma);
                        break;
                    case KeyCode.Period:
                        fadeOut(_period);
                        break;
                    case KeyCode.Slash:
                        fadeOut(_forwardSlash);
                        break;
                    case KeyCode.RightShift:
                        fadeOut(_rightShift);
                        break;
                    //ROW FIVE
                    case KeyCode.LeftControl:
                        fadeOut(_leftControl);
                        break;
                    case KeyCode.LeftAlt:
                        fadeOut(_leftAlt);
                        break;
                    case KeyCode.Space:
                        fadeOut(_space);
                        break;
                    case KeyCode.RightAlt:
                        fadeOut(_rightAlt);
                        break;
                    case KeyCode.RightControl:
                        fadeOut(_rightControl);
                        break;
                    case KeyCode.LeftArrow:
                        fadeOut(_left);
                        break;
                    case KeyCode.DownArrow:
                        fadeOut(_down);
                        break;
                    case KeyCode.RightArrow:
                        fadeOut(_right);
                        break;
                    case KeyCode.UpArrow:
                        fadeOut(_up);
                        break;
                    //CONTROLLER
                    case KeyCode.JoystickButton0:
                        fadeOut(square);
                        break;
                    case KeyCode.JoystickButton1:
                        fadeOut(ex);
                        break;
                    case KeyCode.JoystickButton2:
                        fadeOut(circle);
                        break;
                    case KeyCode.JoystickButton3:
                        fadeOut(triangle);
                        break;
                    case KeyCode.JoystickButton4:
                        fadeOut(l1);
                        break;
                    case KeyCode.JoystickButton5:
                        fadeOut(r1);
                        break;
                    case KeyCode.JoystickButton6:
                        fadeOut(l2);
                        break;
                    case KeyCode.JoystickButton7:
                        fadeOut(r2);
                        break;
                    case KeyCode.JoystickButton8:
                        fadeOut(share);
                        break;
                    case KeyCode.JoystickButton9:
                        fadeOut(options);
                        break;
                    case KeyCode.JoystickButton10:
                        fadeOut(leftStick);
                        break;
                    case KeyCode.JoystickButton11:
                        fadeOut(rightStick);
                        break;
                    case KeyCode.JoystickButton12:
                        fadeOut(ps);
                        break;
                    case KeyCode.JoystickButton13:
                        fadeOut(big);
                        break;
                    default:
                        break;
                }
            }
            //STICKS AND DPAD
            if (Input.GetAxis("DPADH") == 1)
            {
                fadeIn(dpadR);
                fadeOut(dpadR);
            }
            if (Input.GetAxis("DPADH") == -1)
            {
                fadeIn(dpadL);
                fadeOut(dpadL);
            }
            if (Input.GetAxis("DPADV") == 1)
            {
                fadeIn(dpadU);
                fadeOut(dpadU);
            }
            if (Input.GetAxis("DPADV") == -1)
            {
                fadeIn(dpadD);
                fadeOut(dpadD);
            }
            if (Mathf.Abs(Input.GetAxis("LeftStickHorizontal")) > .5f || Mathf.Abs(Input.GetAxis("LeftStickVertical")) > .5f)
            {
                fadeIn(leftStick);
                fadeOut(leftStick);
            }
            if (Mathf.Abs(Input.GetAxis("RightStickHorizontal")) > .5f || Mathf.Abs(Input.GetAxis("RightStickVertical")) > .5f)
            {
                fadeIn(rightStick);
                fadeOut(rightStick);
            }
            
        }
    }
    public void fadeIn(Image image)
    {
        StartCoroutine(fadeCanvas(image, 0.5f, 1.0f , lerpTime));
    }

    public void fadeOut(Image image)
    {
        StartCoroutine(fadeCanvas(image, 1.0f, 0.5f, lerpTime));
    }

    public IEnumerator fadeCanvas(Image keyImage, float start, float end, float lerpTime)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float pComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            var tempColor =  keyImage.color;
            
            timeSinceStarted = Time.time - _timeStartedLerping;
            pComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, pComplete);
            tempColor.a = currentValue;
            keyImage.color = tempColor;

            if(pComplete >=1) break;
            
            yield return new WaitForEndOfFrame();
        }
        
    }
}

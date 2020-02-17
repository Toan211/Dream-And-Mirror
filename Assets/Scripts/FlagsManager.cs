using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Flags list
 * 
 * 0 : walking
 * 1 : 
 * 2 : ...
 */

public class FlagsManager : MonoBehaviour
{
    public const int m_flagcount = 20;
    public static BitArray flags_list = new BitArray(m_flagcount);
    
    public static bool getFlag(int indx)
    {
        if (indx < 0 || indx >= m_flagcount)
        {
            return false;
        }
        return flags_list[indx];
    }
    public static bool setFlag(int indx,bool flag)
    {
        if (indx < 0 || indx >= m_flagcount)
        {
            return false;
        }
        flags_list[indx] = flag;
        return true;
    }
}

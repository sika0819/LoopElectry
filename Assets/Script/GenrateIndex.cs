using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GenrateIndex {
    private static int index=0;
    public static int Index {
        get {
            return index++;
        }
    }
}

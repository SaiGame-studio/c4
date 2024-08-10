using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyScript : MonoBehaviour
{
    void FixedUpdate()
    {
        //this.TestOperator();
        //this.TestClass();

        this.TestIsDead();
    }

    void TestIsDead()
    {
        Zombie zombie = new Zombie();
        zombie.SetHp(-1);
        string logMessage = zombie.GetName() + ": " + zombie.GetCurrentHp() + " " + zombie.IsDead();
        Debug.Log(logMessage);
    }

    void TestOperator()
    {
        int variable1 = 200 + 100;
        int variable2 = 200 - 100;
        int variable3 = 200 * 100;
        int variable4 = 200 / 100;
        Debug.Log("variable1: " + variable1);
        Debug.Log("variable2: " + variable2);
        Debug.Log("variable3: " + variable3);
        Debug.Log("variable4: " + variable4);

        int a = 3;
        int b = 3;
        bool c = a == b;
        Debug.Log(a + " == " + b + " = " + c);
    }

    void TestClass()
    {
        Zombie zombie = new Zombie();
        Wolf wolf = new Wolf();
        Eagle eagle = new Eagle();
        Ghost ghost = new Ghost();

        zombie.Moving();
        wolf.Moving();
        eagle.Moving();
        ghost.Moving();
    }
}

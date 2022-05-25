using System.Collections;
using System.Collections.Generic;
using System;

public class TookRandomMassNumber
{
    private static int count;

    public static int TookRandom() => count = CreatePerson.mass[new Random().Next(CreatePerson.mass.Count)];
}

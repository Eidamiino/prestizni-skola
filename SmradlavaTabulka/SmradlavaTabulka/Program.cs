Console.WriteLine("Tabulka smradu:\n***************************");
smrad("Adam Pala");
smrad("Adam Hanzlík");
smrad("Jan Rada");
smrad("Adam Kijonka");
smrad("Mirek Přeček");
smrad("Matěj Bartusek");
smrad("Ondřej Valenta");




static void smrad(string jmeno)
{
    int suma = 0, delka = jmeno.Length;
    double prumer;
    for (int i = 0; i < delka; i++)
    {
        suma += jmeno[i];
    }
    prumer = (double) suma / delka;
    prumer = Math.Round(prumer);
    if (prumer % 7 == 0)
    {
        Console.WriteLine($"{jmeno}\tsmrdí jako bolavá noha bezdomovce");
    }
    else if (prumer % 5 == 0)
    {
        Console.WriteLine($"{jmeno}\tsmrdí jako koňská řiť");
    }
    else if (prumer % 3 == 0)
    {
        Console.WriteLine($"{jmeno}\tsmrdí jako cibuláči");
    }
    else
    {
        Console.WriteLine($"{jmeno}\tnesmrdí dost");
    }
}

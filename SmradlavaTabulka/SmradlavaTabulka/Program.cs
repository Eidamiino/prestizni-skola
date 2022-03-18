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
    Console.Write($"{jmeno}\t");
    if (prumer % 7 == 0||jmeno.ToUpper()=="HONZA RADA"||jmeno.ToUpper()=="JAN RADA"||jmeno.ToUpper()=="JANUS RADUS"||jmeno.ToUpper()=="HONZUS RADUS"||jmeno.ToUpper()=="ZELVAMAN"||jmeno.ToUpper()=="ŽELVAMAN"||jmeno.ToUpper()=="ZELVA MAN"||jmeno.ToUpper()=="ŽELVA MAN"||jmeno.ToUpper()=="JAN BRADA")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("smrdí jako bolavá noha bezdomovce");

    }
    else if (prumer % 5 == 0)
    {
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("smrdí jako koňská řiť");
    }
    else if (prumer % 3 == 0)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("smrdí jako cibuláči");
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("nesmrdí dost");
    }

    Console.ForegroundColor = ConsoleColor.Gray;
}

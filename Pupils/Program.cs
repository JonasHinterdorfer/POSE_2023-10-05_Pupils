using Pupils;

Console.WriteLine("*** Pupils ***");

var baseYear = DateTime.Now.Year;

var p1 = new Pupil("Horst", "Fuchs",
    new(baseYear - 72, 04, 17));
var p2 = new Pupil("Susi", "Sorglos",
    new(baseYear - 15, 11, 08));
var p3 = new Pupil("Max", "Muster",
    new(baseYear - 16, 08, 30));
var p4 = new Pupil("Petra", "Programmierer",
    new(baseYear - 51, 11, 08));

p1.ZipCode = 4060;
p2.ZipCode = 4020;
p3.ZipCode = 688;
p4.ZipCode = 5020;

PrintNextSection("Overview");
foreach (var pupil in new[] { p1, p2, p3, p4 })
{
    PrintPupilInformation(pupil);
}

PrintNextSection("Age Checks 1");
AgeCheck(p1, AgeType.RetirementAge);
AgeCheck(p2, AgeType.VotingAge);
AgeCheck(p3, AgeType.VotingAge);
AgeCheck(p3, AgeType.FullAge);
AgeCheck(p4, AgeType.FullAge);
AgeCheck(p4, AgeType.RetirementAge);

PrintNextSection("Age Checks 2");
AgeComparison(p1, p2);
AgeComparison(p2, p3);
AgeComparison(p3, p4);
AgeComparison(p4, p1);

PrintNextSection("Location Checks");
LocationComparison(p1, p2);
LocationComparison(p2, p3);
LocationComparison(p3, p4);
LocationComparison(p4, p1);


#region utility methods

void PrintNextSection(string section)
{
    Console.WriteLine($"{Environment.NewLine}{section}");
}

void PrintPupilInformation(Pupil pupil)
{
    Console.WriteLine($"[#{pupil.Id}] {pupil.FirstName} " +
                      $"{pupil.LastName} | Age = {pupil.Age}");
}

void AgeCheck(Pupil pupil, AgeType type)
{
    var fulfilled = $"{(pupil.IsOfAge(type) ? "has" : "has not")} fulfilled";
    Console.WriteLine($"Pupil {pupil.FirstName} {fulfilled} the requirements for {type}");
}

void AgeComparison(Pupil some, Pupil other)
{
    // note: we are ignoring pupils of equal age here

    void PrintOlder(Pupil older, Pupil younger)
    {
        Console.WriteLine($"{older.FirstName} is older than {younger.FirstName}");
    }

    if (some.IsOlderThan(other))
    {
        PrintOlder(some, other);
        return;
    }

    PrintOlder(other, some);
}

void LocationComparison(Pupil some, Pupil other)
{
    if (some.LivesNearby(other))
    {
        Console.WriteLine($"{some.FirstName} lives near {other.FirstName}");
        return;
    }

    Console.WriteLine($"{some.FirstName} and {other.FirstName} live some way apart");
}

#endregion
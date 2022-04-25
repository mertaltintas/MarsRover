using MarsRover.Models;

var pleteauCoord = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();

if (pleteauCoord.Count != 2)
    throw new Exception("Invalid field coordinates");

var plateau = new Plateau(pleteauCoord.First(), pleteauCoord.Last());

List<Rover> roversToDeploy = new List<Rover>();

while (true)
{
    string? positionLine = Console.ReadLine();
    if (string.IsNullOrEmpty(positionLine)) break;

    var position = positionLine.Trim().Split(' ');

    if (position.Count() != 3)
        throw new Exception("Invalid position input");

    int coordX = Convert.ToInt32(position[0]);
    int coordY = Convert.ToInt32(position[1]);
    var direction = (Directions)Enum.Parse(typeof(Directions), position[2]);

    var newRover = new Rover(coordX, coordY, direction);

    string? instructionLine = Console.ReadLine();
    if (string.IsNullOrEmpty(instructionLine)) break;

    newRover.pendingInstructions = instructionLine.ToUpper();

    roversToDeploy.Add(newRover);
}

if (roversToDeploy.Count() == 0)
    throw new Exception("The assigned rover was not found.");

Console.WriteLine("Output:");
foreach (var rover in roversToDeploy)
{
    rover.StartAction(plateau);
    var finalState = rover.GetFinalState();
    Console.WriteLine($"{finalState.x} {finalState.y} {finalState.direction}");
}


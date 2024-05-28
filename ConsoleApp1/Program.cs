Client client;
Console.WriteLine();

client = new Client(new VictorianFactory());
client.Run();

Console.WriteLine();
Console.WriteLine();
client = new Client(new ArtDecoFactory());
client.Run();
Console.WriteLine();
Console.WriteLine();
client = new Client(new ModernFactory());
client.Run();


#region Table
abstract class AbstractTable { }
class VictorianTable : AbstractTable { }
class ArtDecoTable : AbstractTable { }
class ModernTable : AbstractTable { }
#endregion

#region Chair
abstract class AbstractChair { }
class VictorianChair : AbstractChair { }
class ArtDecoChair : AbstractChair { }
class ModernChair : AbstractChair { }
#endregion

#region Sofa
abstract class AbstractSofa
{
    public abstract void Interact(AbstractChair chair);
    public abstract void Interact(AbstractTable table);
}

class VictorianSofa : AbstractSofa
{
    public override void Interact(AbstractChair chair)
    {
        Console.WriteLine(this + " interacts with " + chair);
    }

    public override void Interact(AbstractTable table)
    {
        Console.WriteLine(this + " interacts with " + table);
    }
}

class ModernSofa : AbstractSofa
{
    public override void Interact(AbstractChair chair)
    {
        Console.WriteLine(this + " interacts with " + chair);
    }

    public override void Interact(AbstractTable table)
    {
        Console.WriteLine(this + " interacts with " + table);
    }
}

class ArtDecoSofa : AbstractSofa
{
    public override void Interact(AbstractChair chair)
    {
        Console.WriteLine(this + " interacts with " + chair);
    }

    public override void Interact(AbstractTable table)
    {
        Console.WriteLine(this + " interacts with " + table);
    }
}

#endregion

#region Factory
abstract class AbstractFactory
{

    public abstract AbstractChair CreateChair();
    public abstract AbstractSofa CreateSofa();
    public abstract AbstractTable CreateTable();
}

class VictorianFactory : AbstractFactory
{
    public override AbstractChair CreateChair() => new VictorianChair();
    public override AbstractSofa CreateSofa() => new VictorianSofa();
    public override AbstractTable CreateTable() => new VictorianTable();
}
class ArtDecoFactory : AbstractFactory
{
    public override AbstractChair CreateChair() => new ArtDecoChair();
    public override AbstractSofa CreateSofa() => new ArtDecoSofa();
    public override AbstractTable CreateTable() => new ArtDecoTable();
}
class ModernFactory : AbstractFactory
{
    public override AbstractChair CreateChair() => new ModernChair();
    public override AbstractSofa CreateSofa() => new ModernSofa();
    public override AbstractTable CreateTable() => new ModernTable();
}

#endregion

class Client
{
    AbstractChair? _chair;
    AbstractSofa? _sofa;
    AbstractTable? _table;

    public Client(AbstractFactory factory)
    {
        _chair = factory.CreateChair();
        _sofa = factory.CreateSofa();
        _table = factory.CreateTable();
    }


    public void Run()
    {
        _sofa?.Interact(_chair!);
        _sofa?.Interact(_table!);
    }
}

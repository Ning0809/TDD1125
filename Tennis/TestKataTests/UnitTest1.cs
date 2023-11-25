namespace TestKataTests;

public class TennisKataTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Love_All()
    {
        var tennisKata = new TennisKata();
        var score = tennisKata.Score();
        Assert.AreEqual("Love All",score);
    }
}

public class TennisKata
{
    public string Score()
    {
        return "Love All";
    }
}
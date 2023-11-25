namespace TestKataTest;

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
        Assert.AreEqual("Love All", score);
    }

    [Test]
    public void Fifteen_Love()
    {
        var tennisKata = new TennisKata();
        tennisKata.FirstPlayerScore();
        var score = tennisKata.Score();

        Assert.AreEqual("Fifteen Love", score);
    }

    [Test]
    public void Thirty_Love()
    {
        var tennisKata = new TennisKata();
        tennisKata.FirstPlayerScore();
        tennisKata.FirstPlayerScore();
        var score = tennisKata.Score();

        Assert.AreEqual("Thirty Love", score);
    }

[Test]
    public void Forty_Love()
    {
        var tennisKata = new TennisKata();
        tennisKata.FirstPlayerScore();
        tennisKata.FirstPlayerScore();
        tennisKata.FirstPlayerScore();
        var score = tennisKata.Score();

        Assert.AreEqual("Forty Love", score);
    }
   
    [Test]
    public void First_Player_Win()
    {
        var tennisKata = new TennisKata();
        tennisKata.FirstPlayerScore();
        tennisKata.FirstPlayerScore();
        tennisKata.FirstPlayerScore();
        tennisKata.FirstPlayerScore();
        var score = tennisKata.Score();

        Assert.AreEqual("Tom Win", score);
    }
    
}

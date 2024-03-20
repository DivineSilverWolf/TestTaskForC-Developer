using GameLibrary.Checkers;
[TestFixture]
public class CheckerTests
{
    [Test]
    public void Check_ValidGuess_ReturnsCorrectResult()
    {
        // Arrange
        Checker checker = new()
        {
            SecretWord = "1234"
        };

        // Act
        var result = checker.Check("1324");
        
        // Assert
        Assert.IsFalse(result.Item1);
        Assert.That(result.Item2, Is.EqualTo("2 «коровы» и 2 «быка»"));
    }
    
    [Test]
    public void Check_SecretWordIsNull_ThrowsException()
    {
        // Arrange
        Checker checker = new();
        
        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => checker.SecretWord = null);
    }

    [Test]
    public void CowAndBullStrings_CowAndBullCounts_ReturnsCorrectStrings()
    {
        // Arrange
        int cow = 2;
        int bull = 1;

        // Act
        var result = Checker.CowAndBullStrings(cow, bull);

        // Assert
        Assert.That(result.Item1, Is.EqualTo("коровы"));
        Assert.That(result.Item2, Is.EqualTo("бык"));
    }
}

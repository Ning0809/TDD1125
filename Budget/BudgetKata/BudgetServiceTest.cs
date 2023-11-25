using Budget;
using NSubstitute;
using NUnit.Framework;

namespace BudgetKata;

[TestFixture]
public class BudgetServiceTest
{
    private IBudgetRepo _budgetRepo = Substitute.For<IBudgetRepo>();
    private BudgetService _budgetService;

    [SetUp]
    public void SetUp()
    {
        _budgetService = new BudgetService(_budgetRepo);
    }

[Test]
    public void query_one_day()
    {
        GivenBudget(new List<Budget>()
        {
            new Budget()
            {
                YearMonth = "202311",
                Amount = 300
            }
        });
        var actualBudget = _budgetService.Query(new DateTime(2023, 11, 25), new DateTime(2023, 11, 25));
        BudgetShouldBe(10, actualBudget);
    }

    [Test]
    public void query_same_month()
    {
        GivenBudget(new List<Budget>()
        {
            new Budget()
            {
                YearMonth = "202311",
                Amount = 300
            }
        });
        var actualBudget = _budgetService.Query(new DateTime(2023, 11, 23), new DateTime(2023, 11, 25));
        BudgetShouldBe(30, actualBudget);
    }

[Test]
    public void invalid_request()
    {
        GivenBudget(new List<Budget>()
        {
            new Budget()
            {
                YearMonth = "202311",
                Amount = 300
            }
        });
        var actualBudget = _budgetService.Query(new DateTime(2023, 11, 27), new DateTime(2023, 11, 25));
        BudgetShouldBe(0, actualBudget);
    }

    [Test]
    public void query_no_data()
    {
        GivenBudget(new List<Budget>()
        {
            new Budget()
            {
                YearMonth = "202310",
                Amount = 300
            }
        });
        var actualBudget = _budgetService.Query(new DateTime(2023, 11, 25), new DateTime(2023, 11, 25));
        BudgetShouldBe(0, actualBudget);
    }

    [Test]
    public void leap_month()
    {
        GivenBudget(new List<Budget>()
        {
            new Budget()
            {
                YearMonth = "201602",
                Amount = 290
            }
        });
        var actualBudget = _budgetService.Query(new DateTime(2016, 2, 1), new DateTime(2016, 2, 1));
        BudgetShouldBe(10, actualBudget);
    }

    private static void BudgetShouldBe(decimal expected, decimal actualBudget)
    {
        Assert.AreEqual(expected, actualBudget);
    }

    private void GivenBudget(List<Budget> budget)
    {
        _budgetRepo.GetAll().Returns(budget);
    }
}
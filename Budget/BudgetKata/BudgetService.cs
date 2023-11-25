namespace BudgetKata;

public class BudgetService
{
    private IBudgetRepo _budgetRepo;

    public BudgetService(IBudgetRepo budgetRepo)
    {
        _budgetRepo = budgetRepo;
    }

    public decimal Query(DateTime start, DateTime end)
    {
        if (end < start)
        {
            return 0;
        }
        var budgets = _budgetRepo.GetAll();
        decimal totalBudget = 0;
        foreach (var budget in budgets)
        {
            var year = budget.YearMonth.Substring(0,4);
            var month = budget.YearMonth.Substring(4,2);

            var budgetDate = new DateTime(Int32.Parse(year),Int32.Parse(month),1); 
            var daysInMonth = DateTime.DaysInMonth(budgetDate.Year, budgetDate.Month);
            var budgetPerDay = budget.Amount/daysInMonth;
            var queryDays = (end - start).Days + 1;

            totalBudget= budgetPerDay * queryDays;



        }

        return totalBudget;

    }

}

public interface IBudgetRepo
{
    List<Budget> GetAll();
}
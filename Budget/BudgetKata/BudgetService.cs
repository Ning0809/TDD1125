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
        var budgets = _budgetRepo.GetAll();

        foreach (var budget in budgets)
        {
            var year = budget.YearMonth.Substring(0,4);
            var month = budget.YearMonth.Substring(4,2);

            var budgetDate = new DateTime(Int32.Parse(year),Int32.Parse(month),1);
            
            
        }


    }

}

public interface IBudgetRepo
{
    List<Budget> GetAll();
}
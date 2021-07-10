namespace MyFitnessApp.Web.Validators
{
    // A_Y_N
    public interface IValidator<in T>
        where T : class
    {
        string Validate(T entity);
    }
}

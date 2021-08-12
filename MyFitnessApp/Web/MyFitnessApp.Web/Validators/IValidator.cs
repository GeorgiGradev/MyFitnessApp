namespace MyFitnessApp.Web.Validators
{
    public interface IValidator<in T>
        where T : class
    {
        string Validate(T entity);
    }
}

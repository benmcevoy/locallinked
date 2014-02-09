namespace LocalLinked.Umbraco.Services.Membership
{
    public interface IAuthenticationTokenService
    {
        bool IsValid(IAuthenticationToken authenticationToken);

        IAuthenticationToken Extend(IAuthenticationToken authenticationToken);

        IAuthenticationToken Generate(string userName);
    }
}
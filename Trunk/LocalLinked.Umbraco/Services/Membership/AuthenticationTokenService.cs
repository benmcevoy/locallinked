namespace LocalLinked.Umbraco.Services.Membership
{
    internal class AuthenticationTokenService : IAuthenticationTokenService
    {
        private readonly AuthenticationTokenServiceConfig _config;

        public AuthenticationTokenService(AuthenticationTokenServiceConfig config)
        {
            _config = config;
        }

        public string Encrypt(IAuthenticationToken authenticationToken)
        {
            throw new System.NotImplementedException();
        }

        public IAuthenticationToken Decrypt(string encryptedToken)
        {
            throw new System.NotImplementedException();
        }

        public bool IsValid(IAuthenticationToken authenticationToken)
        {
            // decrypt and test checksum
            // check database
            throw new System.NotImplementedException();
        }

        public IAuthenticationToken Extend(IAuthenticationToken authenticationToken)
        {
            throw new System.NotImplementedException();
        }

        public IAuthenticationToken Generate(string userName)
        {
            // Encrypt(guid + timestamp + username + checksum)
            // in some serialized form
            // store in db with future expiry utc

            throw new System.NotImplementedException();
        }
    }

    internal class AuthenticationTokenServiceConfig
    {
        int ExpiryTimeoutInMinutes { get; set; }
    }
}